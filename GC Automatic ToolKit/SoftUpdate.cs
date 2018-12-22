using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Xml;

namespace GC_Automatic_ToolKit
{
    /// <summary>  
    /// 更新完成触发的事件  
    /// </summary>  
    public delegate void UpdateState();  
    /// <summary>  
    /// 程序更新  
    /// </summary>  
    public class SoftUpdate  
    {  
  
        private string download;  
        private const string updateUrl = @"https://github.com/genghe123/GC-Automatic-Toolkit/tree/master/GC%20Automatic%20ToolKit%20Setup"; //升级配置的XML文件地址  
 
        #region 构造函数  
        public SoftUpdate() { }  
  
        /// <summary>  
        /// 程序更新  
        /// </summary>  
        /// <param name="file">要更新的文件</param>  
        public SoftUpdate(string file,string softName) {  
            this.LoadFile = file;  
            this.SoftName = softName;  
        }

        #endregion
        #region 属性  
        private string newVerson;  
        private string softName;  
        private bool isUpdate;  
  
        /// <summary>  
        /// 获取是否需要更新  
        /// </summary>  
        public bool IsUpdate  
        {  
            get   
            {  
                checkUpdate();  
                return isUpdate;   
            }  
        }

        /// <summary>  
        /// 要检查更新的文件  
        /// </summary>  
        public string LoadFile { get; set; }

        /// <summary>  
        /// 程序集新版本  
        /// </summary>  
        public string NewVerson  
        {  
            get { return NewVerson1; }  
        }  
  
        /// <summary>  
        /// 升级的名称  
        /// </summary>  
        public string SoftName  
        {  
            get { return SoftName1; }  
            set { SoftName1 = value; }  
        }

        public string SoftName1 { get => SoftName2; set => SoftName2 = value; }
        public string SoftName2 { get => SoftName3; set => SoftName3 = value; }
        public string SoftName3 { get => softName; set => softName = value; }
        public string NewVerson1 { get => newVerson; set => newVerson = value; }

        #endregion

        /// <summary>  
        /// 更新完成时触发的事件  
        /// </summary>  
        public event UpdateState UpdateFinish;  
        private void isFinish() {
                UpdateFinish?.Invoke();
            }  
  
        /// <summary>  
        /// 下载更新  
        /// </summary>  
        public void Update()  
        {  
            try  
            {  
                if (!isUpdate)  
                    return;  
                WebClient wc = new WebClient();  
                string filename = "";  
                string exten = download.Substring(download.LastIndexOf("."));  
                if (LoadFile.IndexOf(@"/") == -1)  
                    filename = "Update_" + Path.GetFileNameWithoutExtension(LoadFile) + exten;  
                else  
                    filename = Path.GetDirectoryName(LoadFile) + "//Update_" + Path.GetFileNameWithoutExtension(LoadFile) + exten;  
                wc.DownloadFile(download, filename);  
                wc.Dispose();  
                isFinish();  
            }  
            catch  
            {  
                throw new Exception("更新出现错误，网络连接失败！");  
            }  
        }  
  
        /// <summary>  
        /// 检查是否需要更新  
        /// </summary>  
        public void checkUpdate()   
        {  
            try {  
                WebClient wc = new WebClient();  
                Stream stream = wc.OpenRead(updateUrl);  
                XmlDocument xmlDoc = new XmlDocument();  
                xmlDoc.Load(stream);  
                XmlNode list = xmlDoc.SelectSingleNode("Update");  
                foreach(XmlNode node in list) {  
                    if(node.Name == "Soft" && node.Attributes["Name"].Value.ToLower() == SoftName.ToLower()) {  
                        foreach(XmlNode xml in node) {  
                            if(xml.Name == "Verson")  
                                NewVerson1 = xml.InnerText;  
                            else  
                                download = xml.InnerText;  
                        }  
                    }  
                }  
  
                Version ver = new Version(NewVerson1);  
                Version verson = Assembly.LoadFrom(LoadFile).GetName().Version;  
                int tm = verson.CompareTo(ver);  
  
                if(tm >= 0)  
                    isUpdate = false;  
                else  
                    isUpdate = true;  
            }  
            catch(Exception e) {
                    throw new Exception("更新出现错误，请确认网络连接无误后重试！");  
            }  
        }  
  
        /// <summary>  
        /// 获取要更新的文件  
        /// </summary>  
        /// <returns></returns>  
        public override string ToString()  
        {  
            return this.LoadFile;  
        }  
    }  
}

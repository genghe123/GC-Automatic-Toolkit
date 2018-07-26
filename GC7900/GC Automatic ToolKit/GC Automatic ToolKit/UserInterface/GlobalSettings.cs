using System;
using System.IO;
using System.Windows.Forms;

namespace GC_Automatic_ToolKit.UserInterface
{
    public partial class GlobalSettings : Form
    {

        internal static string _username;
        internal static string _password;
        internal static string _instrumentkey;
        internal static string _rstfilepath = @"D:\GC_Data\Data\Herman\MoO3";

        public GlobalSettings()
        {
            InitializeComponent();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            _username = txtbox_UserName.Text;
            _password = txtbox_password.Text;
            _instrumentkey = txtbox_InstrumentKey.Text;
            _rstfilepath = txtbox_rstFilePath.Text;
            DirectoryInfo directoryInfo = new DirectoryInfo(_rstfilepath);
            if (directoryInfo != null)
            {
                GC_Operation gc = new GC_Operation("HW");
                gc.ResultHandle(directoryInfo);
            }
                
            this.Close();
        }
    }
}

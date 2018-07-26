using System;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using GC_Automatic_ToolKit.GCConfig;

namespace GC_Automatic_ToolKit.Handler
{
    internal static class XmlHandle
    {
        private static readonly FileInfo XmlFileInfo = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\GC Automatic ToolKit\context.xml");
        private static XDocument _xmlFile;
        private static XmlDocument _xml;
        
        static XmlHandle()
        {
            
        }

        
        internal static PerkinElmerConfig XmlRead()
        {
            _xmlFile = XDocument.Load(XmlFileInfo.FullName);
            PerkinElmerConfig config = new PerkinElmerConfig();
            try
            {
                var root = _xmlFile.Element("node");

                if (root != null)
                    foreach (var e in root.Descendants())
                    {
                        var stringValue = e.Value;
                        var value = int.TryParse(stringValue, out var val) ? val : -1;

                        switch (e.Name.LocalName)
                        {
                            case "lowestPeroidLimit":
                                config.PeroidLimit[0] = value;
                                break;
                            case "highestPeroidLimit":
                                config.PeroidLimit[1] = value;
                                break;
                            case "instrumentStopPeroid":
                                config.InstrumentStopPeroid = value;
                                break;
                            case "userID":
                                config.UserId = stringValue;
                                break;
                            case "password":
                                config.Password = stringValue;
                                break;
                            case "instrumentKey":
                                config.InstrumentKey = stringValue;
                                break;
                            case "ResultFile":
                                config.ResultPath = new DirectoryInfo(stringValue);
                                break;
                        }
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return config;
        }
       
        internal static bool XmlWrite(PerkinElmerConfig config)
        {
            _xml = new XmlDocument();
            _xml.Load(XmlFileInfo.FullName);

            try
            {
                foreach (XmlNode firstLevelNode in _xml.LastChild.ChildNodes)
                {
                    foreach (XmlNode e in firstLevelNode.ChildNodes)
                    {
                        switch (e.LocalName)
                        {
                            case "instrumentStopPeroid":
                                e.InnerText = config.InstrumentStopPeroid.ToString(CultureInfo.CurrentCulture);
                                break;
                            case "userID":
                                e.InnerText = config.UserId;
                                break;
                            case "password":
                                e.InnerText = config.Password;
                                break;
                            case "instrumentKey":
                                e.InnerText = config.InstrumentKey;
                                break;
                            case "ResultFile":
                                e.InnerText = config.ResultPath.FullName;
                                break;
                        }
                    }
                }
                _xml.Save(XmlFileInfo.FullName);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
    }
}

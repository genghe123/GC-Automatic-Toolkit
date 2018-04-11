using System.Xml;
using System.Xml.Linq;

namespace GC_Automatic_ToolKit.Handler
{
    internal static class XmlHandle
    {
        private static XElement configfile = null;
        
        static XmlHandle()
        {
            configfile = XElement.Load(@"..\..\Config\config.xml");
        }

        
        internal static string XmlRead(string paraname)
        {
            var reader = configfile.CreateReader();
            bool reuslt = reader.ReadToDescendant(paraname);
            if (!reuslt) return null;
            return reader.ReadElementContentAsString();
        }
        
    }
}

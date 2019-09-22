using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

// xsd.exe /c /l:cs /f /n:DoenaSoft.DVDProfiler.EnhancedPurchaseInfo EnhancedPurchaseInfo.xsd

namespace DoenaSoft.DVDProfiler.EnhancedPurchaseInfo
{
    public sealed partial class EnhancedPurchaseInfoList
    {
        private static XmlSerializer _xmlSerializer;

        [XmlIgnore]
        public static XmlSerializer XmlSerializer
        {
            get
            {
                if (_xmlSerializer == null)
                {
                    _xmlSerializer = new XmlSerializer(typeof(EnhancedPurchaseInfoList));
                }

                return _xmlSerializer;
            }
        }

        public static EnhancedPurchaseInfoList Deserialize(string fileName)
        {
            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var instance = (EnhancedPurchaseInfoList)(XmlSerializer.Deserialize(fs));

                return instance;
            }
        }

        public static void Serialize(EnhancedPurchaseInfoList instance, string fileName)
        {
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                using (var xtw = new XmlTextWriter(fs, Encoding.UTF8))
                {
                    xtw.Formatting = Formatting.Indented;
                    xtw.Namespaces = false;

                    var ns = new XmlSerializerNamespaces();
                    ns.Add(string.Empty, string.Empty);

                    XmlSerializer.Serialize(xtw, instance, ns);
                }
            }
        }

        public void Serialize(string fileName)
        {
            Serialize(this, fileName);
        }
    }

    public sealed partial class EnhancedPurchaseInfo
    {
        private static XmlSerializer _xmlSerializer;

        [XmlIgnore]
        public static XmlSerializer XmlSerializer
        {
            get
            {
                if (_xmlSerializer == null)
                {
                    _xmlSerializer = new XmlSerializer(typeof(EnhancedPurchaseInfo));
                }

                return _xmlSerializer;
            }
        }

        public static EnhancedPurchaseInfo Deserialize(string fileName)
        {
            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var instance = (EnhancedPurchaseInfo)(XmlSerializer.Deserialize(fs));

                return instance;
            }
        }

        public static void Serialize(EnhancedPurchaseInfo instance, string fileName)
        {
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                using (var xtw = new XmlTextWriter(fs, Encoding.UTF8))
                {
                    xtw.Formatting = Formatting.Indented;
                    xtw.Namespaces = false;

                    var ns = new XmlSerializerNamespaces();
                    ns.Add(string.Empty, string.Empty);

                    XmlSerializer.Serialize(xtw, instance, ns);
                }
            }
        }

        public void Serialize(string fileName)
        {
            Serialize(this, fileName);
        }
    }
}
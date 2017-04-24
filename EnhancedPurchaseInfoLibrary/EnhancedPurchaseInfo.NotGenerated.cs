using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

// xsd.exe /c /l:cs /n:DoenaSoft.DVDProfiler.EnhancedPurchaseInfo EnhancedPurchaseInfo.xsd

namespace DoenaSoft.DVDProfiler.EnhancedPurchaseInfo
{
    public sealed partial class EnhancedPurchaseInfoList
    {
        private static XmlSerializer s_XmlSerializer;

        [XmlIgnore]
        public static XmlSerializer XmlSerializer
        {
            get
            {
                if (s_XmlSerializer == null)
                {
                    s_XmlSerializer = new XmlSerializer(typeof(EnhancedPurchaseInfoList));
                }

                return (s_XmlSerializer);
            }
        }

        public static EnhancedPurchaseInfoList Deserialize(String fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                EnhancedPurchaseInfoList instance = (EnhancedPurchaseInfoList)(XmlSerializer.Deserialize(fs));

                return (instance);
            }
        }

        public static void Serialize(EnhancedPurchaseInfoList instance
            , String fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                using (XmlTextWriter xtw = new XmlTextWriter(fs, Encoding.UTF8))
                {
                    xtw.Formatting = Formatting.Indented;

                    XmlSerializer.Serialize(xtw, instance);
                }
            }
        }

        public void Serialize(String fileName)
        {
            Serialize(this, fileName);
        }
    }

    public sealed partial class EnhancedPurchaseInfo
    {
        private static XmlSerializer s_XmlSerializer;

        [XmlIgnore]
        public static XmlSerializer XmlSerializer
        {
            get
            {
                if (s_XmlSerializer == null)
                {
                    s_XmlSerializer = new XmlSerializer(typeof(EnhancedPurchaseInfo));
                }

                return (s_XmlSerializer);
            }
        }

        public static EnhancedPurchaseInfo Deserialize(String fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                EnhancedPurchaseInfo instance = (EnhancedPurchaseInfo)(XmlSerializer.Deserialize(fs));

                return (instance);
            }
        }

        public static void Serialize(EnhancedPurchaseInfo instance
            , String fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                using (XmlTextWriter xtw = new XmlTextWriter(fs, Encoding.UTF8))
                {
                    xtw.Formatting = Formatting.Indented;

                    XmlSerializer.Serialize(xtw, instance);
                }
            }
        }

        public void Serialize(String fileName)
        {
            Serialize(this, fileName);
        }
    }
}
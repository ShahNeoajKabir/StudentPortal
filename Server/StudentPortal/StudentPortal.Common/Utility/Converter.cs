using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace StudentPortal.Common.Utility
{
   public static class Converter
    {
        public static T ObjectConvert<T>(object param) where T : class
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(param));
        }

        public static string SerializeData(object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            StringWriter textWriter = new StringWriter();
            serializer.Serialize(textWriter, obj);
            string text = textWriter.ToString();
            textWriter.Close();
            return text;
        }
    }
}

using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace LangDriverApi.Common.Utilities
{
    public class SerializeHelper
    {
        public static IEnumerable<T> LoadData<T>(string fileName) where T : class
        {
            var serializer = new XmlSerializer(typeof(List<T>));
            using (TextReader reader = new StreamReader(fileName))
            {
                return (IEnumerable<T>)serializer.Deserialize(reader);
            }
        }

        public static void SaveData<T>(T data, string fileName) where T : class
        {
            var serializer = new XmlSerializer(typeof(T));
            using (TextWriter writer = File.CreateText(fileName))
            {
                serializer.Serialize(writer, data);
            }
        }
    }
}

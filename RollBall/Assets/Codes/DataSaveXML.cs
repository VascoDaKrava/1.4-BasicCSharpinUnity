using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Kravchuk
{
    public static class DataSaveXML
    {
        /// <summary>
        /// Save data to the file at the path
        /// </summary>
        /// <param name="data"></param>
        /// <param name="path"></param>
        /// <param name="filename"></param>
        public static void DoSave(List<SavingData> data, string path, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(data.GetType());

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            FileStream fs = new FileStream(
                Path.Combine(path, filename),
                FileMode.Create);

            serializer.Serialize(fs, data);

            fs.Close();
        }
    }
}

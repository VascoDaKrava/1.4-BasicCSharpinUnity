using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Kravchuk
{
    public static class DataLoadXML
    {
        /// <summary>
        /// Load data from the file at the path
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static List<SavingData> DoLoad(string path, string filename)
        {
            string fullPath = Path.Combine(path, filename);

            List<SavingData> data = new List<SavingData>();

            if (File.Exists(fullPath))
            {
                XmlSerializer serializer = new XmlSerializer(data.GetType());

                FileStream fs = new FileStream(
                    fullPath,
                    FileMode.Open);

                data = (List<SavingData>)serializer.Deserialize(fs);

                fs.Close();
            }

            return data;
        }
    }
}

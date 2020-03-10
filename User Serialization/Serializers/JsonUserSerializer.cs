using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Serialization.Models;
using Newtonsoft.Json;
using System.Windows;

namespace User_Serialization.Serializers
{
    public class JsonUserSerializer : IUserSerializer
    {
        public IEnumerable<User> Deserialize(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            {
                return JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
            }
        }

        public void Serialize(IEnumerable<User> users, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                string serializedText = JsonConvert.SerializeObject(users);
                byte[] serializedData = Encoding.UTF8.GetBytes(serializedText);
                fs.Write(serializedData, 0, serializedData.Length);
                fs.Flush();
            }
        }
    }
}

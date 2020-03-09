using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Serialization.Models;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace User_Serialization.Serializers
{
    class XmlUserSerializer : IUserSerializer
    {
        public void Deserialize(FileStream fileStream)
        {
            throw new NotImplementedException();
        }

        public void Serialize(IEnumerable<User> users, string filePath)
        {
            var serializer = new XmlSerializer(users.GetType());
            FileStream fs = new FileStream(filePath, FileMode.Create);
            serializer.Serialize(fs, users);
            fs.Flush();
            fs.Close();
        }
    }
}

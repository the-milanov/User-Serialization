using System;
using System.Collections.Generic;
using System.IO;
using User_Serialization.Models;
using System.Xml.Serialization;

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
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                var serializer = new XmlSerializer(users.GetType());
                serializer.Serialize(fs, users);
                fs.Flush();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using User_Serialization.Models;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace User_Serialization.Serializers
{
    class XmlUserSerializer : IUserSerializer
    {
        public IEnumerable<User> Deserialize(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<User>));
                var usersObject = serializer.Deserialize(fs);
                fs.Flush();
                return (IEnumerable<User>)usersObject;
            }
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

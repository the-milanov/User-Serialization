using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Serialization.Models;
using System.Xml.Linq;
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
            throw new NotImplementedException();
        }
    }
}

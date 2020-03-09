using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Serialization.Models;

namespace User_Serialization.Serializers
{
    public interface IUserSerializer
    {
        void Serialize(IEnumerable<User> users, string filePath);
        void Deserialize(FileStream fileStream);

    }
}

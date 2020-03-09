using System.Collections.Generic;
using System.IO;
using User_Serialization.Models;

namespace User_Serialization.Serializers
{
    public interface IUserSerializer
    {
        void Serialize(IEnumerable<User> users, string filePath);
        void Deserialize(FileStream fileStream);

    }
}

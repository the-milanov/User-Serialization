using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Serialization.Models;

namespace User_Serialization.Serializers
{
    public class BinaryUserSerializer : IUserSerializer
    {
        public void Deserialize(FileStream fileStream)
        {
            throw new NotImplementedException();
        }

        public void Serialize(IEnumerable<User> users, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            using (BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8))
            {
                users.ToList().ForEach(e =>
                {
                    bw.Write(e.Id.ToByteArray());
                    bw.Write(e.FirstName);
                    bw.Write(e.LastName);
                    bw.Write(e.Username);
                    bw.Write(e.Email);
                    bw.Flush();
                });
            }
        }
    }
}

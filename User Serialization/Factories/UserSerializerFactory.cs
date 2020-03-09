using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Serialization.Serializers;

namespace User_Serialization.Factories
{
    public static class UserSerializerFactory
    {
        public static IUserSerializer GetUserSerializer(string extension)
        {
            switch (extension)
            {
                case ".xml":
                    return new XmlUserSerializer();
                default:
                    return null;
            }
        }
    }
}

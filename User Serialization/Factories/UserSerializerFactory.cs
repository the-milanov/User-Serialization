using User_Serialization.Serializers;

namespace User_Serialization.Factories
{
    public static class UserSerializerFactory
    {
        public static IUserSerializer Create(string extension)
        {
            switch (extension.ToLower())
            {
                case ".xml":
                    return new XmlUserSerializer();
                case ".bin":
                    return new BinaryUserSerializer();
                default:
                    return null;
            }
        }
    }
}

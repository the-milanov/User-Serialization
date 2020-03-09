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
                default:
                    return null;
            }
        }
    }
}

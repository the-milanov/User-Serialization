using System;
using User_Serialization.Models;

namespace User_Serialization.Mediators
{
    public class SendUserPubSub
    {
        private event Action<User> userReceived;
        public void Publish(User user)
        {
            userReceived?.Invoke(user);
        }
        public void Subscribe(Action<User> action)
        {
            userReceived += action;
        }
    }
}

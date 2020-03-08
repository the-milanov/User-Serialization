using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

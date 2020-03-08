using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using User_Serialization.Mediators;
using User_Serialization.Models;

namespace User_Serialization.ViewModels
{
    public class AllViewModel
    {
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
        private SendUserPubSub sendUserPubSub;

        public SendUserPubSub SendUserPubSub
        {
            get { return sendUserPubSub; }
            set
            {
                sendUserPubSub= value;
                sendUserPubSub.Subscribe(Add);
            }
        }

        public void Add(User user) => Users.Add(user);
    }
}

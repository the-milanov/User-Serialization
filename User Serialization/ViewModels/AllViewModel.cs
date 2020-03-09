using System.Collections.ObjectModel;
using System.Windows;
using User_Serialization.Mediators;
using User_Serialization.Models;

namespace User_Serialization.ViewModels
{
    public class AllViewModel
    {
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
        
        private GetUsersMediator getUsers;
        public GetUsersMediator GetUsers
        {
            get { return getUsers; }
            set
            {
                getUsers = value;
                value.Users = Users;
            }
        }

        private SendUserPubSub sendUserPubSub;
        public SendUserPubSub SendUserPubSub
        {
            get { return sendUserPubSub; }
            set
            {
                sendUserPubSub = value;
                sendUserPubSub.Subscribe(Add);
            }
        }
        private void Add(User user) => Users.Add(user);
    }
}

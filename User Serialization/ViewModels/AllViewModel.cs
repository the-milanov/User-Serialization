using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using User_Serialization.Commands;
using User_Serialization.Mediators;
using User_Serialization.Models;
using User_Serialization.Views;

namespace User_Serialization.ViewModels
{
    public class AllViewModel
    {
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
        private int selectedIndex;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; }
        }

        public DelegateCommand EditCommand { get; set; }
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
        public AllViewModel()
        {
            EditCommand = new DelegateCommand(EditCommandExecute, EditCommandCanExecute);
        }
        private void EditCommandExecute(object o)
        {
            EditView editView = new EditView(Users[SelectedIndex]);
            editView.ShowDialog();
        }

        private bool EditCommandCanExecute(object o) => SelectedIndex > -1;
        private void Add(User user) => Users.Add(user);
    }
}

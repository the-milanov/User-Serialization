using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using User_Serialization.Commands;
using User_Serialization.Mediators;
using User_Serialization.Models;

namespace User_Serialization.ViewModels
{
    public class AddViewModel : INotifyPropertyChanged
    {
        private User newUser;

        public User NewUser
        {
            get { return newUser; }
            set
            {
                BindProperty(ref newUser, value);
            }
        }

        public SendUserPubSub SendUserPubSub { get; set; }
        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand NewIdCommand { get; set; }

        public AddViewModel()
        {
            NewUser = new User();
            AddCommand = new DelegateCommand(Add, null);
            NewIdCommand = new DelegateCommand(NewId, null);
        }


        private void Add(object o)
        {
            SendUserPubSub.Publish(NewUser);
            NewUser = new User();
        }
        private void NewId(object o)
        {
            NewUser.Id = Guid.NewGuid();
        }
        private void BindProperty<T>(ref T property, T value, [CallerMemberName]string propertyName = null)
        {
            property = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace User_Serialization.Models
{
    public class User : INotifyPropertyChanged
    {

        private Guid id;

        public Guid Id
        {
            get { return id; }
            set
            {
                BindProperty(ref id, value);
            }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set
            {
                BindProperty(ref username, value);
            }
        }
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                BindProperty(ref firstName, value);
            }
        }
        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                BindProperty(ref lastName, value);
            }
        }
        private string email;


        public string Email
        {
            get { return email; }
            set
            {
                BindProperty(ref email, value);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public User()
        {
            this.Id = Guid.NewGuid();
        }
        private void BindProperty<T>(ref T property, T value, [CallerMemberName]string propertyName = null)
        {
            property = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

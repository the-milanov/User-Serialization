using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Serialization.Commands;
using User_Serialization.Models;

namespace User_Serialization.ViewModels
{
    public class EditViewModel
    {
        public User EditedUser { get; set; }
        public User BackedUser { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand NewIdCommand { get; set; }

        private Action Close;
        public EditViewModel(User user, Action close)
        {
            EditedUser = user;
            BackedUser = new User() { Email = user.Email, FirstName = user.FirstName, Id = user.Id, LastName = user.LastName, Username = user.Username };
            CancelCommand = new DelegateCommand(CancelCommandExecute, null);
            SaveCommand = new DelegateCommand(SaveCommandExecute, SaveCommandCanExecute);
            NewIdCommand = new DelegateCommand(NewIdCommandExecute, null);
            Close = close;
        }

        private void NewIdCommandExecute(object obj)
        {
            EditedUser.Id = Guid.NewGuid();
        }

        private bool SaveCommandCanExecute(object arg)
        {
            return !EditedUser.HasErrors;
        }

        private void SaveCommandExecute(object obj)
        {
            Close();
        }

        private void CancelCommandExecute(object o)
        {
            EditedUser.Id = BackedUser.Id;
            EditedUser.FirstName = BackedUser.FirstName;
            EditedUser.LastName = BackedUser.LastName;
            EditedUser.Username = BackedUser.Username;
            EditedUser.Email = BackedUser.Email;
            Close();
        }
    }
}

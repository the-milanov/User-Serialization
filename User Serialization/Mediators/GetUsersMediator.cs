using System.Collections.Generic;
using System.Collections.ObjectModel;
using User_Serialization.Models;

namespace User_Serialization.Mediators
{
    public class GetUsersMediator
    {
        public ObservableCollection<User> Users { get; set; }
    }
}

using System.Collections.Generic;
using User_Serialization.Models;

namespace User_Serialization.Mediators
{
    public class GetUsersMediator
    {
        public IEnumerable<User> Users { get; set; }
    }
}

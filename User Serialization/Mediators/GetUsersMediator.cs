using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Serialization.Models;

namespace User_Serialization.Mediators
{
    public class GetUsersMediator
    {
		private IEnumerable<User> users;

		public IEnumerable<User> Users
		{
			get { return users; }
			set { users = value; }
		}
	}
}

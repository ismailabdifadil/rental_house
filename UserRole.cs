using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management
{
    internal class UserRole
    {
        private string role;

        public UserRole()
        {
            role = "user";
        }

        public string Role
        {
            get { return role; }
            set { role = value; }
        }
    }
}

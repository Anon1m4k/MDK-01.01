using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlSimpleTest
{
    public class UserInfo
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public UserInfo (string login)
        {
            Login = login;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLauncher.MojangInformations
{
    class Connection_elements
    {
        public Connection_elements(string email, string password, string username, bool autorun, string ramamount)
        {
            Email = email;
            Password = password;
            Username = username;
            Autorun = autorun;
            Ramamount = ramamount;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public bool Autorun { get; set; }
        public string Ramamount { get; set; }

    }
}

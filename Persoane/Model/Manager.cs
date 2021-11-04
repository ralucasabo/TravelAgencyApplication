using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model
{
    public class Manager
    {
        private string Name;
        private string Username;
        private string Password;

        public Manager(string Username, string Name, string Password)
        {
            this.Username = Username;
            this.Name = Name;
            this.Password = Password;


        }

        public String getName()
        {
            return Name;
        }

        public String getUsername()
        {
            return Username;
        }

        public String getPassword()
        {
            return Password;
        }

        public void setName(String Name)
        {
            this.Name = Name;
        }

        public void setUsername(String Username)
        {
            this.Username = Username;
        }

        public void setPassword(String Password)
        {
            this.Password = Password;
        }
    }
}

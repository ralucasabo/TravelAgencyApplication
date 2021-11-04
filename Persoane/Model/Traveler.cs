using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model
{
    public class Traveler
    {
        private string Name;
        private string CNP;
        

        public Traveler(string CNP,string Name)
        {
            this.Name = Name;
            this.CNP = CNP;
        }


        public String getName()
        {
            return Name;
        }

        public String getCNP()
        {
            return CNP;
        }

        public void setName(String Name)
        {
            this.Name = Name;
        }

        public void setCNP(String CNP)
        {
            this.CNP = CNP;
        }

    }
}

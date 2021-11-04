using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;

namespace Server.Model
{
    public class Limba
    {
        private string limba;

        public Limba()
        {
            this.limba = "romana";
        }

        public Limba(string limba)
        {
            this.limba = limba;
        }

        public string AccesLimba()
        {
            return this.limba;
        }

        public void ActualizareLimba(string limba)
        {
            this.limba = limba;
        }

        public Dictionary<string, string> CautareInformatie()
        {
            try
            {
                Dictionary<string, string> date = new Dictionary<string, string>();
                XDocument xDoc = XDocument.Load(@"firstpage.xml");
                List<XElement> xElemente = xDoc.Root.Elements(this.limba).ToList();
                foreach (XElement xElement in xElemente)
                {
                    date.Add("Airport", xElement.Element("Airport").Value);
                    date.Add("Destination", xElement.Element("Destination").Value);
                    date.Add("Time", xElement.Element("Time").Value);
                    date.Add("Departure", xElement.Element("Departure").Value);
                    date.Add("Plane", xElement.Element("Plane").Value);
                    date.Add("Search", xElement.Element("Search").Value);
                    date.Add("Flights table", xElement.Element("Flights table").Value);
                }
                return date;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server.Model;

namespace Persoane.Repository
{
    public class TravelerRepository
    {
        private SqlConnection conexiune;

        public TravelerRepository()
        {
            string s = ConfigurationManager.ConnectionStrings["FlightAgency"].ConnectionString;
            this.conexiune = new SqlConnection(s);
        }

        public bool AddTraveler(Traveler traveler)
        {
            try
            {
                //List<Flight> list_of_flights = new List<Flight>();
                if (this.conexiune.State == ConnectionState.Closed)
                    this.conexiune.Open();
                SqlCommand vizualizare = new SqlCommand("Insert into Traveler(cnp, traveler_name) values('" +
                    traveler.getCNP() + "','" + traveler.getName() +"')", this.conexiune);
                SqlDataAdapter dateCitite = new SqlDataAdapter(vizualizare);
                DataTable avioaneTabel = new DataTable();
                dateCitite.Fill(avioaneTabel);
                this.conexiune.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }
        }

        public bool DeleteTraveler(string CNP)
        {
            try
            {
                //List<Flight> list_of_flights = new List<Flight>();
                if (this.conexiune.State == ConnectionState.Closed)
                    this.conexiune.Open();
                SqlCommand vizualizare = new SqlCommand("Delete from Traveler where cnp='" + CNP + "'", this.conexiune);
                SqlDataAdapter dateCitite = new SqlDataAdapter(vizualizare);
                DataTable avioaneTabel = new DataTable();
                dateCitite.Fill(avioaneTabel);
                this.conexiune.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }
        }

        public bool UpdateTraveler(string cnp, Traveler traveler)
        {
            try
            {
                //List<Flight> list_of_flights = new List<Flight>();
                if (this.conexiune.State == ConnectionState.Closed)
                    this.conexiune.Open();
                SqlCommand vizualizare = new SqlCommand("Update Traveler set traveler_name='" + traveler.getName() + "' where cnp='" + cnp + "'", this.conexiune);
                SqlDataAdapter dateCitite = new SqlDataAdapter(vizualizare);
                DataTable avioaneTabel = new DataTable();
                dateCitite.Fill(avioaneTabel);
                this.conexiune.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }
        }
        private List<Traveler> conversie(DataTable avioane)
        {
            List<Traveler> lista = new List<Traveler>();
            foreach (DataRow dr in avioane.Rows)
            {
                Traveler flight = new Traveler((string)dr["cnp"], (string)dr["traveler_name"]);
                lista.Add(flight);
            }
            return lista;
        }
        public List<Traveler> FindAll()
        {
            try
            {
                //List<Flight> list_of_flights = new List<Flight>();
                if (this.conexiune.State == ConnectionState.Closed)
                    this.conexiune.Open();
                SqlCommand vizualizare = new SqlCommand("Select * from Traveler", this.conexiune);
                SqlDataAdapter dateCitite = new SqlDataAdapter(vizualizare);
                DataTable avioaneTabel = new DataTable();
                dateCitite.Fill(avioaneTabel);
                this.conexiune.Close();
                return this.conversie(avioaneTabel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return null;
            }
        }

        public Traveler FindOne(string cnp)
        {
            List<Traveler> list_of_tickets = FindAll();
            Traveler e = null;
            list_of_tickets.ForEach(
                x =>
                {
                    if (x.getCNP().Equals(cnp))
                        e = x;
                });
            return e;
        }
    }
}

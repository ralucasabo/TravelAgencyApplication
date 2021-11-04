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
    public class ManagerRepository
    {
        private SqlConnection conexiune;

        public ManagerRepository()
        {
            string s = ConfigurationManager.ConnectionStrings["FlightAgency"].ConnectionString;
            this.conexiune = new SqlConnection(s);
        }

        private List<Manager> conversie(DataTable avioane)
        {
            List<Manager> lista = new List<Manager>();
            foreach (DataRow dr in avioane.Rows)
            {
                Manager employee = new Manager((string)dr["username"], (string)dr["name"], (string)dr["password"]);
                lista.Add(employee);
            }
            return lista;
        }

        public List<Manager> FindAll()
        {
            try
            {
                if (this.conexiune.State == ConnectionState.Closed)
                    this.conexiune.Open();
                SqlCommand vizualizare = new SqlCommand("Select * from Manager", this.conexiune);
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

        public Manager FindOne(string Username, string Password)
        {
            List<Manager> list_of_employee = FindAll();
            Manager e = null;
            list_of_employee.ForEach(
                x =>
                {
                    if (x.getUsername().Equals(Username) && x.getPassword().Equals(Password))
                        e = x;
                });
            return e;
        }

        public bool AddManager(Manager manager)
        {
            try
            {
                //List<Flight> list_of_flights = new List<Flight>();
                if (this.conexiune.State == ConnectionState.Closed)
                    this.conexiune.Open();
                SqlCommand vizualizare = new SqlCommand("Insert into Manager(username, name, password) values('" +
                    manager.getUsername() + "','" + manager.getName() + "','" + manager.getPassword() + "')", this.conexiune);
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

        public bool DeleteManager(string username)
        {
            try
            {
                //List<Flight> list_of_flights = new List<Flight>();
                if (this.conexiune.State == ConnectionState.Closed)
                    this.conexiune.Open();
                SqlCommand vizualizare = new SqlCommand("Delete from Manager where username='" + username + "'", this.conexiune);
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


        internal bool UpdateManager(string username, Manager manager)
        {
            try
            {
                if (this.conexiune.State == ConnectionState.Closed)
                    this.conexiune.Open();
                SqlCommand vizualizare = new SqlCommand("Update Manager set name = '" + manager.getName() + "'  where username='" + username + "'", this.conexiune);
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
    }
}

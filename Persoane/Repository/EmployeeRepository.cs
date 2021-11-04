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
    [ServiceContract]

    public class EmployeeRepository
    {
        private SqlConnection conexiune;

        public EmployeeRepository()
        {
            string s = ConfigurationManager.ConnectionStrings["FlightAgency"].ConnectionString;
            this.conexiune = new SqlConnection(s);
        }
        [OperationContract]
        private List<Employee> conversie(DataTable avioane)
        {
            List<Employee> lista = new List<Employee>();
            foreach (DataRow dr in avioane.Rows)
            {
                Employee employee = new Employee((string)dr["username"], (string)dr["name"], (string)dr["password"]);
                lista.Add(employee);
            }
            return lista;
        }

        [OperationContract]
        public List<Employee> FindAll()
        {
            try
            {
                if (this.conexiune.State == ConnectionState.Closed)
                    this.conexiune.Open();
                SqlCommand vizualizare = new SqlCommand("Select * from Employee", this.conexiune);
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

        [OperationContract]
        public Employee FindOne(string Username, string Password)
        {
            List<Employee> list_of_employee = FindAll();
            Employee e = null;
            list_of_employee.ForEach(
                x =>
                {
                    if (x.getUsername().Equals(Username) && x.getPassword().Equals(Password))
                        e = x;
                });
            return e;
        }

        [OperationContract]
        public bool AddEmployee(Employee employee)
        {
            try
            {
                //List<Flight> list_of_flights = new List<Flight>();
                if (this.conexiune.State == ConnectionState.Closed)
                    this.conexiune.Open();
                SqlCommand vizualizare = new SqlCommand("Insert into Employee(username, name, password) values('" +
                    employee.getUsername() + "','" + employee.getName() + "','" + employee.getPassword() + "')", this.conexiune);
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

        [OperationContract]
        public bool DeleteEmployee(string username)
        {
            try
            {
                //List<Flight> list_of_flights = new List<Flight>();
                if (this.conexiune.State == ConnectionState.Closed)
                    this.conexiune.Open();
                SqlCommand vizualizare = new SqlCommand("Delete from Employee where username='" + username + "'", this.conexiune);
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

        [OperationContract]
        public bool UpdateEmployee(string username, Employee employee)
        {
            try
            {
                if (this.conexiune.State == ConnectionState.Closed)
                    this.conexiune.Open();
                SqlCommand vizualizare = new SqlCommand("Update Employee set name = '" + employee.getName() + "'  where username='" + username + "'", this.conexiune);
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

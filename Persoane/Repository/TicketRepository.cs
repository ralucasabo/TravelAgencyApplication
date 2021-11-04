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
    public class TicketRepository
    {

        private SqlConnection conexiune;

        public TicketRepository()
        {
            string s = ConfigurationManager.ConnectionStrings["FlightAgency"].ConnectionString;
            this.conexiune = new SqlConnection(s);
        }

        public bool AddTicket(Ticket ticket)
        {
            try
            {
                //List<Flight> list_of_flights = new List<Flight>();
                if (this.conexiune.State == ConnectionState.Closed)
                    this.conexiune.Open();
                SqlCommand vizualizare = new SqlCommand("Insert into Ticket(ticketId, flightId, travelerId) values('" +
                    ticket.getTicketId() + "','" + ticket.getFlightId() + "','" + ticket.getTravelerId()+ "')", this.conexiune);
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

        public bool DeleteTicket(string TicketId)
        {
            try
            {
                //List<Flight> list_of_flights = new List<Flight>();
                if (this.conexiune.State == ConnectionState.Closed)
                    this.conexiune.Open();
                SqlCommand vizualizare = new SqlCommand("Delete from Ticket where ticketId='" + TicketId + "'", this.conexiune);
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

        public bool UpdateTicket(string TicketId, Ticket ticket)
        {
            try
            {
                //List<Flight> list_of_flights = new List<Flight>();
                if (this.conexiune.State == ConnectionState.Closed)
                    this.conexiune.Open();
                SqlCommand vizualizare = new SqlCommand("Update Ticket set flightId='" + ticket.getFlightId() + "', travelerId ='"
                    + ticket.getTravelerId() + "' where ticketId='"+TicketId+"'", this.conexiune);
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
        private List<Ticket> conversie(DataTable avioane)
        {
            List<Ticket> lista = new List<Ticket>();
            foreach (DataRow dr in avioane.Rows)
            {
                Ticket flight = new Ticket((string)dr["ticketId"], (string)dr["flightId"], (string)dr["travelerId"]);
                lista.Add(flight);
            }
            return lista;
        }
        public List<Ticket> FindAll()
        {
            try
            {
                //List<Flight> list_of_flights = new List<Flight>();
                if (this.conexiune.State == ConnectionState.Closed)
                    this.conexiune.Open();
                SqlCommand vizualizare = new SqlCommand("Select * from Ticket", this.conexiune);
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

        public Ticket FindOne(string TicketId)
        {
            List<Ticket> list_of_tickets = FindAll();
            Ticket e = null;
            list_of_tickets.ForEach(
                x =>
                {
                    if (x.getTicketId().Equals(TicketId))
                        e = x;
                });
            return e;
        }
    }
}

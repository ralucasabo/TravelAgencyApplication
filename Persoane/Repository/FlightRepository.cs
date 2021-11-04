using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Server.Model;

namespace Persoane.Repository
{
    public class FlightRepository
    {

        private SqlConnection conexiune;

        public FlightRepository()
        {
            string s = ConfigurationManager.ConnectionStrings["FlightAgency"].ConnectionString;
            this.conexiune = new SqlConnection(s);
        }

        public bool AddFlight(Flight flight)
        {
            try
            {
                //List<Flight> list_of_flights = new List<Flight>();
                if (this.conexiune.State == ConnectionState.Closed)
                    this.conexiune.Open();
                SqlCommand vizualizare = new SqlCommand("Insert into Flight(flightId, airport, departure, destination, time, price, available_seats, plane) values('"+
                    flight.getFlightId()+"','"+flight.getAirport() + "','" +flight.getDeparture() + "','" +flight.getDestination() + "','" +flight.getTime() + "','" +
                    flight.getPrice() + "','" +flight.getAvailableSeats() + "','" +flight.getPlane() + "')", this.conexiune);
                SqlDataAdapter dateCitite = new SqlDataAdapter(vizualizare);
                DataTable avioaneTabel = new DataTable();
                dateCitite.Fill(avioaneTabel);
                this.conexiune.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false ;
            }
        }

        public bool DeleteFlight(string FlightId)
        {
            try
            {
                //List<Flight> list_of_flights = new List<Flight>();
                if (this.conexiune.State == ConnectionState.Closed)
                    this.conexiune.Open();
                SqlCommand vizualizare = new SqlCommand("Delete from Flight where flightId='" + FlightId+"'", this.conexiune);
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

        public bool UpdateFlight(string FlightId, Flight flight)
        {
            try
            {
                //List<Flight> list_of_flights = new List<Flight>();
                if (this.conexiune.State == ConnectionState.Closed)
                    this.conexiune.Open();
                SqlCommand vizualizare = new SqlCommand("Update Flight set airport='"+ flight.getAirport() + "', departure='" + flight.getDeparture() + "', destination ='" 
                    + flight.getDestination() + "', time = '" + flight.getTime() + "', price ='" + flight.getPrice() + "', available_seats='" + flight.getAvailableSeats() 
                    + "',plane='" + flight.getPlane() + "'  where flightId='"+FlightId+"'", this.conexiune);
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


        public Flight FindOne(string FlightId)
        {           
            List<Flight> list_of_flights = FindAll();
            Flight e = null;
            list_of_flights.ForEach(
                x =>
                {
                    if (x.getFlightId().Equals(FlightId))
                        e = x;
                });
            return e;

        }

        private List<Flight> conversie(DataTable avioane)
        {
            List<Flight> lista = new List<Flight>();
            foreach (DataRow dr in avioane.Rows)
            {
                Flight flight = new Flight((string)dr["flightId"], (string)dr["airport"], (string)dr["departure"], (string)dr["destination"], (string)dr["time"], (string)dr["price"], (string)dr["available_seats"], (string)dr["plane"]);
                lista.Add(flight);
            }
            return lista;
        }
        public List<Flight> FindAll()
        {
            try
            {
                //List<Flight> list_of_flights = new List<Flight>();
                if (this.conexiune.State == ConnectionState.Closed)
                    this.conexiune.Open();
                SqlCommand vizualizare = new SqlCommand("Select * from Flight order by flightId", this.conexiune);
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

        public List<Flight> FilterByAirportDestinationTime(string Airport, string Destination, string Time)
        {
            try
            {
                List<Flight> list_of_flights = new List<Flight>();
                if (this.conexiune.State == ConnectionState.Closed)
                    this.conexiune.Open();
                SqlCommand vizualizare = new SqlCommand("Select * from Flight where airport  = '" + Airport + "' and destination = '" + Destination + "' and time = '" + Time+"'", this.conexiune);
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

        public List<Flight> FilterByLocations(string Departure, string Destination)
        {
            try
            {
                List<Flight> list_of_flights = new List<Flight>();
                if (this.conexiune.State == ConnectionState.Closed)
                    this.conexiune.Open();
                SqlCommand vizualizare = new SqlCommand("Select * from Flight where departure  = '" + Departure + "' and destination = '" + Destination +"'", this.conexiune);
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

        public List<Flight> FilterByPlane(string Plane)
        {
            try
            {
                List<Flight> list_of_flights = new List<Flight>();
                if (this.conexiune.State == ConnectionState.Closed)
                    this.conexiune.Open();
                SqlCommand vizualizare = new SqlCommand("Select * from Flight where plane  = '" + Plane +"'", this.conexiune);
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
    }
}


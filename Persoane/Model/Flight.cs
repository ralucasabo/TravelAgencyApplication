using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model
{
    public class Flight
    {
        private string FlightId;
        private string Airport;
        private string Departure;
        private string Destination;
        private string Time;
        private string Price;
        private string AvailableSeats;
        private string Plane;

        public Flight(string FlightId, 
            string Airport, 
            string Departure,
            string Destination,
            string Time,
            string Price,
            string AvailableSeats,
            string Plane)
        {
            this.FlightId = FlightId;
            this.Airport = Airport;
            this.Departure = Departure;
            this.Destination = Destination;
            this.Time = Time;
            this.Price = Price;
            this.AvailableSeats = AvailableSeats;
            this.Plane = Plane;


        }


        public String getFlightId()
        {
            return FlightId;
        }

        public String getAirport()
        {
            return Airport;
        }

        public String getDeparture()
        {
            return Departure;
        }
        
        public String getDestination()
        {
            return Destination;
        }

        public String getTime()
        {
            return Time;
        }

        public String getPrice()
        {
            return Price;
        } 
        public String getAvailableSeats()
        {
            return AvailableSeats;
        }

        public String getPlane()
        {
            return Plane;
        }

        public void setFlightId(String FlightId)
        {
            this.FlightId = FlightId;
        }

        public void setAirport(String Airport)
        {
            this.Airport = Airport;
        }

        public void setDeparture(String Departure)
        {
            this.Departure = Departure;
        }
        public void setDestination(String Destination)
        {
            this.Destination = Destination;
        }

        public void setTime(String Time)
        {
            this.Time = Time;
        }

        public void setPrice(String Price)
        {
            this.Price = Price;
        }
        public void setAvailableSeats(String AvailableSeats)
        {
            this.AvailableSeats = AvailableSeats;
        }

        public void setPlane(String Plane)
        {
            this.Plane = Plane;
        }

        public override string ToString()
        {
            return FlightId + " " +
                Airport + " " +
                Departure + " " +
                Destination + " " +
                Time + " " +
                Price + " " +
                AvailableSeats + " " +
                Plane;
        }
    }
}

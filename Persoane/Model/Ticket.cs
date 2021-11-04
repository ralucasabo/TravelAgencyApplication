using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model
{
    public class Ticket
    {
        private string TicketId;
        private string FlightId;
        private string TravelerId;

        public Ticket(string TicketId, string FlightId, string TravelerId)
        {
            this.TicketId = TicketId;
            this.FlightId = FlightId;
            this.TravelerId = TravelerId;
        }

        public String getTicketId()
        {
            return TicketId;
        }

        public String getFlightId()
        {
            return FlightId;
        }

        public String getTravelerId()
        {
            return TravelerId;
        }

        public void setTicketId(String TicketId)
        {
            this.TicketId = TicketId;
        }

        public void setFlightId(String FlightId)
        {
            this.FlightId = FlightId;
        }

        public void setTravelerId(String TravelerId)
        {
            this.TravelerId = TravelerId;
        }
    }
}

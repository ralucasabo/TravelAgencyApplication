using Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persoane.Repository;
using Persoane.Controller;

namespace Server.Controller
{
    public class MainEmployeeController : Observer

    {


        private FlightRepository flightRepository;
        private EmployeeRepository employeeRepository;
        private ManagerRepository managerRepository;
        private TicketRepository ticketRepository;
        private TravelerRepository travelerRepository;

        public MainEmployeeController(



            FlightRepository flightRepository,
            EmployeeRepository employeeRepository,
            ManagerRepository managerRepository,
            TicketRepository ticketRepository,
            TravelerRepository travelerRepository)
        {

            this.flightRepository = flightRepository;
            this.employeeRepository = employeeRepository;
            this.managerRepository = managerRepository;
            this.ticketRepository = ticketRepository;
            this.travelerRepository = travelerRepository;
        }

        public List<Flight> getAllFlights()
        {
            return flightRepository.FindAll();


        }
        public List<Ticket> getAllTickets()
        {
            return ticketRepository.FindAll();


        }

        public List<Flight> firstFilter(string airport, string destination, string time)
        {
            return flightRepository.FilterByAirportDestinationTime(airport, destination, time);
        }

        public List<Flight> secondFilter(string Departure, string Destination)
        {
            return flightRepository.FilterByLocations(Departure, Destination);
        }

        public List<Flight> thirdFilter(string Plane)
        {
            return flightRepository.FilterByPlane(Plane);
        }

        public Flight findFlight(String FlightId)
        {
            return flightRepository.FindOne(FlightId);
        }

        public bool addFlight(Flight flight)
        {

            return flightRepository.AddFlight(flight);
        }

        public bool deleteFlight(String FlightId)
        {

            return flightRepository.DeleteFlight(FlightId);
        }

        public List<Traveler> getAllTravelers()
        {
            return travelerRepository.FindAll();
        }

        public Traveler findTraveler(String CNP)
        {
            return travelerRepository.FindOne(CNP);
        }

        public Ticket findTicket(String TicketId)
        {
            return ticketRepository.FindOne(TicketId);
        }

        public bool addTraveler(Traveler traveler)
        {

            return travelerRepository.AddTraveler(traveler);
        }

        public bool addTicket(Ticket ticket)
        {

            return ticketRepository.AddTicket(ticket);
        }

        public bool deleteTraveler(String CNP)
        {

            return travelerRepository.DeleteTraveler(CNP);
        }
        public bool updateTraveler(String CNP, Traveler traveler)
        {

            return travelerRepository.UpdateTraveler(CNP, traveler);
        }

        public bool updateFlight(String FlightId, Flight flight)
        {

            return flightRepository.UpdateFlight(FlightId, flight);
        }

        public bool updateTicket(String TicketId, Ticket ticket)
        {

            return ticketRepository.UpdateTicket(TicketId, ticket);
        }

        public bool deleteTicket(String TicketId)
        {

            return ticketRepository.DeleteTicket(TicketId);
        }

        public void Actualizare()
        {
            
        }
    }
}

using Server.Model;
using Server.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persoane.Repository;
using Persoane.Controller;

namespace Server.Controller
{
    public class FirstController : Observer
    {
        private FlightRepository flightRepository;
        private EmployeeRepository employeeRepository;
        private ManagerRepository managerRepository;
        private TicketRepository ticketRepository;
        private TravelerRepository travelerRepository;

        public FirstController(         
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

        public void handleLogin()
        {
            LogInController logInController = new LogInController(flightRepository, employeeRepository, managerRepository, ticketRepository, travelerRepository);
            LogInPage logInPage = new LogInPage(logInController);
            logInPage.Show();

        }

        public void Actualizare(){ }
    }
}

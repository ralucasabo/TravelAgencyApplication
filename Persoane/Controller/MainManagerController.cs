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
    public class MainManagerController : Observer
    {



        private FlightRepository flightRepository;
        private EmployeeRepository employeeRepository;
        private ManagerRepository managerRepository;
        private TicketRepository ticketRepository;
        private TravelerRepository travelerRepository;

        public MainManagerController(


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



        public List<Employee> getAllEmployees()
        {
            return employeeRepository.FindAll();
        }

        public List<Manager> getAllManagers()
        {
            return managerRepository.FindAll();
        }

        public List<Ticket> getAllTickets()
        {
            return ticketRepository.FindAll();
        }

        public List<Flight> getAllFlights()
        {
            return flightRepository.FindAll();
        }

        public Manager findManager(String username, String password)
        {
            return managerRepository.FindOne(username, password);
        } 

        public bool addManager(Manager manager)
        {
           
            return managerRepository.AddManager(manager);
        }

        public bool deleteManager(String username)
        {

            return managerRepository.DeleteManager(username);
        }

        public Employee findEmployee(String username, String password)
        {
            return employeeRepository.FindOne(username, password);
        }

        public bool addEmployee(Employee employee)
        {

            return employeeRepository.AddEmployee(employee);
        }

        public bool deleteEmployee(String username)
        {

            return employeeRepository.DeleteEmployee(username);
        }

        public bool updateEmployee(String Username, Employee employee)
        {

            return employeeRepository.UpdateEmployee(Username, employee);
        }

        public bool updateManager(String Username, Manager manager)
        {

            return managerRepository.UpdateManager(Username, manager);
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

        public void Actualizare()
        {
           
        }
    }
}

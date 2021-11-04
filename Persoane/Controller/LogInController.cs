
using Server.View;
using System;
using System.Windows.Forms;
using Persoane.Repository;
using Persoane.Controller;

namespace Server.Controller
{
    public class LogInController : Observer
    {

        private FlightRepository flightRepository;
        private EmployeeRepository employeeRepository;
        private ManagerRepository managerRepository;
        private TicketRepository ticketRepository;
        private TravelerRepository travelerRepository;

        public LogInController(
            
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

        public void Actualizare(){}

        public void login(String username, String password)
        {
            if (employeeRepository.FindOne(username, password) != null)
            {
                MainEmployeeController mainController = new MainEmployeeController( flightRepository, employeeRepository, managerRepository, ticketRepository, travelerRepository);
                MainEmployeePage mainPage = new MainEmployeePage(mainController);
                mainPage.Show();
            }
            else
            {
                if (managerRepository.FindOne(username, password) != null)
                {
                    MainManagerController mainController = new MainManagerController(flightRepository, employeeRepository, managerRepository, ticketRepository, travelerRepository);
                    MainManagerPage mainPage = new MainManagerPage(mainController);
                    mainPage.Show();
                }
                else
                {
                    MessageBox.Show("insucces!");
                }
            }
        }
    }
}

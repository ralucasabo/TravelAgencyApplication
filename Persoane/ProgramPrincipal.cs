using Server.Controller;
using Server.View;
using System.Windows.Forms;
using Persoane.Repository;
using Persoane.View;

namespace Server
{
    public class ProgramPrincipal
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /*
            FlightRepository flightRepository = new FlightRepository();
            EmployeeRepository employeeRepository = new EmployeeRepository();
            ManagerRepository managerRepository = new ManagerRepository();
            TicketRepository ticketRepository = new TicketRepository();
            TravelerRepository travelerRepository = new TravelerRepository();

            FirstController firstContrller = new FirstController(flightRepository, employeeRepository, managerRepository, ticketRepository, travelerRepository);
            //Application.Run(new FirstPage(firstContrller));*/
            Application.Run(new ServerPage());

        }
    }
}

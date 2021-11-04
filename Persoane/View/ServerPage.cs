using Persoane.Repository;
using Server.Controller;
using Server.View;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Persoane.View
{
    public partial class ServerPage : Form
    {
        public ServerPage()
        {
            InitializeComponent();
        }
        SimpleTcpServer server;
        private void ServerPage_Load(object sender, EventArgs e)
        {
            server = new SimpleTcpServer();
            server.Delimiter = 0x13;
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += Server_DataReceived;
        }

        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            string text = e.MessageString;
            if (!text.Equals("Start the app\u0013"))
            {
                textBox1.Invoke((MethodInvoker)delegate ()
                {
                    textBox1.Text += e.MessageString;
                });
            }
            else
            {
                
                FlightRepository flightRepository = new FlightRepository();
                EmployeeRepository employeeRepository = new EmployeeRepository();
                ManagerRepository managerRepository = new ManagerRepository();
                TicketRepository ticketRepository = new TicketRepository();
                TravelerRepository travelerRepository = new TravelerRepository();

                FirstController firstContrller = new FirstController(flightRepository, employeeRepository, managerRepository, ticketRepository, travelerRepository);
                Application.Run(new FirstPage(firstContrller));
            }
                //textBox1.Text += e.MessageString;
                //e.ReplyLine(string.Format("you said: {0}", e.MessageString));
           
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            txtStatus.Text += "Server started...";
            IPAddress ip = IPAddress.Parse(txtHost.Text);
            server.Start(ip, Convert.ToInt32(txtPort.Text));
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (server.IsStarted){
                server.Stop();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

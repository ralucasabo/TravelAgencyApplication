using Server.Controller;
using Server.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Server.View
{
    public partial class MainEmployeePage : Form
    {
        private MainEmployeeController mainEmployeeController;
        public MainEmployeePage(MainEmployeeController mainEmployeeController)
        {
            InitializeComponent();
            this.mainEmployeeController = mainEmployeeController;
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            List<Flight> table1 = mainEmployeeController.getAllFlights();
            updateFlightsTable(table1);
            List<Traveler> table = mainEmployeeController.getAllTravelers();
            updateTravelersTable(table);
            List<Ticket> table4 = mainEmployeeController.getAllTickets();
            updateTicketsTable(table4);
        }

        //Flights

        public void updateFlightsTable(List<Flight> list)
        {
            dataGridView1.Rows.Clear();
            if (list != null)
            {
                foreach (Flight flight in list)
                {
                    DataGridViewRow rand = new DataGridViewRow();
                    rand.CreateCells(dataGridView1);
                    rand.Cells[0].Value = flight.getFlightId();
                    rand.Cells[1].Value = flight.getAirport();
                    rand.Cells[2].Value = flight.getDeparture();
                    rand.Cells[3].Value = flight.getDestination();
                    rand.Cells[4].Value = flight.getTime();
                    rand.Cells[5].Value = flight.getPrice();
                    rand.Cells[6].Value = flight.getAvailableSeats();
                    rand.Cells[7].Value = flight.getPlane();
                    dataGridView1.Rows.Add(rand);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            String FlightId = textBox9.Text;
            String Airport = textBox10.Text;
            String Departure = textBox11.Text;
            String Destination = textBox12.Text;
            String Time = textBox13.Text;
            String Price = textBox14.Text;
            String AvailableSeats = textBox15.Text;
            String Plane = textBox16.Text;

            if (FlightId.Length > 0 && Airport.Length > 0 && Departure.Length > 0 &&
            Destination.Length > 0 && Time.Length > 0 && Price.Length > 0 &&
            AvailableSeats.Length > 0 && Plane.Length > 0)
            {
                if (mainEmployeeController.findFlight(FlightId) != null)
                {
                    MessageBox.Show("Exista deja o persoana cu acest CNP!");
                }
                else
                {
                    Flight flight = new Flight(FlightId, Airport, Departure, Destination, Time,
                        Price, AvailableSeats, Plane);
                    if (mainEmployeeController.addFlight(flight))
                        MessageBox.Show("Adaugare incheiata cu succes!");
                    else
                        MessageBox.Show("Nu s-a realizat adaugare in fisier!");
                }
            }
            List<Flight> table5 = mainEmployeeController.getAllFlights();
            updateFlightsTable(table5);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nu exista nicio persoana selectata pentru a fi actualizata");
            }
            else
            {
                string FlightId = (string)dataGridView1.SelectedRows[0].Cells[0].Value;
                String Airport = textBox10.Text;
                String Departure = textBox11.Text;
                String Destination = textBox12.Text;
                String Time = textBox13.Text;
                String Price = textBox14.Text;
                String AvailableSeats = textBox15.Text;
                String Plane = textBox16.Text;

                if (FlightId.Length > 0 && Airport.Length > 0 && Departure.Length > 0 &&
                Destination.Length > 0 && Time.Length > 0 && Price.Length > 0 &&
                AvailableSeats.Length > 0 && Plane.Length > 0)
                {
                    if (mainEmployeeController.findFlight(FlightId) == null)
                    {
                        MessageBox.Show("cinci!");
                    }
                    else
                    {
                        Flight flight = new Flight(FlightId, Airport, Departure, Destination, Time,
                        Price, AvailableSeats, Plane);
                        if (mainEmployeeController.updateFlight(FlightId, flight))
                            MessageBox.Show("Actualizare incheiata cu succes!");
                        else
                            MessageBox.Show("Nu s-a realizat actualizare in fisier!");
                    }
                }
                else
                    MessageBox.Show("Nu s-a introdus numele sau CNP-ul!");
            }
            List<Flight> table5 = mainEmployeeController.getAllFlights();
            updateFlightsTable(table5);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nu exista nicio persoana selectata pentru a fi stearsa");
            }
            else
            {
                string cnpSelectat = (string)dataGridView1.SelectedRows[0].Cells[0].Value;
                if (mainEmployeeController.deleteFlight(cnpSelectat))
                    MessageBox.Show("Stergere incheiata cu succes!");
                else
                    MessageBox.Show("Nu s-a realizat stergere in fisier!");
            }
            List<Flight> table5 = mainEmployeeController.getAllFlights();
            updateFlightsTable(table5);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String Airport = textBox1.Text;
            String Destination = textBox2.Text;
            String Time = textBox3.Text;
            
            List<Flight> list = mainEmployeeController.firstFilter(Airport, Destination, Time);

            updateFlightsTable(list);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            String Departure = textBox4.Text;
            String Destination = textBox5.Text;

            List<Flight> list = mainEmployeeController.secondFilter(Departure, Destination);
            updateFlightsTable(list);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            String Plane = textBox6.Text;

            List<Flight> list = mainEmployeeController.thirdFilter(Plane);
            updateFlightsTable(list);
        }

        //Travelers

        public void updateTravelersTable(List<Traveler> list)
        {
            dataGridView3.Rows.Clear();
            if (list != null)
            {
                foreach (Traveler traveler in list)
                {
                    DataGridViewRow rand = new DataGridViewRow();
                    rand.CreateCells(dataGridView3);
                    rand.Cells[0].Value = traveler.getName();
                    rand.Cells[1].Value = traveler.getCNP();
                    dataGridView3.Rows.Add(rand);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String Name = textBox7.Text;
            String CNP = textBox8.Text;


            if (Name.Length > 0 && CNP.Length > 0)
            {
                if (mainEmployeeController.findTraveler(CNP) != null)
                {
                    MessageBox.Show("Exista deja o persoana cu acest CNP!");
                }
                else
                {
                    Traveler traveler = new Traveler(CNP, Name);
                    if (mainEmployeeController.addTraveler(traveler))
                        MessageBox.Show("Adaugare incheiata cu succes!");
                    else
                        MessageBox.Show("Nu s-a realizat adaugare in fisier!");
                }
            }
            List<Traveler> table = mainEmployeeController.getAllTravelers();
            updateTravelersTable(table);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nu exista nicio persoana selectata pentru a fi actualizata");
            }
            else
            {
                string cnpSelectat = (string)dataGridView3.SelectedRows[0].Cells[1].Value;
                String Name = textBox7.Text;

                if (Name.Length > 0 && cnpSelectat.Length > 0)
                {
                    if (mainEmployeeController.findTraveler(cnpSelectat) == null)
                    {
                        MessageBox.Show("patru!");
                    }
                    else
                    {
                        Traveler traveler = new Traveler(cnpSelectat,Name);
                        if (mainEmployeeController.updateTraveler(cnpSelectat, traveler))
                            MessageBox.Show("Actualizare incheiata cu succes!");
                        else
                            MessageBox.Show("Nu s-a realizat actualizare in fisier!");
                    }
                }
                else
                    MessageBox.Show("Nu s-a introdus numele sau CNP-ul!");
            }
            List<Traveler> table = mainEmployeeController.getAllTravelers();
            updateTravelersTable(table);
        }


        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nu exista nicio persoana selectata pentru a fi stearsa");
            }
            else
            {
                string cnpSelectat = (string)dataGridView3.SelectedRows[0].Cells[1].Value;
                if (mainEmployeeController.deleteTraveler(cnpSelectat))
                    MessageBox.Show("Stergere incheiata cu succes!");
                else
                    MessageBox.Show("Nu s-a realizat stergere in fisier!");
            }
            List<Traveler> table = mainEmployeeController.getAllTravelers();
            updateTravelersTable(table);
        }

        //Tickets

        public void updateTicketsTable(List<Ticket> list)
        {
            dataGridView2.Rows.Clear();
            if (list != null)
            {
                foreach (Ticket ticket in list)
                {
                    DataGridViewRow rand = new DataGridViewRow();
                    rand.CreateCells(dataGridView2);
                    rand.Cells[0].Value = ticket.getTicketId();
                    rand.Cells[1].Value = ticket.getFlightId();
                    rand.Cells[2].Value = ticket.getTravelerId();
                    dataGridView2.Rows.Add(rand);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String TicketId = textBox17.Text;
            String FlightId = textBox18.Text;
            String TravelerId = textBox19.Text;


            if (FlightId.Length > 0 && TicketId.Length > 0 && TravelerId.Length > 0)
            {
                if (mainEmployeeController.findTicket(TicketId) != null)
                {
                    MessageBox.Show("Exista deja o persoana cu acest CNP!");
                }
                else
                {
                    Ticket ticket = new Ticket(TicketId, FlightId, TravelerId);
                    if (mainEmployeeController.addTicket(ticket))
                        MessageBox.Show("Adaugare incheiata cu succes!");
                    else
                        MessageBox.Show("Nu s-a realizat adaugare in fisier!");
                }
            }
            List<Ticket> table4 = mainEmployeeController.getAllTickets();
            updateTicketsTable(table4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nu exista nicio persoana selectata pentru a fi actualizata");
            }
            else
            {
                string TicketId = (string)dataGridView2.SelectedRows[0].Cells[0].Value;
                //String TicketId = textBox17.Text;
                String FlightId = textBox18.Text;
                String TravelerId = textBox19.Text;

                if (FlightId.Length > 0 && TicketId.Length > 0 && TravelerId.Length > 0)
                {
                    if (mainEmployeeController.findTicket(TicketId) == null)
                    {
                        MessageBox.Show("cinci!");
                    }
                    else
                    {

                        Ticket ticket = new Ticket(TicketId, FlightId, TravelerId);
                        if (mainEmployeeController.updateTicket(TicketId, ticket))
                            MessageBox.Show("Actualizare incheiata cu succes!");
                        else
                            MessageBox.Show("Nu s-a realizat actualizare in fisier!");
                    }
                }
                else
                    MessageBox.Show("Nu s-a introdus numele sau CNP-ul!");
            }
            List<Ticket> table4 = mainEmployeeController.getAllTickets();
            updateTicketsTable(table4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nu exista nicio persoana selectata pentru a fi stearsa");
            }
            else
            {
                string cnpSelectat = (string)dataGridView2.SelectedRows[0].Cells[0].Value;
                if (mainEmployeeController.deleteTicket(cnpSelectat))
                    MessageBox.Show("Stergere incheiata cu succes!");
                else
                    MessageBox.Show("Nu s-a realizat stergere in fisier!");
            }
            List<Ticket> table4 = mainEmployeeController.getAllTickets();
            updateTicketsTable(table4);
        }

        public void Actualizare(String change, List<Object>list)
        {
            if (list == null){
                if (change.Equals("romana"))
                {
                    label1.Text = "Crud operation:";
                    label2.Text = "Id Zbor:";
                    label3.Text = "Aeroport:";
                    label4.Text = "Plecare:";
                    label5.Text = "Destinatie:";
                    label6.Text = "Ora:";
                    label7.Text = "Pret:";
                    label8.Text = "Locuri libere:";
                    label9.Text = "Avion:";
                    label10.Text = "Tabelul de zboruri:";
                    label11.Text = "Filtre:";
                    label12.Text = "Aeroport:";
                    label13.Text = "Destinatie:";
                    label14.Text = "Ora:";
                    label15.Text = "Tabela de bilete:";
                    label16.Text = "Id Bilete:";
                    label17.Text = "Id Zbor:";
                    label18.Text = "Id Calator:";
                    label19.Text = "Tsbelul de calatori:";
                    label20.Text = "Nume:";
                    label21.Text = "CNP:";
                    label22.Text = "Plecare:";
                    label23.Text = "Destinatie:";
                    label24.Text = "Avion:";

                    button1.Text = "Flitreaza";
                    button2.Text = "Flitreaza";
                    button3.Text = "Flitreaza";
                    button4.Text = "Adauga";
                    button5.Text = "Modifica";
                    button6.Text = "Sterge";
                    button7.Text = "Adauga";
                    button8.Text = "Modifica";
                    button9.Text = "Sterge";
                    button10.Text = "Adauga";
                    button11.Text = "Modifica";
                    button12.Text = "Sterge";
                    button13.Text = "Romana";
                    button14.Text = "Engleza";
                    button15.Text = "Franceza";
                    button16.Text = "Germana";

                    this.dataGridView1.Columns[0].HeaderText = "Id Zbor";
                    this.dataGridView1.Columns[1].HeaderText = "Aeroport";
                    this.dataGridView1.Columns[2].HeaderText = "Plecare";
                    this.dataGridView1.Columns[3].HeaderText = "Destinatie";
                    this.dataGridView1.Columns[4].HeaderText = "Ora";
                    this.dataGridView1.Columns[5].HeaderText = "Pret";
                    this.dataGridView1.Columns[6].HeaderText = "Locuri libere";
                    this.dataGridView1.Columns[7].HeaderText = "Avion";

                    this.dataGridView2.Columns[0].HeaderText = "Id Bilet";
                    this.dataGridView2.Columns[1].HeaderText = "Id Zbor";
                    this.dataGridView2.Columns[2].HeaderText = "Id Calator";

                    this.dataGridView3.Columns[0].HeaderText = "Nume";
                    this.dataGridView3.Columns[1].HeaderText = "CNP";

                }
                if (change.Equals("engleza"))
                {
                    label1.Text = "Crud operation:";
                    label2.Text = "Flight Id:";
                    label3.Text = "Airport:";
                    label4.Text = "Departure:";
                    label5.Text = "Destination:";
                    label6.Text = "Time:";
                    label7.Text = "Price:";
                    label8.Text = "Available Seats:";
                    label9.Text = "Plane:";
                    label10.Text = "Flights table:";
                    label11.Text = "Filters:";
                    label12.Text = "Airport:";
                    label13.Text = "Destination:";
                    label14.Text = "Time:";
                    label15.Text = "Tickets table:";
                    label16.Text = "Ticket Id:";
                    label17.Text = "Flight Id:";
                    label18.Text = "Traveler Id:";
                    label19.Text = "Travelers table:";
                    label20.Text = "Name:";
                    label21.Text = "CNP:";
                    label22.Text = "Departure:";
                    label23.Text = "Destination:";
                    label24.Text = "Plane:";

                    button1.Text = "Filter";
                    button2.Text = "Filter";
                    button3.Text = "Filter";
                    button4.Text = "Add";
                    button5.Text = "Update";
                    button6.Text = "Delete";
                    button7.Text = "Add";
                    button8.Text = "Update";
                    button9.Text = "Delete";
                    button10.Text = "Add";
                    button11.Text = "Update";
                    button12.Text = "Delete";
                    button13.Text = "Romanian";
                    button14.Text = "English";
                    button15.Text = "French";
                    button16.Text = "German";

                    this.dataGridView1.Columns[0].HeaderText = "Flight Id";
                    this.dataGridView1.Columns[1].HeaderText = "Airport";
                    this.dataGridView1.Columns[2].HeaderText = "Departure";
                    this.dataGridView1.Columns[3].HeaderText = "Destination";
                    this.dataGridView1.Columns[4].HeaderText = "Time";
                    this.dataGridView1.Columns[5].HeaderText = "Price";
                    this.dataGridView1.Columns[6].HeaderText = "Available seats";
                    this.dataGridView1.Columns[7].HeaderText = "Plane";

                    this.dataGridView2.Columns[0].HeaderText = "Ticket Id";
                    this.dataGridView2.Columns[1].HeaderText = "Flight Id";
                    this.dataGridView2.Columns[2].HeaderText = "Traveler Id";

                    this.dataGridView3.Columns[0].HeaderText = "Name";
                    this.dataGridView3.Columns[1].HeaderText = "CNP";
                }
                if (change.Equals("franceza"))
                {
                    label1.Text = "Crud opérations:";
                    label2.Text = "Id de vol:";
                    label3.Text = "Aeroport:";
                    label4.Text = "Depart:";
                    label5.Text = "Destination:";
                    label6.Text = "Temps:";
                    label7.Text = "Le prix:";
                    label8.Text = "Places libres:";
                    label9.Text = "Plan:";
                    label10.Text = "Tableau des vols:";
                    label11.Text = "Filtres:";
                    label12.Text = "Aeroport:";
                    label13.Text = "Destination:";
                    label14.Text = "Temps:";
                    label15.Text = "Table des billets:";
                    label16.Text = "Id billet:";
                    label17.Text = "Id de vol:";
                    label18.Text = " Id voyageur:";
                    label19.Text = "Table des voyageurs:";
                    label20.Text = "Nom:";
                    label21.Text = "CNP:";
                    label22.Text = "Depart:";
                    label23.Text = "Destination:";
                    label24.Text = "Plan:";

                    button1.Text = "Filtre";
                    button2.Text = "Filtre";
                    button3.Text = "Filtre";
                    button4.Text = "Ajouter";
                    button5.Text = "Mettre à jour";
                    button6.Text = "Supprimer";
                    button7.Text = "Ajouter";
                    button8.Text = "Mettre à jour";
                    button9.Text = "Supprimer";
                    button10.Text = "Ajouter";
                    button11.Text = "Mettre à jour";
                    button12.Text = "Supprimer";
                    button13.Text = "Roumain";
                    button14.Text = "Anglais";
                    button15.Text = "Français";
                    button16.Text = "Allemand";

                    this.dataGridView1.Columns[0].HeaderText = "Id de vol";
                    this.dataGridView1.Columns[1].HeaderText = "Aeroport";
                    this.dataGridView1.Columns[2].HeaderText = "Depart";
                    this.dataGridView1.Columns[3].HeaderText = "Destination";
                    this.dataGridView1.Columns[4].HeaderText = "Temps";
                    this.dataGridView1.Columns[5].HeaderText = "Le prix";
                    this.dataGridView1.Columns[6].HeaderText = "Places libres";
                    this.dataGridView1.Columns[7].HeaderText = "Plan";

                    this.dataGridView2.Columns[0].HeaderText = "Id billet";
                    this.dataGridView2.Columns[1].HeaderText = "Id de vol";
                    this.dataGridView2.Columns[2].HeaderText = "Traveler Id";

                    this.dataGridView3.Columns[0].HeaderText = "Nom";
                    this.dataGridView3.Columns[1].HeaderText = "CNP";

                }
                if (change.Equals("germana"))
                {
                    label1.Text = " CRUD Operationen:";
                    label2.Text = "Flug-ID:";
                    label3.Text = "Flughafen:";
                    label4.Text = "Abreise:";
                    label5.Text = "Ziel:";
                    label6.Text = "Zeit:";
                    label7.Text = "Preis:";
                    label8.Text = "Verfügbare Sitzplätze:";
                    label9.Text = "Ebene:";
                    label10.Text = "Haken Backgammon:";
                    label11.Text = " Filter:";
                    label12.Text = "Flughafen:";
                    label13.Text = "Ziel:";
                    label14.Text = "Zeit:";
                    label15.Text = " Tickets Tischfilter:";
                    label16.Text = "Ticket Id:";
                    label17.Text = "Flug-ID:";
                    label18.Text = "Reise-Id:";
                    label19.Text = " Reisetisch:";
                    label20.Text = "Namen:";
                    label21.Text = "CNP:";
                    label22.Text = "Abreise:";
                    label23.Text = "Ziel:";
                    label24.Text = "Ebene:";

                    button1.Text = "Filter";
                    button2.Text = "Filter";
                    button3.Text = "Filter";
                    button4.Text = "Hinzufügen";
                    button5.Text = "Aktualisieren";
                    button6.Text = "Löschen";
                    button7.Text = "Hinzufügen";
                    button8.Text = "Aktualisieren";
                    button9.Text = "Löschen";
                    button10.Text = "Hinzufügen";
                    button11.Text = "Aktualisieren";
                    button12.Text = "Löschen";
                    button13.Text = "Rumänisch";
                    button14.Text = "Englisch";
                    button15.Text = "Französisch";
                    button16.Text = "Deutsch";

                    this.dataGridView1.Columns[0].HeaderText = "Flug-ID";
                    this.dataGridView1.Columns[1].HeaderText = "Flughafen";
                    this.dataGridView1.Columns[2].HeaderText = "Abreise";
                    this.dataGridView1.Columns[3].HeaderText = "Ziel";
                    this.dataGridView1.Columns[4].HeaderText = "Zeit";
                    this.dataGridView1.Columns[5].HeaderText = "Preis";
                    this.dataGridView1.Columns[6].HeaderText = "Verfügbare Sitzplätze";
                    this.dataGridView1.Columns[7].HeaderText = "Ebene";

                    this.dataGridView2.Columns[0].HeaderText = "Ticket Id";
                    this.dataGridView2.Columns[1].HeaderText = "Flug-ID";
                    this.dataGridView2.Columns[2].HeaderText = "Reise-Id";

                    this.dataGridView3.Columns[0].HeaderText = "Namen";
                    this.dataGridView3.Columns[1].HeaderText = "CNP";

                }
            }
            else {

            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Actualizare("romana", null);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Actualizare("engleza", null);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Actualizare("franceza", null);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Actualizare("germana", null);
        }
    }
}

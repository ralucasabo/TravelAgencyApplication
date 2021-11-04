using Server.Controller;
using Server.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.View
{
    public partial class FirstPage : Form
    {
        private FirstController firstController;
        public FirstPage(FirstController firstController)
        {
            
            InitializeComponent();
            this.firstController = firstController;

        }

        private void FirstPage_Load(object sender, EventArgs e)
        {
            List<Flight> table = firstController.getAllFlights();
            updateTable(table);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        public void updateTable(List<Flight> list)
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

        public void Actualizare(String change)
        {
            if (change.Equals("romana")) 
            {
                label1.Text = "Cauta:";
                label2.Text = "Aeroport";
                label3.Text = "Destinatie";
                label4.Text = "Ora";
                label5.Text = "Plecare";
                label6.Text = "Destinatie";
                label7.Text = "Avion";
                label8.Text = "Tabela cu zboruri:";

                button1.Text = "Sorteaza";
                button2.Text = "Sorteaza";
                button3.Text = "Sorteaza";
                button4.Text = "Inregistreaza-te";
                button5.Text = "Romana";
                button6.Text = "Engleza";
                button7.Text = "Franceza";
                button8.Text = "Germana";

                this.dataGridView1.Columns[0].HeaderText = "Id Zbor";
                this.dataGridView1.Columns[1].HeaderText = "Aeroport";
                this.dataGridView1.Columns[2].HeaderText = "Plecare";
                this.dataGridView1.Columns[3].HeaderText = "Destinatie";
                this.dataGridView1.Columns[4].HeaderText = "Ora";
                this.dataGridView1.Columns[5].HeaderText = "Pret";
                this.dataGridView1.Columns[6].HeaderText = "Locuri disponibile";
                this.dataGridView1.Columns[7].HeaderText = "Avion";
            }
            if (change.Equals("engleza"))
            {
                label1.Text = "Search:";
                label2.Text = "Airport";
                label3.Text = "Destination";
                label4.Text = "Time";
                label5.Text = "Departure";
                label6.Text = "Destination";
                label7.Text = "Plane";
                label8.Text = "Flights table:";

                button1.Text = "Sort";
                button2.Text = "Sort";
                button3.Text = "Sort";
                button4.Text = "LogIn";
                button5.Text = "Romanian";
                button6.Text = "English";
                button7.Text = "French";
                button8.Text = "German";

                this.dataGridView1.Columns[0].HeaderText = "Flight id";
                this.dataGridView1.Columns[1].HeaderText = "Airport";
                this.dataGridView1.Columns[2].HeaderText = "Departure";
                this.dataGridView1.Columns[3].HeaderText = "Destination";
                this.dataGridView1.Columns[4].HeaderText = "Time";
                this.dataGridView1.Columns[5].HeaderText = "Price";
                this.dataGridView1.Columns[6].HeaderText = "Available seats";
                this.dataGridView1.Columns[7].HeaderText = "Plane";
            }
            if (change.Equals("franceza"))
            {
                label1.Text = "Recherche:";
                label2.Text = "Aeroport";
                label3.Text = "Destination";
                label4.Text = "Temps";
                label5.Text = "Depart";
                label6.Text = "Destination";
                label7.Text = "Plan";
                label8.Text = "Tableau des vols:";

                button1.Text = "Trier";
                button2.Text = "Trier";
                button3.Text = "Trier";
                button4.Text = "Connectez-vous";
                button5.Text = "Roumain";
                button6.Text = "Anglais";
                button7.Text = "Français";
                button8.Text = "Allemand";

                this.dataGridView1.Columns[0].HeaderText = "Fligh id";
                this.dataGridView1.Columns[1].HeaderText = "Aeroport";
                this.dataGridView1.Columns[2].HeaderText = "Depart";
                this.dataGridView1.Columns[3].HeaderText = "Destination";
                this.dataGridView1.Columns[4].HeaderText = "Temps";
                this.dataGridView1.Columns[5].HeaderText = "Prix";
                this.dataGridView1.Columns[6].HeaderText = "Sièges disponibles";
                this.dataGridView1.Columns[7].HeaderText = "Avion";
            }
            if (change.Equals("germana"))
            {
                label1.Text = "Suche:";
                label2.Text = "Flughafen";
                label3.Text = "Ziel";
                label4.Text = "Zeit";
                label5.Text = "Abreise";
                label6.Text = "Ziel";
                label7.Text = "Ebene";
                label8.Text = "Haken Backgammon:";

                button1.Text = "Sortieren";
                button2.Text = "Sortieren";
                button3.Text = "Sortieren";
                button4.Text = "Einloggen";
                button5.Text = "Rumänisch";
                button6.Text = "Englisch";
                button7.Text = "Französisch";
                button8.Text = "Deutsch";

                this.dataGridView1.Columns[0].HeaderText = "Flug-ID";
                this.dataGridView1.Columns[1].HeaderText = "Flughafen";
                this.dataGridView1.Columns[2].HeaderText = "Abreise";
                this.dataGridView1.Columns[3].HeaderText = "Abreise";
                this.dataGridView1.Columns[4].HeaderText = "Zeit";
                this.dataGridView1.Columns[5].HeaderText = "Preis";
                this.dataGridView1.Columns[6].HeaderText = "Verfügbare Sitzplätze";
                this.dataGridView1.Columns[7].HeaderText = "Ebene";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Airport = textBox1.Text;
            String Destination = textBox2.Text;
            String Time = textBox3.Text;

            List<Flight> list = firstController.firstFilter(Airport, Destination, Time);
            updateTable(list);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String Departure = textBox4.Text;
            String Destination = textBox5.Text;

            List<Flight> list = firstController.secondFilter(Departure, Destination);
            updateTable(list);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String Plane = textBox6.Text;

            List<Flight> list = firstController.thirdFilter(Plane);
            updateTable(list);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            firstController.handleLogin();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Actualizare("romana");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Actualizare("engleza");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Actualizare("franceza");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Actualizare("germana");
        }
    }
}

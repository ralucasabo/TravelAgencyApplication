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
    public partial class MainManagerPage : Form
    {
        private MainManagerController mainManagerController;

        public MainManagerPage(MainManagerController mainManagerController)
        {
            InitializeComponent();
            this.mainManagerController = mainManagerController;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MainManagerPage_Load(object sender, EventArgs e)
        {
            List<Flight> table1 = mainManagerController.getAllFlights();
            updateFlightsTable(table1);
            List<Employee> table2 = mainManagerController.getAllEmployees();
            updateEmployeesTable(table2);
            List<Manager> table3 = mainManagerController.getAllManagers();
            updateManagersTable(table3);

        }



        public void updateEmployeesTable(List<Employee> list)
        {
            dataGridView4.Rows.Clear();
            if (list != null)
            {
                foreach (Employee employee in list)
                {
                    DataGridViewRow rand = new DataGridViewRow();
                    rand.CreateCells(dataGridView4);
                    rand.Cells[0].Value = employee.getName();
                    rand.Cells[1].Value = employee.getUsername();
                    rand.Cells[2].Value = employee.getPassword();
                    dataGridView4.Rows.Add(rand);
                }
            }
        }

        public void updateManagersTable(List<Manager> list)
        {
            dataGridView5.Rows.Clear();
            if (list != null)
            {
                foreach (Manager manager in list)
                {
                    DataGridViewRow rand = new DataGridViewRow();
                    rand.CreateCells(dataGridView5);
                    rand.Cells[0].Value = manager.getName();
                    rand.Cells[1].Value = manager.getUsername();
                    rand.Cells[2].Value = manager.getPassword();
                    dataGridView5.Rows.Add(rand);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            String Name = textBox1.Text;
            String Username = textBox2.Text;
            String Password = textBox3.Text;

            if (Name.Length > 0 && Username.Length > 0 && Password.Length > 0)
            {
                if (mainManagerController.findManager(Username, Password) != null)
                {
                    MessageBox.Show("Exista deja o persoana cu acest CNP!");
                }
                else
                {
                    Manager manager = new Manager(Username, Name, Password);
                    if (mainManagerController.addManager(manager))
                        MessageBox.Show("Adaugare incheiata cu succes!");
                    else
                        MessageBox.Show("Nu s-a realizat adaugare in fisier!");
                }
            }
            List<Manager> table3 = mainManagerController.getAllManagers();
            updateManagersTable(table3);
        }

        

            private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView5.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nu exista nicio persoana selectata pentru a fi stearsa");
            }
            else
            {
                string cnpSelectat = (string)dataGridView5.SelectedRows[0].Cells[1].Value;
                if (mainManagerController.deleteManager(cnpSelectat))
                    MessageBox.Show("Stergere incheiata cu succes!");
                else
                    MessageBox.Show("Nu s-a realizat stergere in fisier!");
            }
            List<Manager> table3 = mainManagerController.getAllManagers();
            updateManagersTable(table3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String Name = textBox4.Text;
            String Username = textBox5.Text;
            String Password = textBox6.Text;

            if (Name.Length > 0 && Username.Length > 0 && Password.Length > 0)
            {
                if (mainManagerController.findEmployee(Username, Password) != null)
                {
                    MessageBox.Show("Exista deja o persoana cu acest CNP!");
                }
                else
                {
                    Employee employee = new Employee(Username, Name, Password);
                    if (mainManagerController.addEmployee(employee))
                        MessageBox.Show("Adaugare incheiata cu succes!");
                    else
                        MessageBox.Show("Nu s-a realizat adaugare in fisier!");
                }
            }
            List<Employee> table2 = mainManagerController.getAllEmployees();
            updateEmployeesTable(table2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nu exista nicio persoana selectata pentru a fi stearsa");
            }
            else
            {
                string cnpSelectat = (string)dataGridView4.SelectedRows[0].Cells[1].Value;
                if (mainManagerController.deleteEmployee(cnpSelectat))
                    MessageBox.Show("Stergere incheiata cu succes!");
                else
                    MessageBox.Show("Nu s-a realizat stergere in fisier!");
            }
            List<Employee> table2 = mainManagerController.getAllEmployees();
            updateEmployeesTable(table2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nu exista nicio persoana selectata pentru a fi actualizata");
            }
            else
            {
                String Name = textBox4.Text;
                String Username = (string)dataGridView4.SelectedRows[0].Cells[1].Value;
                String Password = (string)dataGridView4.SelectedRows[0].Cells[2].Value;


                if (Name.Length > 0 && Username.Length > 0 && Password.Length > 0)
                {
                    if (mainManagerController.findEmployee(Username, Password) == null)
                    {
                        MessageBox.Show("sapte");
                    }
                    else
                    {
                        Employee employee = new Employee(Username, Name, Password);
                        if (mainManagerController.updateEmployee(Username, employee))
                            MessageBox.Show("Actualizare incheiata cu succes!");
                        else
                            MessageBox.Show("Nu s-a realizat actualizare in fisier!");
                    }
                }
                else
                    MessageBox.Show("Nu s-a introdus numele sau CNP-ul!");

            }
            List<Employee> table2 = mainManagerController.getAllEmployees();
            updateEmployeesTable(table2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String Airport = textBox7.Text;
            String Destination = textBox8.Text;
            String Time = textBox9.Text;

            List<Flight> list = mainManagerController.firstFilter(Airport, Destination, Time);
            updateFlightsTable(list);
        }

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

        private void button8_Click(object sender, EventArgs e)
        {
            String Departure = textBox10.Text;
            String Destination = textBox11.Text;

            List<Flight> list = mainManagerController.secondFilter(Departure, Destination);
            updateFlightsTable(list);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            String Plane = textBox12.Text;

            List<Flight> list = mainManagerController.thirdFilter(Plane);
            updateFlightsTable(list);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView5.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nu exista nicio persoana selectata pentru a fi actualizata");
            }
            else
            {
                String Username = (string)dataGridView5.SelectedRows[0].Cells[1].Value;
                
                String Name = textBox1.Text;
                //String Username = textBox2.Text;
                String Password = (string)dataGridView5.SelectedRows[0].Cells[2].Value;

                if (Name.Length > 0 && Username.Length > 0 && Password.Length>0)
                {
                    if (mainManagerController.findManager(Username, Password) == null)
                    {
                        MessageBox.Show("sase!");
                    }
                    else
                    {
                        Manager manager = new Manager(Username, Name, Password);
                        if (mainManagerController.updateManager(Username, manager))
                            MessageBox.Show("Actualizare incheiata cu succes!");
                        else
                            MessageBox.Show("Nu s-a realizat actualizare in fisier!");
                    }
                }
                else
                    MessageBox.Show("Nu s-a introdus numele sau CNP-ul!");
            }
            List<Manager> table3 = mainManagerController.getAllManagers();
            updateManagersTable(table3);
            
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        public void Actualizare(String change)
        {
            if (change.Equals("romana"))
            {
                label1.Text = "Tabelul cu zboruri:";
                label2.Text = "Filtre:";
                label3.Text = "Aeroport:";
                label4.Text = "Destinatie:";
                label5.Text = "Ora:";
                label6.Text = "Plecare:";
                label7.Text = "Destinatie:";
                label8.Text = "Avion:";
                label9.Text = "Tabelul cu angajati:";
                label10.Text = "Nume:";
                label11.Text = "Utilizator:";
                label12.Text = "Parola:";
                label13.Text = "Tabelul cu manageri:";
                label14.Text = "Nume:";
                label15.Text = "Utilizator:";
                label16.Text = "Parola:";

                button1.Text = "Adauga";
                button2.Text = "Modifica";
                button3.Text = "Sterge";
                button4.Text = "Adauga";
                button5.Text = "Modifica";
                button6.Text = "Sterge";
                button7.Text = "Filtru";
                button8.Text = "Filtru";
                button9.Text = "Filtru";
                button10.Text = "Romana";
                button11.Text = "Engleza";
                button12.Text = "Franceza";
                button13.Text = "Germana";


                this.dataGridView1.Columns[0].HeaderText = "Id zbor";
                this.dataGridView1.Columns[1].HeaderText = "Aeroport";
                this.dataGridView1.Columns[2].HeaderText = "Plecare";
                this.dataGridView1.Columns[3].HeaderText = "Destinatie";
                this.dataGridView1.Columns[4].HeaderText = "Ora";
                this.dataGridView1.Columns[5].HeaderText = "Pret";
                this.dataGridView1.Columns[6].HeaderText = "Locuri libere";
                this.dataGridView1.Columns[7].HeaderText = "Avion";

                this.dataGridView4.Columns[0].HeaderText = "Nume";
                this.dataGridView4.Columns[1].HeaderText = "Utilizator";
                this.dataGridView4.Columns[2].HeaderText = "Parola";

                this.dataGridView5.Columns[0].HeaderText = "Nume";
                this.dataGridView5.Columns[1].HeaderText = "Utilizator";
                this.dataGridView5.Columns[2].HeaderText = "Parola";


            }
            if (change.Equals("engleza"))
            {
                label1.Text = "Flights table:";
                label2.Text = "Filters:";
                label3.Text = "Airport:";
                label4.Text = "Destination:";
                label5.Text = "Time:";
                label6.Text = "Departure:";
                label7.Text = "Destination:";
                label8.Text = "Plane:";
                label9.Text = "Employees table:";
                label10.Text = "Name:";
                label11.Text = "Username:";
                label12.Text = "Password:";
                label13.Text = "Manager's table:";
                label14.Text = "Name:";
                label15.Text = "Username:";
                label16.Text = "Password:";

                button1.Text = "Add";
                button2.Text = "Update";
                button3.Text = "Delete";
                button4.Text = "Add";
                button5.Text = "Update";
                button6.Text = "Delete";
                button7.Text = "Filter";
                button8.Text = "Filter";
                button9.Text = "Filter";
                button10.Text = "Romanian";
                button11.Text = "English";
                button12.Text = "French";
                button13.Text = "German";


                this.dataGridView1.Columns[0].HeaderText = "Flight Id";
                this.dataGridView1.Columns[1].HeaderText = "Airport";
                this.dataGridView1.Columns[2].HeaderText = "Departure";
                this.dataGridView1.Columns[3].HeaderText = "Destination";
                this.dataGridView1.Columns[4].HeaderText = "Time";
                this.dataGridView1.Columns[5].HeaderText = "Price";
                this.dataGridView1.Columns[6].HeaderText = "Available seats";
                this.dataGridView1.Columns[7].HeaderText = "Plane";

                this.dataGridView4.Columns[0].HeaderText = "Name";
                this.dataGridView4.Columns[1].HeaderText = "Username";
                this.dataGridView4.Columns[2].HeaderText = "Password";

                this.dataGridView5.Columns[0].HeaderText = "Name";
                this.dataGridView5.Columns[1].HeaderText = "Username";
                this.dataGridView5.Columns[2].HeaderText = "Password";
            }
            if (change.Equals("franceza"))
            {
                label1.Text = "Tableau des vols:";
                label2.Text = "Filtres:";
                label3.Text = "Aeroport:";
                label4.Text = "Destination:";
                label5.Text = "Temps:";
                label6.Text = "Depart:";
                label7.Text = "Destination:";
                label8.Text = "Plan:";
                label9.Text = "Table des employés:";
                label10.Text = "Nom:";
                label11.Text = "UserNom:";
                label12.Text = "Mot de passe:";
                label13.Text = "Table des gestionnaires:";
                label14.Text = "Nom:";
                label15.Text = "UserNom:";
                label16.Text = "Mot de passe:";

                button1.Text = "Hinzufügen";
                button2.Text = "Aktualisieren";
                button3.Text = "Löschen";
                button4.Text = "Hinzufügen";
                button5.Text = "Aktualisieren";
                button6.Text = "Löschen";
                button7.Text = "Filter";
                button8.Text = "Filter";
                button9.Text = "Filter";
                button10.Text = "Roumain";
                button11.Text = "Anglais";
                button12.Text = "Français";
                button13.Text = "Allemand";


                this.dataGridView1.Columns[0].HeaderText = "Flight Id";
                this.dataGridView1.Columns[1].HeaderText = "Aeroport";
                this.dataGridView1.Columns[2].HeaderText = "Depart";
                this.dataGridView1.Columns[3].HeaderText = "Destination";
                this.dataGridView1.Columns[4].HeaderText = "Temps";
                this.dataGridView1.Columns[5].HeaderText = "Price";
                this.dataGridView1.Columns[6].HeaderText = "Available seats";
                this.dataGridView1.Columns[7].HeaderText = "Plan";

                this.dataGridView4.Columns[0].HeaderText = "Nom";
                this.dataGridView4.Columns[1].HeaderText = "UserNom";
                this.dataGridView4.Columns[2].HeaderText = "Mot de passe";

                this.dataGridView5.Columns[0].HeaderText = "Nom";
                this.dataGridView5.Columns[1].HeaderText = "UserNom";
                this.dataGridView5.Columns[2].HeaderText = "Mot de passe";


            }
            if (change.Equals("germana"))
            {
                label1.Text = "Haken Backgammon:";
                label2.Text = "Filter:";
                label3.Text = "Flughafen:";
                label4.Text = "Ziel:";
                label5.Text = "Zeit:";
                label6.Text = "Abreise:";
                label7.Text = "Ziel:";
                label8.Text = "Ebene:";
                label9.Text = "Mitarbeitertabelle:";
                label10.Text = "Name:";
                label11.Text = "Benutzername:";
                label12.Text = "Passwort:";
                label13.Text = "Manager-Tabelle:";
                label14.Text = "Name:";
                label15.Text = "Benutzername:";
                label16.Text = "Passwort:";

                button1.Text = "Hinzufügen";
                button2.Text = "Aktualisieren";
                button3.Text = "Löschen";
                button4.Text = "Hinzufügen";
                button5.Text = "Aktualisieren";
                button6.Text = "Löschen";
                button7.Text = "Filter";
                button8.Text = "Filter";
                button9.Text = "Filter";
                button10.Text = "Rumänisch";
                button11.Text = "Englisch";
                button12.Text = "Französisch";
                button13.Text = "Deutsch";


                this.dataGridView1.Columns[0].HeaderText = " Flug-ID ";
                this.dataGridView1.Columns[1].HeaderText = "Flughafen";
                this.dataGridView1.Columns[2].HeaderText = "Abreise";
                this.dataGridView1.Columns[3].HeaderText = "Ziel";
                this.dataGridView1.Columns[4].HeaderText = "Zeit";
                this.dataGridView1.Columns[5].HeaderText = "Preis";
                this.dataGridView1.Columns[6].HeaderText = " Verfügbare Sitzplätze";
                this.dataGridView1.Columns[7].HeaderText = "Ebene";

                this.dataGridView4.Columns[0].HeaderText = "Name";
                this.dataGridView4.Columns[1].HeaderText = "Benutzername";
                this.dataGridView4.Columns[2].HeaderText = "Passwort";

                this.dataGridView5.Columns[0].HeaderText = "Name";
                this.dataGridView5.Columns[1].HeaderText = "Benutzername";
                this.dataGridView5.Columns[2].HeaderText = "Passwort";

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Actualizare("romana");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Actualizare("engleza");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Actualizare("franceza");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Actualizare("germana");
        }
    }
}

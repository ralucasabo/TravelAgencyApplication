using Server.Controller;
using System;
using System.Windows.Forms;

namespace Server.View
{
    public partial class LogInPage : Form
    {
        private LogInController logInController;
        public LogInPage(LogInController logInController)
        {
            this.logInController = logInController;
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            String password = textBox2.Text;

            
            if (username != string.Empty && password != string.Empty)
            {
                logInController.login(username, password);
            }
            else
            {
                MessageBox.Show("insucces!");
            }
            

        }

        public void Actualizare(String change)
        {
            if (change.Equals("romana"))
            {
                label1.Text = "Utilizator";
                label2.Text = "Parola";
                label3.Text = "Bine ati venit";

                button1.Text = "Inregistreaza-te";
                button2.Text = "Romana";
                button3.Text = "Engleza";
                button4.Text = "Franceza";
                button5.Text = "Germana";

            }
            if (change.Equals("engleza"))
            {
                label1.Text = "Username";
                label2.Text = "Password";

                button1.Text = "LogIn";
                button2.Text = "Romanian";
                button3.Text = "English";
                button4.Text = "French";
                button5.Text = "German";

            }
            if (change.Equals("franceza"))
            {
                label1.Text = "Nom d'utilisateur";
                label2.Text = "Mot de passe";
                label3.Text = "Bienvenue";

                button1.Text = "Connectez-vous";
                button2.Text = "Roumain";
                button3.Text = "Anglais";
                button4.Text = "Français";
                button5.Text = "Allemand";

            }
            if (change.Equals("germana"))
            {
                label1.Text = "Benutzername";
                label2.Text = "Passwort";
                label3.Text = "Willkommen";

                button1.Text = "Einloggen";
                button2.Text = "Rumänisch";
                button3.Text = "Englisch";
                button4.Text = "Französisch";
                button5.Text = "Deutsch";

            }
        }

        private void LogInPage_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Actualizare("romana");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Actualizare("engleza");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Actualizare("franceza");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Actualizare("germana");
        }
    }
}

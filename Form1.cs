using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Geld_Automat
{
    public partial class Form1 : Form
    {

        public string currentword = string.Empty;

        private User currentUser;
        public Users Users { get; set; }
        List<string> wordsdictionary = new List<string>();

        public string currentCommand;

        int fuenfer;
        int zehner;
        int zwanziger;
        int fuenfziger;
        int hunderter;
        int zweihunderter;
        int fuenfhunderter ;

        public int GesamtSumme;

        public Form1()
        {
            InitializeComponent();
            InitialisiereFormular();
            Ladebenutzer();
        }

        private void Ladebenutzer()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Users));
            TextReader reader = new StreamReader(@"C:\Users\medin.krupic\Desktop\Konten");
            object obj = deserializer.Deserialize(reader);
            Users = (Users)obj;
            reader.Close();
        }

        private void InitialisiereFormular()
        {
            this.groupBox4.Visible = true;
            this.groupBox5.Visible = false;
            this.groupBox1.Enabled = false;

            this.pictureBox2.Visible = false;
            this.pictureBox1.Visible = true;
            this.pictureBox1.Enabled = true;
            this.groupBox3.Enabled = true;

            
        }

        private void Anmelden(object sender, EventArgs e)
        {
           
            string name = textBox2.Text;//Microsoft.VisualBasic.Interaction.InputBox("Name", "Login");

            groupBox1.Enabled = true;
            this.pictureBox1.Visible = false;
            this.pictureBox2.Visible = true;

            currentCommand = "WaitingForPIN";
            
            textBox4.Text = "Gebe dein PIN ein.";

        }

        public void UpdateUI()
        {


            this.pictureBox1.Visible = false;
            this.pictureBox2.Visible = true;
            this.pictureBox2.Enabled = false;
            this.groupBox3.Enabled = false;
            this.groupBox4.Visible = true;
            this.groupBox4.Enabled = true;
            this.groupBox1.Enabled = true;
        }

        private void Abmelden(object sender, EventArgs e)
        {
            //Auslogen
            currentUser = null;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;

            InitialisiereFormular();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "1";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "2";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "3";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "4";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "5";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "6";
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "7";
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "8";
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "9";
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "*";
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "0";
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "00";
        }

        private void Bestetigen(object sender, EventArgs e)
        {
            textBox4.Text = textBox1.Text;

            string name = textBox2.Text;//Microsoft.VisualBasic.Interaction.InputBox("Name", "Login");

            groupBox1.Enabled = true;
            this.pictureBox1.Visible = false;
            this.pictureBox2.Visible = true;

            if(currentCommand == "WaitingForPIN")
            {
                string pwd = textBox1.Text;//Microsoft.VisualBasic.Interaction.InputBox("Passwort", "Login");
                //this.textBox1.
                //string iban = textBox1.Text;

                if (name == "" || pwd == "")
                {
                    MessageBox.Show("Name oder Passwort war leer.");
                    return;
                }

                User foundUser = Users.User.FirstOrDefault(ee => ee.Name == name && ee.Password == pwd /*&& ee.IBAN == iban*/);

                if (foundUser != null)
                {

                    this.currentUser = foundUser;
                    textBox3.Text = currentUser.Name;
                    this.groupBox5.Visible = true;
                    textBox4.Text = string.Empty;
                    textBox4.Text = "PIN ist richtig";
                    currentCommand = "LogedIn";

                    UpdateUI();
                }
                else
                {
                    MessageBox.Show("Benutzername oder Passwort sind falsch.");

                }
            }
            
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void Hilfe(object sender, EventArgs e)
        {
            textBox4.Text = "- Schieben Sie Ihre Kontokarte in den dafür vorgesehenen platz." + Environment.NewLine + "- Melden ie sich mit Ihrem Namen und PIN an." + Environment.NewLine + "- Sie können Auszahlen, Überweisen oder Einzahlen auswählen." + Environment.NewLine + "- Falls Sie noch Fragen haben, stehen Ihnen unsere Mitarbeiter steht zur Hilfe.";
        }

        private void Uberweisen(object sender, EventArgs e)
        {
            
            //if (iban == "" && iban != iban.Text)
            //{
            //    MessageBox.Show("IBAN Falsch.");
            //    return;
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Geld generieren
            Random zufall = new Random();
           
            fuenfer = zufall.Next(0, 100);
            zehner = zufall.Next(0, 100);
            zwanziger = zufall.Next(0, 100);
            fuenfziger = zufall.Next(0, 100);
            hunderter = zufall.Next(0, 100);
            zweihunderter = zufall.Next(0, 100);
            fuenfhunderter = zufall.Next(0, 100);
            GesamtSumme = fuenfer * 5 + zehner * 10 + zwanziger * 20 + fuenfziger * 50 + hunderter * 100 + zweihunderter * 200 + fuenfhunderter * 500;


        }
    }
}

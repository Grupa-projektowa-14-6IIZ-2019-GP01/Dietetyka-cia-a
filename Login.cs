using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DietetykaCiałą
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Loginn.Text = "";
            Haslo.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Loginn.Text == "" || Haslo.Text == "") { 
            MessageBox.Show("Puste pole"); }

            else if (Loginn.Text == "Admin" && Haslo.Text == "Admin")
            {
                MainForm mainform = new MainForm();
                mainform.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Zły login lub hasło");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}

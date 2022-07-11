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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dodajjczłonka dodajjczłonka = new Dodajjczłonka();
            dodajjczłonka.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Usuńzmień usuńzmień = new Usuńzmień();
            usuńzmień.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Płatności płatności = new Płatności();
            płatności.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Widokczłonków widokczłonków = new Widokczłonków();
            widokczłonków.Show();
            this.Hide();
        }
    }
}

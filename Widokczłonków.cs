using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DietetykaCiałą
{
    public partial class Widokczłonków : Form
    {
        public Widokczłonków()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kempur\Desktop\DietetykaCiałą\baza\Dietka.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private void populate()
        {
            Con.Open();
            string query = "select * from DodajTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            CzlonkowieDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CzlonkowieDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void Widokczłonków_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
            this.Hide();
        }
        private void filterByname()
        {
            Con.Open();
            string query = "select * from DodajTbl where DName = '" + szukaj_czlonkow.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            CzlonkowieDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filterByname();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            populate();
        }
    }
}

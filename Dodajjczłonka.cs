using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DietetykaCiałą
{
    public partial class Dodajjczłonka : Form
    {
        public Dodajjczłonka()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kempur\Desktop\DietetykaCiałą\baza\Dietka.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || WagaTb.Text == "" || ObwodTb.Text == "" || WiekTb.Text == "" || PlatnoscTb.Text == "")
            {
                MessageBox.Show("Wprowadź wszystkie dane");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into DodajTbl values('" + NameTb.Text + "','" + WagaTb.Text + "','" + ObwodTb.Text + "','" + WiekTb.Text + "','" + PlatnoscTb.Text + "','" + BmiCb.SelectedItem.ToString() + "','" + PlecCb.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, Con); ;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Dodano członka");
                    Con.Close();
                    NameTb.Text = "";
                    WagaTb.Text = "";
                    ObwodTb.Text = "";
                    WiekTb.Text = "";
                    PlatnoscTb.Text = "";
                    BmiCb.Text = "";
                    PlecCb.Text = "";

                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            NameTb.Text = "";
            WagaTb.Text = "";
            ObwodTb.Text = "";
            WiekTb.Text = "";
            PlatnoscTb.Text = "";
            BmiCb.Text = "";
            PlecCb.Text = "";

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       

        private void Dodajjczłonka_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
            this.Hide();
        }
    }
}

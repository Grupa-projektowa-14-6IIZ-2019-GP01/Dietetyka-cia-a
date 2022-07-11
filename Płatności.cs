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
    public partial class Płatności : Form
    {
        public Płatności()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kempur\Desktop\DietetykaCiałą\baza\Dietka.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void FillName()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select DName from DodajTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("DName", typeof(string));
            dt.Load(rdr);
            NameCb.ValueMember = "DName";
            NameCb.DataSource = dt;
            Con.Close();


        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void filterByname()
        {
            Con.Open();
            string query = "select * from PlatnoscTbl where PImie = '"+szukaj_menu.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            szukajmenu.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void populate()
        {
            Con.Open();
            string query = "select * from PlatnoscTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            szukajmenu.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //NameTb.Text = "";
            AmountTb.Text = "";
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (NameCb.Text == "" || AmountTb.Text == "")
            {
                MessageBox.Show("Puste pole");
            }
            else
            {
                string payperiode = periode.Value.Month.ToString() + periode.Value.Year.ToString();
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from PlatnoscTbl where PImie='" + NameCb.SelectedValue.ToString() + "' and PMiesiac='" + payperiode + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Zapłaciłeś za ten miesiąc");
                }
                else {
                    string query = "insert into PlatnoscTbl values('" + payperiode + "','" + NameCb.SelectedValue.ToString() + "'," + AmountTb.Text + ")";
                        SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Płatność wykonana pomyślnie");
                }
                Con.Close();
                populate();
            }
        }

       

        private void Płatności_Load(object sender, EventArgs e)
        {
            FillName();
            populate();

        }

        private void AmountTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            filterByname();
            szukaj_menu.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void szukaj_menu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

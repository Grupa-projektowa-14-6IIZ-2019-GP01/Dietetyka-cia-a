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
    public partial class Usuńzmień : Form
    {
        public Usuńzmień()
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
        private void Usuńzmień_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        int key = 0;
        private void CzlonkowieDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(CzlonkowieDGV.SelectedRows[0].Cells[0].Value.ToString());
            NameTb.Text = CzlonkowieDGV.SelectedRows[0].Cells[1].Value.ToString();
            WagaTb.Text = CzlonkowieDGV.SelectedRows[0].Cells[2].Value.ToString();
            ObwodTb.Text = CzlonkowieDGV.SelectedRows[0].Cells[3].Value.ToString();
            WiekTb.Text = CzlonkowieDGV.SelectedRows[0].Cells[4].Value.ToString();
            PlatnoscTb.Text = CzlonkowieDGV.SelectedRows[0].Cells[5].Value.ToString();
            BmiCb.Text = CzlonkowieDGV.SelectedRows[0].Cells[6].Value.ToString();
            PlecCb.Text = CzlonkowieDGV.SelectedRows[0].Cells[7].Value.ToString();
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

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
            this.Hide();
        }

        private void Usun_Click(object sender, EventArgs e)
        {
            if(key == 0)
            {
                MessageBox.Show("Wybierz członka do usunięcia");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from DodajTbl where DId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usunięto członka");
                    Con.Close();
                    populate();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0 || NameTb.Text == "" || WagaTb.Text == "" || ObwodTb.Text == "" || WiekTb.Text == "" || PlatnoscTb.Text == "" || BmiCb.Text == "" || PlecCb.Text == "")
            {
                MessageBox.Show("Uzupełnij dane");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update DodajTbl set DName='" + NameTb.Text + "',DWaga='" + WagaTb.Text + "',DObwod='" + ObwodTb.Text + "',DWiek='" + WiekTb.Text + "',DPlatnosc='" + PlatnoscTb.Text + "',DBMI='" + BmiCb.Text + "','" + PlecCb.Text + "' where DId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Zaktualizowano informacje");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

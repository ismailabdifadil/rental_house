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

namespace Rental_Management
{
    public partial class Dashboard : Form
    {
        SqlConnection Con = new SqlConnection("Data Source=DIINSAALOW\\MSSQLSERVER01;Initial Catalog=HouseRental;Integrated Security=True");

        public Dashboard()
        {
            InitializeComponent();
            showApartmentsCount();
            showRnetsCount();
            showLandlordCount();

        }

        private void showApartmentsCount()
        {
            //Read the number of rents from the database and display it in the label
            Con.Open();
            string query = "select count(*) from apartmentstbl";
            SqlCommand cmd = new SqlCommand(query, Con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            lblApartments.Text = count.ToString();
            Con.Close();
        }
        private void showRnetsCount()
        {
            //Read the number of rents from the database and display it in the label
            Con.Open();
            string query = "select count(*) from RentsTbl";
            SqlCommand cmd = new SqlCommand(query, Con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            rentedCount.Text = count.ToString();
            Con.Close();
        }
        private void showLandlordCount()
        {
            //Read the number of rents from the database and display it in the label
            Con.Open();
            string query = "select count(*) from landlordtbl";
            SqlCommand cmd = new SqlCommand(query, Con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            landlordsCount.Text = count.ToString();
            Con.Close();
        }


        private void label16_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked");
        }

        private void btnSeeAllApart_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "select * from ApartmentsTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            var builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            resultGridView.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void btnSeeAllLand_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "SELECT * FROM LANDLORDTBL";
            SqlDataAdapter dsa = new SqlDataAdapter(query, Con);
            var builder = new SqlCommandBuilder(dsa);
            var ds = new DataSet();
            dsa.Fill(ds);
            resultGridView.DataSource= ds.Tables[0];
            Con.Close ();
        }

        private void btnSeeAllRents_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "SELECT * FROM rentstbl";
            SqlDataAdapter dsa = new SqlDataAdapter(query, Con);
            var builder = new SqlCommandBuilder(dsa);
            var ds = new DataSet();
            dsa.Fill(ds);
            resultGridView.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            new Tenents().Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new Tenents().Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new Apartments().Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            new Apartments().Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new Landlords().Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new Landlords().Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            new Category().Show();
            //this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            new Category().Show();

        }

        private void label9_Click(object sender, EventArgs e)
        {
            //new About().Show(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {
            new SignIn().Show();
            this.Hide();

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            new SignIn().Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

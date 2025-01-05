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

namespace Rental_Management
{
    public partial class Rents : Form
    {
        SqlConnection Con = new SqlConnection("Data Source=DIINSAALOW\\MSSQLSERVER01;Initial Catalog=HouseRental;Integrated Security=True");  
        public Rents()
        {
            InitializeComponent();
            getApartments();
            getTenants();
            showRents();
        }

        private void ResetData()
        {
            cmbApartName.SelectedIndex = -1;
            txtAmount.Clear();
            cmbTName.SelectedIndex = -1;
            rentDate.Value = DateTime.Now;
        }

        private void getCost()
        {
            Con.Open();
            string query = "select * from ApartmentsTbl where AName = '" + cmbApartName.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                string cost = rdr["ACost"].ToString();
                txtAmount.Text = cost;
            }
            Con.Close();
        }
        private void showRents()
        {
            Con.Open();
            string query = "select * from RentsTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            var builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            rentGridView.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void getApartments()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select AName from ApartmentsTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("AName", typeof(string));
            dt.Load(Rdr);
            cmbApartName.ValueMember = "AName";
            cmbApartName.DataSource = dt;
            Con.Close();
        }

        private void getTenants()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select tenName from TenantTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("tenName", typeof(string));
            dt.Load(Rdr);
            cmbTName.ValueMember = "tenName";
            cmbTName.DataSource = dt;
            Con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbApartName.SelectedIndex  == -1 || txtAmount.Text == "" || cmbTName.SelectedIndex  ==  -1 || rentDate.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string period = rentDate.Value.Date.Month + " - "  + rentDate.Value.Date.Year;
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into RentsTbl(aparment,tenant,amount,period) values (@RApart,@RTenant,@RAmount,@RPeriod)", Con);
                    cmd.Parameters.AddWithValue("@RApart", cmbApartName.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@RTenant", cmbTName.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@RAmount", txtAmount.Text);
                    cmd.Parameters.AddWithValue("@RPeriod", period.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rent Added Successfully");
                    Con.Close();
                    ResetData();
                    showRents();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void cmbApartName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getCost();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            new Dashboard().Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new Dashboard().Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new Tenents().Show();
            this.Close();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new Tenents().Show();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new Apartments().Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            new Apartments().Show();
            this.Close();
        }


        private void label6_Click(object sender, EventArgs e)
        {
            new Landlords().Show();
            this.Close();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new Landlords() .Show();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            new Category().Show();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            new Category() .Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //new About().Show();
            //this.Close();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            //new About().Show();
            //this.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            new SignIn().Show();
            this.Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            new SignIn().Show();
            this.Close();
        }
    }
}

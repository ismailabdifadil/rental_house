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
    public partial class Apartments : Form
    {
        SqlConnection Con = new SqlConnection("Data Source=DIINSAALOW\\MSSQLSERVER01;Initial Catalog=HouseRental;Integrated Security=True");

        public Apartments()
        {
            InitializeComponent();
            showApartment();
            getCatageroies();
            getOwners();
        }

        private void ResetData()
        {
            txtAName.Text = "";
            txtACost.Text = "";
            txtAAddress.Text = "";
            cmbAOwner.SelectedIndex = -1;
            cmbAType.SelectedIndex = -1;
        }
        private void getCatageroies()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select category from CategoryTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("category", typeof(string));
            dt.Load(Rdr);
            cmbAType.ValueMember = "category";
            cmbAType.DataSource = dt;
            Con.Close();
        }
        private void getOwners()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select LLNam from landlordtbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("LLNam", typeof(string));
            dt.Load(Rdr);
            cmbAOwner.ValueMember = "LLNam";
            cmbAOwner.DataSource = dt;
            Con.Close();
        }


        //Read all the apartments from the database and display them in the data grid view.
        private void showApartment()
        {
            Con.Open();
            string Query = "Select * from ApartmentsTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            aparmentGridView.DataSource = ds.Tables[0];
            Con.Close();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtAName.Text == "" || txtACost.Text == "" || txtAAddress.Text == "" || cmbAOwner.SelectedIndex == -1 || cmbAType.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                Con.Open();
                string Query = "Insert into ApartmentsTbl values('" + txtAName.Text + "','" +  txtAAddress.Text + "','" + txtACost.Text + "','" + cmbAOwner.SelectedValue.ToString() + "','" + cmbAType.SelectedValue.ToString()  + "')";
                SqlCommand cmd = new SqlCommand(Query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Apartment Added Successfully");
                Con.Close();
                showApartment();
                ResetData();
            }
        }

        int Key = 0;
        private void aparmentGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = aparmentGridView.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                txtAName.Text = row.Cells[1].Value.ToString();
                txtAAddress.Text = row.Cells[2].Value.ToString();
                txtACost.Text = row.Cells[3].Value.ToString();
                cmbAOwner.SelectedValue = row.Cells[4].Value.ToString();
                cmbAType.SelectedValue = row.Cells[5].Value.ToString();
                Key = Convert.ToInt32(row.Cells[0].Value.ToString());
            }
           
            else
            {
                MessageBox.Show("No row selected.");
                Key = 0;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
                if (Key == 0)
                {
                    MessageBox.Show("Select an Apartment to Update");
                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update ApartmentsTbl set AName = @AN, AAddress = @AA, ACost = @AC, Owner = @AO, AType = @AT where ANum = @AKey", Con);
                    cmd.Parameters.AddWithValue("@AN", txtAName.Text);
                    cmd.Parameters.AddWithValue("@AA", txtAAddress.Text);
                    cmd.Parameters.AddWithValue("@AC", txtACost.Text);
                    cmd.Parameters.AddWithValue("@AO", cmbAOwner.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@AT", cmbAType.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@AKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Apartment Updated Successfully");
                    Con.Close();
                    ResetData();
                    showApartment();
                }
            

            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            { 
                MessageBox.Show("Select an Apartment to Delete");
            }
            else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("delete apartmentstbl where Anum= @Akey", Con);
                cmd.Parameters.AddWithValue("@Akey", Key);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Apartment Deleted");
                Con.Close();
                ResetData(); showApartment();
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            new Dashboard().Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new Dashboard().Show();
            this.Hide();
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
            //this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            //new About().Show();
            //this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            //new About().Show();
            //this.Hide();
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

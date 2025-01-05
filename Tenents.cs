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
    public partial class Tenents : Form
    {
        SqlConnection Con = new SqlConnection("Data Source=DIINSAALOW\\MSSQLSERVER01;Initial Catalog=HouseRental;Integrated Security=True");
        UserRole userRole = new UserRole();

        public Tenents()
        {
            InitializeComponent();
            ShowTenants();
            tenantGridView.CellContentClick += new DataGridViewCellEventHandler(tenantGridView_CellContentClick);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Tenents_Load(object sender, EventArgs e)
        {

        }

        private void ShowTenants()
        {
            Con.Open();
            string Query = "Select * from TenantTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            tenantGridView.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void txtAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || comGender.SelectedIndex == -1 || txtPhone.Text == "")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into TenantTbl(tenName, tenPhone, tenGender) values(@TN, @TP, @TG)", Con);
                    cmd.Parameters.AddWithValue("@TN", txtName.Text);
                    cmd.Parameters.AddWithValue("@TP", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@TG", comGender.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tenant Added!!!");
                    Con.Close();
                    ResetData();
                    ShowTenants();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void ResetData()
        {
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            comGender.SelectedIndex = -1;
        }

        int Key = 0;

        private void tenantGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = tenantGridView.Rows[e.RowIndex];
                txtName.Text = row.Cells[1].Value.ToString();
                txtPhone.Text = row.Cells[2].Value.ToString();
                comGender.Text = row.Cells[3].Value.ToString();
                Key = Convert.ToInt32(row.Cells[0].Value.ToString());
            }
            else
            {
                MessageBox.Show("No row selected.");
                Key = 0;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select a Tenant!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from TenantTbl where TenId=@TKey", Con);
                    cmd.Parameters.AddWithValue("@TKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tenant Deleted!!!");
                    Con.Close();
                    ResetData();
                    ShowTenants();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text == ""  &&  comGender.SelectedIndex == -1 && txtPhone.Text == "")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update TenantTbl set tenName=@TN, tenPhone=@TP, tenGender=@TG where TenId=@TKey", Con);
                    cmd.Parameters.AddWithValue("@TN", txtName.Text);
                    cmd.Parameters.AddWithValue("@TP", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@TG", comGender.Text);
                    cmd.Parameters.AddWithValue("@TKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tenant Updated!!!");
                    Con.Close();
                    ResetData();
                    ShowTenants();

                }
                catch(Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if(userRole.Role == "admin")
            {
                new Dashboard().Show();
                this.Hide();
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (userRole.Role == "admin")
            {
                new Dashboard().Show();
                this.Hide();
            }

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
    }
}

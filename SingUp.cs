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

    public partial class SingUp : Form
    {
        SqlConnection Con = new SqlConnection("Data Source=DIINSAALOW\\MSSQLSERVER01;Initial Catalog=HouseRental;Integrated Security=True");
        public SingUp()
        {
            InitializeComponent();
        }

        private void txtLogin_Click(object sender, EventArgs e)
        {
            SignIn obj = new SignIn();
            obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private Boolean isUsernameExist(string username)
        {
            Con.Open();
            string query = "select * from userstbl where username = '" + username + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                Con.Close();
                return true;
            }
            else
            {
                Con.Close();
                return false;
            }
        }

        private void txtSignUp_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("All fields are required!");
            }else if(txtComfirmPass.Text != txtPassword.Text) 
            {
                MessageBox.Show("Passwords do not match.");
            }
            else
            {
                if (isUsernameExist(txtUsername.Text))
                {
                    MessageBox.Show("Username already exists");

                }
                else
                {
                    Con.Open();
                    string query = "insert into userstbl (username,password) values(@UN,@PA)";
                    SqlCommand cmd = new SqlCommand(query, Con);

                    cmd.Parameters.AddWithValue("@UN", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@PA", txtPassword.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    MessageBox.Show("User registered successfully");

                    new Tenents().Show();
                    this.Hide();

                    Con.Close();
                }

            }
        }
    }
}

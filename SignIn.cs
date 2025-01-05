using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental_Management
{
    public partial class SignIn : Form
    {
        SqlConnection Con = new SqlConnection("Data Source=DIINSAALOW\\MSSQLSERVER01;Initial Catalog=HouseRental;Integrated Security=True");

        public SignIn()
        {
            InitializeComponent();
        }

        private void txtLogin_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void txtLogin_Click_1(object sender, EventArgs e)
        {
            if(txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("All fields are required!");
            }
            else
            {
                Con.Open();
                string query = "select * from userstbl where username = '" + txtUsername.Text + "' and password = '" + txtPassword.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    
                    //Assign role object to the role of the user 
                    while (rdr.Read())
                    {
                        string role = rdr["role"].ToString();
                        UserRole userRole = new UserRole();
                        userRole.Role = role;
                        if (userRole.Role == "admin")
                        {
                            new Dashboard().Show();
                            this.Hide();
                        }
                        else
                        {
                            new Tenents().Show();
                            this.Hide();
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");

                }
                Con.Close();
            }
        }

        private void txtRegister_Click(object sender, EventArgs e)
        {
            new SingUp().Show();
            this.Hide();

        }
    }
}

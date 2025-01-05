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
using System.Xml.Linq;

namespace Rental_Management
{
    public partial class Landlords : Form
    {
        SqlConnection Con = new SqlConnection("Data Source=DIINSAALOW\\MSSQLSERVER01;Initial Catalog=HouseRental;Integrated Security=True");
        public Landlords()
        {
            InitializeComponent();
            ShowLandlord();
        }

        private void ShowLandlord()
        {
            Con.Open();
            string Query = "Select * from landlordtbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            landlordGridView.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void ResetData()
        {
            textLName.Text = string.Empty;
            textLPhone.Text = string.Empty;
            comLGender.SelectedIndex = -1;
            comLGender.Text = "";
        }

        private void btnLAdd_Click(object sender, EventArgs e)
        {
            if (textLName.Text == "" || comLGender.SelectedIndex == -1 || textLPhone.Text == "")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into landlordtbl(llnam, llphone, llgender) values(@LN, @LP, @LG)", Con);
                    cmd.Parameters.AddWithValue("@LN", textLName.Text);
                    cmd.Parameters.AddWithValue("LP", textLPhone.Text);
                    cmd.Parameters.AddWithValue("@LG", comLGender.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Landlord Added!!!");
                    Con.Close();
                    ResetData();
                    ShowLandlord();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void btnLUpdate_Click(object sender, EventArgs e)
        {
            if (textLName.Text == "" && comLGender.SelectedIndex == -1 && textLPhone.Text == "")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update landlordtbl set llnam=@LN, llphone=@LP, llgender=@LG where llid=@LLK", Con);
                    cmd.Parameters.AddWithValue("@LN", textLName.Text);
                    cmd.Parameters.AddWithValue("LP", textLPhone.Text);
                    cmd.Parameters.AddWithValue("@LG", comLGender.Text);
                    cmd.Parameters.AddWithValue("@LLK", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Landlord Updated!!!");
                    Con.Close();
                    ResetData();
                    ShowLandlord();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int Key = 0;
        private void landlordGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = landlordGridView.Rows[e.RowIndex];
                textLName.Text = row.Cells[1].Value.ToString();
                textLPhone.Text = row.Cells[2].Value.ToString();
                comLGender.Text = row.Cells[3].Value.ToString();
                Key = Convert.ToInt32(row.Cells[0].Value.ToString());
            }
            else
            {
                MessageBox.Show("No row selected.");
                Key = 0;
            }
        }

        private void btnLDelete_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select a Landlord!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from landlordtbl where LLId=@LLkey", Con);
                    cmd.Parameters.AddWithValue("@LLkey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Landlord Deleted!!!");
                    Con.Close();
                    ResetData();
                    ShowLandlord();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

 
        

        private void label15_Click(object sender, EventArgs e)
        {
            new Dashboard().Show();
            this.Hide();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            new Dashboard().Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
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

        private void label9_Click(object sender, EventArgs e)
        {
            new Rents().Show();
            this.Close();

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            new Rents().Show();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            new Category().Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            new Category().Show();
            this.Hide();
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

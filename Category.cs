using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Rental_Management
{
    public partial class Category : Form
    {
        SqlConnection Con = new SqlConnection("Data Source=DIINSAALOW\\MSSQLSERVER01;Initial Catalog=HouseRental;Integrated Security=True");
        public Category()
        {
            InitializeComponent();
            ShowGategory();
        }

        private void ShowGategory()
        {
            Con.Open();
            string Query = "Select * from CategoryTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            categoryGridView.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void ResetData()
        {
            textCName.Text = "";
            textCDes.Text = "";
        }

        private void btnGAdd_Click(object sender, EventArgs e)
        {
            if(textCName.Text == "" || textCDes.Text == "")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                Con.Open();
                string Query = "Insert into CategoryTbl values('" + textCName.Text + "','" + textCDes.Text + "')";
                SqlCommand cmd = new SqlCommand(Query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category Added Successfully");
                Con.Close();
                ResetData();
                ShowGategory();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

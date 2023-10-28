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

namespace _1st_year_Final_Project
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\yevin\Documents\inventory system databse.mdf"";Integrated Security=True;Connect Timeout=30");

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            try
            {
                string usernameOrEmail = txtUsername.Text;
                string password = txtPassword.Text;

                string query = "SELECT COUNT(*) FROM LoginTable WHERE (username = @usernameOrEmail OR email = @usernameOrEmail) AND password = @password";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@usernameOrEmail", usernameOrEmail);
                cmd.Parameters.AddWithValue("@password", password);

                connection.Open();
                int count = (int)cmd.ExecuteScalar();
                connection.Close();
                if (count > 0)
                {
                    MessageBox.Show("Login successful");

                    dashboard dashboardForm = new dashboard();
                    dashboardForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            register ragisterpage = new register();

            ragisterpage.Show();
            this.Hide();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

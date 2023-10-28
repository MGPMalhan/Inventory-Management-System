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
using System.Text.RegularExpressions;
using System.Security.Policy;

namespace _1st_year_Final_Project
{

    public partial class register : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\yevin\Documents\inventory system databse.mdf"";Integrated Security=True;Connect Timeout=30");

        public register()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form1 back = new Form1();
            back.Show();
            this.Hide();
        }

        private bool IsValidEmail(string email)
        {
            // Regular expression pattern for email validation
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(email, pattern);
        }

        private bool IsUsernameExists(string username)
        {

            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\yevin\Documents\inventory system databse.mdf"";Integrated Security=True;Connect Timeout=30");

            string query = "SELECT COUNT(*) FROM LoginTable WHERE username = @Username";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                connection.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }



        private void btnSignup_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\yevin\Documents\inventory system databse.mdf"";Integrated Security=True;Connect Timeout=30");

            try
            {
                string username = txtUsernameBox.Text;

                if (IsUsernameExists(username))
                {
                    MessageBox.Show("Username already exists");
                    return;
                }

                string email = txtEmailBox.Text;

                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Invalid email format");
                    return;
                }

                // Rest of the code for inserting into the database

                string query = "INSERT INTO LoginTable (name, username, password, email) VALUES (@Name, @Username, @Password, @Email)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", txtNameBox.Text);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", txtPasswordBox.Text);
                    cmd.Parameters.AddWithValue("@Email", email);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Registered");
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
    }
}

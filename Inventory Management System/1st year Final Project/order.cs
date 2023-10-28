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

namespace _1st_year_Final_Project
{
    public partial class order : Form
    {
        public order()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dashboard dashpage = new dashboard();
            dashpage.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            update updatepage = new update();

            updatepage.Show();
            this.Hide();
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            Form1 loginpage = new Form1();
            loginpage.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete deletepage = new delete();
            deletepage.Show();
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //text box clear
            txtOrderCode.Text = "";
            txtPriceOrder.Text = "";
            
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\yevin\Documents\inventory system databse.mdf"";Integrated Security=True;Connect Timeout=30");

            try
            {
                //data Display
                string query2 = "SELECT * FROM OrderTable";
                SqlDataAdapter dataadapter = new SqlDataAdapter(query2, connection);

                DataSet dataset = new DataSet();
                dataadapter.Fill(dataset, "OrderTable");

                DGV.DataSource = dataset.Tables["OrderTable"];

                //data editibility 
                DGV.Columns["item_code"].ReadOnly = true;
                DGV.Columns["item_name"].ReadOnly = true;
                DGV.Columns["item_price"].ReadOnly = true;
                DGV.Columns["item_type"].ReadOnly = true;
            }
            catch (Exception two)
            {
                MessageBox.Show(two.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemoveOrder_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\yevin\Documents\inventory system databse.mdf"";Integrated Security=True;Connect Timeout=30");

            try
            {
                string delete = "DELETE FROM OrderTable WHERE order_number='" + txtOrderCode.Text + "' ";

                SqlCommand cmd = new SqlCommand(delete, connection);

                //delete items


                connection.Open();

                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Order Removed Successfully!");
            }
            catch (Exception five)
            {
                MessageBox.Show(five.Message);
            }
            finally
            {

                //data Display
                string query2 = "SELECT * FROM OrderTable";
                SqlDataAdapter dataadapter = new SqlDataAdapter(query2, connection);

                DataSet dataset = new DataSet();
                dataadapter.Fill(dataset, "OrderTable");

                DGV.DataSource = dataset.Tables["OrderTable"];

                //data editibility 
                DGV.Columns["order_number"].ReadOnly = true;
                DGV.Columns["order_price"].ReadOnly = true;
                DGV.Columns["address"].ReadOnly = true;
                DGV.Columns["customer_name"].ReadOnly = true;

                connection.Close();
            }
        }

        private void btnAddOrders_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\yevin\Documents\inventory system databse.mdf"";Integrated Security=True;Connect Timeout=30");


            try
            {
                //data insertion
                string query = "INSERT INTO ItemTable (order_number,order_price,address,customer_name) VALUES('" + txtOrderCode.Text + "','" + txtPriceOrder.Text + "')";


                SqlCommand cmd = new SqlCommand(query, connection);


                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item Code Added Successfull!");
            }
            catch (Exception one)
            {
                MessageBox.Show(one.Message);
            }
            finally
            {
                //data Display
                string query2 = "SELECT * FROM OrderTable";
                SqlDataAdapter dataadapter = new SqlDataAdapter(query2, connection);

                DataSet dataset = new DataSet();
                dataadapter.Fill(dataset, "OrderTable");

                DGV.DataSource = dataset.Tables["OrderTable"];

                //data editibility 
                DGV.Columns["order_number"].ReadOnly = true;
                DGV.Columns["order_price"].ReadOnly = true;
                DGV.Columns["address"].ReadOnly = true;
                DGV.Columns["customer_name"].ReadOnly = true;

                connection.Close();
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {

        }
    }
}

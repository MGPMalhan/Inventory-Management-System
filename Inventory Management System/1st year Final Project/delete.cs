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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace _1st_year_Final_Project
{
    public partial class delete : Form
    {
        public delete()
        {
            InitializeComponent();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dashboard addpage = new dashboard();

            addpage.Show();
            this.Hide();
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            update updatepage = new update();

            updatepage.Show();
            this.Hide();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            order orderpage = new order();
            orderpage.Show();
            this.Hide();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //click event
            try
            {

                
                txtItemCode.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                txtItemName.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                txtItemPrice.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                txtItemType.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();

                //read only text box --> Item Code
                txtItemCode.ReadOnly = true;
                txtItemName.ReadOnly = true;
                txtItemPrice.ReadOnly = true;
                txtItemType.ReadOnly = true;
            }
            catch (Exception three)
            {
                MessageBox.Show(three.Message);
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            
           
           
        }

        private void btnItemDisplay_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDeleteItem_Click_1(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\yevin\Documents\inventory system databse.mdf"";Integrated Security=True;Connect Timeout=30");

            try
            {
                string delete = "DELETE FROM ItemTable WHERE item_code='"+txtItemCode.Text+"' ";

                SqlCommand cmd = new SqlCommand(delete, connection);

                //delete items


                connection.Open();

                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Record Deleted Successfully!");
            }
            catch (Exception five)
            {
                MessageBox.Show(five.Message);
            }
            finally
            {
              
                //data Display
                string query2 = "SELECT * FROM ItemTable";
                SqlDataAdapter dataadapter = new SqlDataAdapter(query2, connection);

                DataSet dataset = new DataSet();
                dataadapter.Fill(dataset, "ItemTable");

                dataGridView2.DataSource = dataset.Tables["ItemTable"];

                //data editibility 
                dataGridView2.Columns["item_code"].ReadOnly = true;
                dataGridView2.Columns["item_name"].ReadOnly = true;
                dataGridView2.Columns["item_price"].ReadOnly = true;
                dataGridView2.Columns["item_type"].ReadOnly = true;

                connection.Close();
            }
        }

        private void btnItemDisplay_Click_1(object sender, EventArgs e)
        {
            //display
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\yevin\Documents\inventory system databse.mdf"";Integrated Security=True;Connect Timeout=30");


            try
            {
                
                //data Display
                string query2 = "SELECT * FROM ItemTable";
                SqlDataAdapter dataadapter = new SqlDataAdapter(query2, connection);

                DataSet dataset = new DataSet();
                dataadapter.Fill(dataset, "ItemTable");

                dataGridView2.DataSource = dataset.Tables["ItemTable"];

                //data editibility 
                dataGridView2.Columns["item_code"].ReadOnly = true;
                dataGridView2.Columns["item_name"].ReadOnly = true;
                dataGridView2.Columns["item_price"].ReadOnly = true;
                dataGridView2.Columns["item_type"].ReadOnly = true;
            }
            catch(Exception six)
            {
                MessageBox.Show(six.Message);
            }
            finally
            {
                connection.Close();
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //text box clear
            txtItemCode.Text = "";
            txtItemName.Text = "";
            txtItemPrice.Text = "";
            txtItemType.Text = "";
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

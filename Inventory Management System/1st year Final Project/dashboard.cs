using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace _1st_year_Final_Project
{
    public partial class dashboard : Form
    {

        public dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            this.Hide();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete deletepage = new delete();
            deletepage.Show();
            this.Hide();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            order orderpage = new order();
            orderpage.Show();
            this.Hide();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            update updatepage = new update();

            updatepage.Show();
            this.Hide();

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {
            
            
          
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\yevin\Documents\inventory system databse.mdf"";Integrated Security=True;Connect Timeout=30");


            try
            {
                //data insertion
                string query = "INSERT INTO ItemTable (item_code,item_name,item_price,item_type) VALUES('" + txtItemCode.Text + "','" + txtItemName.Text + "','" + txtItemPrice.Text + "','" + txtItemType.Text + "')";
                

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
                string query2 = "SELECT * FROM ItemTable";
                SqlDataAdapter dataadapter = new SqlDataAdapter(query2, connection);

                DataSet dataset = new DataSet();
                dataadapter.Fill(dataset, "ItemTable");

                DGV.DataSource = dataset.Tables["ItemTable"];

                //data editibility 
                DGV.Columns["item_code"].ReadOnly = true;
                DGV.Columns["item_name"].ReadOnly = true;
                DGV.Columns["item_price"].ReadOnly = true;
                DGV.Columns["item_type"].ReadOnly = true;

                connection.Close();
            }
            

           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\yevin\Documents\inventory system databse.mdf"";Integrated Security=True;Connect Timeout=30");

            try
            {
                //data Display
                string query2 = "SELECT * FROM ItemTable";
                SqlDataAdapter dataadapter = new SqlDataAdapter(query2, connection);

                DataSet dataset = new DataSet();
                dataadapter.Fill(dataset, "ItemTable");

                DGV.DataSource = dataset.Tables["ItemTable"];

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

        private void btnClear_Click(object sender, EventArgs e)
        {
            //text box clear
            txtItemCode.Text = "";
            txtItemName.Text = "";
            txtItemPrice.Text = "";
            txtItemType.Text = "";
        }

        private void dashboard_Load(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtItemPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

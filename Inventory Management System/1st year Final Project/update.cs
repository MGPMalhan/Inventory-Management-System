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
using TheArtOfDevHtmlRenderer.Adapters;

namespace _1st_year_Final_Project
{
    public partial class update : Form
    {
        public update()
        {
            InitializeComponent();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            dashboard additemspage = new dashboard();

            additemspage.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            delete deletapage = new delete();

            deletapage.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            order orderpage = new order();

            orderpage.Show();
            this.Hide();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            //update
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\yevin\Documents\inventory system databse.mdf"";Integrated Security=True;Connect Timeout=30");
            
            

            try
            {
                
                SqlCommand command = new SqlCommand("UPDATE ItemTable SET item_code = @item_code , item_name = @item_name , item_price = @item_price , item_type = @item_type", connection);

                connection.Open();
                command.Parameters.AddWithValue("@item_code", txtItemCode.Text);
                command.Parameters.AddWithValue("@item_name", txtItemName.Text);
                command.Parameters.AddWithValue("@item_price", txtItemPrice.Text);
                command.Parameters.AddWithValue("@item_type", txtItemType.Text);

                
                command.ExecuteNonQuery();
                //data Display
                string query2 = "SELECT * FROM ItemTable";
                SqlDataAdapter dataadapter = new SqlDataAdapter(query2, connection);

                DataSet dataset = new DataSet();
                dataadapter.Fill(dataset, "ItemTable");

                dataGridView1.DataSource = dataset.Tables["ItemTable"];

                //data editibility 
                dataGridView1.Columns["item_code"].ReadOnly = true;
                dataGridView1.Columns["item_name"].ReadOnly = true;
                dataGridView1.Columns["item_price"].ReadOnly = true;
                dataGridView1.Columns["item_type"].ReadOnly = true;

                SqlCommandBuilder builder = new SqlCommandBuilder(dataadapter);
                dataadapter.Update(dataset.Tables["Itemtable"]);
                MessageBox.Show("Item Data Edited Successfully! ");
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);                
            }
            finally
            {
                //data Display
                string query2 = "SELECT * FROM ItemTable";
                SqlDataAdapter dataadapter = new SqlDataAdapter(query2, connection);

                DataSet dataset = new DataSet();
                dataadapter.Fill(dataset, "ItemTable");

                dataGridView1.DataSource = dataset.Tables["ItemTable"];

                //data editibility 
                dataGridView1.Columns["item_code"].ReadOnly = true;
                dataGridView1.Columns["item_name"].ReadOnly = true;
                dataGridView1.Columns["item_price"].ReadOnly = true;
                dataGridView1.Columns["item_type"].ReadOnly = true;

                connection.Close();
            }

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnItemDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\yevin\Documents\inventory system databse.mdf"";Integrated Security=True;Connect Timeout=30");

                //data Display
                string query2 = "SELECT * FROM ItemTable";
                SqlDataAdapter dataadapter = new SqlDataAdapter(query2, connection);

                DataSet dataset = new DataSet();
                dataadapter.Fill(dataset, "ItemTable");

                dataGridView1.DataSource = dataset.Tables["ItemTable"];

                //data editibility 
                dataGridView1.Columns["item_code"].ReadOnly = true;
                dataGridView1.Columns["item_name"].ReadOnly = true;
                dataGridView1.Columns["item_price"].ReadOnly = true;
                dataGridView1.Columns["item_type"].ReadOnly = true;

                SqlCommandBuilder builder = new SqlCommandBuilder(dataadapter);
                dataadapter.Update(dataset.Tables["Itemtable"]);
            }
            catch(Exception four)
            {
                MessageBox.Show(four.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                    txtCode.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    txtItemCode.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    txtItemName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    txtItemPrice.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    txtItemType.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                
                //read only text box --> Item Code
                txtCode.ReadOnly = true;
            }
            catch (Exception three)
            {
                MessageBox.Show(three.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //text box clear
            txtCode.Text = "";
            txtItemCode.Text = "";
            txtItemName.Text = "";
            txtItemPrice.Text = "";
            txtItemType.Text = "";
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

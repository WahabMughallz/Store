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

namespace Stock
{
    public partial class products : Form
    {
        public products()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void products_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=EMB3;Initial Catalog=Stock;Integrated Security=True");
            // insart logic
            con.Open();
            bool Status = false;
            if (comboBox1.SelectedIndex == 0)
            {
                Status = true;
            }
            else
            {
                Status = false;
            }
            
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [Stock].[dbo].[Products]([ProductCode],[ProductName],[ProductStatus])
            VALUES
           ('"+textBox1.Text+ "','" + textBox2.Text + "','" + Status + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();

            // Reading Data
            LoadData();
        }

        private bool ifProductsExists()
        {
            return true;
        }
        public void LoadData()
        {
            SqlConnection con = new SqlConnection("Data Source=EMB3;Initial Catalog=Stock;Integrated Security=True");
            SqlDataAdapter SDA = new SqlDataAdapter("Select * From [Stock].[dbo].[Products]", con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["ProductCode"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["ProductName"].ToString();
                if ((bool)item["ProductStatus"])
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Active";
                }
                else
                {

                    dataGridView1.Rows[n].Cells[2].Value = "Deactive";
                }
             }
         }
        

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            if (dataGridView1.SelectedRows[0].Cells[2].Value.ToString() == "Active")
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {

                comboBox1.SelectedIndex = 1;
            }
            comboBox1.SelectedText = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }
    }
}

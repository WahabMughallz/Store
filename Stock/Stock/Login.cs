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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //to-do: Check login UserName and password
            SqlConnection con = new SqlConnection("Data Source=EMB3;Initial Catalog=Stock;Integrated Security=True");
            SqlDataAdapter SDA = new SqlDataAdapter(@"SELECT * FROM[Stock].[dbo].[Login] where UserName = '"+textBox1.Text+"' and password = '"+textBox2.Text+"'", con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                this.Hide();
                StockMaincs main = new StockMaincs();
                main.Show();

            }
            else
                {
                    MessageBox.Show("Invalid User Name or Password. ", "Login Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                button1_Click(sender, e);
                }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}

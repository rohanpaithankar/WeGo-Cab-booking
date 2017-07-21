using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WeGo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
          /*  try
            {
                MySqlConnection cn = new MySqlConnection("server=localhost;user id=root;database=projectdatabase;pwd=rohan!@#");
                cn.Open();


            }
            catch (Exception ex)
            { MessageBox.Show("Connection failed\n" + ex.Message); }*/
            menu a = new menu();
            a.Show();
            this.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            //this.TopMost = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin a = new Admin();
            a.Show();
            this.Hide();
        }
    }
}

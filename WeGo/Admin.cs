using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeGo
{
    public partial class Admin : Form
    {
        MySqlConnection cn = new MySqlConnection("server=localhost;user id=root;database=projectdatabase;pwd=rohan!@#");

        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("Enter all fields");
            }
            else
            {
                try
                {
                    cn.Open();
                    MySqlCommand selectCommand = new MySqlCommand("select aid from projectdatabase.admin where aname='" + textBox1.Text + "'and apass='" + textBox2.Text + "';", cn);
                    MySqlDataReader myreader;
                    //int rid = 0;
                    myreader = selectCommand.ExecuteReader();
                    int count = 0;
                    while (myreader.Read())
                    {
                        //rid = myreader.GetInt32(0);
                        count += 1;
                        //MessageBox.Show(rid.ToString());
                    }
                    if (count == 1)
                    {
                        MessageBox.Show("Username & Password found in database...WELCOME");
                        adminmod bk = new adminmod();

                        bk.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("WRONG USERNAME/Password");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            cn.Close();
        }
    }
}

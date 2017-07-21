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
using System.Text.RegularExpressions;
namespace WeGo
{
    public partial class LoginUser : Form
    {

        String[] a = new String[] { "smwm", "W68HP" };
        Random rnd = new Random();
        int index;
        //static int i = 0;
        MySqlConnection cn = new MySqlConnection("server=localhost;user id=root;database=projectdatabase;pwd=rohan!@#");
        
        public LoginUser()
        {
            
               
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LoginUser_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            //this.TopMost = true;
            index= rnd.Next(0, 1);
            pictureBox2.Image = imageList1.Images[index];
        }
        private void pictureBox1_Load(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals(""))
            {
                MessageBox.Show("Enter all fields");
            }
            else
            {
                try
                {
                    cn.Open();
                    MySqlCommand selectCommand = new MySqlCommand("select uid from projectdatabase.user where uname='" + textBox1.Text + "'and pass='" + textBox2.Text + "';", cn);
                    MySqlDataReader myreader;
                    int rid = 0; 
                    myreader = selectCommand.ExecuteReader();
                    int count = 0;
                    while (myreader.Read())
                    {
                        rid = myreader.GetInt32(0);
                        count += 1;
                    //MessageBox.Show(rid.ToString());
                    }
                    if (count == 1 && textBox3.Text.Equals(a[index]))
                    {
                        MessageBox.Show("Username & Password found in database");
                        BookingPage bk = new BookingPage(rid);
                        
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

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            menu f = new menu();
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // int uid=0; 
            char g=comboBox2.Text[0];
            cn.Open();
            String emailString = textBox10.Text;
            bool isEmail = Regex.IsMatch(emailString, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (isEmail == true)
            {
                String insquery1 = "insert into projectdatabase.user(uname,pass,fname,lname,addr,gender,uemail,uphone) values('" + textBox6.Text + "','" + textBox5.Text + "','" + textBox8.Text + "','" + textBox7.Text + "','" + richTextBox1.Text + "','" + g + "','"+textBox10.Text+"',"+textBox4.Text+");";


                try
                {
                    MySqlCommand insertCommand1 = new MySqlCommand(insquery1, cn);
                    if (insertCommand1.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("You have been registered.\nAn email has been sent to you.\nLogin from the Login Tab.");
                    }
                    else
                        MessageBox.Show("Not inserted");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {             
                MessageBox.Show("Invalid ID!\nEnter again");
            }
            cn.Close();
            
        }
    }
}

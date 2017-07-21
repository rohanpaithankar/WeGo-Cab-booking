using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WeGo
{
    public partial class BookingPage : Form
    {
        MySqlConnection cn = new MySqlConnection("server=localhost;user id=root;database=projectdatabase;pwd=rohan!@#");
        public BookingPage()
        {
            InitializeComponent();
            dateTimePicker2.CustomFormat = "hh mm ss";
        }
        public BookingPage(int id)
        {
            InitializeComponent();
            label9.Text = id.ToString();
        }

        private void BookingPage_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            //this.TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            //String toemail = "Select uemail from projectdatabase.user where uid=" + label9.Text;
           cn.Open();
           int cid=0;
           MySqlCommand selectCommand = new MySqlCommand("select car_id from car where car_type='" + comboBox1.Text[0] + "' and capacity=" + int.Parse(passenger.Text) +";", cn);
           MySqlDataReader reader;
           reader = selectCommand.ExecuteReader();
           while (reader.Read())
           {
               cid = reader.GetInt32(0);
           }
           reader.Close();
            //String getcarid="select car_id from car where car_type='"+comboBox1.Text[0]+"' and capacity="+int.Parse(passenger.Text)+";";
           String insquery1 = "insert into projectdatabase.bookings(b_carid,b_uid,pickup_loc,pickup_date,pickup_time,numpass,destination) values("+cid+","+int.Parse(label9.Text)+",'" + pickloc.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") +"','" + dateTimePicker2.Value.ToString("hh:mm:ss") + "'," + int.Parse(passenger.Text) + ",'" + destloc.Text + "');";
          
            try
                {
                     MySqlCommand insertbooking=new MySqlCommand(insquery1,cn);
                    if (insertbooking.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Entered");
                    }
                    else
                        MessageBox.Show("Not inserted");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("aaroh.mathur@gmail.com");
                message.To.Add(new MailAddress("aaroh.mathur@gmail.com"));
                message.Subject = "Test";
                message.Body = "Content";

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("aaroh.mathur@gmail.com", "ritusaharia");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("err: " + ex.Message);
            }
            MessageBox.Show("chksdbcsdhcbs");
            cn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[comboBox1.SelectedIndex];


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            LoginUser lu = new LoginUser();
            this.Hide();
            lu.Show();
        }
        
    }
}

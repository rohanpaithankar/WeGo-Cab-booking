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
    public partial class adminmod : Form
    {
        MySqlConnection cn = new MySqlConnection("server=localhost;user id=root;database=projectdatabase;pwd=rohan!@#");

        public adminmod()
        {
            InitializeComponent();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cn.Open();
            MySqlDataAdapter selectCommand = new MySqlDataAdapter("select * from bookings natural join car as a where car_id=b_carid;", cn);
            try
            {
                DataSet ds = new DataSet();
                selectCommand.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cn.Open();
            MySqlDataAdapter selectCommand = new MySqlDataAdapter("select * from car;", cn);
            try
            {
                DataSet ds = new DataSet();
                selectCommand.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cn.Open();
            MySqlDataAdapter selectCommand = new MySqlDataAdapter("select * from driver;", cn);
            try
            {
                DataSet ds = new DataSet();
                selectCommand.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cn.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Admin a = new Admin();
            this.Hide();
            a.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cn.Open();
            MySqlDataAdapter selectCommand = new MySqlDataAdapter("select * from assigned", cn);
            try
            {
                DataSet ds = new DataSet();
                selectCommand.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cn.Open();
            MySqlDataAdapter selectCommand = new MySqlDataAdapter("select * from assigned", cn);
            try
            {
                DataSet ds = new DataSet();
                selectCommand.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cn.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void adminmod_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectdatabaseDataSet.driver' table. You can move, or remove it, as needed.
            this.driverTableAdapter.Fill(this.projectdatabaseDataSet.driver);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            cn.Open();
            MySqlDataAdapter selectCommand = new MySqlDataAdapter("select * from driver;", cn);
            try
            {
                DataSet ds = new DataSet();
                selectCommand.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cn.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            cn.Open();
            MySqlDataAdapter selectCommand = new MySqlDataAdapter("select * from bookings;", cn);
            try
            {
                DataSet ds = new DataSet();
                selectCommand.Fill(ds);
                dataGridView3.DataSource = ds.Tables[0];



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            cn.Open();

            String insquery1 = "insert into assigned values(" + int.Parse(textBox14.Text) + "," + int.Parse(textBox15.Text)+");";


                try
                {
                    MySqlCommand insertCommand1 = new MySqlCommand(insquery1, cn);
                    if (insertCommand1.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Driver Assigned");
                    }
                    else
                        MessageBox.Show("Not assigned");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
           
            
            cn.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            cn.Open();

            String insquery1 = "update driver set d_status='o' where dri_id in(select a_did from assigned)";


            try
            {
                MySqlCommand insertCommand1 = new MySqlCommand(insquery1, cn);
                if (insertCommand1.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Driver updated");
                }
                else
                    MessageBox.Show("Not updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            cn.Close();
        }
    }
}

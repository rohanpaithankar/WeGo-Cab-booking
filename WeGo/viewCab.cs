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
    public partial class viewCab : Form
    {
        MySqlConnection cn = new MySqlConnection("server=localhost;user id=root;database=projectdatabase;pwd=rohan!@#");

        public viewCab()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            menu m = new menu();
            m.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            MySqlDataAdapter selectCommand = new MySqlDataAdapter("select * from car where capacity<="+int.Parse(comboBox2.Text)+" and car_type='"+comboBox1.Text+"';", cn);
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Клиент
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client s = new ServiceReference1.Service1Client("NetTcpBinding_IService1");
            DataSet ds = s.GetData();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Update();

            DataSet ds1 = s.Fill();
            comboBox1.DataSource = ds1.Tables[0];
            comboBox1.DisplayMember = "Название книги";
            comboBox1.ValueMember = "Название книги";

        }

        private void Button_add_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client s = new ServiceReference1.Service1Client("NetTcpBinding_IService1");

            s.NewRec(textBox1.Text, comboBox1.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            Form1_Load(sender, e);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PROJEKANN.Usercontrol
{
    public partial class register : UserControl
    {
        private Form1 mainform;
        public register(Form1 form1)
        {
            InitializeComponent();
            mainform = form1;
            pilihan_role();
        }

        private void pilihan_role()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Distributor");
            comboBox1.Items.Add("Nelayan");
        }
        private void dashboard_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nama = textBox3.Text.Trim();
            string telp = textBox1.Text.Trim();
            string alamat = textBox4.Text.Trim();
            string username = textBox5.Text.Trim();
            string password = textBox6.Text.Trim();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

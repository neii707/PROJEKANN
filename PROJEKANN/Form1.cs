using System;
using System.Windows.Forms;
using PROJEKANN.Usercontrol;

namespace PROJEKANN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            login halamanLogin = new login(this);
            this.ClientSize = halamanLogin.Size;
            TampilkanHalaman(halamanLogin);
        }

        public void TampilkanHalaman(UserControl halamanBaru)
        {
            if (halamanBaru is PROJEKANN.Usercontrol.dashboard_admin)
            {
                this.ClientSize = new System.Drawing.Size(950, 600);
                this.CenterToScreen(); 
            }

            panel1.Controls.Clear();
            halamanBaru.Dock = DockStyle.Fill; 
            panel1.Controls.Add(halamanBaru);
        }
    }
}
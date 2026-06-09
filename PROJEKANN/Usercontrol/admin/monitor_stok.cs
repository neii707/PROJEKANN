using System;
using System.Windows.Forms;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using PROJEKANN.controller; 
using PROJEKANN.model;      

namespace PROJEKANN.Usercontrol.admin
{
    public partial class monitor_stok : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;
        private ControllerMonitorStok _controller = new ControllerMonitorStok();

        public monitor_stok(Form1 form1, string username)
        {
            InitializeComponent();
            this.mainForm = form1;
            this.userLoginAktif = username;

            SegarkanDataTampilan();
        }

        private void SegarkanDataTampilan()
        {
            ModelMonitorStok data = _controller.AmbilDataMonitorStok(this.userLoginAktif);
            label5.Text = data.NamaUserReal;
            cartesianChart1.Series = new ISeries[]
            {
                new LineSeries<int>
                {
                    Name = "Grade A",
                    Values = data.DataGradeA,
                    GeometrySize = 10
                },
                new LineSeries<int>
                {
                    Name = "Grade B",
                    Values = data.DataGradeB,
                    GeometrySize = 10
                },
                new LineSeries<int>
                {
                    Name = "Grade C",
                    Values = data.DataGradeC,
                    GeometrySize = 10
                }
            };

            cartesianChart1.XAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Bulan",
                    Labels = data.LabelBulan.ToArray()
                }
            };

            cartesianChart1.YAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Jumlah Stok"
                }
            };
        }

        private void GantiHalamanFitur(UserControl ucBaru)
        {
            panel1.Controls.Clear();
            ucBaru.Dock = DockStyle.Fill;
            panel1.Controls.Add(ucBaru);
            ucBaru.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.dashboard_admin(this.mainForm, this.userLoginAktif));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.admin.kelola_akun(this.mainForm, this.userLoginAktif));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.admin.kelola_demand(this.mainForm, this.userLoginAktif));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.admin.monitor_stok(this.mainForm, this.userLoginAktif));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.admin.monitor_transaksi(this.mainForm, this.userLoginAktif));
        }

        private void keluarbutton_dashboard_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show(
                "Apakah Anda yakin ingin keluar dari program?",
                "Konfirmasi Keluar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (konfirmasi == DialogResult.Yes)
            {
                GantiHalamanFitur(new PROJEKANN.Usercontrol.login((Form1)this.FindForm()));
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void cartesianChart1_Load(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
    }
}
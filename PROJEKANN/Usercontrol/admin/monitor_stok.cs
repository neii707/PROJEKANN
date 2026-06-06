using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PROJEKANN.Usercontrol.admin
{
    public partial class monitor_stok : UserControl
    {
        public monitor_stok()
        {
            InitializeComponent();
            tampilkanchart();
        }

        private void GantiHalamanFitur(UserControl ucBaru)
        {
            panel1.Controls.Clear();
            ucBaru.Dock = DockStyle.Fill;
            panel1.Controls.Add(ucBaru);
            ucBaru.BringToFront();
        }

        private void tampilkanchart()
        {
            List<int> dataGradeA = new List<int>();
            List<int> dataGradeB = new List<int>();
            List<int> dataGradeC = new List<int>();
            List<string> labelBulan = new List<string>();

            try
            {
                using (NpgsqlConnection conn = PROJEKANN.database.DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM v_grafik_line_stok";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        using (NpgsqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                string bulan = dr["bulan"].ToString().Trim();
                                string grade = dr["grade"].ToString().Trim().ToUpper();
                                int total = Convert.ToInt32(dr["stok"]);

                                if (!labelBulan.Contains(bulan))
                                {
                                    labelBulan.Add(bulan);
                                }

                                if (grade == "A")
                                {
                                    dataGradeA.Add(total);
                                }
                                else if (grade == "B")
                                {
                                    dataGradeB.Add(total);
                                }
                                else if (grade == "C")
                                {
                                    dataGradeC.Add(total);
                                }
                            }
                        }
                    }
                }

                cartesianChart1.Series = new ISeries[]
                {
                    new LineSeries<int>
                    {
                        Name = "Grade A",
                        Values = dataGradeA,
                        GeometrySize = 10
                    },
                    new LineSeries<int>
                    {
                        Name = "Grade B",
                        Values = dataGradeB,
                        GeometrySize = 10
                    },
                    new LineSeries<int>
                    {
                        Name = "Grade C",
                        Values = dataGradeC,
                        GeometrySize = 10
                    }
                };

                cartesianChart1.XAxes = new Axis[]
                {
                    new Axis
                    {
                        Name = "Bulan",
                        Labels = labelBulan.ToArray()
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
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat multi-line chart: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.admin.monitor_transaksi());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.admin.monitor_stok());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.admin.kelola_akun());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.dashboard_admin());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.admin.kelola_demand());
        }

        private void cartesianChart1_Load(object sender, EventArgs e)
        {

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
    }
}

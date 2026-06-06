using Npgsql;
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
            comboBox1.Items.Add("DISTRIBUTOR");
            comboBox1.Items.Add("NELAYAN");
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
            string roleTerpilih = comboBox1.SelectedItem != null ? comboBox1.SelectedItem.ToString() : "";

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(telp) || string.IsNullOrEmpty(alamat))
            {
                MessageBox.Show("Data tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string statusKonfirmasi = "";
            if (roleTerpilih.ToUpper() == "DISTRIBUTOR")
            {
                statusKonfirmasi = "Menunggu"; 
            }
            else if (roleTerpilih.ToUpper() == "NELAYAN")
            {
                statusKonfirmasi = "Konfirmasi"; 
            }

            try
            {
                using (NpgsqlConnection conn = PROJEKANN.database.DBConnection.GetConnection())
                {
                    conn.Open();
                    string querycek = "SELECT COUNT (*) FROM usser WHERE username = @username";
                    using (NpgsqlCommand cmdcek = new NpgsqlCommand(querycek, conn))
                    {
                        cmdcek.Parameters.AddWithValue("@username", username);
                        int userada = Convert.ToInt32(cmdcek.ExecuteScalar());

                        if (userada > 0)
                        {
                            MessageBox.Show("Username ini sudah dipakai orang lain, cari nama unik lain!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    string querymasuk = @"
                    INSERT INTO usser (username, passwd, role_pilihan, nama, no_hp, alamat, status_konfir_akun)
                    VALUES (@username, @password, @role::tipe_role, @nama, @telp, @alamat, @statusKonfirmasi)
                    ";

                    using (NpgsqlCommand cmdInsert = new NpgsqlCommand(querymasuk, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@username", username);
                        cmdInsert.Parameters.AddWithValue("@password", password);
                        cmdInsert.Parameters.AddWithValue("@role", roleTerpilih);
                        cmdInsert.Parameters.AddWithValue("@nama", nama);
                        cmdInsert.Parameters.AddWithValue("@telp", telp);
                        cmdInsert.Parameters.AddWithValue("@alamat", alamat);
                        cmdInsert.Parameters.AddWithValue("@statusKonfirmasi", statusKonfirmasi);

                        cmdInsert.ExecuteNonQuery();
                    }

                    if (roleTerpilih == "DISTRIBUTOR")
                    {
                        MessageBox.Show("Registrasi Berhasil! Akun Anda sedang menunggu konfirmasi dari Admin sebelum bisa login.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Akun Nelayan baru berhasil diaktifkan! Silakan login.", "Sukses Registrasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    mainform.TampilkanHalaman(new PROJEKANN.Usercontrol.login(mainform));
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan ke database: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

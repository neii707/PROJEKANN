namespace PROJEKANN.Usercontrol
{
    partial class KelolaPanen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KelolaPanen));
            kelolapanenpanel = new Panel();
            dashboardbutton_kelola = new Button();
            inputpanenbutton_kelola = new Button();
            penawaranbutton_kelola = new Button();
            transaksibutton_kelola = new Button();
            button1 = new Button();
            keluarbutton_kelola = new Button();
            beratinput_kelola = new Label();
            numBerat = new NumericUpDown();
            inputpanen = new Label();
            labelinput = new Label();
            tanggalinput_kelola = new Label();
            dtptanggalpanen = new DateTimePicker();
            simpanpanen_kelola = new Button();
            hapuspanen_kelola = new Button();
            labelgrade_kelola = new Label();
            labelriwayat_kelola = new Label();
            dgvriwayatpanen = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colBerat = new DataGridViewTextBoxColumn();
            colGrade = new DataGridViewTextBoxColumn();
            colHarga = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            lbnamauser_kelola = new Label();
            kelolapanenpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBerat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvriwayatpanen).BeginInit();
            SuspendLayout();
            // 
            // kelolapanenpanel
            // 
            kelolapanenpanel.BackgroundImage = (Image)resources.GetObject("kelolapanenpanel.BackgroundImage");
            kelolapanenpanel.BackgroundImageLayout = ImageLayout.Stretch;
            kelolapanenpanel.Controls.Add(lbnamauser_kelola);
            kelolapanenpanel.Controls.Add(dgvriwayatpanen);
            kelolapanenpanel.Controls.Add(labelriwayat_kelola);
            kelolapanenpanel.Controls.Add(labelgrade_kelola);
            kelolapanenpanel.Controls.Add(hapuspanen_kelola);
            kelolapanenpanel.Controls.Add(simpanpanen_kelola);
            kelolapanenpanel.Controls.Add(dtptanggalpanen);
            kelolapanenpanel.Controls.Add(tanggalinput_kelola);
            kelolapanenpanel.Controls.Add(inputpanen);
            kelolapanenpanel.Controls.Add(numBerat);
            kelolapanenpanel.Controls.Add(beratinput_kelola);
            kelolapanenpanel.Controls.Add(keluarbutton_kelola);
            kelolapanenpanel.Controls.Add(button1);
            kelolapanenpanel.Controls.Add(transaksibutton_kelola);
            kelolapanenpanel.Controls.Add(penawaranbutton_kelola);
            kelolapanenpanel.Controls.Add(inputpanenbutton_kelola);
            kelolapanenpanel.Controls.Add(dashboardbutton_kelola);
            kelolapanenpanel.Controls.Add(labelinput);
            kelolapanenpanel.Location = new Point(0, 0);
            kelolapanenpanel.Name = "kelolapanenpanel";
            kelolapanenpanel.Size = new Size(908, 555);
            kelolapanenpanel.TabIndex = 0;
            // 
            // dashboardbutton_kelola
            // 
            dashboardbutton_kelola.BackColor = Color.Transparent;
            dashboardbutton_kelola.FlatAppearance.BorderSize = 0;
            dashboardbutton_kelola.FlatStyle = FlatStyle.Flat;
            dashboardbutton_kelola.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dashboardbutton_kelola.Location = new Point(33, 114);
            dashboardbutton_kelola.Name = "dashboardbutton_kelola";
            dashboardbutton_kelola.Size = new Size(119, 26);
            dashboardbutton_kelola.TabIndex = 1;
            dashboardbutton_kelola.Text = "DASHBOARD";
            dashboardbutton_kelola.UseVisualStyleBackColor = false;
            dashboardbutton_kelola.Click += dashboardbutton_kelola_Click;
            // 
            // inputpanenbutton_kelola
            // 
            inputpanenbutton_kelola.BackColor = Color.Transparent;
            inputpanenbutton_kelola.FlatAppearance.BorderSize = 0;
            inputpanenbutton_kelola.FlatStyle = FlatStyle.Flat;
            inputpanenbutton_kelola.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            inputpanenbutton_kelola.Location = new Point(36, 164);
            inputpanenbutton_kelola.Name = "inputpanenbutton_kelola";
            inputpanenbutton_kelola.Size = new Size(143, 26);
            inputpanenbutton_kelola.TabIndex = 2;
            inputpanenbutton_kelola.Text = "KELOLA PANEN";
            inputpanenbutton_kelola.TextAlign = ContentAlignment.MiddleLeft;
            inputpanenbutton_kelola.UseVisualStyleBackColor = false;
            inputpanenbutton_kelola.Click += inputpanenbutton_kelola_Click;
            // 
            // penawaranbutton_kelola
            // 
            penawaranbutton_kelola.BackColor = Color.Transparent;
            penawaranbutton_kelola.FlatAppearance.BorderSize = 0;
            penawaranbutton_kelola.FlatStyle = FlatStyle.Flat;
            penawaranbutton_kelola.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            penawaranbutton_kelola.Location = new Point(35, 191);
            penawaranbutton_kelola.Name = "penawaranbutton_kelola";
            penawaranbutton_kelola.Size = new Size(180, 26);
            penawaranbutton_kelola.TabIndex = 3;
            penawaranbutton_kelola.Text = "PENAWARAN PANEN";
            penawaranbutton_kelola.TextAlign = ContentAlignment.MiddleLeft;
            penawaranbutton_kelola.UseVisualStyleBackColor = false;
            penawaranbutton_kelola.Click += penawaranbutton_kelola_Click;
            // 
            // transaksibutton_kelola
            // 
            transaksibutton_kelola.BackColor = Color.Transparent;
            transaksibutton_kelola.FlatAppearance.BorderSize = 0;
            transaksibutton_kelola.FlatStyle = FlatStyle.Flat;
            transaksibutton_kelola.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            transaksibutton_kelola.Location = new Point(37, 220);
            transaksibutton_kelola.Name = "transaksibutton_kelola";
            transaksibutton_kelola.Size = new Size(101, 26);
            transaksibutton_kelola.TabIndex = 4;
            transaksibutton_kelola.Text = "TRANSAKSI";
            transaksibutton_kelola.TextAlign = ContentAlignment.MiddleLeft;
            transaksibutton_kelola.UseVisualStyleBackColor = false;
            transaksibutton_kelola.Click += transaksibutton_kelola_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            button1.Location = new Point(36, 264);
            button1.Name = "button1";
            button1.Size = new Size(180, 26);
            button1.TabIndex = 5;
            button1.Text = "RIWAYAT TRANSAKSI";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = false;
            // 
            // keluarbutton_kelola
            // 
            keluarbutton_kelola.BackColor = Color.Transparent;
            keluarbutton_kelola.BackgroundImage = (Image)resources.GetObject("keluarbutton_kelola.BackgroundImage");
            keluarbutton_kelola.BackgroundImageLayout = ImageLayout.Stretch;
            keluarbutton_kelola.Cursor = Cursors.Hand;
            keluarbutton_kelola.FlatAppearance.BorderSize = 0;
            keluarbutton_kelola.FlatStyle = FlatStyle.Flat;
            keluarbutton_kelola.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            keluarbutton_kelola.Location = new Point(-16, 486);
            keluarbutton_kelola.Name = "keluarbutton_kelola";
            keluarbutton_kelola.Size = new Size(110, 69);
            keluarbutton_kelola.TabIndex = 13;
            keluarbutton_kelola.TextAlign = ContentAlignment.MiddleLeft;
            keluarbutton_kelola.UseVisualStyleBackColor = false;
            keluarbutton_kelola.Click += keluarbutton_kelola_Click;
            // 
            // beratinput_kelola
            // 
            beratinput_kelola.AutoSize = true;
            beratinput_kelola.BackColor = Color.MediumAquamarine;
            beratinput_kelola.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            beratinput_kelola.Location = new Point(274, 158);
            beratinput_kelola.Name = "beratinput_kelola";
            beratinput_kelola.Size = new Size(103, 25);
            beratinput_kelola.TabIndex = 14;
            beratinput_kelola.Text = "Berat (kg):";
            // 
            // numBerat
            // 
            numBerat.Location = new Point(274, 186);
            numBerat.Name = "numBerat";
            numBerat.Size = new Size(180, 31);
            numBerat.TabIndex = 15;
            // 
            // inputpanen
            // 
            inputpanen.AutoSize = true;
            inputpanen.BackColor = Color.Transparent;
            inputpanen.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            inputpanen.Location = new Point(274, 108);
            inputpanen.Name = "inputpanen";
            inputpanen.Size = new Size(213, 32);
            inputpanen.TabIndex = 16;
            inputpanen.Text = "Input Data Panen";
            // 
            // labelinput
            // 
            labelinput.BackColor = Color.MediumAquamarine;
            labelinput.Location = new Point(256, 95);
            labelinput.Name = "labelinput";
            labelinput.Size = new Size(639, 151);
            labelinput.TabIndex = 17;
            labelinput.TextAlign = ContentAlignment.BottomCenter;
            // 
            // tanggalinput_kelola
            // 
            tanggalinput_kelola.AutoSize = true;
            tanggalinput_kelola.BackColor = Color.MediumAquamarine;
            tanggalinput_kelola.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tanggalinput_kelola.Location = new Point(468, 158);
            tanggalinput_kelola.Name = "tanggalinput_kelola";
            tanggalinput_kelola.Size = new Size(142, 25);
            tanggalinput_kelola.TabIndex = 18;
            tanggalinput_kelola.Text = "Tanggal Panen:";
            // 
            // dtptanggalpanen
            // 
            dtptanggalpanen.Location = new Point(468, 185);
            dtptanggalpanen.Name = "dtptanggalpanen";
            dtptanggalpanen.Size = new Size(228, 31);
            dtptanggalpanen.TabIndex = 19;
            // 
            // simpanpanen_kelola
            // 
            simpanpanen_kelola.BackColor = Color.LimeGreen;
            simpanpanen_kelola.FlatAppearance.BorderSize = 0;
            simpanpanen_kelola.FlatStyle = FlatStyle.Flat;
            simpanpanen_kelola.Font = new Font("Calibri", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            simpanpanen_kelola.Location = new Point(711, 176);
            simpanpanen_kelola.Name = "simpanpanen_kelola";
            simpanpanen_kelola.Size = new Size(81, 41);
            simpanpanen_kelola.TabIndex = 20;
            simpanpanen_kelola.Text = "simpan";
            simpanpanen_kelola.UseVisualStyleBackColor = false;
            simpanpanen_kelola.Click += simpanpanen_kelola_Click;
            // 
            // hapuspanen_kelola
            // 
            hapuspanen_kelola.BackColor = Color.Red;
            hapuspanen_kelola.FlatAppearance.BorderSize = 0;
            hapuspanen_kelola.FlatStyle = FlatStyle.Flat;
            hapuspanen_kelola.Font = new Font("Calibri", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hapuspanen_kelola.Location = new Point(801, 176);
            hapuspanen_kelola.Name = "hapuspanen_kelola";
            hapuspanen_kelola.Size = new Size(81, 41);
            hapuspanen_kelola.TabIndex = 21;
            hapuspanen_kelola.Text = "hapus";
            hapuspanen_kelola.UseVisualStyleBackColor = false;
            hapuspanen_kelola.Click += hapuspanen_kelola_Click;
            // 
            // labelgrade_kelola
            // 
            labelgrade_kelola.AutoSize = true;
            labelgrade_kelola.BackColor = Color.MediumAquamarine;
            labelgrade_kelola.Font = new Font("Segoe UI", 7F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelgrade_kelola.Location = new Point(274, 223);
            labelgrade_kelola.Name = "labelgrade_kelola";
            labelgrade_kelola.Size = new Size(276, 19);
            labelgrade_kelola.TabIndex = 22;
            labelgrade_kelola.Text = "[!] Grade akan ditentukan oleh Distributor.";
            // 
            // labelriwayat_kelola
            // 
            labelriwayat_kelola.AutoSize = true;
            labelriwayat_kelola.BackColor = Color.Transparent;
            labelriwayat_kelola.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelriwayat_kelola.Location = new Point(274, 275);
            labelriwayat_kelola.Name = "labelriwayat_kelola";
            labelriwayat_kelola.Size = new Size(202, 28);
            labelriwayat_kelola.TabIndex = 23;
            labelriwayat_kelola.Text = "Riwayat Panen Saya";
            // 
            // dgvriwayatpanen
            // 
            dgvriwayatpanen.AllowUserToAddRows = false;
            dgvriwayatpanen.AllowUserToDeleteRows = false;
            dgvriwayatpanen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvriwayatpanen.BackgroundColor = Color.MediumAquamarine;
            dgvriwayatpanen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvriwayatpanen.Columns.AddRange(new DataGridViewColumn[] { colID, colBerat, colGrade, colHarga, colStatus });
            dgvriwayatpanen.Location = new Point(256, 306);
            dgvriwayatpanen.Name = "dgvriwayatpanen";
            dgvriwayatpanen.ReadOnly = true;
            dgvriwayatpanen.RowHeadersVisible = false;
            dgvriwayatpanen.RowHeadersWidth = 62;
            dgvriwayatpanen.Size = new Size(639, 223);
            dgvriwayatpanen.TabIndex = 24;
            // 
            // colID
            // 
            colID.HeaderText = "ID";
            colID.MinimumWidth = 8;
            colID.Name = "colID";
            colID.ReadOnly = true;
            // 
            // colBerat
            // 
            colBerat.HeaderText = "Berat (kg)";
            colBerat.MinimumWidth = 8;
            colBerat.Name = "colBerat";
            colBerat.ReadOnly = true;
            // 
            // colGrade
            // 
            colGrade.HeaderText = "Grade";
            colGrade.MinimumWidth = 8;
            colGrade.Name = "colGrade";
            colGrade.ReadOnly = true;
            // 
            // colHarga
            // 
            colHarga.HeaderText = "Harga/kg";
            colHarga.MinimumWidth = 8;
            colHarga.Name = "colHarga";
            colHarga.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 8;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // lbnamauser_kelola
            // 
            lbnamauser_kelola.AutoSize = true;
            lbnamauser_kelola.BackColor = Color.Transparent;
            lbnamauser_kelola.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbnamauser_kelola.Location = new Point(83, 56);
            lbnamauser_kelola.Name = "lbnamauser_kelola";
            lbnamauser_kelola.Size = new Size(88, 25);
            lbnamauser_kelola.TabIndex = 25;
            lbnamauser_kelola.Text = "Natachai";
            // 
            // KelolaPanen
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(kelolapanenpanel);
            Name = "KelolaPanen";
            Size = new Size(908, 555);
            kelolapanenpanel.ResumeLayout(false);
            kelolapanenpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numBerat).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvriwayatpanen).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel kelolapanenpanel;
        private Button dashboardbutton_kelola;
        private Button inputpanenbutton_kelola;
        private Button penawaranbutton_kelola;
        private Button transaksibutton_kelola;
        private Button button1;
        private Button keluarbutton_kelola;
        private NumericUpDown numBerat;
        private Label beratinput_kelola;
        private Label labelinput;
        private Label inputpanen;
        private Label tanggalinput_kelola;
        private DateTimePicker dtptanggalpanen;
        private Button simpanpanen_kelola;
        private Button hapuspanen_kelola;
        private Label labelgrade_kelola;
        private Label labelriwayat_kelola;
        private DataGridView dgvriwayatpanen;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colBerat;
        private DataGridViewTextBoxColumn colGrade;
        private DataGridViewTextBoxColumn colHarga;
        private DataGridViewTextBoxColumn colStatus;
        private Label lbnamauser_kelola;
    }
}

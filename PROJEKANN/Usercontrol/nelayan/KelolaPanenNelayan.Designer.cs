namespace PROJEKANN.Usercontrol.nelayan
{
    partial class KelolaPanenNelayan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KelolaPanenNelayan));
            lbnamauser_kelola = new Label();
            dgvriwayatpanen = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colBerat = new DataGridViewTextBoxColumn();
            colGrade = new DataGridViewTextBoxColumn();
            colHarga = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            labelriwayat_kelola = new Label();
            labelgrade_kelola = new Label();
            hapuspanen_kelola = new Button();
            simpanpanen_kelola = new Button();
            dtptanggalpanen = new DateTimePicker();
            tanggalinput_kelola = new Label();
            inputpanen = new Label();
            numBerat = new NumericUpDown();
            beratinput_kelola = new Label();
            keluarbutton_kelola = new Button();
            riwayatbutton_kelola = new Button();
            transaksibutton_kelola = new Button();
            penawaranbutton_kelola = new Button();
            inputpanenbutton_kelola = new Button();
            dashboardbutton_kelola = new Button();
            labelinput = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvriwayatpanen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBerat).BeginInit();
            SuspendLayout();
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
            dgvriwayatpanen.CellClick += dgvriwayatpanen_CellClick;
            dgvriwayatpanen.CellContentClick += dgvriwayatpanen_CellContentClick;
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
            // dtptanggalpanen
            // 
            dtptanggalpanen.Location = new Point(468, 185);
            dtptanggalpanen.Name = "dtptanggalpanen";
            dtptanggalpanen.Size = new Size(228, 31);
            dtptanggalpanen.TabIndex = 19;
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
            // numBerat
            // 
            numBerat.Location = new Point(274, 186);
            numBerat.Name = "numBerat";
            numBerat.Size = new Size(180, 31);
            numBerat.TabIndex = 15;
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
            // keluarbutton_kelola
            // 
            keluarbutton_kelola.BackColor = Color.Transparent;
            keluarbutton_kelola.BackgroundImage = (Image)resources.GetObject("keluarbutton_kelola.BackgroundImage");
            keluarbutton_kelola.BackgroundImageLayout = ImageLayout.Stretch;
            keluarbutton_kelola.Cursor = Cursors.Hand;
            keluarbutton_kelola.FlatAppearance.BorderSize = 0;
            keluarbutton_kelola.FlatStyle = FlatStyle.Flat;
            keluarbutton_kelola.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            keluarbutton_kelola.Location = new Point(-23, 486);
            keluarbutton_kelola.Name = "keluarbutton_kelola";
            keluarbutton_kelola.Size = new Size(110, 69);
            keluarbutton_kelola.TabIndex = 13;
            keluarbutton_kelola.TextAlign = ContentAlignment.MiddleLeft;
            keluarbutton_kelola.UseVisualStyleBackColor = false;
            keluarbutton_kelola.Click += keluarbutton_kelola_Click;
            // 
            // riwayatbutton_kelola
            // 
            riwayatbutton_kelola.BackColor = Color.Transparent;
            riwayatbutton_kelola.FlatAppearance.BorderSize = 0;
            riwayatbutton_kelola.FlatStyle = FlatStyle.Flat;
            riwayatbutton_kelola.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            riwayatbutton_kelola.Location = new Point(36, 264);
            riwayatbutton_kelola.Name = "riwayatbutton_kelola";
            riwayatbutton_kelola.Size = new Size(180, 26);
            riwayatbutton_kelola.TabIndex = 5;
            riwayatbutton_kelola.Text = "RIWAYAT TRANSAKSI";
            riwayatbutton_kelola.TextAlign = ContentAlignment.MiddleLeft;
            riwayatbutton_kelola.UseVisualStyleBackColor = false;
            riwayatbutton_kelola.Click += riwayatbutton_kelola_Click;
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
            // labelinput
            // 
            labelinput.BackColor = Color.MediumAquamarine;
            labelinput.Location = new Point(256, 95);
            labelinput.Name = "labelinput";
            labelinput.Size = new Size(639, 151);
            labelinput.TabIndex = 17;
            labelinput.TextAlign = ContentAlignment.BottomCenter;
            // 
            // KelolaPanenNelayan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.LOGIN__4_;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(dgvriwayatpanen);
            Controls.Add(lbnamauser_kelola);
            Controls.Add(labelriwayat_kelola);
            Controls.Add(labelgrade_kelola);
            Controls.Add(simpanpanen_kelola);
            Controls.Add(hapuspanen_kelola);
            Controls.Add(dtptanggalpanen);
            Controls.Add(tanggalinput_kelola);
            Controls.Add(inputpanen);
            Controls.Add(numBerat);
            Controls.Add(beratinput_kelola);
            Controls.Add(keluarbutton_kelola);
            Controls.Add(transaksibutton_kelola);
            Controls.Add(riwayatbutton_kelola);
            Controls.Add(penawaranbutton_kelola);
            Controls.Add(inputpanenbutton_kelola);
            Controls.Add(dashboardbutton_kelola);
            Controls.Add(labelinput);
            Name = "KelolaPanenNelayan";
            Size = new Size(908, 555);
            ((System.ComponentModel.ISupportInitialize)dgvriwayatpanen).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBerat).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button dashboardbutton_kelola;
        private Button inputpanenbutton_kelola;
        private Button penawaranbutton_kelola;
        private Button transaksibutton_kelola;
        private Button riwayatbutton_kelola;
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
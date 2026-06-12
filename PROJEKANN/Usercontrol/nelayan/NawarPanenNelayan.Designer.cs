namespace PROJEKANN.Usercontrol.nelayan
{
    partial class NawarPanenNelayan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NawarPanenNelayan));
            terima_tolak_tawaran = new Label();
            tolak_tawaran = new Button();
            terima_nawar = new Button();
            dgvpenawaran = new DataGridView();
            labeldatanawar_nawar = new Label();
            lbnamauser_dashboard = new Label();
            keluarbutton_nawar = new Button();
            riwayatbutton_nawar = new Button();
            transaksibutton_nawar = new Button();
            penawaranbutton_nawar = new Button();
            inputpanenbutton_nawar = new Button();
            dashboardbutton_nawar = new Button();
            colID = new DataGridViewTextBoxColumn();
            colDistributor = new DataGridViewTextBoxColumn();
            colBerat = new DataGridViewTextBoxColumn();
            colGrade = new DataGridViewTextBoxColumn();
            colHarga = new DataGridViewTextBoxColumn();
            colEstimasi = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvpenawaran).BeginInit();
            SuspendLayout();
            // 
            // terima_tolak_tawaran
            // 
            terima_tolak_tawaran.AutoSize = true;
            terima_tolak_tawaran.BackColor = Color.Transparent;
            terima_tolak_tawaran.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            terima_tolak_tawaran.Location = new Point(258, 471);
            terima_tolak_tawaran.Name = "terima_tolak_tawaran";
            terima_tolak_tawaran.Size = new Size(210, 19);
            terima_tolak_tawaran.TabIndex = 32;
            terima_tolak_tawaran.Text = "Terima atau Tolak penawaran.";
            // 
            // tolak_tawaran
            // 
            tolak_tawaran.BackColor = Color.Red;
            tolak_tawaran.FlatAppearance.BorderSize = 0;
            tolak_tawaran.FlatStyle = FlatStyle.Flat;
            tolak_tawaran.Font = new Font("Calibri", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tolak_tawaran.Location = new Point(351, 499);
            tolak_tawaran.Name = "tolak_tawaran";
            tolak_tawaran.Size = new Size(81, 41);
            tolak_tawaran.TabIndex = 31;
            tolak_tawaran.Text = "Tolak";
            tolak_tawaran.UseVisualStyleBackColor = false;
            tolak_tawaran.Click += tolak_tawaran_Click;
            // 
            // terima_nawar
            // 
            terima_nawar.BackColor = Color.LimeGreen;
            terima_nawar.FlatAppearance.BorderSize = 0;
            terima_nawar.FlatStyle = FlatStyle.Flat;
            terima_nawar.Font = new Font("Calibri", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            terima_nawar.Location = new Point(263, 499);
            terima_nawar.Name = "terima_nawar";
            terima_nawar.Size = new Size(81, 41);
            terima_nawar.TabIndex = 30;
            terima_nawar.Text = "Terima";
            terima_nawar.UseVisualStyleBackColor = false;
            terima_nawar.Click += terima_nawar_Click;
            // 
            // dgvpenawaran
            // 
            dgvpenawaran.AllowUserToAddRows = false;
            dgvpenawaran.AllowUserToDeleteRows = false;
            dgvpenawaran.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvpenawaran.BackgroundColor = Color.MediumAquamarine;
            dgvpenawaran.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvpenawaran.Columns.AddRange(new DataGridViewColumn[] { colID, colDistributor, colBerat, colGrade, colHarga, colEstimasi, colStatus });
            dgvpenawaran.Location = new Point(258, 114);
            dgvpenawaran.Name = "dgvpenawaran";
            dgvpenawaran.ReadOnly = true;
            dgvpenawaran.RowHeadersVisible = false;
            dgvpenawaran.RowHeadersWidth = 62;
            dgvpenawaran.Size = new Size(635, 345);
            dgvpenawaran.TabIndex = 29;
            dgvpenawaran.CellContentClick += dataGridView1_CellContentClick;
            // 
            // labeldatanawar_nawar
            // 
            labeldatanawar_nawar.AutoSize = true;
            labeldatanawar_nawar.BackColor = Color.Transparent;
            labeldatanawar_nawar.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            labeldatanawar_nawar.Location = new Point(258, 84);
            labeldatanawar_nawar.Name = "labeldatanawar_nawar";
            labeldatanawar_nawar.Size = new Size(528, 21);
            labeldatanawar_nawar.TabIndex = 28;
            labeldatanawar_nawar.Text = "Berikut adalah penawaran harga dari Distributor untuk panen Anda.";
            // 
            // lbnamauser_dashboard
            // 
            lbnamauser_dashboard.AutoSize = true;
            lbnamauser_dashboard.BackColor = Color.Transparent;
            lbnamauser_dashboard.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbnamauser_dashboard.Location = new Point(91, 49);
            lbnamauser_dashboard.Name = "lbnamauser_dashboard";
            lbnamauser_dashboard.Size = new Size(88, 25);
            lbnamauser_dashboard.TabIndex = 27;
            lbnamauser_dashboard.Text = "Natachai";
            // 
            // keluarbutton_nawar
            // 
            keluarbutton_nawar.BackColor = Color.Transparent;
            keluarbutton_nawar.BackgroundImage = (Image)resources.GetObject("keluarbutton_nawar.BackgroundImage");
            keluarbutton_nawar.BackgroundImageLayout = ImageLayout.Stretch;
            keluarbutton_nawar.Cursor = Cursors.Hand;
            keluarbutton_nawar.FlatAppearance.BorderSize = 0;
            keluarbutton_nawar.FlatStyle = FlatStyle.Flat;
            keluarbutton_nawar.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            keluarbutton_nawar.Location = new Point(-19, 486);
            keluarbutton_nawar.Name = "keluarbutton_nawar";
            keluarbutton_nawar.Size = new Size(110, 69);
            keluarbutton_nawar.TabIndex = 13;
            keluarbutton_nawar.TextAlign = ContentAlignment.MiddleLeft;
            keluarbutton_nawar.UseVisualStyleBackColor = false;
            keluarbutton_nawar.Click += keluarbutton_nawar_Click;
            // 
            // riwayatbutton_nawar
            // 
            riwayatbutton_nawar.BackColor = Color.Transparent;
            riwayatbutton_nawar.FlatAppearance.BorderSize = 0;
            riwayatbutton_nawar.FlatStyle = FlatStyle.Flat;
            riwayatbutton_nawar.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            riwayatbutton_nawar.Location = new Point(35, 264);
            riwayatbutton_nawar.Name = "riwayatbutton_nawar";
            riwayatbutton_nawar.Size = new Size(180, 26);
            riwayatbutton_nawar.TabIndex = 5;
            riwayatbutton_nawar.Text = "RIWAYAT TRANSAKSI";
            riwayatbutton_nawar.TextAlign = ContentAlignment.MiddleLeft;
            riwayatbutton_nawar.UseVisualStyleBackColor = false;
            riwayatbutton_nawar.Click += riwayatbutton_nawar_Click;
            // 
            // transaksibutton_nawar
            // 
            transaksibutton_nawar.BackColor = Color.Transparent;
            transaksibutton_nawar.FlatAppearance.BorderSize = 0;
            transaksibutton_nawar.FlatStyle = FlatStyle.Flat;
            transaksibutton_nawar.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            transaksibutton_nawar.Location = new Point(35, 219);
            transaksibutton_nawar.Name = "transaksibutton_nawar";
            transaksibutton_nawar.Size = new Size(105, 26);
            transaksibutton_nawar.TabIndex = 4;
            transaksibutton_nawar.Text = "TRANSAKSI";
            transaksibutton_nawar.TextAlign = ContentAlignment.MiddleLeft;
            transaksibutton_nawar.UseVisualStyleBackColor = false;
            transaksibutton_nawar.Click += transaksibutton_nawar_Click;
            // 
            // penawaranbutton_nawar
            // 
            penawaranbutton_nawar.BackColor = Color.Transparent;
            penawaranbutton_nawar.FlatAppearance.BorderSize = 0;
            penawaranbutton_nawar.FlatStyle = FlatStyle.Flat;
            penawaranbutton_nawar.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            penawaranbutton_nawar.Location = new Point(36, 190);
            penawaranbutton_nawar.Name = "penawaranbutton_nawar";
            penawaranbutton_nawar.Size = new Size(180, 26);
            penawaranbutton_nawar.TabIndex = 3;
            penawaranbutton_nawar.Text = "PENAWARAN PANEN";
            penawaranbutton_nawar.TextAlign = ContentAlignment.MiddleLeft;
            penawaranbutton_nawar.UseVisualStyleBackColor = false;
            penawaranbutton_nawar.Click += penawaranbutton_nawar_Click;
            // 
            // inputpanenbutton_nawar
            // 
            inputpanenbutton_nawar.BackColor = Color.Transparent;
            inputpanenbutton_nawar.FlatAppearance.BorderSize = 0;
            inputpanenbutton_nawar.FlatStyle = FlatStyle.Flat;
            inputpanenbutton_nawar.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            inputpanenbutton_nawar.Location = new Point(36, 163);
            inputpanenbutton_nawar.Name = "inputpanenbutton_nawar";
            inputpanenbutton_nawar.Size = new Size(143, 26);
            inputpanenbutton_nawar.TabIndex = 2;
            inputpanenbutton_nawar.Text = "KELOLA PANEN";
            inputpanenbutton_nawar.TextAlign = ContentAlignment.MiddleLeft;
            inputpanenbutton_nawar.UseVisualStyleBackColor = false;
            inputpanenbutton_nawar.Click += inputpanenbutton_nawar_Click;
            // 
            // dashboardbutton_nawar
            // 
            dashboardbutton_nawar.BackColor = Color.Transparent;
            dashboardbutton_nawar.FlatAppearance.BorderSize = 0;
            dashboardbutton_nawar.FlatStyle = FlatStyle.Flat;
            dashboardbutton_nawar.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dashboardbutton_nawar.Location = new Point(33, 114);
            dashboardbutton_nawar.Name = "dashboardbutton_nawar";
            dashboardbutton_nawar.Size = new Size(119, 26);
            dashboardbutton_nawar.TabIndex = 1;
            dashboardbutton_nawar.Text = "DASHBOARD";
            dashboardbutton_nawar.UseVisualStyleBackColor = false;
            dashboardbutton_nawar.Click += dashboardbutton_nawar_Click;
            // 
            // colID
            // 
            colID.HeaderText = "ID Panen";
            colID.MinimumWidth = 8;
            colID.Name = "colID";
            colID.ReadOnly = true;
            // 
            // colDistributor
            // 
            colDistributor.HeaderText = "Distributor";
            colDistributor.MinimumWidth = 8;
            colDistributor.Name = "colDistributor";
            colDistributor.ReadOnly = true;
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
            colHarga.HeaderText = "Harga";
            colHarga.MinimumWidth = 8;
            colHarga.Name = "colHarga";
            colHarga.ReadOnly = true;
            // 
            // colEstimasi
            // 
            colEstimasi.HeaderText = "Total";
            colEstimasi.MinimumWidth = 8;
            colEstimasi.Name = "colEstimasi";
            colEstimasi.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 8;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // NawarPanenNelayan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.LOGIN__5_;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(terima_tolak_tawaran);
            Controls.Add(tolak_tawaran);
            Controls.Add(terima_nawar);
            Controls.Add(labeldatanawar_nawar);
            Controls.Add(lbnamauser_dashboard);
            Controls.Add(dgvpenawaran);
            Controls.Add(keluarbutton_nawar);
            Controls.Add(riwayatbutton_nawar);
            Controls.Add(transaksibutton_nawar);
            Controls.Add(penawaranbutton_nawar);
            Controls.Add(inputpanenbutton_nawar);
            Controls.Add(dashboardbutton_nawar);
            Name = "NawarPanenNelayan";
            Size = new Size(908, 555);
            ((System.ComponentModel.ISupportInitialize)dgvpenawaran).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button dashboardbutton_nawar;
        private Button inputpanenbutton_nawar;
        private Button penawaranbutton_nawar;
        private Button transaksibutton_nawar;
        private Button riwayatbutton_nawar;
        private Button keluarbutton_nawar;
        private Label lbnamauser_dashboard;
        private Label labeldatanawar_nawar;
        private DataGridView dgvpenawaran;
        private Button terima_nawar;
        private Button tolak_tawaran;
        private Label terima_tolak_tawaran;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colDistributor;
        private DataGridViewTextBoxColumn colBerat;
        private DataGridViewTextBoxColumn colGrade;
        private DataGridViewTextBoxColumn colHarga;
        private DataGridViewTextBoxColumn colEstimasi;
        private DataGridViewTextBoxColumn colStatus;
    }
}
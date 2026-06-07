namespace PROJEKANN.Usercontrol.admin
{
    partial class kelola_demand
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kelola_demand));
            panel1 = new Panel();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button6 = new Button();
            dataGridView1 = new DataGridView();
            dateTimePicker1 = new DateTimePicker();
            textBox1 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            keluarbutton_dashboard = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.demand;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(keluarbutton_dashboard);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(905, 552);
            panel1.TabIndex = 0;
            // 
            // button5
            // 
            button5.BackColor = Color.Transparent;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(35, 261);
            button5.Name = "button5";
            button5.Size = new Size(219, 34);
            button5.TabIndex = 12;
            button5.Text = "MONITOR TRANSAKSI";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(35, 225);
            button4.Name = "button4";
            button4.Size = new Size(219, 34);
            button4.TabIndex = 11;
            button4.Text = "MONITOR STOK";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(35, 185);
            button3.Name = "button3";
            button3.Size = new Size(175, 34);
            button3.TabIndex = 10;
            button3.Text = "KELOLA DEMAND";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(35, 145);
            button2.Name = "button2";
            button2.Size = new Size(149, 34);
            button2.TabIndex = 9;
            button2.Text = "KELOLA AKUN";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(35, 109);
            button6.Name = "button6";
            button6.Size = new Size(135, 34);
            button6.TabIndex = 8;
            button6.Text = "DASHBOARD";
            button6.TextAlign = ContentAlignment.MiddleLeft;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.FromArgb(228, 254, 233);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = Color.FromArgb(192, 255, 192);
            dataGridView1.Location = new Point(262, 299);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(618, 206);
            dataGridView1.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Segoe UI", 7F);
            dateTimePicker1.Font = new Font("Segoe UI", 7F);
            dateTimePicker1.Location = new Point(597, 149);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(283, 26);
            dateTimePicker1.TabIndex = 6;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 7F);
            textBox1.Location = new Point(267, 149);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(252, 26);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(597, 117);
            label4.Name = "label4";
            label4.Size = new Size(97, 25);
            label4.TabIndex = 4;
            label4.Text = "TANGGAL";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(261, 117);
            label3.Name = "label3";
            label3.Size = new Size(124, 25);
            label3.TabIndex = 3;
            label3.Text = "TARGET (KG)";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(69, 115, 28);
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(262, 186);
            button1.Name = "button1";
            button1.Size = new Size(618, 34);
            button1.TabIndex = 2;
            button1.Text = "TAMBAH DEMAND";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(251, 249);
            label2.Name = "label2";
            label2.Size = new Size(207, 25);
            label2.TabIndex = 1;
            label2.Text = "LIST TARGET DEMAND";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(248, 77);
            label1.Name = "label1";
            label1.Size = new Size(249, 25);
            label1.TabIndex = 0;
            label1.Text = "+ TAMBAH DEMAND BARU";
            // 
            // keluarbutton_dashboard
            // 
            keluarbutton_dashboard.BackColor = Color.Transparent;
            keluarbutton_dashboard.BackgroundImage = (Image)resources.GetObject("keluarbutton_dashboard.BackgroundImage");
            keluarbutton_dashboard.BackgroundImageLayout = ImageLayout.Stretch;
            keluarbutton_dashboard.Cursor = Cursors.Hand;
            keluarbutton_dashboard.FlatAppearance.BorderSize = 0;
            keluarbutton_dashboard.FlatStyle = FlatStyle.Flat;
            keluarbutton_dashboard.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            keluarbutton_dashboard.Location = new Point(-22, 503);
            keluarbutton_dashboard.Name = "keluarbutton_dashboard";
            keluarbutton_dashboard.Size = new Size(85, 46);
            keluarbutton_dashboard.TabIndex = 15;
            keluarbutton_dashboard.TextAlign = ContentAlignment.MiddleLeft;
            keluarbutton_dashboard.UseVisualStyleBackColor = false;
            keluarbutton_dashboard.Click += keluarbutton_dashboard_Click;
            // 
            // kelola_demand
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "kelola_demand";
            Size = new Size(908, 555);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label4;
        private Label label3;
        private Button button1;
        private Label label2;
        private DataGridView dataGridView1;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox1;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button6;
        private Button keluarbutton_dashboard;
    }
}

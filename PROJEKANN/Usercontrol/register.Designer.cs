namespace PROJEKANN.Usercontrol
{
    partial class register
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
            button1 = new Button();
            comboBox1 = new ComboBox();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.SeaGreen;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(814, 581);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 14;
            button1.Text = "REGISTER";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.White;
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(758, 513);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(247, 29);
            comboBox1.TabIndex = 13;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox6
            // 
            textBox6.BackColor = Color.White;
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox6.Location = new Point(758, 465);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(247, 22);
            textBox6.TabIndex = 12;
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.White;
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox5.Location = new Point(763, 414);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(242, 22);
            textBox5.TabIndex = 11;
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.White;
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox4.Location = new Point(762, 362);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(243, 22);
            textBox4.TabIndex = 10;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.White;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(763, 261);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(242, 22);
            textBox3.TabIndex = 9;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(762, 308);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(243, 22);
            textBox1.TabIndex = 8;
            // 
            // register
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.registrasi;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(textBox3);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox6);
            Name = "register";
            Size = new Size(1135, 690);
            Load += dashboard_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button REGISTER;
        private ComboBox comboBox1;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox1;
        private Button button1;
    }
}


namespace ChươngTrinhInBarcode
{
    partial class In_Lai
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btnInlai = new System.Windows.Forms.Button();
            this.btnQuaylai = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblGhichu = new System.Windows.Forms.Label();
            this.lblDangNhap = new System.Windows.Forms.Label();
            this.lblKetNoi = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInKhongThanhCong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInThanhCong = new System.Windows.Forms.TextBox();
            this.lblInThanhCong = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập Barcode In Lại:";
            // 
            // txtBarcode
            // 
            this.txtBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtBarcode.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(316, 60);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(301, 35);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Máy In:";
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(316, 122);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(301, 30);
            this.comboBox2.TabIndex = 4;
            // 
            // btnInlai
            // 
            this.btnInlai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnInlai.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInlai.Location = new System.Drawing.Point(665, 76);
            this.btnInlai.Name = "btnInlai";
            this.btnInlai.Size = new System.Drawing.Size(162, 58);
            this.btnInlai.TabIndex = 5;
            this.btnInlai.Text = "IN LẠI";
            this.btnInlai.UseVisualStyleBackColor = false;
            this.btnInlai.Click += new System.EventHandler(this.btnInlai_Click);
            // 
            // btnQuaylai
            // 
            this.btnQuaylai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuaylai.Location = new System.Drawing.Point(4, 4);
            this.btnQuaylai.Name = "btnQuaylai";
            this.btnQuaylai.Size = new System.Drawing.Size(75, 36);
            this.btnQuaylai.TabIndex = 6;
            this.btnQuaylai.Text = "Back";
            this.btnQuaylai.UseVisualStyleBackColor = true;
            this.btnQuaylai.Click += new System.EventHandler(this.btnQuaylai_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.lblGhichu);
            this.panel1.Location = new System.Drawing.Point(2, 188);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 258);
            this.panel1.TabIndex = 7;
            // 
            // lblGhichu
            // 
            this.lblGhichu.AutoSize = true;
            this.lblGhichu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhichu.Location = new System.Drawing.Point(21, 18);
            this.lblGhichu.Name = "lblGhichu";
            this.lblGhichu.Size = new System.Drawing.Size(0, 19);
            this.lblGhichu.TabIndex = 0;
            this.lblGhichu.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblDangNhap
            // 
            this.lblDangNhap.AutoSize = true;
            this.lblDangNhap.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDangNhap.Location = new System.Drawing.Point(577, 8);
            this.lblDangNhap.Name = "lblDangNhap";
            this.lblDangNhap.Size = new System.Drawing.Size(89, 22);
            this.lblDangNhap.TabIndex = 8;
            this.lblDangNhap.Text = "conghung";
            // 
            // lblKetNoi
            // 
            this.lblKetNoi.AutoSize = true;
            this.lblKetNoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKetNoi.Location = new System.Drawing.Point(683, 10);
            this.lblKetNoi.Name = "lblKetNoi";
            this.lblKetNoi.Size = new System.Drawing.Size(0, 19);
            this.lblKetNoi.TabIndex = 9;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 180000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(29, 68);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(766, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 31);
            this.button1.TabIndex = 16;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPath
            // 
            this.txtPath.Enabled = false;
            this.txtPath.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.Location = new System.Drawing.Point(535, 158);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(228, 26);
            this.txtPath.TabIndex = 15;
            this.txtPath.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(486, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "Path:";
            this.label3.Visible = false;
            // 
            // txtInKhongThanhCong
            // 
            this.txtInKhongThanhCong.Enabled = false;
            this.txtInKhongThanhCong.Location = new System.Drawing.Point(283, 164);
            this.txtInKhongThanhCong.Name = "txtInKhongThanhCong";
            this.txtInKhongThanhCong.Size = new System.Drawing.Size(41, 20);
            this.txtInKhongThanhCong.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(156, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "In  Không Thành  Công:";
            // 
            // txtInThanhCong
            // 
            this.txtInThanhCong.Enabled = false;
            this.txtInThanhCong.Location = new System.Drawing.Point(99, 165);
            this.txtInThanhCong.Name = "txtInThanhCong";
            this.txtInThanhCong.Size = new System.Drawing.Size(41, 20);
            this.txtInThanhCong.TabIndex = 18;
            // 
            // lblInThanhCong
            // 
            this.lblInThanhCong.AutoSize = true;
            this.lblInThanhCong.ForeColor = System.Drawing.Color.Red;
            this.lblInThanhCong.Location = new System.Drawing.Point(12, 168);
            this.lblInThanhCong.Name = "lblInThanhCong";
            this.lblInThanhCong.Size = new System.Drawing.Size(81, 13);
            this.lblInThanhCong.TabIndex = 17;
            this.lblInThanhCong.Text = "In Thành Công:";
            // 
            // In_Lai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 448);
            this.Controls.Add(this.txtInKhongThanhCong);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtInThanhCong);
            this.Controls.Add(this.lblInThanhCong);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lblKetNoi);
            this.Controls.Add(this.lblDangNhap);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnQuaylai);
            this.Controls.Add(this.btnInlai);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.label1);
            this.Name = "In_Lai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In_Lai";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.In_Lai_FormClosing);
            this.Load += new System.EventHandler(this.In_Lai_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button btnInlai;
        private System.Windows.Forms.Button btnQuaylai;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblGhichu;
        private System.Windows.Forms.Label lblDangNhap;
        private System.Windows.Forms.Label lblKetNoi;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInKhongThanhCong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInThanhCong;
        private System.Windows.Forms.Label lblInThanhCong;
    }
}
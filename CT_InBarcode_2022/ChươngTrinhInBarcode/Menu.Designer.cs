
namespace ChươngTrinhInBarcode
{
    partial class Menu
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
            this.btnInBarcode = new System.Windows.Forms.Button();
            this.btnInLai = new System.Windows.Forms.Button();
            this.btnMoKhoa = new System.Windows.Forms.Button();
            this.btnTaoTK = new System.Windows.Forms.Button();
            this.txtMoKhoa = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInBarcode
            // 
            this.btnInBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnInBarcode.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInBarcode.Location = new System.Drawing.Point(38, 59);
            this.btnInBarcode.Name = "btnInBarcode";
            this.btnInBarcode.Size = new System.Drawing.Size(328, 59);
            this.btnInBarcode.TabIndex = 0;
            this.btnInBarcode.Text = "IN BARCODE";
            this.btnInBarcode.UseVisualStyleBackColor = false;
            this.btnInBarcode.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnInLai
            // 
            this.btnInLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnInLai.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInLai.Location = new System.Drawing.Point(38, 142);
            this.btnInLai.Name = "btnInLai";
            this.btnInLai.Size = new System.Drawing.Size(328, 59);
            this.btnInLai.TabIndex = 0;
            this.btnInLai.Text = "IN LẠI BARCODE";
            this.btnInLai.UseVisualStyleBackColor = false;
            this.btnInLai.Click += new System.EventHandler(this.btnInLai_Click);
            // 
            // btnMoKhoa
            // 
            this.btnMoKhoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnMoKhoa.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoKhoa.Location = new System.Drawing.Point(38, 313);
            this.btnMoKhoa.Name = "btnMoKhoa";
            this.btnMoKhoa.Size = new System.Drawing.Size(150, 59);
            this.btnMoKhoa.TabIndex = 0;
            this.btnMoKhoa.Text = "MỞ KHÓA TÀI KHOẢN";
            this.btnMoKhoa.UseVisualStyleBackColor = false;
            this.btnMoKhoa.Click += new System.EventHandler(this.btnMoKhoa_Click);
            // 
            // btnTaoTK
            // 
            this.btnTaoTK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnTaoTK.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoTK.Location = new System.Drawing.Point(38, 229);
            this.btnTaoTK.Name = "btnTaoTK";
            this.btnTaoTK.Size = new System.Drawing.Size(328, 59);
            this.btnTaoTK.TabIndex = 0;
            this.btnTaoTK.Text = "TẠO TÀI KHOẢN";
            this.btnTaoTK.UseVisualStyleBackColor = false;
            this.btnTaoTK.Click += new System.EventHandler(this.btnTaoTK_Click);
            // 
            // txtMoKhoa
            // 
            this.txtMoKhoa.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoKhoa.Location = new System.Drawing.Point(215, 329);
            this.txtMoKhoa.Name = "txtMoKhoa";
            this.txtMoKhoa.Size = new System.Drawing.Size(151, 29);
            this.txtMoKhoa.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Silver;
            this.btnBack.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(12, 6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(74, 31);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(409, 386);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtMoKhoa);
            this.Controls.Add(this.btnTaoTK);
            this.Controls.Add(this.btnMoKhoa);
            this.Controls.Add(this.btnInLai);
            this.Controls.Add(this.btnInBarcode);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_FormClosing);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInBarcode;
        private System.Windows.Forms.Button btnInLai;
        private System.Windows.Forms.Button btnMoKhoa;
        private System.Windows.Forms.Button btnTaoTK;
        private System.Windows.Forms.TextBox txtMoKhoa;
        private System.Windows.Forms.Button btnBack;
    }
}
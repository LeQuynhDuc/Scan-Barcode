using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET;
namespace ChươngTrinhInBarcode
{
    public partial class checkVersion : Form
    {
        public checkVersion()
        {
            InitializeComponent();
        }

        private void checkVersion_Load(object sender, EventArgs e)
        {
                     
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            TestLogincs dd = new TestLogincs();
            this.Hide();
            dd.Show();           
        }
        private void checkVersion_FormClosing(object sender, FormClosingEventArgs e)
        {
           
           Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Muốn Lấy File Cài Đặt Vui Lòng Truy Cập Đường Dẫn Trong Máy Tính : 'C:\\FILE_CAI_INTEMBARCODE'\n" +
                "Sau Đó Giải Nén File Debug.zip ra\n"+"Tìm Đến File 'ChuongTrinhInbarcode.exe' Và Chạy File Lên\n\n"+"LƯU Ý :=> Nếu đã làm xong những thao tác trên mà vẫn không chạy được : Vui Lòng Báo Lên IT!");
            Application.Exit();
        }
    }
}

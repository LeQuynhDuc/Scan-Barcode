using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChươngTrinhInBarcode
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        string sql33 = "Data Source= 198.1.10.33; Initial Catalog= erp;User ID= kendakv2;Password= kenda123;";
        string sql34 = "Data Source= 198.1.10.34; Initial Catalog= erp;User ID= kendakv2;Password= kenda123;";
        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
            InBarcode BR = new InBarcode();
            BR.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            if(BienTam.reprint == "Y" && BienTam.full_control == "Y")
            { }
            else if(BienTam.reprint == "Y" && BienTam.full_control == "N")
            {
                btnMoKhoa.Visible = false;
                btnTaoTK.Visible = false;
                txtMoKhoa.Visible = false;

            } 
            else if(BienTam.reprint == "N" && BienTam.full_control == "N")
            {
                btnInLai.Visible = false;
                btnMoKhoa.Visible = false;
                btnTaoTK.Visible = false;
                txtMoKhoa.Visible = false;
            }
            else
            {
                btnInLai.Visible = false;
                btnMoKhoa.Visible = false;
                btnTaoTK.Visible = false;
                txtMoKhoa.Visible = false;
            }    
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Visible = false;
            TestLogincs lg = new TestLogincs();
            lg.Show();
                    }

        private void btnInLai_Click(object sender, EventArgs e)
        {
            Visible = false;
            In_Lai IL = new In_Lai();
            IL.Show();
            
        }

        private void btnMoKhoa_Click(object sender, EventArgs e)
        {
            string update_wrong = "Update User_Inbarcode set wrong = 0 where name ='" + txtMoKhoa.Text.Trim() + "'";
            bool dt = Conn.ExecuteNonQuery(sql34, update_wrong);
            if (!dt)
            {
                MessageBox.Show("Chưa Update được!");
                return;
            }
            else
            {
                MessageBox.Show("Đã Mở Khóa ");
                return;
            }    
        }

        private void btnTaoTK_Click(object sender, EventArgs e)
        {
            TaoTK TK = new TaoTK();
            Visible = false;
            TK.Show();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            Application.Exit();
        }
    }
}

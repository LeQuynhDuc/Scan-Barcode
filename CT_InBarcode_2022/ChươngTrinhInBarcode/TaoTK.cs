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
    public partial class TaoTK : Form
    {
        public TaoTK()
        {
            InitializeComponent();
            txtName.Focus();
            cb_fullcontrol.SelectedIndex = 1;
            cb_reprint.SelectedIndex = 1;
        }
        DataTable dt = new DataTable();
        bool dt1;
        string sql33 = "Data Source= 198.1.10.33; Initial Catalog= erp;User ID= kendakv2;Password= kenda123;";
        string sql34 = "Data Source= 198.1.10.34; Initial Catalog= erp;User ID= kendakv2;Password= kenda123;";
        private void btnBack_Click(object sender, EventArgs e)
        {
            Visible = false;
            Menu mn = new Menu();
            mn.Show();
        }

        private void TaoTK_Load(object sender, EventArgs e)
        {

        }

        private void btnTaoTK_Click(object sender, EventArgs e)
        {
            string ngay = DateTime.Now.ToString("yyyyMMdd");
            string thoigian = DateTime.Now.ToString("hh:MM:ss");
            string Create = "Insert Into User_Inbarcode values('" + txtName.Text.Trim() + "','" + txtpass.Text.Trim() + "',0," + ngay + ",'" + thoigian + "','" + cb_reprint.SelectedItem.ToString() + "','" + cb_fullcontrol.SelectedItem.ToString() + "')";

            dt1 = Conn.ExecuteNonQuery(sql34, Create);
            if(!dt1)
            {
                MessageBox.Show("Tạo Tài Khoản Không Thành Công!");
                return;
            }   
            else
            {
                MessageBox.Show("Tạo Tài Khoản Thành Công!");
                return;
            }    
        }

        private void TaoTK_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            Application.Exit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET;
namespace ChươngTrinhInBarcode
{
    public partial class TestLogincs : Form
    {
        public TestLogincs()
        {
            InitializeComponent();
            cbUser.SelectedIndex = 0;
        }
       
        string sql33 = "Data Source= 198.1.10.33; Initial Catalog= erp;User ID= kendakv2;Password= kenda123;";
        string sql34 = "Data Source= 198.1.10.34;Initial Catalog= erp;User ID= kendakv2;Password= kenda123;";
      
        private void cbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbUser.SelectedItem.ToString() == "HAIHK")
            {
                txtMatKhau.Text = "";
                BienTam.name = "haihk";
            }
            if (cbUser.SelectedItem.ToString() == "VIP 1*")
            {
                BienTam.name = "conghung";
                txtMatKhau.Text = "";
                txtMatKhau.Focus();
            }
            if (cbUser.SelectedItem.ToString() == "VIP 2*")
            {
                BienTam.name = "no1";
                txtMatKhau.Text = "";
                txtMatKhau.Focus();
            }
            if (cbUser.SelectedItem.ToString() == "VIP 3*")
            {
                BienTam.name = "ducit";
                txtMatKhau.Text = "";
                txtMatKhau.Focus();
            }
            if (cbUser.SelectedItem.ToString() == "VIP 4*")
            {
                BienTam.name = "no2";
                txtMatKhau.Text = "";
                txtMatKhau.Focus();
            }
           
        }
       
        public void btnDangNhap_Click(object sender, EventArgs e)
        {
            //if (dem == 0)
            //{
            //    getversion();
                
            //}
            DataTable dt = new DataTable();
            bool dt1;
            Cursor.Current = Cursors.WaitCursor;
            if(txtMatKhau.Text == "")
            {
                MessageBox.Show("Mật Khẩu Không Được Bỏ Trống!");
                txtMatKhau.Focus();
            }
            string empno = "SELECT * FROM User_Inbarcode WHERE name ='" + BienTam.name.Trim() + "'";
            dt = Conn.ExecuteQuery(sql34, empno);
            if (BienTam.name =="no1" || BienTam.name == "no2")
            {
                MessageBox.Show("Sai Mật Khẩu!");
                txtMatKhau.Text = "";
                cbUser.SelectedIndex = 0;            
            }
            else
            {
                BienTam.wrong = dt.Rows[0]["wrong"].ToString();
                BienTam.password = dt.Rows[0]["password"].ToString();
                if (int.Parse(BienTam.wrong) >= 3)
                {
                    MessageBox.Show("Tài Khoản Của Bạn Đã Bị Khóa! Liên Hệ IT ");
                    return;
                }
                else if (txtMatKhau.Text.Trim() != BienTam.password.Trim() && BienTam.name != "ducit")
                {

                    string update_wrong = " Update User_Inbarcode set wrong = wrong + " + 1 + " where name = '" + BienTam.name.Trim() + "'";
                    dt1 = Conn.ExecuteNonQuery(sql34, update_wrong);
                    if (!dt1)
                    {
                        MessageBox.Show("Có Vấn Đề ! Liên Hệ IT \n wrong");
                        return;
                    }
                    int dem = 3 - (int.Parse(BienTam.wrong) + 1);
                    if (dem == 0)
                    {
                        MessageBox.Show("Tài Khoản Của Bạn Đã Bị Khóa Liên Hệ IT!");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Sai Mật Khẩu! Còn " + dem + " lần nữa sẽ khóa tài khoản!");
                        txtMatKhau.Text = "";
                        txtMatKhau.Focus();
                        return;
                    }

                }
                else if (BienTam.name == "ducit" && txtMatKhau.Text.Trim() != BienTam.password.Trim())
                {
                    MessageBox.Show("Sai Mật Khẩu!");
                    txtMatKhau.Text = "";
                    txtMatKhau.Focus();
                    return;
                }
                else
                {                 
                    BienTam.reprint = dt.Rows[0]["RePrint"].ToString().Trim();
                    BienTam.full_control = dt.Rows[0]["full_control"].ToString().Trim();
                    Menu inbar = new Menu();
                    inbar.Show();
                    Visible = false;
                }
            }    
        }

        public void TestLogincs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //public void getversion()
        //{
        //    System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
        //    System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
        //    AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
        //    string version = fvi.FileVersion;
        //    lblphienban.Text = "Phiên bản: " + version;
        //    AutoUpdater.DownloadPath = "update";
        //    AutoUpdater.Start("http://198.1.9.245:1271/update.xml");
        //    System.Timers.Timer timer = new System.Timers.Timer
        //    {
        //        Interval = 6*3600*1000,
        //        SynchronizingObject = this
        //    };
        //    timer.Elapsed += delegate
        //    {
        //        AutoUpdater.Start("http://198.1.9.245:1271/update.xml");
        //    };
        //    timer.Start();
           
        //}
        private void TestLogincs_Load(object sender, EventArgs e)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
            string version = fvi.FileVersion;
            lblVersion.Text = "Phiên bản: " + version;
            AutoUpdater.DownloadPath = "C:\\FILE_CAI_INTEMBARCODE";
            System.Timers.Timer timer = new System.Timers.Timer
            {
                Interval = 50 * 60 * 1000,
                SynchronizingObject = this
            };
            timer.Elapsed += delegate
            {
                AutoUpdater.Start("http://198.1.9.245:1271/Version_CT_Inbarcode/update.xml");
            };
            timer.Start();

        }
        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args.IsUpdateAvailable)
            {
                DialogResult dialogResult;
                dialogResult =
                        MessageBox.Show(
                            $@"Bạn ơi, phần mềm của bạn có phiên bản mới {args.CurrentVersion}. Phiên bản bạn đang sử dụng hiện tại  {args.InstalledVersion}. Bạn có muốn cập nhật phần mềm không?", @"Cập nhật phần mềm",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information);
                if(dialogResult.Equals(DialogResult.No))
                {
                    Application.Exit();
                }    
                if (dialogResult.Equals(DialogResult.Yes) || dialogResult.Equals(DialogResult.OK))
                {
                    try
                    {
                        if (AutoUpdater.DownloadUpdate(args))
                        {
                            this.Close();
                            Application.Exit();
                            return;
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(@"Phiên bản bạn đang sử dụng đã được cập nhật mới nhất.", @"Cập nhật phần mềm",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                timer1.Stop();              
            }
        }
     
        public void TestLogincs_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            AutoUpdater.Start("http://198.1.9.245:1271/Version_CT_Inbarcode/update.xml");
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            button2_Click(sender, e);                 
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChươngTrinhInBarcode
{
    public partial class InBarcode : Form
    {
        public InBarcode()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        string sql33 = "Data Source= 198.1.10.33;  Initial Catalog= erp;User ID= kendakv2;Password= kenda123;";
        string sql34 = "Data Source= 198.1.10.34;Initial Catalog= erp;User ID= kendakv2;Password= kenda123;";
        string sql34May = "Data Source= 198.1.10.39; Initial Catalog= erp;User ID= kendakv2;Password= kenda123;";
        DataTable dt = new DataTable();
        bool dt1;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLuuCauhinh_Click(object sender, EventArgs e)
        {
            autoclose();
            string pathfile3 = System.AppDomain.CurrentDomain.BaseDirectory + @"label";

            string line = BienTam.infors;
            using (StreamWriter sw = new StreamWriter(@"label"))
            {
                sw.WriteLine(line);
            }
            MessageBox.Show(" Lưu Thành Công!");

        }

        private void InBarcode_Load(object sender, EventArgs e)
        {

            lblTaiKhoan.Text = BienTam.name;
            timer1_Tick(sender, e);
            if (BienTam.reprint == "N" && BienTam.full_control == "N")
            {
                cbMayIn.Enabled = false;
            }
            string path1 = Directory.GetCurrentDirectory() + @"\Printer";
            if (!(File.Exists(path1)))
            {
                File.Delete(path1);
                using (FileStream fs = File.Create(path1))
                {
                    byte[] author = new UTF8Encoding(true).GetBytes("");

                    fs.Write(author, 0, author.Length);

                }
            }
            string infor1 = File.ReadAllText(path1).Trim();
            cbMayIn.Text = infor1;
            int i = 0;
            string[] sPrinterList = new string[System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count];
            if (System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count == 0)
                sPrinterList[i] = "";
            else
            {
                cbMayIn.Items.Add("");
                foreach (string printers in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {

                    sPrinterList[i] = printers;
                    i++;
                    cbMayIn.Items.Add(printers);
                }
            }
            string name = cbMayIn.Text;
            string sqlCol = "";
            string data = "";
            string L = "";
            string L2 = "";
            string U = "";
            string U2 = "";
            int n1 = 1;
            string infor = "";
            string path = Directory.GetCurrentDirectory() + @"\label";
            if (!(File.Exists(path)))
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] author = new UTF8Encoding(true).GetBytes("130,5,70,37,");
                    fs.Write(author, 0, author.Length);

                }
            }
            infor = File.ReadAllText(path).Trim();
            if (infor == "")
            {
                string lining = "130" + "," + "5" + "," + "70" + "," + "37" + ",";
                using (StreamWriter sw = new StreamWriter(@"label", true))
                {
                    sw.WriteLine(lining);
                }
            }
            infor = File.ReadAllText(path).Trim();
            for (int k = 0; k < infor.Length; k++)
            {
                sqlCol = "";
                sqlCol = "" + infor.Substring(k, 1) + "";
                data += sqlCol;
                if (sqlCol == ",")
                {
                    if (n1 == 4)
                    {
                        n1 = n1 + 1;
                        U2 = data.Replace(",", "");
                    }
                    if (n1 == 3)
                    {
                        n1 = n1 + 1;
                        L2 = data.Replace(",", "");
                    }
                    if (n1 == 2)
                    {
                        n1 = n1 + 1;
                        U = data.Replace(",", "");
                    }
                    if (n1 == 1)
                    {
                        n1 = n1 + 1;
                        L = data.Replace(",", "");
                    }

                    data = "";
                }

            }
            lblUP.Text = U.ToString() + " - " + U2.ToString();
            lbl_Down.Text = U.ToString() + " - " + U2.ToString();
            lbl_LefT.Text = L.ToString() + " - " + L2.ToString();
            lblRIGHT.Text = L.ToString() + " - " + L2.ToString();
            string lable = BienTam.setting_barcode.Replace("[L]", L).Replace("[U]", U).Replace("[L2", L2).Replace("[U2]", U2);
            BienTam.lables = lable;
            BienTam.infors = infor;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void btnright_Click(object sender, EventArgs e)
        {
            autoclose();
            int a = 0;
            int b = 0;
            string sqlCol = "";
            string data = "";
            string L = "";
            string L2 = "";
            string U = "";
            string U2 = "";
            int n1 = 1;
            string infor = BienTam.infors;
            for (int f = 0; f < infor.Length; f++)
            {
                sqlCol = "";
                sqlCol = "" + infor.Substring(f, 1) + "";
                data += sqlCol;
                if (sqlCol == ",")
                {
                    if (n1 == 4)
                    {
                        n1 = n1 + 1;
                        U2 = data.Replace(",", "");
                    }
                    if (n1 == 3)
                    {
                        n1 = n1 + 1;
                        L2 = data.Replace(",", "");
                        b = int.Parse(L2);
                    }

                    if (n1 == 2)
                    {
                        n1 = n1 + 1;
                        U = data.Replace(",", "");
                    }
                    if (n1 == 1)
                    {
                        n1 = n1 + 1;
                        L = data.Replace(",", "");
                        a = int.Parse(L);
                    }
                    data = "";
                }
            }
            if (a > 0)
            {
                pictureBox1.Left += 1;
                a = a + 1;
                b = b + 1;
            }

            lblRIGHT.Text = a.ToString() + "-" + b.ToString();
            lbl_LefT.Text = a.ToString() + "-" + b.ToString();
            lblUP.Text = U + "-" + U2;
            lbl_Down.Text = U + "-" + U2;
            string line = "" + a + "" + "," + "" + U + "" + "," + "" + b + "" + "," + "" + U2 + "" + ",";
            BienTam.infors = line;
        }


        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
            Menu mn = new Menu();
            mn.Show();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Ping p1 = new Ping();
                PingReply PR = p1.Send("198.1.10.34");
                if (PR.Status == IPStatus.Success)
                {
                    btnIn.Visible = true;
                    lblKetNoi.Text = "Kết Nối OK!";
                    lblKetNoi.ForeColor = Color.Black;
                }
                if (PR.Status != IPStatus.Success)
                {
                    lblKetNoi.Text = "mất kết nối! 10.34";
                    btnIn.Visible = false;
                    lblKetNoi.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            { }
        }
        public void txtMaThanhPham_TextChanged(object sender, EventArgs e)
        {
            btnIn.Enabled = true;
            autoclose();
            txtMaThanhPham.MaxLength = 8;
            if (txtMaThanhPham.Text.Length == 8)
            {
                cbNhaMay.SelectedIndex = 0;
                txtsodau.Text = BienTam.year;
                string sql = "select itnbr, itdsc FROM invmas wHERE itnbr = '" + txtMaThanhPham.Text.Trim() + "'";
                dt = Conn.ExecuteQuery(sql34, sql);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Mã Thành Phẩm Sai!");
                    cbNhaMay.Text = "";
                    txtsodau.Text = "";
                    txtMaThanhPham.Text = "";
                    txtSTT.Text = "";
                    txtSoCuoi.Text = "";
                    txtstdc.Text = "";
                    txtMaThanhPham.Focus();
                    return;
                }
              
              
                string invmas = dt.Rows[0]["itnbr"].ToString().Trim(); //  Mã Thành Phẩm
                string itsdc = dt.Rows[0]["itdsc"].ToString().Trim();
                string sqlcount_Itnbr = "select count(slipno) as soluong, ptime from prdbat where pdate ='" + DateTime.Now.ToString("yyyyMMdd").Trim() + "' and slipno LIKE '%" + invmas + "%' group by ptime order by ptime desc";
                DataTable dtcount = new DataTable();
                dtcount = Conn.ExecuteQuery(sql34, sqlcount_Itnbr);
                if (dtcount.Rows.Count == 0)
                { }
                else
                {
                    DialogResult RS = MessageBox.Show("Mã Thành Phẩm Này Đã In Được " + dtcount.Rows[0]["soluong"].ToString().Trim() + " Tem Vào Lúc " + dtcount.Rows[0]["ptime"].ToString().Trim() + "! Bạn Có Muốn In Tiếp Không???", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (RS == DialogResult.Cancel)
                    {
                        Application.Exit();
                        return;
                    }
                }
                BienTam.invmas = invmas;
                BienTam.itdsc = itsdc;
                // check invmat nếu modsta không có Thông Báo "Mã Này Không Được Sản Xuất"
                #region check table invmat  
                DataTable dt_invmas = new DataTable();
                string modsta = "";
                string invmat = "select modsta from invmat where itnbr = '" + invmas + "'";
                dt_invmas = Conn.ExecuteQuery(sql34, invmat);
                if(dt_invmas.Rows.Count == 0)
                {
                    MessageBox.Show("Mã Thành Phẩm '"+ txtMaThanhPham.Text.Trim()+"' Này Không Có Trong Hệ Thống! Liên Hệ IT!\ninvmat");
                    txtMaThanhPham.Text = "";
                    btnIn.Enabled = false;
                    return;
                }
                else
                {
                    modsta = dt_invmas.Rows[0]["modsta"].ToString().Trim();
                    if(modsta == "N")
                    {
                        MessageBox.Show("Mã Thành Phẩm '" + txtMaThanhPham.Text.Trim() + "' Này Không Được Sản Xuất!\ninvmat");
                        txtMaThanhPham.Text = "";
                        btnIn.Enabled = false;
                        return;
                    }    
                }                
                #endregion
                xulikitubarcode();
                txtSoLuong.Focus();
            }
            else
            {
                cbNhaMay.Text = "";
                txtsodau.Text = "";
                txtSoCuoi.Text = "";
                txtSoLuong.Text = "";
                txtSTT.Text = "";
                txtstdc.Text = "";
            }
        }
        public void xulikitubarcode()
        {

            string barcode_tem = "";
            int value;

            int dem = 0;
            if (!(int.TryParse(txtMaThanhPham.Text, out value)))
            {
                string tong;

                foreach (var item in txtMaThanhPham.Text)
                {
                    switch (Convert.ToString(item))
                    {
                        case "0": tong = "0"; dem += int.Parse(tong); break;
                        case "1": tong = "1"; dem += int.Parse(tong); break;
                        case "2": tong = "2"; dem += int.Parse(tong); break;
                        case "3": tong = "3"; dem += int.Parse(tong); break;
                        case "4": tong = "4"; dem += int.Parse(tong); break;
                        case "5": tong = "5"; dem += int.Parse(tong); break;
                        case "6": tong = "6"; dem += int.Parse(tong); break;
                        case "7": tong = "7"; dem += int.Parse(tong); break;
                        case "8": tong = "8"; dem += int.Parse(tong); break;
                        case "9": tong = "9"; dem += int.Parse(tong); break;
                        case "A": tong = "10"; dem += int.Parse(tong); break;
                        case "B": tong = "11"; dem += int.Parse(tong); break;
                        case "C": tong = "12"; dem += int.Parse(tong); break;
                        case "D": tong = "13"; dem += int.Parse(tong); break;
                        case "E": tong = "14"; dem += int.Parse(tong); break;
                        case "F": tong = "15"; dem += int.Parse(tong); break;
                        case "G": tong = "16"; dem += int.Parse(tong); break;
                        case "H": tong = "17"; dem += int.Parse(tong); break;
                        case "I": tong = "18"; dem += int.Parse(tong); break;
                        case "J": tong = "19"; dem += int.Parse(tong); break;
                        case "K": tong = "20"; dem += int.Parse(tong); break;
                        case "L": tong = "21"; dem += int.Parse(tong); break;
                        case "M": tong = "22"; dem += int.Parse(tong); break;
                        case "N": tong = "23"; dem += int.Parse(tong); break;
                        case "O": tong = "24"; dem += int.Parse(tong); break;
                        case "P": tong = "25"; dem += int.Parse(tong); break;
                        case "Q": tong = "26"; dem += int.Parse(tong); break;
                        case "R": tong = "27"; dem += int.Parse(tong); break;
                        case "S": tong = "28"; dem += int.Parse(tong); break;
                        case "T": tong = "29"; dem += int.Parse(tong); break;
                        case "U": tong = "30"; dem += int.Parse(tong); break;
                        case "V": tong = "31"; dem += int.Parse(tong); break;
                        case "W": tong = "32"; dem += int.Parse(tong); break;
                        case "X": tong = "33"; dem += int.Parse(tong); break;
                        case "Y": tong = "34"; dem += int.Parse(tong); break;
                        case "Z": tong = "35"; dem += int.Parse(tong); break;

                        case "a": tong = "10"; dem += int.Parse(tong); break;
                        case "b": tong = "11"; dem += int.Parse(tong); break;
                        case "c": tong = "12"; dem += int.Parse(tong); break;
                        case "d": tong = "13"; dem += int.Parse(tong); break;
                        case "e": tong = "14"; dem += int.Parse(tong); break;
                        case "f": tong = "15"; dem += int.Parse(tong); break;
                        case "g": tong = "16"; dem += int.Parse(tong); break;
                        case "h": tong = "17"; dem += int.Parse(tong); break;
                        case "i": tong = "18"; dem += int.Parse(tong); break;
                        case "j": tong = "19"; dem += int.Parse(tong); break;
                        case "k": tong = "20"; dem += int.Parse(tong); break;
                        case "l": tong = "21"; dem += int.Parse(tong); break;
                        case "m": tong = "22"; dem += int.Parse(tong); break;
                        case "n": tong = "23"; dem += int.Parse(tong); break;
                        case "o": tong = "24"; dem += int.Parse(tong); break;
                        case "p": tong = "25"; dem += int.Parse(tong); break;
                        case "q": tong = "26"; dem += int.Parse(tong); break;
                        case "r": tong = "27"; dem += int.Parse(tong); break;
                        case "s": tong = "28"; dem += int.Parse(tong); break;
                        case "t": tong = "29"; dem += int.Parse(tong); break;
                        case "u": tong = "30"; dem += int.Parse(tong); break;
                        case "v": tong = "31"; dem += int.Parse(tong); break;
                        case "w": tong = "32"; dem += int.Parse(tong); break;
                        case "x": tong = "33"; dem += int.Parse(tong); break;
                        case "y": tong = "34"; dem += int.Parse(tong); break;
                        case "z": tong = "35"; dem += int.Parse(tong); break;

                    }

                }
                BienTam.tongitnbr = dem;
            }
            else
            {

                foreach (var item in txtMaThanhPham.Text)
                {
                    string its = Convert.ToString(item);
                    dem += int.Parse(its);
                }
                BienTam.tongitnbr = dem;
            }
            string sn = "";
            string sd;
            string sodau = "";
            string sothuhai = "";
            string d = "";
            string sql_prdbat = "select max(sn) as number from prdbat where slipno like '%" + BienTam.invmas + "%' and pdate like '" + DateTime.Now.ToString("yyyy") + "%'";
            dt = Conn.ExecuteQuery(sql34, sql_prdbat); //FIX
            string num = dt.Rows[0]["number"].ToString().Trim();
            if (num == "" || num == null || num == "0")
            {
                sn = "00001";
                d = "1";
            }
            else
            {
               
                d = (int.Parse(dt.Rows[0]["number"].ToString()) + 1).ToString("00000");
                int sn1 = int.Parse(d);
                if (sn1 > 1295999)
                {
                    MessageBox.Show("Đã Vượt Qua giới Hạn Intem!Vui lòng Gọi IT");
                    return;
                }

                int x = ((sn1 - (sn1 % 1000)) / 1000) % 36; // số thu 2
                int x1 = (sn1 / 1000) / 36; // số thứ 1  
                int b = sn1 % 1000; // đuôi phần sau
                string f = b.ToString("000"); // đuôi phần sau hoàn chỉnh                                            
                #region dem so dau
                switch (x1)
                {
                    case 0: sodau = "0"; break;
                    case 1: sodau = "1"; break;
                    case 2: sodau = "2"; break;
                    case 3: sodau = "3"; break;
                    case 4: sodau = "4"; break;
                    case 5: sodau = "5"; break;
                    case 6: sodau = "6"; break;
                    case 7: sodau = "7"; break;
                    case 8: sodau = "8"; break;
                    case 9: sodau = "9"; break;
                    case 10: sodau = "A"; break;
                    case 11: sodau = "B"; break;
                    case 12: sodau = "C"; break;
                    case 13: sodau = "D"; break;
                    case 14: sodau = "E"; break;
                    case 15: sodau = "F"; break;
                    case 16: sodau = "G"; break;
                    case 17: sodau = "H"; break;
                    case 18: sodau = "I"; break;
                    case 19: sodau = "J"; break;
                    case 20: sodau = "K"; break;
                    case 21: sodau = "L"; break;
                    case 22: sodau = "M"; break;
                    case 23: sodau = "N"; break;
                    case 24: sodau = "O"; break;
                    case 25: sodau = "P"; break;
                    case 26: sodau = "Q"; break;
                    case 27: sodau = "R"; break;
                    case 28: sodau = "S"; break;
                    case 29: sodau = "T"; break;
                    case 30: sodau = "U"; break;
                    case 31: sodau = "V"; break;
                    case 32: sodau = "W"; break;
                    case 33: sodau = "X"; break;
                    case 34: sodau = "Y"; break;
                    case 35: sodau = "Z"; break;
                }
                #endregion
                #region dem so thu hai
                switch (x)
                {
                    case 0: sothuhai = "0"; break;
                    case 1: sothuhai = "1"; break;
                    case 2: sothuhai = "2"; break;
                    case 3: sothuhai = "3"; break;
                    case 4: sothuhai = "4"; break;
                    case 5: sothuhai = "5"; break;
                    case 6: sothuhai = "6"; break;
                    case 7: sothuhai = "7"; break;
                    case 8: sothuhai = "8"; break;
                    case 9: sothuhai = "9"; break;
                    case 10: sothuhai = "A"; break;
                    case 11: sothuhai = "B"; break;
                    case 12: sothuhai = "C"; break;
                    case 13: sothuhai = "D"; break;
                    case 14: sothuhai = "E"; break;
                    case 15: sothuhai = "F"; break;
                    case 16: sothuhai = "G"; break;
                    case 17: sothuhai = "H"; break;
                    case 18: sothuhai = "I"; break;
                    case 19: sothuhai = "J"; break;
                    case 20: sothuhai = "K"; break;
                    case 21: sothuhai = "L"; break;
                    case 22: sothuhai = "M"; break;
                    case 23: sothuhai = "N"; break;
                    case 24: sothuhai = "O"; break;
                    case 25: sothuhai = "P"; break;
                    case 26: sothuhai = "Q"; break;
                    case 27: sothuhai = "R"; break;
                    case 28: sothuhai = "S"; break;
                    case 29: sothuhai = "T"; break;
                    case 30: sothuhai = "U"; break;
                    case 31: sothuhai = "V"; break;
                    case 32: sothuhai = "W"; break;
                    case 33: sothuhai = "X"; break;
                    case 34: sothuhai = "Y"; break;
                    case 35: sothuhai = "Z"; break;
                        #endregion                     
                }
                sn = (sodau + sothuhai + f).ToString();
                sn = string.Format("{0:#####}", sn);
            }

            txtSTT.Text = sn;
            int tongSN = 0;
            foreach (var item in d)
            {
                string it = Convert.ToString(item);
                tongSN += int.Parse(it);

            }
            decimal chisocuoicung = (BienTam.numberFirst + BienTam.tongitnbr + tongSN) % 36;

            string barcode = "7" + BienTam.year + BienTam.invmas.ToUpper() + sn;
            switch (chisocuoicung)
            {
                case 0: barcode = barcode + "0"; break;
                case 1: barcode = barcode + "1"; break;
                case 2: barcode = barcode + "2"; break;
                case 3: barcode = barcode + "3"; break;
                case 4: barcode = barcode + "4"; break;
                case 5: barcode = barcode + "5"; break;
                case 6: barcode = barcode + "6"; break;
                case 7: barcode = barcode + "7"; break;
                case 8: barcode = barcode + "8"; break;
                case 9: barcode = barcode + "9"; break;
                case 10: barcode = barcode + "A"; break;
                case 11: barcode = barcode + "B"; break;
                case 12: barcode = barcode + "C"; break;
                case 13: barcode = barcode + "D"; break;
                case 14: barcode = barcode + "E"; break;
                case 15: barcode = barcode + "F"; break;
                case 16: barcode = barcode + "G"; break;
                case 17: barcode = barcode + "H"; break;
                case 18: barcode = barcode + "I"; break;
                case 19: barcode = barcode + "J"; break;
                case 20: barcode = barcode + "K"; break;
                case 21: barcode = barcode + "L"; break;
                case 22: barcode = barcode + "M"; break;
                case 23: barcode = barcode + "N"; break;
                case 24: barcode = barcode + "O"; break;
                case 25: barcode = barcode + "P"; break;
                case 26: barcode = barcode + "Q"; break;
                case 27: barcode = barcode + "R"; break;
                case 28: barcode = barcode + "S"; break;
                case 29: barcode = barcode + "T"; break;
                case 30: barcode = barcode + "U"; break;
                case 31: barcode = barcode + "V"; break;
                case 32: barcode = barcode + "W"; break;
                case 33: barcode = barcode + "X"; break;
                case 34: barcode = barcode + "Y"; break;
                case 35: barcode = barcode + "Z"; break;

            }
            txtstdc.Text = txtMaThanhPham.Text.Trim() + " - " + BienTam.itdsc;
            txtSoCuoi.Text = barcode.Substring(15, 1);
            BienTam.barcode = barcode; /// Lưu Barcode
            if (barcode == barcode_tem)
            {
                BienTam.error = BienTam.error + 1;
                Error_Barcode();
            }
            barcode_tem = barcode;
        }

        private void cbMayIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMayIn.Text == "")
            {
                cbMayIn.Text = "Chọn máy in";
                return;
            }
            else
            {
                string names = cbMayIn.Text;
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"" + "Printer"))
                {
                    sw.WriteLine(cbMayIn.Text);

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            autoclose();
            string pathfile3 = System.AppDomain.CurrentDomain.BaseDirectory + @"label";

            string line = "130,5,70,37,";
            using (StreamWriter sw = new StreamWriter(@"label"))
            {
                sw.WriteLine(line);
            }
            MessageBox.Show("Reset OK!!");
            InBarcode_Load(sender, e);
            pictureBox1.Left = 130;
            pictureBox1.Top = 15;
        }

        private void InBarcode_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Dispose();
            timer2.Dispose();
            Application.Exit();
        }
        public void autoclose()
        {
            timer2.Enabled = false;
            //  timer2.Interval = 300000;
            timer2.Start();

        }
        private void btnup_Click(object sender, EventArgs e)
        {
            autoclose();
            int a = 0;
            int b = 0;
            string sqlCol = "";
            string data = "";
            string L = "";
            string L2 = "";
            string U = "";
            string U2 = "";
            int n1 = 1;
            string infor = BienTam.infors;
            for (int f = 0; f < infor.Length; f++)
            {
                sqlCol = "";
                sqlCol = "" + infor.Substring(f, 1) + "";
                data += sqlCol;
                if (sqlCol == ",")
                {
                    if (n1 == 4)
                    {
                        n1 = n1 + 1;
                        U2 = data.Replace(",", "");
                        b = int.Parse(U2);
                        if (a > 0)
                        {
                            b = b - 1;

                        }
                        if (a == 0)
                        {
                            b = 27;
                        }
                    }
                    if (n1 == 3)
                    {
                        n1 = n1 + 1;
                        L2 = data.Replace(",", "");


                    }

                    if (n1 == 2)
                    {
                        n1 = n1 + 1;
                        U = data.Replace(",", "");
                        a = int.Parse(U);
                        if (a > 0)
                        {
                            a = a - 1;
                        }
                        if (a == 0)
                        {
                            a = 0;
                        }
                    }
                    if (n1 == 1)
                    {
                        n1 = n1 + 1;
                        L = data.Replace(",", "");
                    }
                    data = "";
                }
            }
            if (a > 0)
            {
                pictureBox1.Top -= 1;
            }
            else
            {
                pictureBox1.Top = 0;
            }
            lblUP.Text = a.ToString() + "-" + b.ToString();
            lbl_Down.Text = a.ToString() + "-" + b.ToString();
            lbl_LefT.Text = L + "-" + L2;
            lblRIGHT.Text = L + "-" + L2;
            string line = "" + L + "" + "," + "" + a + "" + "," + "" + L2 + "" + "," + "" + b + "" + ",";
            BienTam.infors = line;
        }

        private void btndown_Click(object sender, EventArgs e)
        {
            autoclose();
            int a = 0;
            int b = 0;
            string sqlCol = "";
            string data = "";
            string L = "";
            string L2 = "";
            string U = "";
            string U2 = "";
            int n1 = 1;
            string infor = BienTam.infors;
            for (int f = 0; f < infor.Length; f++)
            {
                sqlCol = "";
                sqlCol = "" + infor.Substring(f, 1) + "";
                data += sqlCol;
                if (sqlCol == ",")
                {
                    if (n1 == 4)
                    {
                        n1 = n1 + 1;
                        U2 = data.Replace(",", "");
                        b = int.Parse(U2);
                        b = b + 1;
                    }
                    if (n1 == 3)
                    {
                        n1 = n1 + 1;
                        L2 = data.Replace(",", "");
                    }

                    if (n1 == 2)
                    {
                        n1 = n1 + 1;
                        U = data.Replace(",", "");
                        a = int.Parse(U);
                        a = a + 1;
                    }
                    if (n1 == 1)
                    {
                        n1 = n1 + 1;
                        L = data.Replace(",", "");
                    }
                    data = "";
                }
            }
            if (a > 0)
            {
                pictureBox1.Top += 1;
            }
            else
            {
                pictureBox1.Top = 0;
            }
            lblUP.Text = a.ToString() + "-" + b.ToString();
            lbl_Down.Text = a.ToString() + "-" + b.ToString();
            lbl_LefT.Text = L + "-" + L2;
            lblRIGHT.Text = L + "-" + L2;
            string line = "" + L + "" + "," + "" + a + "" + "," + "" + L2 + "" + "," + "" + b + "" + ",";
            BienTam.infors = line;

        }

        private void btnleft_Click(object sender, EventArgs e)
        {
            autoclose();
            int a = 0;
            int b = 0;
            string sqlCol = "";
            string data = "";
            string L = "";
            string L2 = "";
            string U = "";
            string U2 = "";
            int n1 = 1;
            string infor = BienTam.infors;
            for (int f = 0; f < infor.Length; f++)
            {
                sqlCol = "";
                sqlCol = "" + infor.Substring(f, 1) + "";
                data += sqlCol;
                if (sqlCol == ",")
                {
                    if (n1 == 4)
                    {
                        n1 = n1 + 1;
                        U2 = data.Replace(",", "");
                    }
                    if (n1 == 3)
                    {
                        n1 = n1 + 1;
                        L2 = data.Replace(",", "");
                        b = int.Parse(L2);
                    }

                    if (n1 == 2)
                    {
                        n1 = n1 + 1;
                        U = data.Replace(",", "");
                    }
                    if (n1 == 1)
                    {
                        n1 = n1 + 1;
                        L = data.Replace(",", "");
                        a = int.Parse(L);
                    }
                    data = "";
                }
            }
            if (b > 0)
            {
                pictureBox1.Left -= 1;
                a = a - 1;
                b = b - 1;
            }
            else
            {
                pictureBox1.Left = 0;
                a = 85;
                b = 0;
            }
            lblRIGHT.Text = a.ToString() + "-" + b.ToString();
            lbl_LefT.Text = a.ToString() + "-" + b.ToString();
            lblUP.Text = U + "-" + U2;
            lbl_Down.Text = U + "-" + U2;
            string line = "" + a + "" + "," + "" + U + "" + "," + "" + b + "" + "," + "" + U2 + "" + ",";
            BienTam.infors = line;
        }
        public void Error_Barcode()
        {
            if (BienTam.error == 1)
            {
                MessageBox.Show("Lỗi !!! Gọi It - 702");
                lblghichu.Text = "Lỗi !!! Kết Nối";
                using (StreamWriter sw = new StreamWriter(@"" + "Logs", true))
                {
                    sw.WriteLine("- lỗi in barcode! " + DateTime.Now.ToString() + '*' + BienTam.barcode + '*' + Environment.NewLine);
                }
                return;
            }

        }
        public void btnIn_Click(object sender, EventArgs e)
        {
            //  string barcode_tem = "";
            autoclose();
            string year = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
            string time = year.Substring(9, 8);
            string year1 = year.Substring(0, 8);
            string sqlCol = "";
            string data = "";
            string L = "";
            string L2 = "";
            string U = "";
            string U2 = "";
            int n1 = 1;
            string sn = "";
            string sql_prdbat;
            string sn_p;
            int SN_p;
            int tongSN = 0;
            string it;
            decimal chisocuoicung;
            string barcode;
            string sql_Insert;
            int x = 0;
            bool print;
            string LABEL;
            string bt = BienTam.infors;
            if (BienTam.infors != "")
            {
                for (int k = 0; k < BienTam.infors.Length; k++)
                {
                    sqlCol = "";
                    sqlCol = "" + BienTam.infors.Substring(k, 1) + "";
                    data += sqlCol;
                    if (sqlCol == ",")
                    {
                        if (n1 == 4)
                        {
                            n1 = n1 + 1;
                            U2 = data.Replace(",", "");
                        }
                        if (n1 == 3)
                        {
                            n1 = n1 + 1;
                            L2 = data.Replace(",", "");

                        }
                        if (n1 == 2)
                        {
                            n1 = n1 + 1;
                            U = data.Replace(",", "");
                        }
                        if (n1 == 1)
                        {
                            n1 = n1 + 1;
                            L = data.Replace(",", "");
                        }
                        data = "";
                    }
                }
            }

            string labels = BienTam.setting_barcode.Replace("[L]", L).Replace("[U]", U).Replace("[L2]", L2).Replace("[U2]", U2);
            BienTam.labels = labels;
            int sl = Convert.ToInt32(txtSoLuong.Text);
            DataTable dt = new DataTable();
            bool dtt = false;
            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Chưa Nhập Số Lượng ");
                txtSoLuong.Focus();
                return;
            }
            if (cbMayIn.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng kiểm tra  máy in!");
                return;
            }
            for (int i = 1; i <= sl; i++)
            {
                if (txtMaThanhPham.Text.Length < 8)
                {
                    MessageBox.Show("Mã Thành Phẩm Sai!");
                    return;
                }

                #region Xuất Kí Tự Barcode-----------------------------------------------------------------------------------------                                   
                string sd;
                string sodau = "";
                string sothuhai = "";
                string d = "";
                
                sql_prdbat = "select max(sn) as number from prdbat where slipno like '%" + BienTam.invmas + "%' and pdate like '" + DateTime.Now.ToString("yyyy") + "%'";
                dt = Conn.ExecuteQuery(sql34, sql_prdbat); //FIX
                string dem = dt.Rows[0]["number"].ToString().Trim();
                if (dem == "" || dem == null || dem == "0")
                {
                    sn = "00001";
                    d = "1";
                }
                else
                {
                    d = (int.Parse(dt.Rows[0]["number"].ToString()) + 1).ToString("00000");
                    int sn1 = int.Parse(d);
                    if (sn1 > 1295999)
                    {
                        MessageBox.Show("Đã Vượt Qua giới Hạn Intem!Vui lòng Gọi IT");
                        return;
                    }

                    int x2 = ((sn1 - (sn1 % 1000)) / 1000) % 36; // số thu 2
                    int x1 = (sn1 / 1000) / 36; // số thứ 1  
                    int b = sn1 % 1000; // đuôi phần sau
                    string f = b.ToString("000"); // đuôi phần sau hoàn chỉnh                                            
                    #region dem so dau
                    switch (x1)
                    {
                        case 0: sodau = "0"; break;
                        case 1: sodau = "1"; break;
                        case 2: sodau = "2"; break;
                        case 3: sodau = "3"; break;
                        case 4: sodau = "4"; break;
                        case 5: sodau = "5"; break;
                        case 6: sodau = "6"; break;
                        case 7: sodau = "7"; break;
                        case 8: sodau = "8"; break;
                        case 9: sodau = "9"; break;
                        case 10: sodau = "A"; break;
                        case 11: sodau = "B"; break;
                        case 12: sodau = "C"; break;
                        case 13: sodau = "D"; break;
                        case 14: sodau = "E"; break;
                        case 15: sodau = "F"; break;
                        case 16: sodau = "G"; break;
                        case 17: sodau = "H"; break;
                        case 18: sodau = "I"; break;
                        case 19: sodau = "J"; break;
                        case 20: sodau = "K"; break;
                        case 21: sodau = "L"; break;
                        case 22: sodau = "M"; break;
                        case 23: sodau = "N"; break;
                        case 24: sodau = "O"; break;
                        case 25: sodau = "P"; break;
                        case 26: sodau = "Q"; break;
                        case 27: sodau = "R"; break;
                        case 28: sodau = "S"; break;
                        case 29: sodau = "T"; break;
                        case 30: sodau = "U"; break;
                        case 31: sodau = "V"; break;
                        case 32: sodau = "W"; break;
                        case 33: sodau = "X"; break;
                        case 34: sodau = "Y"; break;
                        case 35: sodau = "Z"; break;
                    }
                    #endregion
                    #region dem so thu hai
                    switch (x2)
                    {
                        case 0: sothuhai = "0"; break;
                        case 1: sothuhai = "1"; break;
                        case 2: sothuhai = "2"; break;
                        case 3: sothuhai = "3"; break;
                        case 4: sothuhai = "4"; break;
                        case 5: sothuhai = "5"; break;
                        case 6: sothuhai = "6"; break;
                        case 7: sothuhai = "7"; break;
                        case 8: sothuhai = "8"; break;
                        case 9: sothuhai = "9"; break;
                        case 10: sothuhai = "A"; break;
                        case 11: sothuhai = "B"; break;
                        case 12: sothuhai = "C"; break;
                        case 13: sothuhai = "D"; break;
                        case 14: sothuhai = "E"; break;
                        case 15: sothuhai = "F"; break;
                        case 16: sothuhai = "G"; break;
                        case 17: sothuhai = "H"; break;
                        case 18: sothuhai = "I"; break;
                        case 19: sothuhai = "J"; break;
                        case 20: sothuhai = "K"; break;
                        case 21: sothuhai = "L"; break;
                        case 22: sothuhai = "M"; break;
                        case 23: sothuhai = "N"; break;
                        case 24: sothuhai = "O"; break;
                        case 25: sothuhai = "P"; break;
                        case 26: sothuhai = "Q"; break;
                        case 27: sothuhai = "R"; break;
                        case 28: sothuhai = "S"; break;
                        case 29: sothuhai = "T"; break;
                        case 30: sothuhai = "U"; break;
                        case 31: sothuhai = "V"; break;
                        case 32: sothuhai = "W"; break;
                        case 33: sothuhai = "X"; break;
                        case 34: sothuhai = "Y"; break;
                        case 35: sothuhai = "Z"; break;
                            #endregion
                    }
                    sn = (sodau + sothuhai + f).ToString();
                    sn = string.Format("{0:#####}", sn);
                }
                foreach (var item in d)
                {
                    it = Convert.ToString(item);
                    tongSN += int.Parse(it);

                }
                chisocuoicung = (BienTam.numberFirst + BienTam.tongitnbr + tongSN) % 36;
                barcode = "7" + BienTam.year + BienTam.invmas.ToUpper() + sn;
                switch (chisocuoicung)
                {
                    case 0: barcode = barcode + "0"; break;
                    case 1: barcode = barcode + "1"; break;
                    case 2: barcode = barcode + "2"; break;
                    case 3: barcode = barcode + "3"; break;
                    case 4: barcode = barcode + "4"; break;
                    case 5: barcode = barcode + "5"; break;
                    case 6: barcode = barcode + "6"; break;
                    case 7: barcode = barcode + "7"; break;
                    case 8: barcode = barcode + "8"; break;
                    case 9: barcode = barcode + "9"; break;
                    case 10: barcode = barcode + "A"; break;
                    case 11: barcode = barcode + "B"; break;
                    case 12: barcode = barcode + "C"; break;
                    case 13: barcode = barcode + "D"; break;
                    case 14: barcode = barcode + "E"; break;
                    case 15: barcode = barcode + "F"; break;
                    case 16: barcode = barcode + "G"; break;
                    case 17: barcode = barcode + "H"; break;
                    case 18: barcode = barcode + "I"; break;
                    case 19: barcode = barcode + "J"; break;
                    case 20: barcode = barcode + "K"; break;
                    case 21: barcode = barcode + "L"; break;
                    case 22: barcode = barcode + "M"; break;
                    case 23: barcode = barcode + "N"; break;
                    case 24: barcode = barcode + "O"; break;
                    case 25: barcode = barcode + "P"; break;
                    case 26: barcode = barcode + "Q"; break;
                    case 27: barcode = barcode + "R"; break;
                    case 28: barcode = barcode + "S"; break;
                    case 29: barcode = barcode + "T"; break;
                    case 30: barcode = barcode + "U"; break;
                    case 31: barcode = barcode + "V"; break;
                    case 32: barcode = barcode + "W"; break;
                    case 33: barcode = barcode + "X"; break;
                    case 34: barcode = barcode + "Y"; break;
                    case 35: barcode = barcode + "Z"; break;

                }
                if (barcode == BienTam.barcode_tem)
                {
                    BienTam.error = BienTam.error + 1;
                    Error_Barcode();
                }
                BienTam.barcode_tem = barcode;
                #endregion

                sql_Insert = "Insert Into prdbat Values('7','" + BienTam.barcode_tem.Trim() + "','" + year1.Substring(0, 8).Trim() + "','" + time.Trim() + "','" + BienTam.name.Trim() + "','" + d + "','1')";
                dtt = Conn.ExecuteNonQuery(sql34, sql_Insert);
                tongSN = 0;
                if (!dtt)
                {
                    MessageBox.Show("Chưa Insert Liệu Gọi IT!");
                    return;
                }

                #region PrintZPL -------------------------------------------------------------------------------------------------------

                LABEL = BienTam.labels.Replace("[DATA]", BienTam.barcode_tem);
                print = ZplPrintHelper.SendStringToPrinter(cbMayIn.Text, LABEL);
                if (print == true)
                {
                    x += 1;

                    if (lblghichu.Text == "")
                    {

                        lblghichu.Text = x + "- In thành công mã " + BienTam.barcode_tem + " lúc" + " " + DateTime.Now.ToString() + "\n";

                        using (StreamWriter sw = new StreamWriter(@"" + "Logs", true))
                        {
                            sw.WriteLine("- Insert và in thành công mã " + BienTam.barcode_tem + " " + DateTime.Now.ToString());

                        }
                    }
                    else
                    {


                        lblghichu.Text = lblghichu.Text + "\n" + x + "- In thành công mã " + BienTam.barcode_tem + " lúc" + " " + DateTime.Now.ToString() + "\n";
                        using (StreamWriter sw = new StreamWriter(@"" + "Logs", true))
                        {
                            sw.WriteLine("- Insert và in thành công mã " + BienTam.barcode_tem + " " + DateTime.Now.ToString());
                        }
                    }
                }
                else
                {

                    x += 1;
                    if (lblghichu.Text == "")
                    {

                        lblghichu.Text = x + "- In không thành công TỪ   mã " + BienTam.barcode_tem + " lúc" + " " + DateTime.Now.ToString() + "! Vui lòng thử lại! " + "\n";
                        using (StreamWriter sw = new StreamWriter(@"" + "Logs", true))
                        {
                            sw.WriteLine("- In không thành công TỪ  mã " + BienTam.barcode_tem + " " + DateTime.Now.ToString() + Environment.NewLine);

                            string sql_prdbatt = "SELECT sn FROM prdbat WHERE slipno ='" + BienTam.barcode_tem + "'";
                            dt = Conn.ExecuteQuery(sql34, sql_prdbatt);
                            string snn = dt.Rows[0]["sn"].ToString().Trim();

                            string sql_delete_prdbat = "DELETE  from prdbat where slipno like '%" + txtMaThanhPham.Text + "%' and sn >= '" + snn + "'";
                            bool dttt = Conn.ExecuteNonQuery(sql34, sql_delete_prdbat);
                            MessageBox.Show("Có Lỗi Không In Được ! Gọi IT!");
                            return;

                        }

                    }
                    else
                    {


                        lblghichu.Text = lblghichu.Text + "\n" + x + "- In không thành công TỪ  mã " + BienTam.barcode_tem + " lúc" + " " + DateTime.Now.ToString() + "! Vui lòng thử lại!" + "\n";
                        using (StreamWriter sw = new StreamWriter(@"" + "Logs", true))
                        {
                            sw.WriteLine("- In không thành công  TỪ mã " + BienTam.barcode_tem + " " + DateTime.Now.ToString() + Environment.NewLine);

                            string sql_prdbatt = "SELECT sn FROM prdbat  WHERE slipno ='" + BienTam.barcode_tem + "'";
                            dt = Conn.ExecuteQuery(sql34, sql_prdbatt);
                            string snn = dt.Rows[0]["sn"].ToString().Trim();

                            string sql_delete_prdbat = "DELETE  from prdbat where slipno like '%" + txtMaThanhPham.Text.Trim() + "%' and sn >= '" + snn + "'";
                            bool dttt = Conn.ExecuteNonQuery(sql34, sql_delete_prdbat);
                            MessageBox.Show("Có Lỗi Gọi IT!");
                            return;
                        }

                    }

                }
                #endregion

            }
            MessageBox.Show("Đã In Xong!");
            txtMaThanhPham.Text = "";
            txtSoLuong.Text = "";
            txtsodau.Text = "";
            txtSTT.Text = "";
            txtSoCuoi.Text = "";
            return;
        }

        private void btnInThu_Click(object sender, EventArgs e)
        {
            autoclose();
            string sqlCol = "";
            string data = "";
            string L = "";
            string L2 = "";
            string U = "";
            string U2 = "";
            int n1 = 1;
            if (BienTam.infors != "")
            {
                for (int k = 0; k < BienTam.infors.Length; k++)
                {
                    sqlCol = "";
                    sqlCol = "" + BienTam.infors.Substring(k, 1) + "";
                    data += sqlCol;
                    if (sqlCol == ",")
                    {
                        if (n1 == 4)
                        {
                            n1 = n1 + 1;
                            U2 = data.Replace(",", "");
                        }
                        if (n1 == 3)
                        {
                            n1 = n1 + 1;
                            L2 = data.Replace(",", "");

                        }
                        if (n1 == 2)
                        {
                            n1 = n1 + 1;
                            U = data.Replace(",", "");
                        }
                        if (n1 == 1)
                        {
                            n1 = n1 + 1;
                            L = data.Replace(",", "");
                        }
                        data = "";
                    }
                }
            }

            string labels = BienTam.setting_barcode.Replace("[L]", L).Replace("[U]", U).Replace("[L2]", L2).Replace("[U2]", U2);
            BienTam.labels = labels;
            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Vui Lòng Nhập Số Lượng!");
                return;
            }
            int sl = Convert.ToInt32(txtSoLuong.Text);
            for (int i = 0; i <= sl; i++)
            {
                bool print;
                string LABEL = BienTam.labels.Replace("[DATA]", "INTESTTEMBARCODE");
                print = ZplPrintHelper.SendStringToPrinter(cbMayIn.Text, LABEL);
                if (print == true)
                { }
                else
                {
                    MessageBox.Show("Lỗi Không In Thử Đươc!");
                    return;
                }
            }
            MessageBox.Show("Đã In Xong");
            txtSoLuong.Text = "";
            return;

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Dispose();
            timer2.Dispose();
            Application.Exit();
        }
    }
}





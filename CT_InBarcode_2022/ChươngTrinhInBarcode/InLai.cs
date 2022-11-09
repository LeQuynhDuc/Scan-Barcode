using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChươngTrinhInBarcode
{
    public partial class In_Lai : Form
    {
        public In_Lai()
        {
            InitializeComponent();
        }
        string sql33 = "Data Source= 198.1.10.33; Initial Catalog= erp;User ID= kendakv2;Password= kenda123;";
        string sql34 = "Data Source= 198.1.10.34; Initial Catalog= erp;User ID= kendakv2;Password= kenda123;";
        OpenFileDialog open;
        bool print;
        DataTable dtCsv = new DataTable();
        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            Visible = false;
            Menu mn = new Menu();
            mn.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            btnInlai.Enabled = true;
            autoclose();
            if (txtBarcode.Text.Length == 16)
            {
                string sql_select = "SELECT * from  prdbat where slipno ='" + txtBarcode.Text.Trim().ToUpper() + "'";
                DataTable dt = new DataTable();
                dt = Conn.ExecuteQuery(sql34, sql_select);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không Có Mã Barcode này! Xin Kiểm Tra Lại!");
                    txtBarcode.Text = "";
                }
                else
                {
                    string pcnt = dt.Rows[0]["pcnt"].ToString().Trim();

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không Có Mã Barcode Này!");
                        txtBarcode.Text = "";
                        return;
                    }
                    else
                    {
                        if (int.Parse(pcnt) == 1)
                        {
                            lblGhichu.Text = "Thông Báo! Barcode Này Chưa In Lại Lần Nào!";
                            btnInlai.Enabled = true;
                        }
                        else if (int.Parse(pcnt) > 1)

                        {
                            lblGhichu.Text = "Thông báo: tem này đã in lại" + " " + (int.Parse(dt.Rows[0]["pcnt"].ToString()) - 1) + " lần!!!";
                            btnInlai.Enabled = true;
                            comboBox2.Enabled = true;
                        }
                    }

                }
            }
        }

        private void In_Lai_Load(object sender, EventArgs e)
        {
            autoclose();
            lblDangNhap.Text = BienTam.name;
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
            comboBox2.Text = infor1;
            int i = 0;
            string[] sPrinterList = new string[System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count];
            if (System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count == 0)
                sPrinterList[i] = "";
            else
            {
                comboBox2.Items.Add("");
                foreach (string printers in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {

                    sPrinterList[i] = printers;
                    i++;
                    comboBox2.Items.Add(printers);
                }
            }
            comboBox2.SelectedIndex = 1;
            string name = comboBox2.Text;

            //-----------------------------------------------------------
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
            BienTam.infors = infor;
        }

        private void In_Lai_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Dispose();
            timer2.Dispose();
            Application.Exit();
        }
        public void autoclose()
        {
            timer2.Enabled = false;
         //   timer2.Interval = 300000;
            timer2.Start();

        }
        private void btnInlai_Click(object sender, EventArgs e)
        {
            int biendemduoc = 0;
            int bienkhongdemduoc = 0;
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
            bool b3 = false;
            string labels = BienTam.setting_barcode.Replace("[L]", L).Replace("[U]", U).Replace("[L2]", L2).Replace("[U2]", U2);
            BienTam.labels = labels;
            DataTable dt = new DataTable();
            List<string> lst = new List<string>();
            bool print;
            var field1 = "";
            if (txtBarcode.Text != "")
            {
                field1 = txtBarcode.Text;
                string invmas = field1.Substring(2, 8);
                // check invmat nếu modsta không có Thông Báo "Mã Này Không Được Sản Xuất"
                #region check table invmat  
                DataTable dt_invmas = new DataTable();
                string modsta = "";
                string invmat = "select modsta from invmat where itnbr = '" + invmas + "'";
                dt_invmas = Conn.ExecuteQuery(sql34, invmat);
                if (dt_invmas.Rows.Count == 0)
                {
                    MessageBox.Show("Mã Thành Phẩm '" + invmas + "' Này Không Có Trong Hệ Thống! Liên Hệ IT!\ninvmat");
                    txtBarcode.Text = "";
                    btnInlai.Enabled = false;
                    return;
                }
                else
                {
                    modsta = dt_invmas.Rows[0]["modsta"].ToString().Trim();
                    if (modsta == "N")
                    {
                        MessageBox.Show("Mã Thành Phẩm '" + invmas + "' Này Không Được Sản Xuất!\ninvmat");
                        txtBarcode.Text = "";
                        btnInlai.Enabled = false;
                        return;
                    }
                }
                #endregion
                string sql_select = "SELECT * from  prdbat where slipno ='" + field1 + "'";
                dt = Conn.ExecuteQuery(sql34, sql_select);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Mã Barcode '" + field1 + "' không có! Xin Kiểm Tra Lại!");
                    return;

                }
                string sn = dt.Rows[0]["sn"].ToString().Trim();
                string pcnt = dt.Rows[0]["pcnt"].ToString().Trim();
                int dem = Convert.ToInt32(pcnt);
                dem += 1;
                string sql_update = "Update prdbat set usrno = '" + BienTam.name + "', pcnt = '" + dem + "' where slipno = '" + field1 + "'";
                bool b1 = Conn.ExecuteNonQuery(sql34, sql_update);
                // bool b2 = ConnUnix.ExecuteNonQuery(sql_update);
                try
                {
                    if (b1)
                    {
                        string LABEL = BienTam.labels.Replace("[DATA]", field1);
                        print = ZplPrintHelper.SendStringToPrinter(comboBox2.Text, LABEL);

                        if (print == true)
                        {
                            string insertpk = "insert into prdbatbk values('7','" + field1.Trim() + "','" + DateTime.Now.ToString("yyyMMdd") + "','" + DateTime.Now.ToString("HH:mm:ss") + "','" + sn + "','1','" + BienTam.name + "')";
                            b3 = Conn.ExecuteNonQuery(sql34, insertpk);
                            lblGhichu.Text = "- In lại thành công mã " + field1.Trim() + "" + "\n" + " SQL " + b1.ToString() + "" + "\n" + " batbk " + b3.ToString() + "";
                            using (StreamWriter sw = new StreamWriter(@"Logs_Inlai", true))
                            {
                                sw.WriteLine("- Update và in lại thành công mã " + field1.Trim() + "\n" + " SQL " + b1.ToString() + "" + "\n" + " batbk " + b3.ToString() + " " + BienTam.name + DateTime.Now.ToString());
                                txtBarcode.Text = "";

                            }
                        }
                        else
                        {
                            lblGhichu.Text = "- In lại không thành công mã " + field1.Trim() + "" + "\n" + "" + "\n" + " SQL " + b1.ToString() + "" + "\n" + " batbk " + b3.ToString() + "";
                            using (StreamWriter sw = new StreamWriter(@"Logs_Inlai", true))
                            {
                                sw.WriteLine("- 0Update và in lại không thành công mã " + field1.Trim() + "\n" + " SQL " + b1.ToString() + "" + "\n" + " batbk " + b3.ToString() + "" + BienTam.name + DateTime.Now.ToString());
                            }

                        }
                    }

                    else
                    {
                        lblGhichu.Text = "In lại không thành công!" + "\n" + "" + "\n" + " SQL " + b1.ToString() + "" + "\n" + " batbk " + b3.ToString() + "";
                        using (StreamWriter sw = new StreamWriter(@"Logs_Inlai", true))
                        {
                            sw.WriteLine("- 1Update và in lại không thành công mã " + field1.Trim() + "" + "\n" + " SQL " + b1.ToString() + "" + "\n" + " batbk " + b3.ToString() + "" + BienTam.name + DateTime.Now.ToString());
                        }
                    }
                }
                catch { }
                field1 = "";
            }
            else
            {
                foreach (DataRow dtRow in dtCsv.Rows)
                {
                    // On all tables' columns
                    foreach (DataColumn dc in dtCsv.Columns)
                    {
                        field1 = dtRow[dc].ToString().Trim().ToUpper();

                        string invmas = field1.Substring(2, 8);
                        // check invmat nếu modsta không có Thông Báo "Mã Này Không Được Sản Xuất"
                        #region check table invmat  
                        DataTable dt_invmas = new DataTable();
                        string modsta = "";
                        string invmat = "select modsta from invmat where itnbr = '" + invmas + "'";
                        dt_invmas = Conn.ExecuteQuery(sql34, invmat);
                        if (dt_invmas.Rows.Count == 0)
                        {
                            MessageBox.Show("Mã Thành Phẩm '" + invmas + "' Này Không Có Trong Hệ Thống! Liên Hệ IT!\ninvmat");
                            txtBarcode.Text = "";
                            btnInlai.Enabled = false;
                            return;
                        }
                        else
                        {
                            modsta = dt_invmas.Rows[0]["modsta"].ToString().Trim();
                            if (modsta == "N")
                            {
                                MessageBox.Show("Mã Thành Phẩm '" + invmas + "' Này Không Được Sản Xuất!\ninvmat");
                                txtBarcode.Text = "";
                                btnInlai.Enabled = false;
                                return;
                            }
                        }
                        #endregion
                        string sql_select = "SELECT * from  prdbat where slipno ='" + field1 + "'";
                        dt = Conn.ExecuteQuery(sql34, sql_select);
                        string sn = dt.Rows[0]["sn"].ToString().Trim();
                        if (dt.Rows.Count == 0)
                        {
                           
                          lst.Add(field1);
                            bienkhongdemduoc++;
                        }
                        else
                        {

                            string pcnt = dt.Rows[0]["pcnt"].ToString().Trim();
                            int dem = Convert.ToInt32(pcnt);
                            dem += 1;
                            string sql_update = "Update prdbat set usrno = '" + BienTam.name + "', pcnt = '" + dem + "' where slipno = '" + field1 + "'";
                            bool b1 = Conn.ExecuteNonQuery(sql34, sql_update);

                            try
                            {
                                if (b1)
                                {
                                    string LABEL = BienTam.labels.Replace("[DATA]", field1);
                                    print = ZplPrintHelper.SendStringToPrinter(comboBox2.Text, LABEL);

                                    if (print == true)
                                    {
                                        string insertpk = "insert into prdbatbk values('7','" + field1.Trim() + "','" + DateTime.Now.ToString("yyyMMdd") + "','" + DateTime.Now.ToString("HH:mm:ss") + "','" + sn + "','1','" + BienTam.name + "')";
                                        b3 = Conn.ExecuteNonQuery(sql34, insertpk);
                                        if(b3 == false)
                                        {
                                            b3 = Conn.ExecuteNonQuery(sql34, insertpk);
                                        }
                                        lblGhichu.Text = "- In lại thành công mã " + field1.Trim() + "" + "\n" + " SQL " + b1.ToString() + "" + "\n" + " batbk " + b3.ToString() + "";
                                        using (StreamWriter sw = new StreamWriter(@"Logs_Inlai", true))
                                        {
                                            sw.WriteLine("- Update và in lại thành công mã " + field1.Trim() + "\n" + " SQL " + b1.ToString() + "" + "\n" + " batbk " + b3.ToString() + " " + BienTam.name + DateTime.Now.ToString() + Environment.NewLine);
                                            txtBarcode.Text = "";

                                        }
                                        biendemduoc++;
                                    }
                                    else
                                    {
                                        lblGhichu.Text = "- In lại không thành công mã " + field1.Trim() + "" + "\n" + "" + "\n" + " SQL " + b1.ToString() + "" + "\n" + " batbk " + b3.ToString() + "";
                                        using (StreamWriter sw = new StreamWriter(@"Logs_Inlai", true))
                                        {
                                            sw.WriteLine("- 0Update và in lại không thành công mã " + field1.Trim() + "\n" + " SQL " + b1.ToString() + "" + "\n" + " batbk " + b3.ToString() + "" + BienTam.name + DateTime.Now.ToString() + Environment.NewLine);
                                        }
                                        bienkhongdemduoc++;
                                    }
                                }

                                else
                                {
                                    lblGhichu.Text = "In lại không thành công!" + "\n" + "" + "\n" + " SQL " + b1.ToString() + "" + "\n" + " batbk " + b3.ToString() + "";
                                    using (StreamWriter sw = new StreamWriter(@"Logs_Inlai", true))
                                    {
                                        sw.WriteLine("- 1Update và in lại không thành công mã " + field1.Trim() + "" + "\n" + " SQL " + b1.ToString() + "" + "\n" + " batbk " + b3.ToString() + "" + BienTam.name + DateTime.Now.ToString() + Environment.NewLine);
                                    }
                                    bienkhongdemduoc++;
                                }
                            }
                            catch { }
                        }
                        field1 = "";
                        sn = "";
                    }
                }
            }
           
            MessageBox.Show("Đã In Xong");
            foreach (string a in lst)
            {
                lblGhichu.Text = lblGhichu.Text + "\n Mã " + a + " Không In được Xin Kiểm Tra Lại \n";
            }
            txtInThanhCong.Text = Convert.ToString(biendemduoc);
            txtInKhongThanhCong.Text = Convert.ToString(bienkhongdemduoc);
            return;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {

                Ping p1 = new Ping();
                PingReply PR = p1.Send("198.1.10.34");             
                if (PR.Status == IPStatus.Success)
                {
                    lblKetNoi.Text = "| Kết Nối OK!";
                    btnInlai.Visible = true;
                }
                if (PR.Status != IPStatus.Success)
                {
                    lblKetNoi.Text = "| Mất kết nối! 10.34";
                    btnInlai.Visible = false;
                }              
            }
            catch (Exception ex)
            { }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Dispose();
            timer2.Dispose();
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            btnInlai.Enabled = true;
            txtBarcode.Text = "";
            if (checkBox1.Checked == true)
            {
                txtPath.Visible = false;
                button1.Visible = false;
                label3.Visible = false;
            }
            else
            {
                txtPath.Visible = true;
                button1.Visible = true;
                label3.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Fulltext;

            open = new OpenFileDialog();
            open.Filter = "|*.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = open.FileName;
                using (StreamReader sr = new StreamReader(open.FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        Fulltext = sr.ReadToEnd().ToString();
                        string[] rows = Fulltext.Split('\n');
                        for (int i = 0; i < rows.Count() - 1; i++)
                        {
                            string[] rowValues = rows[i].Split(',');
                            {
                                if (i == 0)
                                {
                                    for (int j = 0; j < rowValues.Count(); j++)
                                    {
                                        dtCsv.Columns.Add(rowValues[j]);
                                    }
                                }
                                else
                                {
                                    DataRow dr = dtCsv.NewRow();
                                    for (int k = 0; k < rowValues.Count(); k++)
                                    {
                                        dr[k] = rowValues[k].ToString();
                                    }
                                    dtCsv.Rows.Add(dr);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    }


    

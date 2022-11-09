using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChươngTrinhInBarcode
{
    class BienTam
    {
        public static string name = "";
        public static string password = "";
        public static string wrong = "";
        public static string reprint = "";
        public static string full_control = "";
        public static string setting_barcode = "^XA" + "\n" + "^BY2,2,50" + "\n" + "^FO[L],[U]^A010,35^FD[DATA]^FS" + "\n" + "^FO[L2],[U2]^BCN,N,N^FD[DATA]^FS" + "\n" + "^XZ";
        public static string year = DateTime.Now.ToString("yyyy").Substring(3, 1);
        public static int numberFirst = 7 + int.Parse(year);
        public static string invmas = ""; // itnrbr
        public static string itdsc = "";
        public static string SN = "";
        public static int tongitnbr = 0;
        public static string lables = "";
        public static string infors = "";
        public static int error = 0;
        public static string barcode = "";
        public static string labels = "";
        public static string barcode_tem = "";
       
       
    }
}

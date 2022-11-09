using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChươngTrinhInBarcode
{
    class ConnUnix
    {
        static string ConnectionString = "DSN=web4;UID=kendausr;PWD=kenda;DATABASE=erp;" +
    "HOST=192.1.1.1;SRVR=ids12;SERV=on7tcp;PRO=onsoctcp;CLOC=zh_TW.big5;DLOC=zh_TW.big5;" +
    "VMB=0;CURB=0;OPT=;SCUR=0;ICUR=0;OAC=1;OPTOFC=0;RKC=0;ODTYP=0;DDFP=0;DNL=0;RCWC=0";
        //static string ConnectionString = "Driver={IBM INFORMIX 3.82 32 BIT}; Host=192.1.1.1; Server=ids12;" +
        //                               "Service=on7tcp; Protocol=onsoctcp; Database=erp; Uid=kendausr; Pwd=kenda;" +
        //                                 "NEWLOCALE=zh_cn,zh_tw; NEWCODESET=big5,57352,utf8;" +
        //                                 "DB_LOCALE=zh_tw.57352; CLIENT_LOCALE=zh_tw.big5";
        /// <summary>
        /// Excute a Query and return a Datatable
        /// </summary>
        /// <param name="Query">Query</param>
        /// <param name="commandType">Command Type</param>
        /// <param name="parameter">List Param</param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(string Query, object[] parameter = null)
        {
            using (var conn = new OdbcConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    OdbcCommand cmd = new OdbcCommand(Query, conn);
                    if (parameter != null)
                    {
                        string[] listPara = Query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('?'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    OdbcDataAdapter adapter = new OdbcDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    //MethodBase currentMethod = MethodBase.GetCurrentMethod();
                    //Logger.WriteToLog(currentMethod.DeclaringType.Namespace, currentMethod.DeclaringType.Name, currentMethod.Name, ex.ToString());
                    //MailSender.SendAlarmMailToAdmin(Query, ex);
                    return new DataTable();
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }

        }

        /// <summary>
        /// Excute a non query anf return true or false
        /// </summary>
        /// <param name="query"></param>
        /// <param name="commandType"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static bool ExecuteNonQuery(string query,
           object[] parameter = null)
        {
            using (var conn = new OdbcConnection(ConnectionString))
            {
                try
                {
                    conn.Open();

                    OdbcCommand cmd = new OdbcCommand(query, conn);

                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('?'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    int effectedRow = cmd.ExecuteNonQuery();
                    return effectedRow > 0;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }
    }
}

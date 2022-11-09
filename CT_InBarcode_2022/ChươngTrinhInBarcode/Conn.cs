using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChươngTrinhInBarcode
{
    class Conn
    {
        public static DataTable ExecuteQuery(string connectionSTR, string query, object[] parameter = null)
        {
            using (var conn = new SqlConnection(connectionSTR))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
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
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }              
        public static bool ExecuteNonQuery( string ConnectionString, string query, Dictionary<string, object> param = null)
        {
          //  string ConnectionString = "Data Source=198.1.10.34;Initial Catalog=erp;User ID=kendakv2;Password=kenda123";
            //  string Connect = "Data Source=" + IP + ";Initial Catalog=JianDaMES;User ID=kendakv2;Password=kenda123";
            //string ConnectionString = "Data Source=198.1.10.34;Initial Catalog=erp;User ID=kendakv2;Password=kenda123";
            //string ConnectionString = @"Data Source = 198.1.1.95; Initial Catalog = JianDaMES; User ID = kendakv2; Password = kenda123";
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.Text;

                    if (param != null && param.Count > 0)
                        foreach (var item in param)
                            cmd.Parameters.AddWithValue(item.Key, item.Value);

                    int effectedRow = cmd.ExecuteNonQuery();
                    return effectedRow > 0;
                }
                catch (Exception ex)
                {
                    //throw;
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

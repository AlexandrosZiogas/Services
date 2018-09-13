using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data;

namespace MyG
{
    public static class Db
    {
        public static OdbcConnection Cn =
            new OdbcConnection();

        public static void Connect(string server, string port, string db, string user, string password)
        {
            try
            {
                if (Cn == null)
                    Cn = new OdbcConnection();

                if (Cn.State != ConnectionState.Open)
                {
                    Cn.ConnectionString =
                        "Provider=MSDASQL" +
                        ";Driver={MySQL ODBC 5.3 Unicode Driver}" +
                        ";Server=" + server +
                        ";Port=" + port +
                        ";Database=" + db +
                        ";User=" + user +
                        ";Password=" + password +
                        ";Options=3";
                    Cn.Open();
                }



            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        public static void Disconnect()
        {
            try
            {
                if (Cn == null) return;
                if (Cn.State != ConnectionState.Closed)
                    Cn.Close();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}

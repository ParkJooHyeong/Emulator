using jsLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipManager
{
    class SQLDB
    {
        SqlConnection sqlconn = new SqlConnection();
        SqlCommand sqlcmd = new SqlCommand();
        string ConnStr;

        public SQLDB(string str)
        {
            ConnStr = str;
            sqlconn.ConnectionString = ConnStr;
            sqlconn.Open();
            sqlcmd.Connection = sqlconn;
        }
        public object Run(string sql)
        {
            try
            {
                sqlcmd.CommandText = sql;
                if (jslib.GetToken(0, sql.Trim(), ' ').ToUpper() == "SELECT")
                {
                    SqlDataReader sr = sqlcmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(sr);
                    sr.Close();
                    return dt;
                }
                else
                {
                    return sqlcmd.ExecuteNonQuery();      // insert, update, delete, create etc..조회결과가 없은 SQL문 처리
                }
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1);
                return null;
            }
        }

        public object Get(string sql)
        {
            try
            {
                sqlcmd.CommandText = sql;
                if (jslib.GetToken(0, sql.Trim(), ' ').ToUpper() == "SELECT")
                {
                    object obj = sqlcmd.ExecuteScalar();
                    return obj;
                }
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1);
            }
            return null;
        }

    }
}

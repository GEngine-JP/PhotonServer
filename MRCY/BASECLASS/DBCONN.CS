using System.Data.SqlClient;

namespace MrCy.BaseClass
{
    static class DbConn
    {
        public static SqlConnection CyCon()
        {
            return new SqlConnection("server=(local);database=eat;uid=sa;pwd=888888");
        }
    }
}
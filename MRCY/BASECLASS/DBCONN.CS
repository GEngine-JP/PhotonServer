using System.Data.SqlClient;

namespace MrCy.BaseClass
{
    static class DbConn
    {
        public static SqlConnection CyCon()
        {
            return new SqlConnection("server=(local);database=MrCy;uid=sa;pwd=sa");
        }
    }
}
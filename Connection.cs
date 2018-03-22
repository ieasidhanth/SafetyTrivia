using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Quizzed
{
    class Connection
    {
        private SqlConnection sqlconn;
        private SqlConnection transitDBconn;
        public SqlConnection initiateConnection()
        {
            try
            {
                sqlconn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["QuizzedDB"]));
                sqlconn.Open();
                return sqlconn;
            }
            catch (SqlException e)
            {

                throw e;
            }
        }
        public void dispose(SqlConnection conn)
        {
            conn.Dispose();

        }
        
    }
}

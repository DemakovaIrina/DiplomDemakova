using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport
{
    internal class BD
    {
        SqlConnection connection = new SqlConnection("data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user45_db;persist security info=True;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework");
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public SqlConnection getConnection()
        {
            return connection;
        }
    }
}

using System.Data;
using System.Data.SqlClient;

namespace BBSWebAPI.Core
{
    public class SqlHelper
    {
        string connString = @"Persist Security Info=False;Initial Catalog=AdventureWorks;server=LAPTOP-FOMVS4G2\MSSQLSERVER_2019;database=forum;User ID=sa;PassWord=123456;";
        public DataTable ExecuteTable(string command,params SqlParameter[] sqlParameters)
        {
            using SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
            sqlCommand.Parameters.AddRange(sqlParameters);

            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            return ds.Tables[0];
        }

        public int ExecuteNonQuery(string command,params SqlParameter[] sqlParameters)
        {
            using SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
            sqlCommand.Parameters.AddRange(sqlParameters);

            return sqlCommand.ExecuteNonQuery();
        }
    }
}

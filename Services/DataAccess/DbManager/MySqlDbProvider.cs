using MySql.Data.MySqlClient;
using System.Data;

namespace Services.DataAccess.DbManager
{
    public class MySqlDbProvider : DbProvider
    {
        public override IDbConnection CreateConnection(string connectionString)
        {
            return new MySqlConnection(connectionString);
        }

        public override IDbDataAdapter CreateDataAdapter(IDbCommand command)
        {
            return new MySqlDataAdapter((MySqlCommand)command);
        }

        public override DataTable GetData(IDbConnection connection, string query, Dictionary<string, object> paramList)
        {
            using (var cmd = CreateCommand(connection, query, paramList))
            {
                MySqlDataAdapter adapter = (MySqlDataAdapter)CreateDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}

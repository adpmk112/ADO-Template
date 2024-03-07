using System.Data;

namespace Services.DataAccess.DbManager
{
    public abstract class DbProvider
    {
        public abstract IDbConnection CreateConnection(string connectionString);
        public abstract IDbDataAdapter CreateDataAdapter(IDbCommand command);
        public abstract DataTable GetData(IDbConnection connection, string query,
          Dictionary<string, object> paramList);

        public IDbCommand CreateCommand(IDbConnection connection, string query,
                                                 Dictionary<string, object> paramList)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd = AddParamList(cmd, paramList);
            return cmd;
        }

        public IDbCommand AddParamList(IDbCommand command, Dictionary<string, object> paramList)
        {
            if (paramList != null && paramList.Count > 0)
            {
                foreach (KeyValuePair<string, object> result in paramList)
                {
                    IDbDataParameter parameter = command.CreateParameter();
                    parameter.ParameterName = result.Key;
                    parameter.Value = result.Value;
                    command.Parameters.Add(parameter);
                }
            }
            return command;
        }
    }
}

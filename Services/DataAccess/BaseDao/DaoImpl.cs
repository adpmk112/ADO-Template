using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Services.DataAccess.DbManager;
using Services.Utilities;
using System.Data;
using System.Data.Common;

namespace Services.DataAccess.BaseDao
{
    public class DaoImpl : IDao
    {
        private DbConnection _connection;
        private readonly DbProvider _dbProvider;

        public DaoImpl(DbProvider dbProvider, DbConnection dbConnection)
        {
            string connection = ConstantUtility.connectionString;
            _dbProvider = dbProvider;
            _connection = dbConnection;
            _connection.ConnectionString = connection;
        }

        //for Create,Update,Delete that dont return data but return row affected
        public int Execute(string query, Dictionary<string, object> paramList)
        {
            _connection.Open();

            using (IDbCommand cmd = _dbProvider.CreateCommand(_connection, query, paramList))
            {
                var result = cmd.ExecuteNonQuery();

                _connection.Close();

                return result;
            }
        }

        //to get only one row data
        public T GetOne<T>(string query, Dictionary<string, object> paramList)
        {
            _connection.Open();

            try
            {
                DataTable dt = _dbProvider.GetData(_connection, query, paramList);

                _connection.Close();

                var jsonDt = JsonConvert.SerializeObject(dt);

                JArray jsonArray = JArray.Parse(jsonDt);

                // Get the first object in the JArray as a JObject
                JObject jsonObject = (JObject)jsonArray[0];

                var row = jsonObject.ToObject<T>();

                return row;
            }

            catch (Exception ex)
            {
                // never used ex is like hiding exception
                // it is bad and need to save log for exception in future
                return default(T);
            }

        }

        public List<T>? GetList<T>(string query, Dictionary<string, object> paramList)
        {
            try
            {
                _connection.Open();
                DataTable dt = _dbProvider.GetData(_connection, query, paramList);
                _connection.Close();

                var list = JsonConvert.DeserializeObject<List<T>>(JsonConvert.SerializeObject(dt));
                return list;
            }
            catch (Exception ex)
            {
                // never used ex is like hiding exception
                // it is bad and need to save log for exception in future

                //return default(List<T>);

                throw new Exception(ex.Message);
            }

        }
    }
}

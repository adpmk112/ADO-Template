namespace Services.DataAccess.BaseDao
{
    public interface IDao
    {
        int Execute(string query, Dictionary<string, object> paramList);
        T GetOne<T>(string query, Dictionary<string, object>? paramList = null);
        List<T> GetList<T>(string query, Dictionary<string, object>? paramList = null);
    }
}

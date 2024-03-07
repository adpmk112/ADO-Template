using DataModels.Entities;
using Services.DataAccess.BaseDao;

namespace Services.Repositories.PersonRepo
{
    public class PersonRepoImpl : IPersonRepo
    {
        private readonly IDao _iDao;

        public PersonRepoImpl(IDao daoImpl)
        {
            _iDao = daoImpl;
        }

        public int CheckDuplicate(Person entity)
        {
            throw new NotImplementedException();
        }

        public int Create(Person entity)
        {
            var sql = "INSERT INTO person (Name,Age) Values (@Name,@Age)";

            Dictionary<string,object> paramPairs = new Dictionary<string,object>();
            paramPairs.Add("@Name", entity.Name);
            paramPairs.Add("@Age", entity.Age);

            return _iDao.Execute(sql, paramPairs);
        }

        public int Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAll()
        {
            var sql = "SELECT * FROM person";
            return _iDao.GetList<Person>(sql);
        }

        public Person GetById(long id)
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public int Update(Person entity, long id)
        {
            throw new NotImplementedException();
        }
    }
}

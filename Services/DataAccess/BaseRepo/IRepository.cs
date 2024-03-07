using DataModels.Entities;

namespace Services.DataAccess.BaseRepo
{
    public interface IRepository<T>
        where T : IEntity
    {
        int Create(T entity);
        int Update(T entity, long id);
        int Delete(long id);
        List<T> GetAll();
        T GetById(long id);
        int GetCount();
        int CheckDuplicate(T entity);

    }
}

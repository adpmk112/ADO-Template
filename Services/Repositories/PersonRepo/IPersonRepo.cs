using DataModels.Entities;
using Services.DataAccess.BaseRepo;

namespace Services.Repositories.PersonRepo
{
    public interface IPersonRepo : IRepository<Person>
    {
    }
}

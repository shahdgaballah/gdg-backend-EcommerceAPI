
using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Contracts
{
    public interface IUnitofWork
    {
        IGenericRepositories<T> Repository<T>() where T : BaseEntity;

        int Complete();
    }
}

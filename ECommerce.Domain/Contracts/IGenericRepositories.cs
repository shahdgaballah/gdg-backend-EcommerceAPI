using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Contracts
{
    public interface IGenericRepositories<T> where T : BaseEntity
    {
        public T Get(int Id);

        public IEnumerable<T> GetAll();

        public void Add(T item);

        public void Update(T item);

        public void Delete(T item);
    }
}

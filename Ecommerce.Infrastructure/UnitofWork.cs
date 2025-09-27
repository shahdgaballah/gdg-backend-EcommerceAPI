using Ecommerce.Infrastructure.Repositories;
using ECommerce.Domain.Contracts;
using ECommerce.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure
{
    public class UnitofWork : IUnitofWork, IDisposable
    {
        private readonly ECommerceContext _eCommercecontext;

        private Hashtable _repositories { get; set; }

        public UnitofWork(ECommerceContext eCommerceContext)
        {
            _eCommercecontext = eCommerceContext;
            _repositories = new Hashtable();
        }
        public IGenericRepositories<T> Repository<T>() where T : BaseEntity
        {
            var key = typeof(T).Name;
            if(!_repositories.ContainsKey(key))
            {
                _repositories.Add(key, new GenericRepositories<T>(_eCommercecontext));

            }
            return (IGenericRepositories<T>)_repositories[key];
        }
        public int Complete()
        {
           return _eCommercecontext.SaveChanges();
        }

        public void Dispose()
        {
            _eCommercecontext.Dispose();
        }
    }
}

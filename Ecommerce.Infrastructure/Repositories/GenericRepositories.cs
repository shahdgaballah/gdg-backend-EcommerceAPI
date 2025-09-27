using ECommerce.Domain.Contracts;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class GenericRepositories<T> : IGenericRepositories<T> where T : BaseEntity
    {
        private readonly ECommerceContext _eCommerceContext;
        public GenericRepositories(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;

        }
        public T Get(int Id)
        {
            if(typeof(T) == typeof(Product))
                return _eCommerceContext.Set<Product>().Include(p => p.Brand).Include(p => p.Type).Where(p => p.Id == Id).FirstOrDefault() as T;

            return _eCommerceContext.Set<T>().Find(Id);
        }

        public IEnumerable<T> GetAll()
        {
            if (typeof(T) == typeof(Product))
                return (IEnumerable<T>)_eCommerceContext.Set<Product>().Include(p => p.Brand).Include(p => p.Type).ToList();
           
            return _eCommerceContext.Set<T>().ToList();

        }
        public void Add(T item)
        {
            _eCommerceContext.Set<T>().Add(item);
            _eCommerceContext.SaveChanges();
        }

        public void Delete(T item)
        {
            _eCommerceContext.Set<T>().Remove(item);
            _eCommerceContext.SaveChanges();
        }

       

        public void Update(T item)
        {
            _eCommerceContext.Set<T>().Update(item);
            _eCommerceContext.SaveChanges();
        }
    }


}

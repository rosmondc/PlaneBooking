using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PlaneBooking.DataAccess.Repositories.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate);


        Task<IEnumerable<T>> GetAllWithInclude(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdWithInclude(Expression<Func<T, bool>> predicae, params Expression<Func<T, object>>[] includes);

        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
    }
}

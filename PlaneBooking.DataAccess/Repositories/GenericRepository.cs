using Microsoft.EntityFrameworkCore;
using PlaneBooking.DataAccess.Repositories.Contracts;
using PlaneBooking.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PlaneBooking.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private PlaneBookingContext _context = null;
        private DbSet<T> entity = null;

        public GenericRepository(PlaneBookingContext _context)
        {
            this._context = _context;
            entity = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await entity.ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await entity.FindAsync(id);
        }

        public void Insert(T obj)
        {
            entity.Add(obj);
        }

        public void Update(T obj)
        {
            entity.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = entity.Find(id);
            entity.Remove(existing);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate)
        {
            return await entity.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithInclude(params Expression<Func<T, object>>[] includes)
        {
            var query = entity.AsQueryable();
            return await includes.Aggregate(query, (current, includeProperty) =>
                    current.Include(includeProperty)).ToListAsync();
        }

        public async Task<T> GetByIdWithInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().Where(predicate);
            return await includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).FirstAsync();
        }
    }
}

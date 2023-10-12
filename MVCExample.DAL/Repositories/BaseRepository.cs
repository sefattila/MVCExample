using Microsoft.EntityFrameworkCore;
using MVCExample.CORE.Abstarct;
using MVCExample.CORE.Repositories;
using MVCExample.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _table.Any(expression);
        }

        public void Create(T entity)
        {
            _table.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.SaveChanges();
        }

        public IList<T> FilteredList(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> queryable = _table.AsNoTracking();

            if (filter != null)
                queryable = queryable.Where(filter);

            if (orderBy != null)
                queryable = orderBy(queryable);

            return queryable.ToList();
        }

        public IList<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetDefault(Expression<Func<T, bool>> expression)
        {
            return _table.FirstOrDefault(expression);
        }

        public T GetDefaultById(int id)
        {
            return _table.Find(id);
        }

        public IList<T> GetDefaults(Expression<Func<T, bool>> expression)
        {
            return _table.Where(expression).ToList();
        }

        public IList<T> OrderByAsc<TKey>(Expression<Func<T, TKey>> expression)
        {
            return _table.OrderBy(expression).ToList();
        }

        public IList<T> OrderByDesc<TKey>(Expression<Func<T, TKey>> expression)
        {
            return _table.OrderByDescending(expression).ToList();
        }

        public void Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

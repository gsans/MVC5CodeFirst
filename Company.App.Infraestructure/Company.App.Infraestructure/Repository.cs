using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using Company.App.Domain;
using System.Data.Entity;

namespace Company.App.Infraestructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _context;
        protected IDbSet<T> _dbset;

        public Repository(DbContext dataContext)
        {
            if (dataContext == null) throw new ArgumentNullException("dbContext");
            _context = dataContext;
            _dbset = dataContext.Set<T>();
        }

        #region IRepository<T> Members

        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _dbset.Add(entity);
        }
        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                _context.Set<T>().Attach(entity);
                entry = _context.Entry(entity);
            }
            entry.State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _dbset.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _dbset;
        }

        public T GetById(int? id)
        {
            if (!id.HasValue) return default(T);
            return _dbset.Find(id);
        }

        #endregion

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

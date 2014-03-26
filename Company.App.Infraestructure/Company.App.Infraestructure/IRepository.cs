using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Company.App.Infraestructure
{
    public interface IRepository<T> : IDisposable
        where T : class
    {        
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
        T GetById(int? id);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        void Save();
    }
}

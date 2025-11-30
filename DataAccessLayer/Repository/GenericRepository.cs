using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly MvcKampContext c = new MvcKampContext();
        private readonly DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        public List<T> GetList()
        {
            return _object.ToList();
        }

        public void Insert(T entity)
        {
            _object.Add(entity);
            c.SaveChanges();
        }

        public void Update(T entity)
        {
            var updateded = c.Entry(entity);
            updateded.State = EntityState.Modified;
            c.SaveChanges();
        }

        public void Delete(T entity)
        {
            _object.Remove(entity);
            c.SaveChanges();
        }

        public T GetID(int id)
        {
            return _object.Find(id);
        }

        public List<T> ListToFilter(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }
    }
}

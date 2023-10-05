using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {

        Context c = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }
        public void Delete(T t)
        {
            _object.Remove(t);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public T GetByID(int id)
        {
            var c = new Context();
            return c.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return _object.ToList();
        }

        public void Insert(T t)
        {
            c.Set<T>().Add(t);
            c.SaveChanges();    
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T t)
        {
            _object.AddOrUpdate(t);
            c.SaveChanges();
        }
    }
}

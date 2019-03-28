using EasyHarmonica.DAL.EF;
using EasyHarmonica.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EasyHarmonica.DAL.Repositories
{
    public class Repository<T>: IRepository<T> where T:class
    {
        protected readonly EasyHarmonicaContext Context;

        public Repository(EasyHarmonicaContext context)
        {
            Context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public T Get(int id)
        {
            var entity = Context.Set<T>().Find(id);

            return entity;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public T GetOne(Func<T, bool> predicate)
        {
            return Context.Set<T>().FirstOrDefault(predicate);
        }

        public void Create(T item)
        {
            Context.Set<T>().Add(item);
        }

        public void Update(T item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(T item)
        {
            Context.Set<T>().Remove(item);
        }
    }
}

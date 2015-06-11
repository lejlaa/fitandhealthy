using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAndHealthy
{
    public class baseRepository<T> : baseInterface<T> where T : class
    {
        protected FandHContext ctx;
        protected DbSet<T> dbSet;
        public baseRepository(FandHContext dCon)
        {
            ctx = dCon;
            dbSet = ctx.Set<T>();
        }
        public FandHContext baseContext()
        {
            return ctx;
        }
        public T Get(int Id)
        {
            return dbSet.Find(Id);
        }
        public IQueryable<T> GetAll()
        {
            return dbSet;
        }
        public void Insert(T entity)
        {
            dbSet.Add(entity);
        }
        public void Update(T oldEntity, T newEntity)
        {
            ctx.Entry(oldEntity).CurrentValues.SetValues(newEntity);
        }
        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }
        public void Commit()
        {
            ctx.SaveChanges();
        }
    }
}

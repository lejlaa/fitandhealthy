using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAndHealthy
{
    public interface baseInterface<T>
    {
        FandHContext baseContext();
        void Insert(T entity);
        void Delete(T entity);
        void Update(T oldEntity, T newEntity);
        T Get(int Id);
        IQueryable<T> GetAll();
        void Commit();
    }
}

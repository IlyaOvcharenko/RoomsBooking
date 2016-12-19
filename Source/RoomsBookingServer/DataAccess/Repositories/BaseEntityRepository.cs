using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace DataAccess.Repositories
{
    public class BaseEntityRepository<T> : IBaseEntityRepository<T> where T : BaseEntity
    {
        protected readonly DataContext DataContext;

        public BaseEntityRepository(DataContext dataContext)
        {
            this.DataContext = dataContext;
        }

        public void Dispose()
        {
            DataContext?.Dispose();
        }

        public T Add(T entity)
        {
            return DataContext.Set<T>().Add(entity);
        }

        public IQueryable<T> GetAll()
        {
            return DataContext.Set<T>();
        }

        public virtual T GetById(int id)
        {
            return DataContext.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public void Update(T entity)
        {
            DataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            DataContext.Set<T>().Remove(entity);
        }

        public virtual void SaveChanges()
        {
            DataContext.SaveChanges();
        }
    }
}

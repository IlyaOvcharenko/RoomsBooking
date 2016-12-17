using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace DataAccess.Repositories
{
    public interface IBaseEntityRepository<T> : IDisposable where T : BaseEntity
    {
        T Add(T entity);

        IQueryable<T> GetAll();

        T GetById(int id);

        void Update(T entity);

        void Delete(T entity);

        void SaveChanges();
    }
}

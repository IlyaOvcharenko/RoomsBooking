using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace DataAccess.Repositories
{
    public interface IUserRepository : IBaseEntityRepository<User>
    {
        Task<User> AddUserAsync(User entity);

        Task<User> FindByLoginAsync(string login);
        Task<User> FindByIdAsync(int id);
        
    }
}

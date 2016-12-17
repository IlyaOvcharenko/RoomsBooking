using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace DataAccess.Repositories
{
    public class UserRepository : BaseEntityRepository<User>, IUserRepository
    {
        public UserRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<User> AddUserAsync(User entity)
        {
            DataContext.Set<User>().Add(entity);
            await DataContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }

        public Task<User> FindByLoginAsync(string login)
        {
            Task<User> task = DataContext.Users.Where(
                              apu => apu.Login == login)
                              .FirstOrDefaultAsync();

            return task;
        }

        public Task<User> FindByIdAsync(int id)
        {
            Task<User> task = DataContext.Users.Where(
                              apu => apu.Id == id)
                              .FirstOrDefaultAsync();

            return task;
        }
    }
}

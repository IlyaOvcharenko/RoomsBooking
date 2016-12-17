using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace BusinessLogic
{
    public interface IUserService : IDisposable
    {
        Task<User> RegisterAsync(string login, string password);

        Task<User> FindByLoginAsync(string login);

        Task<User> FindByIdAsync(int id);

        string GetHashPasswordHash(string password);
    }
}

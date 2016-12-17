using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Enums;
using DataAccess.Repositories;
using Utility;

namespace BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly ICryptoManager cryptoManager;

        public UserService(IUserRepository userRepository, ICryptoManager cryptoManager)
        {
            this.userRepository = userRepository;
            this.cryptoManager = cryptoManager;
        }

        public Task<User> RegisterAsync(string login, string password)
        {
            var user = new User { Login = login, Password = cryptoManager.GetHash(password), Role = Role.User };
            var result = userRepository.AddUserAsync(user).Result;
            return Task.FromResult(result);
        }

        public Task<User> FindByLoginAsync(string login)
        {
            return userRepository.FindByLoginAsync(login);
        }

        public Task<User> FindByIdAsync(int id)
        {
            return userRepository.FindByIdAsync(id);
        }

        public string GetHashPasswordHash(string password)
        {
            return cryptoManager.GetHash(password);
        }

        public void Dispose()
        {
            userRepository.Dispose();
        }
    }
}

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
        private readonly IUserRepository _userRepository;
        private readonly ICryptoManager _cryptoManager;

        public UserService(IUserRepository userRepository, ICryptoManager cryptoManager)
        {
            this._userRepository = userRepository;
            this._cryptoManager = cryptoManager;
        }

        public Task<User> RegisterAsync(string login, string password)
        {
            var user = new User { Login = login, Password = _cryptoManager.GetHash(password), Role = Role.User };
            var result = _userRepository.AddUserAsync(user).Result;
            return Task.FromResult(result);
        }

        public Task<User> FindByLoginAsync(string login)
        {
            return _userRepository.FindByLoginAsync(login);
        }

        public Task<User> FindByIdAsync(int id)
        {
            return _userRepository.FindByIdAsync(id);
        }

        public string GetHashPasswordHash(string password)
        {
            return _cryptoManager.GetHash(password);
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }
    }
}

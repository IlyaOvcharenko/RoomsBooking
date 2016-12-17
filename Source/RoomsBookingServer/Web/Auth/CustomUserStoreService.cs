using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BusinessLogic;
using Microsoft.AspNet.Identity;
using Ninject;
using Web.App_Start;

namespace Web.Auth
{
    public class CustomUserStoreService : IUserStore<AppUser>, IUserPasswordStore<AppUser>, IUserLockoutStore<AppUser, string>, IUserTwoFactorStore<AppUser, string>
    {
        [Inject]
        public IUserService UserService { get; set; }
        public CustomUserStoreService()
        {
            IKernel kernel = NinjectConfig.CreateKernel.Value;
            UserService = kernel.Get<IUserService>();
        }
        public Task CreateAsync(AppUser user)
        {
            var result = UserService.RegisterAsync(user.UserName, user.Password).Result;
            if (result != null)
            {
                user.Id = result.Id.ToString();
                user.UserName = result.Login;
                user.Role = result.Role.ToString();
                user.Password = result.Password;
            }
            return Task.FromResult(0);
        }

        public Task DeleteAsync(AppUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if(UserService != null)
                UserService.Dispose();
        }

        public Task<AppUser> FindByIdAsync(string userId)
        {
            int intId;
            if (!int.TryParse(userId, out intId))
                return Task.FromResult(new AppUser());

            var task = UserService.FindByIdAsync(intId);
            return
                task.ContinueWith(
                    t =>
                        t.Result == null
                            ? new AppUser()
                            : new AppUser
                            {
                                Id = t.Result.Id.ToString(),
                                UserName = t.Result.Login,
                                Password = t.Result.Password,
                                Role = t.Result.Role.ToString()
                            });
        }

        public Task<AppUser> FindByNameAsync(string userName)
        {
            var task = UserService.FindByLoginAsync(userName);
            return
                task.ContinueWith(
                    t =>
                        t.Result == null
                            ? null
                            : new AppUser
                            {
                                Id = t.Result.Id.ToString(),
                                UserName = t.Result.Login,
                                Password = t.Result.Password,
                                Role = t.Result.Role.ToString()
                            });
        }

        public Task<string> GetPasswordHashAsync(AppUser user)
        {
            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(AppUser user)
        {
            return Task.FromResult(user.Password != null);
        }

        public Task SetPasswordHashAsync(AppUser user, string passwordHash)
        {
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        public Task UpdateAsync(AppUser user)
        {
            return Task.FromResult(0);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(AppUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(AppUser user)
        {
            return Task.Factory.StartNew<int>(() => 0);
        }

        public Task<int> GetAccessFailedCountAsync(AppUser user)
        {
            return Task.Factory.StartNew<int>(() => 1);
        }

        public Task<bool> GetLockoutEnabledAsync(AppUser user)
        {
            return Task.Factory.StartNew<bool>(() => false);
        }

        public Task SetLockoutEnabledAsync(AppUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task SetTwoFactorEnabledAsync(AppUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetTwoFactorEnabledAsync(AppUser user)
        {
            return Task.Factory.StartNew<bool>(() => false);
        }
    }
}
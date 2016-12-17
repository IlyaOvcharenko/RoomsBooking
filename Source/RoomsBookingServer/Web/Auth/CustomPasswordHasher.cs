using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogic;
using Microsoft.AspNet.Identity;
using Ninject;
using Web.App_Start;

namespace Web.Auth
{
    public class CustomPasswordHasher : IPasswordHasher
    {
        [Inject]
        public IUserService UserService { get; set; }
        public CustomPasswordHasher()
        {

            IKernel kernel = NinjectConfig.CreateKernel.Value;
            UserService = kernel.Get<IUserService>();
        }
        public string HashPassword(string password)
        {
            return UserService.GetHashPasswordHash(password);
        }

        public PasswordVerificationResult VerifyHashedPassword
                      (string hashedPassword, string providedPassword)
        {
            if (hashedPassword == HashPassword(providedPassword))
                return PasswordVerificationResult.Success;
            else
                return PasswordVerificationResult.Failed;
        }
    }
}
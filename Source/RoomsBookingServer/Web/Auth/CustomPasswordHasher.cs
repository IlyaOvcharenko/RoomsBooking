using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogic;
using Microsoft.AspNet.Identity;
using Ninject;
using Utility;
using Web.App_Start;

namespace Web.Auth
{
    public class CustomPasswordHasher : IPasswordHasher
    {
        [Inject]
        public IUserService UserService { get; set; }

        [Inject]
        public ICryptoManager CryptoManager { get; set; }
        public CustomPasswordHasher()
        {

            IKernel kernel = NinjectConfig.CreateKernel.Value;
            UserService = kernel.Get<IUserService>();
            CryptoManager = kernel.Get<ICryptoManager>();
        }
        public string HashPassword(string password)
        {
            return password;
        }

        public PasswordVerificationResult VerifyHashedPassword
                      (string hashedPassword, string providedPassword)
        {
            var hashedProvidedPassword = CryptoManager.GetHash(providedPassword);
            if (hashedPassword == hashedProvidedPassword)
                return PasswordVerificationResult.Success;
            else
                return PasswordVerificationResult.Failed;
        }
    }
}
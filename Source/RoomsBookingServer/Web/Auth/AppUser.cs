using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Web.Auth
{
    public class AppUser : IUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {

            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim(ClaimTypes.Role, this.Role));
            return userIdentity;
        }
    }
}
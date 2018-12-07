using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wagner_DAmaral_Assignment01.Models
{
    public static class IdentitySeedData
    {
        private const string user1 = "User1";
        private const string user2 = "User2";
        private const string userPassword = "Secret123$";



        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            UserManager<IdentityUser> userManager = app.ApplicationServices
            .GetRequiredService<UserManager<IdentityUser>>();
            IdentityUser _user1 = await userManager.FindByIdAsync(user1);
            IdentityUser _user2 = await userManager.FindByIdAsync(user2);
            if (_user1 == null)
            {
                _user1 = new IdentityUser("User1");
                await userManager.CreateAsync(_user1, userPassword);
            }

            if (_user2 == null)
            {
                _user2 = new IdentityUser("User2");
                await userManager.CreateAsync(_user2, userPassword);
            }
        }
    }
}

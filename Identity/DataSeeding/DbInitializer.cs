using System.Security.Claims;
using Duende.IdentityModel;
using Identity.Data;
using Identity.Models;
using Identity.Models.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.DataSeeding
{
    public class DbInitializer : IDbInitializer
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _applicationDbContext;

        public DbInitializer(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _applicationDbContext = applicationDbContext;
        }

        public void Initialize()
        {
           
            if (!_roleManager.RoleExistsAsync(CommanIdentityDetails.Admin).
            GetAwaiter().GetResult())
            {
                //creating roles
                _roleManager.CreateAsync(new IdentityRole(CommanIdentityDetails.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(CommanIdentityDetails.Customer)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Admin",
                    Email = "admin@gmail.com",
                    Name = "Admin",
                    EmailConfirmed = true,


                },"Admin@123").GetAwaiter().GetResult();
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "customer",
                    Email = "customer@gmail.com",
                    Name = "Customer_Test",
                    EmailConfirmed = true,


                },"Test@123").GetAwaiter().GetResult();

                ApplicationUser adminUser = _applicationDbContext.ApplicationUsers.FirstOrDefault(x => x.Email.Equals("admin@gmail.com"));
                ApplicationUser customerUser = _applicationDbContext.ApplicationUsers.FirstOrDefault(x => x.Email.Equals("customer@gmail.com"));

                _userManager.AddToRoleAsync(adminUser, CommanIdentityDetails.Customer);


                var claims1 = _userManager.AddClaimsAsync(adminUser, new Claim[]
                {
                    new Claim(JwtClaimTypes.Name,adminUser.Name),
                    new Claim(JwtClaimTypes.Role,CommanIdentityDetails.Admin),

                }).Result;

                var claims2 = _userManager.AddClaimsAsync(customerUser, new Claim[]
               {
                    new Claim(JwtClaimTypes.Name,customerUser.Name),
                    new Claim(JwtClaimTypes.Role,CommanIdentityDetails.Customer),

               }).Result;
            }
        }
    }
}

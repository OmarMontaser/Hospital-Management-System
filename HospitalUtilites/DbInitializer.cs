using HospitalModels;
using HospitalRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalUtilites
{
    public class DbInitializer : IDbInitializer
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext  _context ;

        public DbInitializer(UserManager<IdentityUser> userManager,
                             RoleManager<IdentityRole> roleManager,
                             ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task Initialize()
        {
            try
            {
                if ((await _context.Database.GetPendingMigrationsAsync().ConfigureAwait(false)).Any())

                    {
                        await _context.Database.MigrateAsync().ConfigureAwait(false);
                }
            }
            catch (Exception)
            {

                throw;
            }
            if (!await _roleManager.RoleExistsAsync(WebSiteRoles.webSites_Admin).ConfigureAwait(false))
            {
                await _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.webSites_Admin)).ConfigureAwait(false);
                await _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.webSites_Patient)).ConfigureAwait(false);
                await _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.webSites_Doctor)).ConfigureAwait(false);

                await _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Omar",
                    Email = "Omar@xyz.com",
                },"Omar@1234").ConfigureAwait(false);

                var AppUser = _context.ApplicationUsers.FirstOrDefault(u => u.Email == "Omar@1234");
                if (AppUser != null)
                {
                    await _userManager.AddToRoleAsync(AppUser, WebSiteRoles.webSites_Admin).ConfigureAwait(false);
                }
            }
        }
    }
}

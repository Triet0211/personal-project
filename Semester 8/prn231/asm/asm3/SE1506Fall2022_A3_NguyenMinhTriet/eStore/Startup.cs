using BusinessObject;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<eStoreUser, IdentityRole>(options => {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            })
            .AddRoles<IdentityRole>()
            .AddRoleManager<RoleManager<IdentityRole>>()
            .AddDefaultTokenProviders()
            .AddDefaultUI()
            .AddEntityFrameworkStores<eStoreDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<eStoreUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();

            });
            CreateRoles(_userManager, _roleManager);
        }

        private void CreateRoles(UserManager<eStoreUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {

            Task<IdentityResult> roleResult;
            string adminEmail = Configuration["Administrator:Email"];
            string adminPassword = Configuration["Administrator:Password"];

            //Check that there is an Administrator role and create if not
            Task<bool> hasAdminRole = _roleManager.RoleExistsAsync("Administrator");
            hasAdminRole.Wait();

            if (!hasAdminRole.Result)
            {
                roleResult = _roleManager.CreateAsync(new IdentityRole("Administrator"));
                roleResult.Wait();
            }

            Task<bool> hasMemberRole = _roleManager.RoleExistsAsync("Member");
            hasMemberRole.Wait();

            if (!hasMemberRole.Result)
            {
                roleResult = _roleManager.CreateAsync(new IdentityRole("Member"));
                roleResult.Wait();
            }

            //Check if the admin user exists and create it if not
            //Add to the Administrator role

            Task<eStoreUser> testUser = _userManager.FindByEmailAsync(adminEmail);
            testUser.Wait();

            if (testUser.Result == null)
            {
                eStoreUser administrator = new eStoreUser();
                administrator.Email = adminEmail;
                administrator.UserName = adminEmail;
                administrator.FirstName = "eStore";
                administrator.LastName = "Administrator";

                Task<IdentityResult> newUser = _userManager.CreateAsync(administrator, adminPassword);
                newUser.Wait();

                if (newUser.Result.Succeeded)
                {
                    Task<IdentityResult> newUserRole = _userManager.AddToRoleAsync(administrator, "Administrator");
                    newUserRole.Wait();
                }
            }

        }
    }
}

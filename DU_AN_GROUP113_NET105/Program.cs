using DU_AN_GROUP113_NET105.Models.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace DU_AN_GROUP113_NET105
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ProjectContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectASM_GR113")));

            builder.Services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromSeconds(600); // Set thời gian timeout của session là 600 giây
            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Customer/AccountCustomer/Login"; // Đường dẫn tới trang đăng nhập
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                // Cấu hình route cho area Customer
                endpoints.MapControllerRoute(
                    name: "customer",
                    pattern: "{area:exists}/{controller=HomeCustomer}/{action=Index}/{id?}",
                    defaults: new { area = "Customer", controller = "HomeCustomer", action = "Index" });

            });
            app.Run();
        }
    }
}

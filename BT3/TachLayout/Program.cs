using TachLayout.Models;
using Microsoft.Data.SqlClient;
using TachLayout.Services;

namespace TachLayout
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ?? ??ng k� c�c d?ch v? c?n thi?t
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSession();                 // d�ng session
            builder.Services.AddSingleton<DbService>();    // k?t n?i DB

            var app = builder.Build();

            // ?? X? l� l?i v� HTTPS
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // ?? Th? t? middleware r?t quan tr?ng
            app.UseHttpsRedirection();
            app.UseStaticFiles();  // cho ph�p load ?nh, css, js

            app.UseRouting();

            app.UseSession();      // session n�n ??t sau Routing, tr??c Authorization
            app.UseAuthorization();

            // ?? Map route cho khu v?c (Areas)
            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
            );

            // ?? Route m?c ??nh
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

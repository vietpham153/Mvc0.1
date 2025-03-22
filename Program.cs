using App.ExtendMethods;
using App.Services;

namespace App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddSingleton<PlanetService>();
            //builder.Services.AddDbContext<AppDbContext>(options =>
            //{
            //    var connectString = builder.Services.GetConnectionString("DbConnect");
            //    options.UseSqlServer(connectString);
            //});
            builder.Services.Configure<RouteOptions>(routes =>
            {
                routes.LowercaseUrls = true;
            });
            builder.Services.AddSingleton<ProductService>();
            var app = builder.Build();
            var env = app.Services.GetRequiredService<IWebHostEnvironment>();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.AddStatusCodePage(); // loi 400 - 599 da duoc extend method

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

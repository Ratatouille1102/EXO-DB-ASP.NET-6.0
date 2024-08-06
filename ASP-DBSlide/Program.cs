using BLL = BLL_DBSlide;
using DAL = DAL_DBSlide;
using Common_DBSlide.Repositories;
using ASP_DBSlide.Handlers;

namespace ASP_DBSlide
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options => {
                options.Cookie.Name = "ASPDBSlide";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(5);
            });
            builder.Services.Configure<CookiePolicyOptions>(options => {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.Secure = CookieSecurePolicy.Always;
            });

            builder.Services.AddScoped<SessionManager>();

            builder.Services.AddScoped<IStudentRepository<BLL.Entities.Student>, BLL.Services.StudentService>();
            builder.Services.AddScoped<IStudentRepository<DAL.Entities.Student>, DAL.Services.StudentService>();
            builder.Services.AddScoped<ISectionRepository<BLL.Entities.Section>, BLL.Services.SectionService>();
            builder.Services.AddScoped<ISectionRepository<DAL.Entities.Section>, DAL.Services.SectionService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSession();
            app.UseCookiePolicy();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

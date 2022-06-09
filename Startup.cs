using KKKKPPP.Data;
using KKKKPPP.Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KKKKPPP.Data.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace KKKKPPP
{
    public class Startup
    {

        private IConfigurationRoot _confString;

        public Startup(IHostEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            }); 
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                 .AddCookie(options => //CookieAuthenticationOptions
                {
                     options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                 });
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddTransient<IАвтор, АвторRepos>();
            services.AddTransient<IТехника, ТехникаRepos>();
            services.AddTransient<IСостояние, СостояниеRepos>();
            services.AddTransient<IСтатусКартины, СтатусКартиныRepos>();
            services.AddTransient<IСтатусЭкспозиции, СтатусЭкспозицииRepos>();
            services.AddTransient<IСтрана, СтранаRepos>();
            services.AddTransient<IЖанр, ЖанрRepos>();
            services.AddTransient<IСтиль, СтильRepos>();
            services.AddTransient<IСущности, СущностьRepos>();
            services.AddTransient<IКартина, КартинаRepos>();
            services.AddTransient<IСвязь_Материал_Картина, Связь_Материал_КартинаRepos>();
            services.AddTransient<IСвязь_Рест_Вид, Связь_Рест_ВидRepos>();
            services.AddTransient<IРеставрация, РеставрацияRepos>();
            services.AddTransient<IМатериал, МатериалRepos>();
            services.AddTransient<IВид_реставрации, Вид_реставрацииRepos>();
            services.AddTransient<IЭкспозиция, ЭкспозицияRepos>();
            services.AddTransient<IЭкскурсия, ЭкскурсияRepos>();
            services.AddTransient<IЭкспонат, ЭкспонатRepos>();
            services.AddTransient<IЗал, ЗалRepos>();
            services.AddTransient<IМесто, МестоRepos>();
            services.AddTransient<IАналитический_отчет, Аналитический_отчетRepos>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();    // аутентификация
            app.UseAuthorization();     // авторизация
            app.UseSession();
            app.UseMvcWithDefaultRoute();

            using (var scope = app.ApplicationServices.CreateScope())
            {
                //**добавляем объекты сущностей в бд**
                AppDBContext context = scope.ServiceProvider.GetRequiredService<AppDBContext>(); //подключаем adddbcоnetnt к бд?
            }
        }
    }
}

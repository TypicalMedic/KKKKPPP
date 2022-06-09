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
            services.AddTransient<I�����, �����Repos>();
            services.AddTransient<I�������, �������Repos>();
            services.AddTransient<I���������, ���������Repos>();
            services.AddTransient<I�������������, �������������Repos>();
            services.AddTransient<I����������������, ����������������Repos>();
            services.AddTransient<I������, ������Repos>();
            services.AddTransient<I����, ����Repos>();
            services.AddTransient<I�����, �����Repos>();
            services.AddTransient<I��������, ��������Repos>();
            services.AddTransient<I�������, �������Repos>();
            services.AddTransient<I�����_��������_�������, �����_��������_�������Repos>();
            services.AddTransient<I�����_����_���, �����_����_���Repos>();
            services.AddTransient<I�����������, �����������Repos>();
            services.AddTransient<I��������, ��������Repos>();
            services.AddTransient<I���_�����������, ���_�����������Repos>();
            services.AddTransient<I����������, ����������Repos>();
            services.AddTransient<I���������, ���������Repos>();
            services.AddTransient<I��������, ��������Repos>();
            services.AddTransient<I���, ���Repos>();
            services.AddTransient<I�����, �����Repos>();
            services.AddTransient<I�������������_�����, �������������_�����Repos>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();    // ��������������
            app.UseAuthorization();     // �����������
            app.UseSession();
            app.UseMvcWithDefaultRoute();

            using (var scope = app.ApplicationServices.CreateScope())
            {
                //**��������� ������� ��������� � ��**
                AppDBContext context = scope.ServiceProvider.GetRequiredService<AppDBContext>(); //���������� adddbc�netnt � ��?
            }
        }
    }
}

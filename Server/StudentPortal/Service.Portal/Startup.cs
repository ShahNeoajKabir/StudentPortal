using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Security.BLLManager;
using StudentPortal.DAL;
using Microsoft.EntityFrameworkCore;
using SecurityBLLManager;
using Newtonsoft.Json.Serialization;
namespace Service.Portal
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

            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    });
            services.AddControllers();
            services.AddDbContext<StudentPortalDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Connection")), ServiceLifetime.Transient);
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.AddScoped<ISecurityBLLManager, Security.BLLManager.SecurityBLLManager>();
            services.AddScoped<IUserBLLManager, UserBLLManager>(); 
            services.AddScoped<IStudentBLLManager, StudentBLLManager>();
            services.AddScoped<IParentsBLLManager, ParentsBLLManager>();
            services.AddScoped<ICourseBLLManager, CourseBLLManager>();
            services.AddScoped<ITeacherBLLManager, TeacherBLLManager>();
            services.AddScoped<ISemesterBLLManager, SemesterBLLManager>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

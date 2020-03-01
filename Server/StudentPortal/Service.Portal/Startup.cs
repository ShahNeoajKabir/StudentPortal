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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using StudentPortal.DTO.ViewModel;
using System.Text;
using Service.Portal.Handler;
using Microsoft.AspNetCore.HttpOverrides;

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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JwtTokenSetting:Issuer"],
                    ValidAudience = Configuration["JwtTokenSetting:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtTokenSetting:Key"]))
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", null);
                //var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                //var xmlPath = Path.Combine(basePath, "SwaggerProject.xml");
                //c.IncludeXmlComments(xmlPath);
            });


            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.Configure<JwtTokenSetting>(Configuration.GetSection("JwtTokenSetting")); 
            services.AddScoped<ISecurityBLLManager, Security.BLLManager.SecurityBLLManager>();
            services.AddScoped<IUserBLLManager, UserBLLManager>();
            services.AddScoped<IAuthenticationManager, AuthenticationManager>();

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
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

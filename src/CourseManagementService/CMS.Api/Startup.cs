using System;
using CMS.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EFCore.GenericRepository;
using CMS.BLL.CourseInformationBusiness;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;
using CMS.BLL.StudentCourseJunctionBusiness;
using CMS.BLL.StudentCourseScoreBusiness;
using EventManager.DefaultManager.Extensions;

namespace CMS.Api
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
            services.AddDbContext<CourseServiceDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("CourseManagementDefaultConnection")));


            services.AddEMDefaultManager(opt =>
            {
                opt.CheckIsEventUnique = false;
            });
            //.UseSQLChecker(opt => opt.UseSqlServer(Configuration.GetConnectionString("EventDbConnectionString")));
            services.AddGenericRepositoryScoped();

            services.AddTransient<CourseInformationService>();
            services.AddTransient<StudentCourseJunctionService>();
            services.AddTransient<StudentCourseScoreService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Course Management Api",
                    Description = "Course Management Api",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Musa Demir", Email = "demirmusa96@gmail.com" }
                });
            });
            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI V1");
                });
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            serviceProvider.InitializeEMDefaultManager("localhost");

            app.UseHttpsRedirection();
            app.UseMvc();
           
        }
    }
}

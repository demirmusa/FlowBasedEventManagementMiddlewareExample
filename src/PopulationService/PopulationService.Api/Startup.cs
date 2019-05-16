using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PopulationService.BLL;
using PopulationService.DAL;
using AutoMapper;
using EFCore.GenericRepository;
using Swashbuckle.AspNetCore.Swagger;

namespace PopulationService.Api
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
            services.AddDbContext<PopulationDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("PopulationServiceConnectionString")));

            services.AddAutoMapper();
            services.AddTransient<IPopulationService, PopulationServiceBL>();

            services.AddGenericRepositoryScoped();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info()
                {
                    Version = "v1",
                    Title = "Population Management Api",
                    Description = "Population Management Api",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Musa Demir", Email = "demirmusa96@gmail.com" }
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI V1");
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

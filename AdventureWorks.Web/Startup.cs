using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorks.Business.Models;
using AdventureWorks.Business.Services;
using AdventureWorks.Data;
using AdventureWorks.Data.Entities;
using AdventureWorks.Data.Repositories;
using AdventureWorks.Web.Controllers;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AdventureWorks.Web
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
            services.AddTransient(typeof(GenericRepository<>));
            services.AddTransient(typeof(GenericService<,>));
            services.AddTransient(typeof(GenericController<,>));

            services.AddDbContext<AdventureWorksContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AdventureWorks"));
            });

            services.AddControllers();
        }

        // public void ConfigureContainer(ContainerBuilder builder)
        // {
        //     builder.RegisterType(typeof(GenericRepository<>))
        // }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
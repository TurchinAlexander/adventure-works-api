using AdventureWorks.Web.Filter;
using AdventureWorks.Web.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using System.Reflection;

namespace AdventureWorks.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add
        // services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Adventure Works API", Version = "v1" });
            });

            var projectAssemblies = Assembly.GetExecutingAssembly()
                .GetReferencedAssemblies()
                .Where(a => a.FullName.Contains("AdventureWorks"))
                .Select(a => Assembly.Load(a))
                .ToArray();

            // projectAssemblies = projectAssemblies.Where(a => a.FullName.Contains("AdventureWorks")).ToArray();

            services.AddAutoMapper(projectAssemblies);

            services.AddDependecyRegistration();

            services.AddMvc(options =>
            {
                options.Filters.Add<ExceptionFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure
        // the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

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
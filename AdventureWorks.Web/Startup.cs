using System.Configuration;
using AdventureWorks.Business.Services;
using AdventureWorks.Data;
using AdventureWorks.Data.Repositories;
using AdventureWorks.Web.Controllers;
using AdventureWorks.Web.Filter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

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
            services.AddTransient(typeof(GenericRepository<>));
            services.AddTransient(typeof(GenericService<,,>));
            // services.AddTransient(typeof(GenericController<,,>));
            services.AddTransient(typeof(ProductController));

            services.AddDbContext<AdventureWorksContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AdventureWorks"));
            });

            services.AddControllers();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Adventure Works API", Version = "v1" });
            });

            services.AddMvc(options =>
            {
                // options.Filters.Add<ExceptionFilter>();
            });

            services.AddOptions();

            services.Configure<AzureSettings>(Configuration.GetSection("Azure"));
        }

        // This method gets called by the runtime. Use this method to configure
        // the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IOptions<AzureSettings> azureSettings)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddTableStorage(azureSettings.Value.Table, azureSettings.Value.ConnectionString);

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
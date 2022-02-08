using ApiCRUD.Bl.IoC;
using ApiCRUD.Bl.Mapping;
using ApiCRUD.Context;
using ApiCRUD.Core.IoC;
using ApiCRUD.Core.Model;
using ApiCRUD.Model.IoC;
using ApiCRUD.Services;
using ApiCRUD.Services.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace ApiCRUD
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
            services.AddControllers();

            services.AddCoreRegistry();
            services.AddModelRegistry();
            services.AddBlRegistry();
            services.AddServiceRegistry();

            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<VehicleContext>( op => op.UseSqlite(connectionString));
        }

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

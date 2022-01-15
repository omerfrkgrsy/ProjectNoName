using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProjectNoName.Business.Abstract;
using ProjectNoName.Business.Concrete;
using ProjectNoName.Core.Data.Abstract;
using ProjectNoName.Core.Data.Concrete;
using ProjectNoName.Core.Service.Abstract;
using ProjectNoName.Core.Service.Concrete;
using ProjectNoName.Repository;
using ProjectNoName.Repository.Abstract;
using ProjectNoName.Repository.Concrete;
using ProjectNoName.Repository.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNoName.Api
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjectNoName.Api", Version = "v1" });
            });
            //services.AddDbContext<DataContext>(options => options.UseNpgsql(Configuration.GetConnectionString("ProjectDB"), b => b.MigrationsAssembly("Blog.Api")));
            services.AddDbContextPool<DataContext>(options => options.UseNpgsql(Configuration.GetConnectionString("ProjectDB")).EnableSensitiveDataLogging());

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserManager>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectNoName.Api v1"));
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

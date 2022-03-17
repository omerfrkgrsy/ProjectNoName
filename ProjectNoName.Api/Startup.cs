using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using ProjectNoName.Api.Filter;
using ProjectNoName.Api.Helper;
using ProjectNoName.Business.Abstract;
using ProjectNoName.Business.Concrete;
using ProjectNoName.Business.Dto;
using ProjectNoName.Business.ValidationRules.FluentValidation;
using ProjectNoName.Repository.EntityFramework.Abstract;
using ProjectNoName.Repository.EntityFramework.Concrete;
using ProjectNoName.Repository.EntityFramework.Context;
using System.Linq;
using System.Text.Json.Serialization;

namespace ProjectNoName.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjectNoName.Api", Version = "v1" });
            });
            services.AddDbContext<DataContext>(options => options.UseNpgsql(Configuration.GetConnectionString("ProjectDB"), b => b.MigrationsAssembly("ProjectNoName.Api")));

            

            services
              .AddControllers(options =>
              {
                  options.Filters.Add(typeof(ValidationFilter));
                  options.EnableEndpointRouting = false;
              }).ConfigureApiBehaviorOptions(options =>
              {
                  options.SuppressModelStateInvalidFilter = true;
              })
              .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserRegisterValidator>())
              .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);


            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostService, PostManager>();
            services.AddScoped<IRelationShipRepository, RelationShipRepository>();
            services.AddScoped<IRelationShipService, RelationShipManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,DataContext dataContext)
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

            if (dataContext.Database.GetPendingMigrations().Any())
            {
                dataContext.Database.Migrate();
            }
           

        }
    }
}

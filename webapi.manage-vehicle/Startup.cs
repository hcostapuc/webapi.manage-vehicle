using AutoMapper;
using infrastructure.manage_vehicle.Context;
using infrastructure.manage_vehicle.Interfaces;
using infrastructure.manage_vehicle.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using service.manage_vehicle.Configuration;
using System;
using MediatR;
using System.Text.Json.Serialization;

namespace webapi.manage_vehicle
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
                    .AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddDbContext<ManageVehicleContext>(opt => opt.UseInMemoryDatabase("poc"));

            //DI
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IVendaRepository), typeof(VendaRepository));

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "API Manage Vehicle",
                    Version = "v2",
                    Description = "Sample service for Learner",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact { 
                        Email = "hcostapuc@gmail.com",
                        Name = "Hebert Costa Andrade",
                        Url = new System.Uri("https://github.com/hcostapuc")
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(opt => opt.SwaggerEndpoint("/swagger/v2/swagger.json", "PlaceInfo Services"));
        }
    }
}

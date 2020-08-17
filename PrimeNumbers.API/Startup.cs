using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using PrimeNumbers.API.Data;
using PrimeNumbers.API.Repositories;
using PrimeNumbers.API.Services;
using PrimeNumbers.API.Settings;

namespace PrimeNumbers.API
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

            // Register services for dependency injection. Any class that references them will get fetch them from appsettings.
            services.Configure<NumbersDatabaseSettings>(Configuration.GetSection(nameof(NumbersDatabaseSettings)));
            services.AddSingleton<INumbersDatabaseSettings>(s => s.GetRequiredService<IOptions<NumbersDatabaseSettings>>().Value);

            services.AddTransient<INumbersContext, NumbersContext>();
            services.AddTransient<IPrimeNumberCoupleRepository, PrimeNumberCoupleRepository>();
            services.AddTransient<INumbersService, NumbersService>();

            services.AddSwaggerGen(s =>
            s.SwaggerDoc("v1.0", new OpenApiInfo
            {
                Title = "Prime Numbers API",
                Version = "v1.0",
                Description = "A small .NET Core Web API to check whether a number is prime and what's the next prime number after a given one."
            }));
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
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Prime Numbers API v1.0");
            });
        }
    }
}

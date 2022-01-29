using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bank.API.Controllers.Customer;
using Bank.API.Controllers.Manager;
using Bank.API.Controllers.Officer;
using Bank.API.Controllers.Teller;
using Bank.Data;
using Microsoft.EntityFrameworkCore;

namespace Bank.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddCors(options =>
            {
                options.AddPolicy("_myAllowSpecificOrigins",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200",
                            "http://localhost:6600");
                    });
            });


            services.AddControllers();
            
            /* Here we register our DBContext, which is BankContext, and we are getting the connection string from
             appsettings.json under the parent category of ConnectionStrings.
             */
            services.AddDbContext<BankContext>(opt =>
                opt.UseSqlServer("Server=sql-banking-app.database.windows.net,1433;Database=sqldb-banking-app;UID=uami-bank-app-db;Authentication=Active Directory Interactive")
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll)
                    .EnableSensitiveDataLogging());
            
            // Here we configure to ignore the infinite loops of relation/reference created by ef core
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            // Allows us to use ICustomer/Customer Repository as a service
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IManagerRepository, ManagerRepository>();
            services.AddScoped<IOfficerRepository, OfficerRepository>();
            services.AddScoped<ITellerRepository, TellerRepository>();
            
            // This allows us to use the mapper which can convert Objects to model Objects and vice versa.
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(x => x.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

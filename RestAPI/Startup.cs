using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PetShop2019.Core.ApplicationService;
using PetShop2019.Core.ApplicationService.Implementation;
using PetShop2019.Core.DomainService;
using PetShop2019.Infrastructure.Data;
using PetShop.Infrastructure.SQL;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using OwnerRepository = PetShop.Infrastructure.SQL.Repositories.OwnerRepository;
using PetRepository = PetShop.Infrastructure.SQL.Repositories.PetRepository;

namespace RestAPI
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add CORS
            services.AddCors();

            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();

            services.AddMvc().AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                opt.SerializerSettings.MaxDepth = 3;
            });

            //Add the DB here please..
            if (Environment.IsDevelopment())
            {
                //In-memory DB
                //services.AddDbContext<PetShop2019Context>(options => options.UseInMemoryDatabase("petshopDB"));
                services.AddDbContext<PetShop2019Context>(options => options.UseSqlite("Data Source=PetshopApp.db"));
            }
            else
            {
                //Azure SQL Database
                services.AddDbContext<PetShop2019Context>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            }

            services.AddTransient<IDbInitializer, DbInitializer>();



            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Initialize Data
            using (var scope = app.ApplicationServices.CreateScope())
            {
                //Initialize database
                var services = scope.ServiceProvider;
                var dbContext = services.GetService<PetShop2019Context>();
                var dbInitializer = services.GetService<IDbInitializer>();
                dbInitializer.Initialize(dbContext);
            }

            if (env.IsDevelopment())
            {



                //Initialize Data
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    //Initialize database
                    var services = scope.ServiceProvider;
                    var dbContext = services.GetService<PetShop2019Context>();
                    var dbInitializer = services.GetService<IDbInitializer>();
                    dbContext.Database.EnsureDeleted();
                    dbContext.Database.EnsureCreated();
                    dbInitializer.Initialize(dbContext);
                }

                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // Enable CORS
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseMvc();
        }
    }
}

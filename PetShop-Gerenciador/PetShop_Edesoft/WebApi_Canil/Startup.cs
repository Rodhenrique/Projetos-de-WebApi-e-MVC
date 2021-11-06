using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Canil.Domains;
using WebApi_Canil.Interfaces;
using WebApi_Canil.Repositories;

namespace WebApi_Canil
{
    public class Startup
    {
        private DatabaseSettings databaseSettings { get; set; }

        public Startup()
        {
            this.databaseSettings = ConfigRepository.GetAppSetting().DatabaseSettings;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
             .AddTransient<ICaes, CaesRepository>()
             .AddTransient<ICaesDono, CaesDonoRepository>()
             .AddTransient<IDonos, DonosRepository>()
             .AddTransient<IRaca, RacaRepository>()
             .AddMvc()
             .AddJsonOptions(options => {
                 options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                 options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
             })
             .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen();

            if (databaseSettings.SqlServer)
                services.AddDbContext<CanilContext>(options => options.UseSqlServer($"Data Source={databaseSettings.ConnectionString}"));
            else
                services.AddDbContext<CanilContext>(options => options.UseSqlite($"Data Source={databaseSettings.Path}"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, CanilContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            if (databaseSettings.SqlServer && db.Database.EnsureCreated())
            {
                db.Database.Migrate();
            }
            else
            {
                SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder();
                connectionStringBuilder.DataSource = "Database/canil.db";
                db.Database.Migrate();
            }
            app.UseMvc();
        }
    }
}

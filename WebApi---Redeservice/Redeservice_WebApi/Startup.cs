using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Redeservice_WebApi.Context;
using Redeservice_WebApi.Interfaces;
using Redeservice_WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Redeservice_WebApi
{
    public class Startup
    {
        private string PATH = "Database/agrotools.db";

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddTransient<IUsuario, UsuarioRepository>()
                .AddDbContext<ContextService>(options => options.UseSqlite($"Data Source={PATH}"))
             .AddMvc()
             .AddJsonOptions(options => {
                 options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                 options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
             })

             .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Context.ContextService db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder();

            if (!File.Exists(PATH))
            {
                connectionStringBuilder.DataSource = "Database/agrotools.db";
                db.Database.Migrate();
            }
            app.UseMvc();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi_Invest_Peak_Net_Core.Interfaces;
using WebApi_Invest_Peak_Net_Core.Models;
using WebApi_Invest_Peak_Net_Core.Repositories;
using WebApi_Invest_Peak_Net_Core.ViewModels;

namespace WebApi_Invest_Peak_Net_Core
{
    public class Startup
    {
     
        public void ConfigureServices(IServiceCollection services)
        {
            services
               .AddMvc()
               .AddJsonOptions(options =>
               {
                   options.JsonSerializerOptions.IgnoreNullValues = true;
               });

            services.AddControllers();
            services.AddTransient<IUsuario, UsuarioRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            UsuarioRepository repository = new UsuarioRepository();
            repository.post(new UsuarioViewModel() { nome = "João" });
            repository.post(new UsuarioViewModel() { nome = "Maria" });
            repository.post(new UsuarioViewModel() { nome = "Ana" });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

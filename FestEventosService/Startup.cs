using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FestEventosDomain.Contracts.IRepositories;
using FestEventosDomain.Contracts.IServices;
using FestEventosDomain.Contracts.UoW;
using FestEventosDomain.Services;
using FestEventosInfra.DataContext;
using FestEventosInfra.Repositories;
using FestEventosInfra.UoW;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SimpleInjector;

namespace FestEventosService
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<FestEventoContext>();
            services.AddScoped<IUnnitOfWork, EfUnitOfWork>();
            services.AddScoped<IEventoService, EventoService>();
            services.AddScoped<IEventoRepository, EventoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

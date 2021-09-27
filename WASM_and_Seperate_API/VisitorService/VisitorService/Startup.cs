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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorService.ModelContexts;
using VisitorService.Repositories;
using AutoMapper;

namespace VisitorService
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VisitorService", Version = "v1" });
            });

            //13.09.2021
            services.AddDbContext<AppDbContext>(
               options => options.UseNpgsql(
                   Configuration.GetConnectionString("LocalConnection") //appsettings.json
               )
            );
            //services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMemDb"));
            services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>()); //
            services.AddScoped<IVisitorRepository, VisitorRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //24.09
            services.AddCors();
            //services.AddRazorPages();
            services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VisitorService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //24.09
            app.UseCors(
                options => options.WithOrigins("https://localhost:44313").AllowAnyMethod()
            );
            app.UseMvc();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //PrepareDb.PreparePopulation(app);
        }
    }
}


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SOSU2022_BacEnd.Domain.IRepositories;
using SOSU2022_BacEnd.Domain.Services;
using SOSU2022_BackEnd.Core.IServices;
using SOSU2022_BackEnd.Core.Models;
using SOSU2022_BackEnd.DataAcces.Repositories;

namespace SOSU2022_BackEnd
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
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "SOSU2022_BackEnd.WebApi", Version = "v1"});
                
            });

            services.AddScoped<ICitizenRepository, CitizenRepository>();
            services.AddScoped<ICitizenService, CitizenService>();
            services.AddScoped<ICitizenDatabaseSettings, SOSUDatabaseSettings>();
            services.AddScoped<ICaseOpeningRepository, CaseOpeningRepository>();
            services.AddScoped<ICaseOpeningService, CaseOpeningService>();
            services.AddScoped<IGeneralInfoRepository, GeneralInfoRepository>();
            services.AddScoped<IGeneralInfoService, GeneralInfoService>();
            services.AddScoped<IFunctionalStateRepository, FunctionalStateRepository>();
            services.AddScoped<IFunctionalStateService, FunctionalStateService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddCors(options => 
                {options.AddPolicy("Dev-cors", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SOSU2022_BackEnd.WebApi v1"));
                app.UseCors("Dev-cors");
                app.UseWebSockets();

            }
                
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
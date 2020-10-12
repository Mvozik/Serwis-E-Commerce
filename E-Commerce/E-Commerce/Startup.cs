using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using E_Commerce.Shared.Models;
using System.Text;
using E_Commerce.Shared.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using E_Commerce.ShopModule.Services.IService;
using E_Commerce.ShopModule.Services;

namespace E_Commerce
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

            var jwtSettings = new JwtSettings();
            Configuration.Bind(nameof(jwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);
            services.AddMvc(options=> { options.EnableEndpointRouting = false; }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddDbContext<DataContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
               );

            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<DataContext>();

            services.AddScoped<IAdvertService, AdvertService>();
            services.AddScoped<IShoppingCardService, ShoppingCardService>();

            services.AddSwaggerGen(c=>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { Version="V1",Title="E-Commerce API",Description="My Project" });

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer",new string[0] }
                };

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                { 
                    Description="JWT AUTH",
                    Name="Authorization",
                    In=ParameterLocation.Header,
                    Type=SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { new OpenApiSecurityScheme{ Reference = new OpenApiReference{ Id="Bearer",Type=ReferenceType.SecurityScheme} },new List<string>() }
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

            app.UseSwagger(c => 
            { 
                c.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Api");
                c.RoutePrefix = string.Empty;
            });
            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }



    }
}

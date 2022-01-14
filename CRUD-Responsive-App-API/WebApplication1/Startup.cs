using CRUD_Reponsive_Web_API;
using CRUD_Reponsive_Web_API.Interfaces;
using CRUD_Reponsive_Web_API.Mapping;
using CRUD_Reponsive_Web_API.Services;
using CRUD_Resonsive_Web_API.Interfaces;
using CRUD_Resonsive_Web_API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace WebApplication1
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

            services.AddMvc();
            services.AddDbContext<MyDBContext>(options => options.UseInMemoryDatabase("MyDbContext"));
            services.AddScoped<MyDBContext>();

            var userAccounts = new Dictionary<string, string>
            {
                { "testuser@gmail.com", "test1234"}
            };
            services.AddMemoryCache();

            //Register services
            services.AddSingleton<IAccountService>(new AccountService(userAccounts));
            services.AddTransient<IUserService, UserService>();

            var key = Encoding.ASCII.GetBytes("SomeRandomlyGeneratedStringSomeRandomlyGeneratedString");
            services.AddAutoMapper(typeof(EntityToDTO));
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           app.UseRouting();
            app.UseCors(x => x
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();
         
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });


        }
    }
}

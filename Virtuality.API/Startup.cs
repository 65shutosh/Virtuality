using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Virtuality.API.Data;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Virtuality.API.Helpers;

namespace Virtuality.API
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
            //# Adding DataBase as SQLite and configuring its connection
            services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            //Install Microsoft.AspNetCore.Mvc.NewtonsoftJson using Nuget
            //add AddNewtonsoftJson() to service.AddControllers()
            services.AddControllers().AddNewtonsoftJson();
            //# Adding  CORS - Cross Origin Resource sharing
            services.AddCors();

            // Marking Services so that they can be injected anywhere per need
            //singleton - for single instance only
            //singleTransient - for every call new object gets created and these are light weight objects
            //AddScoped - for one HTTP request there is only one instance gets created
            services.AddScoped<IAuthRepository, AuthRepository>();

            //Authentication middleware
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                              .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
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
            // this else part is there to control what results should be returned when 
            // the project is not in development mode and Exception occures
            // all this just to make sure client does not get anything that's not for him and a proper error
            else
            {
                app.UseExceptionHandler(
                    builder =>
                    {
                        builder.Run(
                            async context =>
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                var error = context.Features.Get<IExceptionHandlerFeature>();

                                if (error != null)
                                {
                                    context.Response.AddApplicationError(error.Error.Message);
                                    await context.Response.WriteAsync(error.Error.Message);
                                }
                            }
                         );
                    }
                );
            }
            //# Allowing  CORS - if error might popup use it afterhttpRedirection -
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();
            //# Authentication is about letting in 
            app.UseAuthentication();

            // Previously Provided - its all about allowed actions
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

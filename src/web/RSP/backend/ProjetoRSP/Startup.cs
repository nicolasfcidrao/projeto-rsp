using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProjetoRSP.Infra;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ProjectRSP.Shared.DTOs;

namespace ProjetoRSP
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
            var jwtSettings = new JwtSettings();
            Configuration.Bind(nameof(JwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);

            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjetoRSP", Version = "v1" });
                // c.AddSecurityDefinition("Bearer",
                //     new OpenApiSecurityScheme
                //     {
                //         In = ParameterLocation.Header,
                //         Description = "Please enter into field the word 'Bearer' following by space and JWT", 
                //         Name = "Authorization", 
                //         Type = SecuritySchemeType.ApiKey,
                //         Scheme = "Bearer"
                //     });
                //     c.AddSecurityRequirement(
                //         new OpenApiSecurityRequirement
                //         {
                //             {
                //                 new OpenApiSecurityScheme
                //                 {
                //                     Reference = new OpenApiReference
                //                     {
                //                         Type = ReferenceType.SecurityScheme,
                //                         Id = "Bearer"
                //                     }
                //                 },
                //                 Array.Empty<string>()
                //             }
                //         }
                //     );
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });
            });
            services.AddDbContext<ProjectRSPContext>(options => 
            {
                var connectionString = Configuration[$"ConnectionStrings:DefaultConnection@{Environment.MachineName}"];
                connectionString ??= Configuration["ConnectionStrings:DefaultConnection"];
                options.UseSqlServer(connectionString);
            });
            services.AddValidatorsFromAssembly(typeof(Startup).Assembly);

            //JWT Authentication
            var key = Encoding.UTF8.GetBytes(jwtSettings.Secret);
            var tokenParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero,

            };
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = tokenParameters;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ProjectRSPContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (context)
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();
                context.Database.Migrate();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoRSP v1"));

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

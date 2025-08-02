﻿using Dashboard.Application.Interfaces;
using Dashboard.Infrastructure.Persistence;
using Dashboard.Infrastructure.Repository;
using Dashboard.Infrastructure.Services.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System.Reflection.Metadata;
using System.Text;

namespace Dashboard.WebAPI.Extensions
{
    public static class DependencyInjection
    {
        public static WebApplicationBuilder AddApiServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers(options =>
            {
                options.ReturnHttpNotAcceptable = true;
            })
            .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver())
            .AddXmlSerializerFormatters();

            builder.Services.AddOpenApi();

            return builder;
        }

        public static WebApplicationBuilder AddApplicationServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));

            builder.Services.AddTransient<ITokenProvider , TokenProvider>();

            builder.Services.AddScoped<IUserRepository, UserRepository>();


            return builder;
        }

        public static WebApplicationBuilder AddDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                sqlServerOptionsAction => sqlServerOptionsAction.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Application))
                );

            builder.Services.AddDbContext<ApplicationIdentityDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                sqlServerOptionsAction => sqlServerOptionsAction.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Identity))
                );

            return builder;
        }

        public static WebApplicationBuilder AddAuthenticationServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>();

            builder.Services.Configure<JwtAuthOptions>(builder.Configuration.GetSection("Jwt"));

            JwtAuthOptions jwtAuthOptions = builder.Configuration.GetSection("Jwt").Get<JwtAuthOptions>()!;

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = jwtAuthOptions.Issuer,
                        ValidAudience = jwtAuthOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAuthOptions.Key))
                    };
                });

            builder.Services.AddAuthorization();

            return builder;
        }

    }
}

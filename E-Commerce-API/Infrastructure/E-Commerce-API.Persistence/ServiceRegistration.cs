﻿using E_Commerce_API.Application.AutoMapper;
using E_Commerce_API.Application.Repositories;
using E_Commerce_API.Persistence.Contexts;
using E_Commerce_API.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using E_Commerce_API.Domain.Entites;
using E_Commerce_API.Persistence.Concretes;
using E_Commerce_API.Infrastructure.Interfaces;
using E_Commerce_API.Infrastructure.ImageService;
using E_Commerce_API.Persistence.Concretes.ProductColor;
using E_Commerce_API.Infrastructure.Interfaces.PymentService;
using E_Commerce_API.Infrastructure.PaymetServices;

namespace E_Commerce_API.Persistence
{
    public static class ServiceRegistration
    {
        
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            #region Connection String
            services.AddDbContext<ECommerceAPIDBContext>(options => options.UseSqlServer(Configuration.ConnectionString, b => b.MigrationsAssembly(typeof(ECommerceAPIDBContext).Assembly.FullName)));
            #endregion

            #region Automapper
            services.AddAutoMapper(typeof(AutoMapperProfile));
            #endregion

            #region JWT Configure
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("myksssssssssssss3333ey")),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // Dependency Injection Jwt service
            services.AddScoped<ITokenServiceRepository, TokenServiceRepository>();
            #endregion

            #region Identity services configure
            services.AddIdentityCore<AppUser>(opt => {
                opt.User.RequireUniqueEmail = true;
            })
            .AddRoles<Role>()
            .AddEntityFrameworkStores<ECommerceAPIDBContext>();
            #endregion

            #region Dependency Injection category service 
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            #endregion

            #region Dependency Injection product service 
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            //Product Photo 
            services.AddScoped<IProductPhotoReadRepository, ProductPhotoReadRepository>();
            services.AddScoped<IProductPhotoWriteRepository, ProductPhotoWriteRepository>();
            //Product Tags 
            services.AddScoped<IProductTagReadRepository, ProductTagReadRepository>();
            services.AddScoped<IProductTagWriteRepository, ProductTagWriteRepository>();

            services.AddScoped<ITagReadRepository, TagReadRepository>();
            services.AddScoped<ITagWriteRepository, TagWriteRepository>();

            //Product Color
            services.AddScoped<IProductColorReadRepository, ProductColorReadRepository>();
            services.AddScoped<IProductColorWriteRepository, ProductColorWriteRepository>();
            services.AddScoped<IColorReadRepository, ColorReadRepository>();

            //Product Campaign 
            services.AddScoped<ICampaignReadRepository, CampaignReadRepository>();
            #endregion

            #region Dependency Injection Image  Services
            services.AddScoped<IImageServices, ImageServices>();
            #endregion

            #region Dependency Injection Basket service
            services.AddScoped<IBasketReadRepository, BasketReadRepository>();
            services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();
            services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
            services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();
            #endregion

            #region Dependency Injection Order service
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            #endregion
            #region Dependency Injection Order service
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            #endregion

            #region Dependency Injection Payment service
            services.AddScoped<IstripePaymentService, StripePaymentService>();
            #endregion

            #region Dependency Injection Comment service
            services.AddScoped<ICommentReadRepository, CommentReadRepository>();
            services.AddScoped<ICommentWriteRepository, CommentWriteRepository>();
            #endregion

            #region Dependency Injection Blog service
            services.AddScoped<IBlogReadRepository, BlogReadRepository>();
            services.AddScoped<IBlogWriteRepository, BlogWriteRepository>();
            #endregion

        }

    }
}

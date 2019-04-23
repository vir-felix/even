﻿using System.Text;
using EvenCart.Core.Infrastructure;
using EvenCart.Core.Plugins;
using EvenCart.Data.Database;
using EvenCart.Infrastructure.Authentication;
using EvenCart.Infrastructure.Mvc.Models;
using EvenCart.Infrastructure.Plugins;
using EvenCart.Infrastructure.Routing.Conventions;
using EvenCart.Infrastructure.ViewEngines;
using EvenCart.Services.Security;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Converters;

namespace EvenCart.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAppAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = ApplicationConfig.DefaultAuthenticationScheme;
                    options.DefaultChallengeScheme = ApplicationConfig.DefaultAuthenticationScheme;
                    options.DefaultSignInScheme = ApplicationConfig.DefaultAuthenticationScheme;
                })
                .AddCookie(ApplicationConfig.VisitorAuthenticationScheme, options =>
                {
                    options.LoginPath = new PathString(ApplicationConfig.DefaultLoginUrl);
                    options.Events = new CookieAuthEvents();
                })
                .AddCookie(ApplicationConfig.DefaultAuthenticationScheme, options =>
                {
                    options.LoginPath = new PathString(ApplicationConfig.DefaultLoginUrl);
                    options.AccessDeniedPath = new PathString(ApplicationConfig.DefaultLoginUrl);
                    options.Events = new CookieAuthEvents();
                });

            services.AddAuthentication(ApplicationConfig.ApiAuthenticationScheme)
                .AddJwtBearer(ApplicationConfig.ApiAuthenticationScheme, x =>
                {
                    var configuration = DependencyResolver.Resolve<IApplicationConfiguration>();
                    var key = Encoding.UTF8.GetBytes(configuration.GetSetting("apiSecret"));
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                    x.Events = new JwtAuthEvents();
                });
            services.AddAuthorization(options =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
                    ApplicationConfig.VisitorAuthenticationScheme,
                    ApplicationConfig.DefaultAuthenticationScheme,
                    ApplicationConfig.ApiAuthenticationScheme);
                defaultAuthorizationPolicyBuilder =
                    defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            });
        }

        public static IMvcBuilder AddAppMvc(this IServiceCollection services, IHostingEnvironment hostingEnvironment)
        {
            var mvcBuilder = services.AddMvc(options =>
                {
                    if (DatabaseManager.IsDatabaseInstalled())
                    {
                        options.Conventions.Add(new AppRoutingConvention());
                        options.ModelBinderProviders.Insert(0, new WidgetSettingsModelBinderProvider());
                    }

                })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                })
                //load plugins
                .AddAppPlugins(new PluginLoader(hostingEnvironment))
                .AddViewOptions(options =>
                {
                    options.ViewEngines.Clear();
                    options.ViewEngines.Add(new DefaultAppViewEngine());
                })
                //sets compatibility to 2.1
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                //add controllers as services
                .AddControllersAsServices();
            return mvcBuilder;
        }

        public static void AddAppRouting(this IServiceCollection services)
        {
            //use lowercase urls
            services.AddRouting(options => options.LowercaseUrls = true);
        }
        public static void AddGlobalSingletons(this IServiceCollection services)
        {
            //add httpcontext accessor
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //add action context
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            //url helper
            services.AddSingleton<IUrlHelperFactory, UrlHelperFactory>();
        }

        public static IMvcBuilder AddAppPlugins(this IMvcBuilder mvcBuilder, IPluginLoader pluginLoader)
        {
            pluginLoader.LoadAvailablePlugins();
            var pluginInfos = pluginLoader.GetAvailablePlugins();
            mvcBuilder.ConfigureApplicationPartManager(manager =>
            {
                foreach (var pluginInfo in pluginInfos)
                {
                    manager.ApplicationParts.Add(new AssemblyPart(pluginInfo.Assembly));
                }
            });
            return mvcBuilder;
        }
    }
}
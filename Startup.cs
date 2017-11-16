using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dashboard.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AutoMapper;
using dashboard.Persistence;
using dashboard.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using dashboard_app.Controllers;
using Newtonsoft.Json;
using dashboard.Hubs;

namespace dashboard_app
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


            services.Configure<PhotoSettings>(Configuration.GetSection("PhotoSettings"));
            services.Configure<SpotifySettings>(Configuration.GetSection("SpotifySettings"));
            services.AddCors(option =>
            {
                option.AddPolicy("AllowEverything",
                    policy => policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });

            services.AddSignalR();

            // Repository Injections
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
            services.AddScoped<ITeamEnvironmentRepository, TeamEnvironmentRepository>();
            services.AddScoped<IClientGroupRepository, ClientGroupRepository>();
            services.AddScoped<ISpotifyRepository, SpotifyRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPhotosRepository, PhotosRepository>();

            //First install automapper and extension
            services.AddAutoMapper();

            //Dbcontext service -- Db connection
            services.AddDbContext<DashboardDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddAuthorization(options =>
            {
                // options.AddPolicy("RequireAdminRole", policy => policy.RequireClaim("https://dashapp.com/roles", "Admin"));
                options.AddPolicy(Roles.RequireAdminRole, policy => policy.RequireClaim("https://dashapp.com/roles", "Admin"));
            })
            .AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Audience = "https://api.dashboardapp.com";
                options.Authority = "https://dashapp.eu.auth0.com/";
                // options.RequireHttpsMetadata = false;                
            });

            //Fix for Circular Reference .. �nclude(v => v.Suff)
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //Workaround for HRM (text/mime) problem --------------- 
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                    HotModuleReplacementEndpoint = "/dist/_webpack_hrm"
                });

                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }

}

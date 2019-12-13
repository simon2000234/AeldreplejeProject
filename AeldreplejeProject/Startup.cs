using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AeldreplejeCore.Core.Application;
using AeldreplejeCore.Core.Application.Impl;
using AeldreplejeCore.Core.Domain;
using AeldreplejeInfrastructure;
using AeldreplejeInfrastructure.Helpers;
using AeldreplejeInfrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace AeldreplejeAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }

        public IHostingEnvironment Environment { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Create a byte array with random values. This byte array is used
            // to generate a key for signing JWT tokens.
            Byte[] secretBytes = new byte[40];
            Random rand = new Random();
            rand.NextBytes(secretBytes);

            // Add JWT based authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    //ValidAudience = "TodoApiClient",
                    ValidateIssuer = false,
                    //ValidIssuer = "TodoApi",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(60) //60 minute tolerance for the expiration date
                };
            });
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGroupRepo, GroupRepo>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IRouteRepo, RouteRepo>();
            services.AddScoped<IRouteService, RouteService>();
            services.AddScoped<IShiftRepo, ShiftRepo>();
            services.AddScoped<IShiftService, ShiftService>();
            services.AddScoped<IPendingShiftRepo, PendingShiftRepo>();
            services.AddScoped<IPendingShiftService, PendingShiftService>();
            services.AddScoped<IActiveRouteRepo, ActiveRouteRepo>();
            services.AddScoped<IActiveRouteService, ActiveRouteService>();
            services.AddScoped<ITimeStartRepo, TimeStartRepo>();
            services.AddScoped<ITimeStartService, TimeStartService>();
            services.AddScoped<ITimeEndRepo, TimeEndRepo>();
            services.AddScoped<ITimeEndService, TimeEndService>();
            services.AddSingleton<IAuthenticationHelper>(new AuthenticationHelper(secretBytes));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors();
            services.AddMvc().AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                opt.SerializerSettings.MaxDepth = 10;
            });

            if (Environment.IsDevelopment())
            {
                // In-memory database:
                services.AddDbContext<AeldrePlejeContext>(opt =>
                    opt.UseSqlite("Data Source=AeldrePleje.db"));
            }
            else
            {
                // Azure SQL database:
                services.AddDbContext<AeldrePlejeContext>(opt =>
                    opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
                if (Environment.IsDevelopment())
                {
                    var ctx = scope.ServiceProvider.GetService<AeldrePlejeContext>();
                    ctx.Database.EnsureDeleted();
                    ctx.Database.EnsureCreated();
                    DBInit.SeedDB(ctx);
                }
                else
                {
                    var ctx = scope.ServiceProvider.GetService<AeldrePlejeContext>();
                    if(ctx.Database.EnsureCreated())
                    {
                        DBInit.SeedDB(ctx);
                    }
                    app.UseHsts();
                }
            app.UseHttpsRedirection();
            app.UseCors(monkey => monkey.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}

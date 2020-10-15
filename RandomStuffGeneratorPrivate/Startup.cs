using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RandomStuffGeneratorPrivate.AuthorizationScopes;
using RandomStuffGeneratorPrivate.DatabaseClasses;
using RandomStuffGeneratorPrivate.HelperStuff;

namespace RandomStuffGeneratorPrivate
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
            var tempConfigHelperStuff = new ConfigHelperStuff();

            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(tempConfigHelperStuff.SwaggerDocname, new OpenApiInfo
                {
                    Version = tempConfigHelperStuff.SwaggerDocVersion,
                    Title = tempConfigHelperStuff.SwaggerDocTitle,
                    Description = tempConfigHelperStuff.SwaggerDocDescription,
                    TermsOfService = new Uri(tempConfigHelperStuff.SwaggerDocTermsOfService),
                    Contact = new OpenApiContact
                    {
                        Name = tempConfigHelperStuff.SwaggerDocContactName,
                        Email = tempConfigHelperStuff.SwaggerDocContactEmail,
                        Url = new Uri(tempConfigHelperStuff.SwaggerDocContactUrl),
                    },
                    License = new OpenApiLicense
                    {
                        Name = tempConfigHelperStuff.SwaggerDocLicenseName,
                        Url = new Uri(tempConfigHelperStuff.SwaggerDocLicenseUrl),
                    }
                });

                //lets allow Swagger to put security tokens.
                var securityScheme = new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                };

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "bearerAuth"
                                }
                            },
                            new string[] {}
                    }
                };
                c.AddSecurityDefinition("bearerAuth", securityScheme);
                c.AddSecurityRequirement(securityRequirement);

            });

            //lets add some CORS stuff 
            //this is the standard way
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(tempConfigHelperStuff.AddCorsOrigin1LocalHost,
                                        tempConfigHelperStuff.AddCorsOrigin2ProductionSite,
                                        tempConfigHelperStuff.AddCorsOrigin3DevOrTestOrSomethingElseSite);
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                    builder.AllowCredentials();
                });
            });

            //this is another way, reading the origins from appsettings.
            //https://stackoverflow.com/questions/64166545/provide-an-array-of-origins-to-builder-withorigins-in-addcors
            //string[] s = Configuration["Origins"].Split(",");
            ////just a random string put here for kicsk
            //var tempHelloFromAppSettings = Configuration["HelloWorld"];
            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(builder => {
            //        builder.WithOrigins(s);
            //        builder.AllowAnyMethod();
            //        builder.AllowAnyHeader();
            //        builder.AllowCredentials();
            //    });
            //});

            //database context
            services.AddDbContext<BloggingContext>(options =>
                        options.UseSqlite("Data Source=blogging.db"));

            // 1. Add Authentication Services
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                //TODO1 - migrate this to appsettings.json
                //https://auth0.com/docs/quickstart/backend/aspnet-core-webapi#post-passwordless-start
                options.Authority = "https://randomquoteexperimental.us.auth0.com/";
                options.Audience = "https://thechalakas.com";
            });

            // Register the scope authorization handler
            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

            services.AddAuthorization(options =>
            {
                //TODO1 - similar to above , migrate this also to appsettings.json
                //these are some test roles. 
                options.AddPolicy("capquotes", policy => policy.Requirements.Add(new HasScopeRequirement("read:capquotes", "https://randomquoteexperimental.us.auth0.com/")));
                options.AddPolicy("penquotes", policy => policy.Requirements.Add(new HasScopeRequirement("read:penquotes", "https://randomquoteexperimental.us.auth0.com/")));
                //Check Roles.md for detailed documentation on how roles are defined in this project
                //policy related to User Role
                options.AddPolicy("User", policy => 
                {
                    policy.Requirements.Add(new HasScopeRequirement("read:profiledetails", "https://randomquoteexperimental.us.auth0.com/"));
                });
                //policy related to Moderator Role
                options.AddPolicy("Moderator", policy =>
                {
                    policy.Requirements.Add(new HasScopeRequirement("read:profiledetails", "https://randomquoteexperimental.us.auth0.com/"));
                    policy.Requirements.Add(new HasScopeRequirement("read:seeallquotes", "https://randomquoteexperimental.us.auth0.com/"));
                });
                //policy related to Admin Role
                options.AddPolicy("Admin", policy =>
                {
                    policy.Requirements.Add(new HasScopeRequirement("read:profiledetails", "https://randomquoteexperimental.us.auth0.com/"));
                    policy.Requirements.Add(new HasScopeRequirement("read:seeallquotes", "https://randomquoteexperimental.us.auth0.com/"));
                    policy.Requirements.Add(new HasScopeRequirement("read:sitestats", "https://randomquoteexperimental.us.auth0.com/"));
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

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            // 2. Enable authentication middleware
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using System;
using System.Collections.Generic;
using CrudASP_NET_CORE.Controllers.Model.Context;
using CrudASP_NET_CORE.Buseness;
using CrudASP_NET_CORE.Buseness.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CrudASP_NET_CORE.Repository.Generic;
using Microsoft.Net.Http.Headers;
using Tapioca.HATEOAS;
using CrudASP_NET_CORE.Hypermedia;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Rewrite;
using CrudASP_NET_CORE.Security.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace CrudASP_NET_CORE
{
    public class Startup
    {
        private readonly ILogger _logger;
        public IConfiguration _configuration { get; }
        public IHostingEnvironment _iHostingEnvironment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment iHostingEnvironment, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _iHostingEnvironment = iHostingEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration["MySqlConnection:MysqlConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connectionString));

            ExecuteMigrations(connectionString);

            //Inicia as configurações e adiciona a injeção de dependencias
            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfiguration();

            //Carrega as configurações pre definicas no "appsetting.json"
            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                _configuration.GetSection("TokenConfigurations")
                ).Configure(tokenConfigurations);
            //Adiciona a configuração na injeção de dependencias
            services.AddSingleton(tokenConfigurations);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(beareOptions =>
            {
                var paramValidation = beareOptions.TokenValidationParameters;
                paramValidation.IssuerSigningKey = signingConfigurations.key;
                paramValidation.ValidAudience = tokenConfigurations.Audience;
                paramValidation.ValidIssuer = tokenConfigurations.Issuer;

                //valida a assinatura do tokem recebida
                paramValidation.ValidateIssuerSigningKey = true;

                //Valida se o token ainda é valido
                paramValidation.ValidateLifetime = true;

                //Tempo de tolerancia para validade do token
                paramValidation.ClockSkew = TimeSpan.Zero;

            });

            services.AddAuthorization(auth =>
           {
               auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                   .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                   .RequireAuthenticatedUser().Build());
           });

            services.AddMvc(options =>
            {

                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));

            })
            .AddXmlSerializerFormatters();

            var filerOptions = new HyperMediaFilterOptions();
            filerOptions.ObjectContentResponseEnricherList.Add(new PersonEnricher());
            services.AddSingleton(filerOptions);

            services.AddApiVersioning(option => option.ReportApiVersions = true);

            //<Aplicativo Swagger> ( Usado para documentação de API)
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                "v1",
                new Info
                {
                    Title = "RESTFul API With ASP.NET Core 2.0",
                    Version = "v1"
                });
            });
            //<Aplicativo Swagger>

            //Injessao de dependencia
            services.AddScoped<IPersonBuseness, PersonBusenessImpl>();
            services.AddScoped<IBookBuseness, BookBusenessImpl>();

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }

        //Metodo para configurar dados do Migrations
        private void ExecuteMigrations(string connectionString)
        {
            if (_iHostingEnvironment.IsDevelopment())
            {
                try
                {
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                    var evolve = new Evolve.Evolve("evolve.json", evolveConnection, msg => _logger.LogInformation(msg))
                    {
                        Locations = new List<String> { "db/migrations" },
                        IsEraseDisabled = true,
                    };
                    evolve.Migrate();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("Database migration failed.", ex);
                    throw;
                }

            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //<Aplicativo Swagger>
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseMvc(routes => routes.MapRoute(
                name: "DefaultApi",
                template:"{controller=Values}/{id?}"));
        }
    }
}
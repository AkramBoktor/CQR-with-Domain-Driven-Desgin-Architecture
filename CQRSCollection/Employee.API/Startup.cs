using System;
using System.Collections.Generic;
using System.Linq;
namespace Emp.API
{

    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using Employee.API.Infrastructure.AutofacModules;
    using Emp.Infrastructure;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;
    using Microsoft.AspNetCore.Http;
  //  using Emp.API.Infrastructure.Filters;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.ApplicationInsights.Extensibility;
    using Microsoft.ApplicationInsights.ServiceFabric;
    using Emp.API.Infrastructure.Filters;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsights(Configuration)
                .AddCustomMvc()
                .AddCustomDbContext(Configuration);
            //.AddCustomConfiguration(Configuration);

            var container = new ContainerBuilder();
            container.Populate(services);

            container.RegisterModule(new MediaterModule());
            container.RegisterModule(new ApplicationModule(Configuration["ConnectionString"]));

            return new AutofacServiceProvider(container.Build());
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }

    static class CustomExtensionsMethods
    {
        public static IServiceCollection AddApplicationInsights(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationInsightsTelemetry(configuration);
            var orchestratorType = configuration.GetValue<string>("OrchestratorType");

            if (orchestratorType?.ToUpper() == "K8S")
            {
                // Enable K8s telemetry initializer
                services.AddApplicationInsightsKubernetesEnricher();
            }
            if (orchestratorType?.ToUpper() == "SF")
            {
                // Enable SF telemetry initializer
                services.AddSingleton<ITelemetryInitializer>((serviceProvider) =>
                    new FabricTelemetryInitializer());
            }

            return services;
        }

        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

           // Add framework services.
           services.AddMvc(options =>
           {
               options.Filters.Add(typeof(HttpGlobalExceptionFilter));
           })
               .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
               .AddControllersAsServices();  //Injecting Controllers themselves thru DI
                                             //For further info see: http://docs.autofac.org/en/latest/integration/aspnetcore.html#controllers-as-services

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            return services;
        }

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer()
                   .AddDbContext<EmployeeContext>(options =>
                   {
                       options.UseSqlServer("Server=.;Initial Catalog=EmployeeDb;Integrated Security=true",
                           sqlServerOptionsAction: sqlOptions =>
                           {
                               sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                               sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                           });
                   },
                       ServiceLifetime.Scoped  //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
                   );



            return services;
        }

        //public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddOptions();
        //    services.Configure<EmployeeSettings>(configuration);
        //    services.Configure<ApiBehaviorOptions>(options =>
        //    {
        //        options.InvalidModelStateResponseFactory = context =>
        //        {
        //            var problemDetails = new ValidationProblemDetails(context.ModelState)
        //            {
        //                Instance = context.HttpContext.Request.Path,
        //                Status = StatusCodes.Status400BadRequest,
        //                Detail = "Please refer to the errors property for additional details."
        //            };

        //            return new BadRequestObjectResult(problemDetails)
        //            {
        //                ContentTypes = { "application/problem+json", "application/problem+xml" }
        //            };
        //        };
        //    });

        //    return services;
        //}
    }

}




using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using HiMVC.Models;
using HiMVC.Services;
using AutoMapper;
using NonFactors.Mvc.Grid;
using Microsoft.AspNet.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using HiMVC.Models.Domain;
using HiMVC.ViewModels;
using HiMVC.Models.Interfaces;
using HiMVC.Models.Repository;
using HiMVC.Data;
//using Microsoft.AspNetCore.Mvc.Formatters.Xml;

namespace HiMVC
{

    public static class MappingConfig
    {
        public static MapperConfiguration mapperConfig;

        public static void RegisterMaps()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentModel>()
                    .ForMember(dest => dest.NewName, opt => opt.MapFrom(src => $"Mr. {src.Name}"))
                    .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age - 5));

                cfg.CreateMap<StudentModel, Student>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NewName));
                //cfg.AddProfile<FooProfile>();
            });

            mapperConfig = config;
        }

    }


    //  not used in this project. This is SimpleInject config for DI
    public static class DIConfiguration
    {

        public static void PrepRepository()
        {
            var container = new Container();

            container.Register<IRepository, Repository>(Lifestyle.Transient);
            //container.Register<ILogger, MailLogger>(Lifestyle.Singleton);
            container.Verify();

            //DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();

                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            Startup.ConfigurationStatic = Configuration;//TODO: refactor; used to pass config to DataContext. There should be a better way

            MappingConfig.RegisterMaps();
        }

        public IConfigurationRoot Configuration { get; set; }
        public static IConfigurationRoot ConfigurationStatic { get; set; } //TODO: refactor

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<DataContext>(options =>
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
            services.AddMvcGrid();


            //configure MVC - mine
            services.Configure<MvcOptions>(options =>
            {
                options.MaxModelValidationErrors = 50;
            });

            // Add application services.
            services.Configure<AppKeyConfig>(Configuration.GetSection("AppKeys"));// for user secrets

            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<ICache, CacheServices >();
            //services.AddTransient<ILogger, Logger>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
                try
                {
                    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                        .CreateScope())
                    {
                        serviceScope.ServiceProvider.GetService<DataContext>()
                             .Database.Migrate();
                    }
                }
                catch { }
            }

            app.UseIISPlatformHandler(options => options.AuthenticationDescriptions.Clear());

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseIdentity();

            //app.UseWelcomePage();

            // To configure external authentication please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


            // intitiaize database witht data
            SeedData.Initialize(app.ApplicationServices);
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}

using ChallengeAlkemyC.Models;
using ChallengeAlkemyC.Repositories;
using ChallengeAlkemyC.Repositories.Implements;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;



namespace ChallengeAlkemyC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllersWithViews();
            services.AddControllers();

            services.AddEntityFrameworkSqlServer();

            services.AddDbContextPool<DisneyContext>((services, options) =>
            {
                options.UseInternalServiceProvider(services);
                options.UseSqlServer(Configuration.GetConnectionString("ChallengeAlkemyContext"));
            });

            //services.AddDbContext<DisneyContext>((services, options) =>
            //{
            //    options.UseInternalServiceProvider(services);
            //    options.UseSqlServer(Configuration.GetConnectionString("ChallengeAlkemyContext"));
            //});

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                { Title = "Api Caduca REST", Version = "v1" });
            });
         
            //Repositories
            services.AddScoped<IPersonajeRepository, PersonajeRepository>();
            services.AddScoped<IPeliculaRepository, PeliculaRepository>();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //indica la ruta para generar la configuraci�n de swagger
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Caduca REST");
                    c.RoutePrefix = string.Empty;
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //Habilitar swagger
            app.UseSwagger();

            //indica la ruta para generar la configuraci�n de swagger
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Caduca REST");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}

using ATP.MyNotesApp.API.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ATP.MyNotesApp.API
{
    public class Startup
    {
        private IApiVersionDescriptionProvider _provider;
        private bool _userInMemoryDb;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _userInMemoryDb = configuration.GetValue<bool>("UseInMemoryDb");
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext(Configuration, _userInMemoryDb);

            services.AddApiVersioning();

            services.AddVersioning();

            _provider = services.AddCustomSwagger();

            services.AddCustomAutoMapper();

            services.AddRepositoriesConfiguration();

            services.AddServicesConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!_userInMemoryDb)
            {
                app.ApplyDatabaseMigrations();
            }

            if (env.IsDevelopment())
            {
                app.UseCustomSwagger(_provider);
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

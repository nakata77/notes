using System.Linq;
using ATP.MyNotesApp.Core.Entitties;
using ATP.MyNotesApp.Core.Interfaces;
using ATP.MyNotesApp.Core.Interfaces.Repositories;
using ATP.MyNotesApp.Core.Interfaces.Services;
using ATP.MyNotesApp.Core.MappingProfiles;
using ATP.MyNotesApp.Core.Services;
using ATP.MyNotesApp.Infrastructure;
using ATP.MyNotesApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ATP.MyNotesApp.API.Configuration
{
    public static class ServiceCollectionExtensions
    {
        private const string _dbName = "MyNotesApp";

        public static void AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<ICategoryService, CategoryService>();
        }

        public static void AddRepositoriesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<DbContext, ApplicationDbContext>();
            services.AddScoped<IRepository<Note>, Repository<Note>>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration, bool userInMemoryDb)
        {
            if(userInMemoryDb)
            {
                services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(_dbName));
            }
            else
            {
                services.AddDbContextPool<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("MyNotesAppConnectionString")));
            }
        }

        public static void AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(cfg =>
            {
                cfg.ReportApiVersions = true;
                cfg.ApiVersionReader = new UrlSegmentApiVersionReader();
            });
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }

        public static IApiVersionDescriptionProvider AddCustomSwagger(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(c =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    c.SwaggerDoc(description.GroupName, new OpenApiInfo
                    {
                        Title = "MyNotes App API",
                        Version = description.ApiVersion.ToString()
                    });
                }

                c.ResolveConflictingActions(api => api.First());
            });

            return provider;
        }

        public static void AddCustomAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(NoteProfile));
        }
    }
}

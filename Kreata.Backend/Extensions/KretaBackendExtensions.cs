using Kreata.Backend.Context;
using Kreata.Backend.Repos;
using Kreta.Shared.Assemblers;
using Kreta.Shared.Dtos;
using Kreta.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.Extensions
{
    public static class KretaBackendExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {

            services.AddCors(option =>
                 option.AddPolicy(name: "KretaCors",
                     policy =>
                     {
                         policy.WithOrigins("https://localhost:7090/")
                         .AllowAnyHeader()
                         .AllowAnyMethod();
                     }
                 )
            );
        }

        public static void ConfigureInMemoryContext(this IServiceCollection services)
        {
            string dbNameKretaContext = "Kreta" + Guid.NewGuid();
            services.AddDbContext<KretaContext>
            (
                 options => options.UseInMemoryDatabase(databaseName: dbNameKretaContext),
                 ServiceLifetime.Scoped,
                 ServiceLifetime.Scoped
            );


            string dbNameInMemoryContext = "Kreta" + Guid.NewGuid();
            services.AddDbContext<KretaInMemoryContext>
            (
                 options => options.UseInMemoryDatabase(databaseName: dbNameInMemoryContext),
                 ServiceLifetime.Scoped,
                 ServiceLifetime.Scoped
            );
        }

        public static void ConfigureRepos(this IServiceCollection services) 
        {
            services.AddScoped<StudentAssembler>();

            services.AddScoped<IStudentRepo, StudentRepo<KretaInMemoryContext>>();
        }
    }
}

using EmployeeManagement.Persistence;
using EmployeeManagement.Profiles;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return services;
        }
    }
}

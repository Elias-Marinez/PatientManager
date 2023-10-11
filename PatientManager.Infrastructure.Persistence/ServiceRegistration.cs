
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientManager.Core.Application.Interfaces.Repository;
using PatientManager.Infrastructure.Persistence.Contexts;
using PatientManager.Infrastructure.Persistence.Repositories;

namespace PatientManager.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Context
            services.AddDbContext<ApplicationContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            #endregion

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<ILabReportRepository, LabReportRepository>();
            services.AddTransient<ILabTestRepository, LabTestRepository>();
            services.AddTransient<IAppointmentRepository, AppointmentRepository>();
            #endregion
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using PatientManager.Core.Application.Helpers;
using PatientManager.Core.Application.Interfaces.Helpers;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.Services;
using System.Reflection;

namespace PatientManager.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            #region "AutoMaper"
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #endregion

            #region Services
            services.AddTransient(typeof(IGenericService<,,,>), typeof(GenericService<,,,>));
            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<ILabReportService, LabReportService>();
            services.AddTransient<ILabTestService,  LabTestService>();
            services.AddTransient<IUserService,  UserService>();
            #endregion

            #region Helpers
            services.AddTransient<IFileManager, FileManager>();
            #endregion
        }
    }
}

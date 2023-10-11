
using PatientManager.Core.Application.ViewModels.Appointment;
using PatientManager.Core.Domain.Entities;

namespace PatientManager.Core.Application.Interfaces.Services
{
    public interface IAppointmentService : IGenericService<AppointmentViewModel,
                                                           AppointmentSaveViewModel,
                                                           AppointmentUpdateViewModel,
                                                           Appointment>
    {

    }
}

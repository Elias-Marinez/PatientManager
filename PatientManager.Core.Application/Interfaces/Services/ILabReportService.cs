﻿
using PatientManager.Core.Application.ViewModels.Appointment;
using PatientManager.Core.Application.ViewModels.LabReport;
using PatientManager.Core.Domain.Entities;

namespace PatientManager.Core.Application.Interfaces.Services
{
    public interface ILabReportService : IGenericService<LabReportViewModel,
                                                         LabReportSaveViewModel,
                                                         LabReportUpdateViewModel,
                                                         LabReport>
    {
        Task AddByAppointment(AppointmentConsultViewModel vm);
    }
}

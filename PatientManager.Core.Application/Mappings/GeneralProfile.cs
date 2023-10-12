
using AutoMapper;
using PatientManager.Core.Application.ViewModels.Appointment;
using PatientManager.Core.Application.ViewModels.Doctor;
using PatientManager.Core.Application.ViewModels.LabReport;
using PatientManager.Core.Application.ViewModels.LabTest;
using PatientManager.Core.Application.ViewModels.Patient;
using PatientManager.Core.Application.ViewModels.User;
using PatientManager.Core.Domain.Entities;

namespace PatientManager.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region Users
            CreateMap<User, UserSaveViewModel>()
                .ForMember(x => x.ConfirmPassword, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.UserId, opt => opt.Ignore());

            CreateMap<User, UserUpdateViewModel>()
                .ForMember(x => x.ConfirmPassword, opt => opt.Ignore());

            CreateMap<User, UserViewModel>();
            #endregion

            #region Doctor
            CreateMap<Doctor, DoctorSaveViewModel>()
                .ForMember(x => x.Image, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.DoctorId, opt => opt.Ignore())
                .ForMember(x => x.Appointments, opt => opt.Ignore());

            CreateMap<Doctor, DoctorUpdateViewModel>()
                .ForMember(x => x.Image, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.Appointments, opt => opt.Ignore());

            CreateMap<Doctor, DoctorViewModel>();
            #endregion

            #region Patient
            CreateMap<Patient, PatientSaveViewModel>()
                .ForMember(x => x.Image, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.PatientId, opt => opt.Ignore())
                .ForMember(x => x.Appointments, opt => opt.Ignore());

            CreateMap<Patient, PatientUpdateViewModel>()
                .ForMember(x => x.Image, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.Appointments, opt => opt.Ignore());

            CreateMap<Patient, PatientViewModel>();
            #endregion

            #region Appointments
            CreateMap<Appointment, AppointmentSaveViewModel>()
                .ReverseMap()
                .ForMember(x => x.AppointmentId, opt => opt.Ignore())
                .ForMember(x => x.Doctor, opt => opt.Ignore())
                .ForMember(x => x.Patient, opt => opt.Ignore())
                .ForMember(x => x.LabReports, opt => opt.Ignore());

            CreateMap<Appointment, AppointmentUpdateViewModel>()
                .ReverseMap()
                .ForMember(x => x.Doctor, opt => opt.Ignore())
                .ForMember(x => x.Patient, opt => opt.Ignore())
                .ForMember(x => x.LabReports, opt => opt.Ignore());

            CreateMap<Appointment, AppointmentViewModel>();
            #endregion

            #region LabTest
            CreateMap<LabTest, LabTestSaveViewModel>()
                .ReverseMap()
                .ForMember(x => x.LabTestId, opt => opt.Ignore())
                .ForMember(x => x.LabReports, opt => opt.Ignore());

            CreateMap<LabTest, LabTestUpdateViewModel>()
                .ReverseMap()
                .ForMember(x => x.LabReports, opt => opt.Ignore());

            CreateMap<LabTest, LabTestViewModel>();
            #endregion

            #region LabReport
            CreateMap<LabReport, LabReportSaveViewModel>()
                .ForMember(x => x.Results, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.LabReportId, opt => opt.Ignore())
                .ForMember(x => x.Appointment, opt => opt.Ignore())
                .ForMember(x => x.LabTest, opt => opt.Ignore());

            CreateMap<LabReport, LabReportUpdateViewModel>()
                .ReverseMap()
                .ForMember(x => x.Appointment, opt => opt.Ignore())
                .ForMember(x => x.LabTest, opt => opt.Ignore());

            CreateMap<LabReport, LabReportViewModel>();
            #endregion

        }
    }
}

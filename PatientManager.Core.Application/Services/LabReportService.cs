
using AutoMapper;
using PatientManager.Core.Application.Interfaces.Repository;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.ViewModels.LabReport;
using PatientManager.Core.Domain.Entities;

namespace PatientManager.Core.Application.Services
{
    public class LabReportService : GenericService<LabReportViewModel,  LabReportSaveViewModel, LabReportUpdateViewModel, LabReport>, ILabReportService
    {
        private readonly ILabReportRepository _repository;
        private readonly IMapper _mapper;

        public LabReportService(ILabReportRepository repository, IMapper mapper) :base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}


using AutoMapper;
using PatientManager.Core.Application.Interfaces.Repository;
using PatientManager.Core.Application.Interfaces.Services;

namespace PatientManager.Core.Application.Services
{
    public class GenericService<ViewModel, SaveViewModel, UpdateViewModel, Entity> 
        : IGenericService<ViewModel, SaveViewModel, UpdateViewModel, Entity>
                where ViewModel : class
                where SaveViewModel : class
                where UpdateViewModel : class
                where Entity : class
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;
        private ILabReportRepository repository;
        private IMapper mapper;

        public GenericService(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Add(SaveViewModel vm)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            await _repository.AddAsync(entity);
        }
        public async Task Update(UpdateViewModel vm, int id)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            await _repository.UpdateAsync(entity, id);
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<ViewModel>> Get()
        {
            var entities = await _repository.GetAllAsync();
            List<ViewModel> result = _mapper.Map<List<ViewModel>>(entities);

            return result;
        }

        public async Task<ViewModel> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            ViewModel result = _mapper.Map<ViewModel>(entity);

            return result;
        }

        public async Task<List<ViewModel>> GetWithAll()
        {
            var entities = await _repository.GetAllWithIncludeAsync();
            List<ViewModel> result = _mapper.Map<List<ViewModel>>(entities);

            return result;
        }
    }
}

using AutoMapper;
using Core.Dto.DtoServices;
using Core.Interfaces;
using Data.Entities;

namespace Core.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IRepository<ServiceEntity> _serviceRepository;
        private readonly IMapper _mapper;

        public ServiceService(IRepository<ServiceEntity> serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ServiceDto>> GetAllServicesAsync()
        {
            var services = await _serviceRepository.GetAll();
            return _mapper.Map<IEnumerable<ServiceDto>>(services);
        }

        public async Task<ServiceDto> GetServiceByIdAsync(int id)
        {
            var service = await _serviceRepository.GetByID(id);
            return _mapper.Map<ServiceDto>(service);
        }

        public async Task CreateServiceAsync(ServiceDto serviceDto)
        {
            var service = _mapper.Map<ServiceEntity>(serviceDto);
            await _serviceRepository.Insert(service);
            await _serviceRepository.Save();
        }

        public async Task UpdateServiceAsync(ServiceDto serviceDto)
        {
            var service = _mapper.Map<ServiceEntity>(serviceDto);
            await _serviceRepository.Update(service);
            await _serviceRepository.Save();
        }

        public async Task DeleteServiceAsync(int id)
        {
            var service = await _serviceRepository.GetByID(id);
            if (service != null)
            {
                await _serviceRepository.Delete(service);
                await _serviceRepository.Save();
            }
        }
    }
}

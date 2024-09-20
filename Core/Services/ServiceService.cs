using AutoMapper;
using Core.Dto.DtoServices;
using Core.Interfaces;
using Core.Specifications;
using Data.Entities;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Core.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IRepository<ServiceEntity> _serviceRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateServiceDto> _validator;
        public ServiceService(IRepository<ServiceEntity> serviceRepository, IMapper mapper, IValidator<CreateServiceDto> validator)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
            _validator = validator;
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

        public async Task<int> CreateServiceAsync(CreateServiceDto serviceDto)
        {
            _validator.ValidateAndThrow(serviceDto);
            var service = _mapper.Map<ServiceEntity>(serviceDto);
            await _serviceRepository.Insert(service);
            await _serviceRepository.Save();
            return service.Id;
        }

        public async Task UpdateServiceAsync(UpdateServiceDto serviceDto)
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
        public async Task<IEnumerable<ServiceDto>> GetServicesByCategoryIdAsync(int categoryId)
        {
            var spec = new ServiceSpecs.ByCategoryId(categoryId);
            var services = await _serviceRepository.GetListBySpec(spec);
            return _mapper.Map<IEnumerable<ServiceDto>>(services);
        }

        public async Task<IEnumerable<ServiceDto>> GetServicesByRatingAsync(int rating)
        {
            var spec = new ServiceSpecs.ByRating(rating);
            var services = await _serviceRepository.GetListBySpec(spec);
            return _mapper.Map<IEnumerable<ServiceDto>>(services);
        }

        public async Task<IEnumerable<ServiceDto>> GetServicesByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            var spec = new ServiceSpecs.ByPriceRange(minPrice, maxPrice);
            var services = await _serviceRepository.GetListBySpec(spec);
            return _mapper.Map<IEnumerable<ServiceDto>>(services);
        }
    }
}

using Core.Dto.DtoServices;

namespace Core.Interfaces
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceDto>> GetAllServicesAsync();
        Task<ServiceDto> GetServiceByIdAsync(int id);
        Task<int> CreateServiceAsync(CreateServiceDto serviceDto);
        Task UpdateServiceAsync(UpdateServiceDto serviceDto);
        Task DeleteServiceAsync(int id);
    }
}

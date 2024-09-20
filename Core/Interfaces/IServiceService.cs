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
        Task<IEnumerable<ServiceDto>> GetServicesByCategoryIdAsync(int categoryId);
        Task<IEnumerable<ServiceDto>> GetServicesByRatingAsync(int rating);
        Task<IEnumerable<ServiceDto>> GetServicesByPriceRangeAsync(decimal minPrice, decimal maxPrice);
    }
}

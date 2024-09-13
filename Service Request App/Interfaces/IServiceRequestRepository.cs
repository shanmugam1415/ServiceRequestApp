using Service_Request_App.Model;

namespace Service_Request_App.Interfaces
{
    public interface IServiceRequestRepository
    {
        Task<IEnumerable<ServiceRequest>> GetAllAsync();
        Task<ServiceRequest> GetByIdAsync(Guid id);
        Task AddAsync(ServiceRequest serviceRequest);
        Task UpdateAsync(ServiceRequest serviceRequest);
        Task DeleteAsync(Guid id);
    }
}

using Service_Request_App.Model;

namespace Service_Request_App.Interfaces
{
    public interface IServiceRequestService
    {
        Task<ServiceRequest> CloseServiceRequest(Guid id);
    }
}

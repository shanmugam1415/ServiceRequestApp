using Service_Request_App.Interfaces;
using Service_Request_App.Model;
using System.Net.Mail;
namespace Service_Request_App.Services
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly IServiceRequestRepository _repository;
        private readonly INotificationService _notificationService;

        public ServiceRequestService(IServiceRequestRepository repository, INotificationService notificationService)
        {
            _repository = repository;
            _notificationService = notificationService;
        }

        public async Task<ServiceRequest> CloseServiceRequest(Guid id)
        {
            var serviceRequest = await _repository.GetByIdAsync(id);
            if (serviceRequest == null)
                throw new Exception("Service Request not found");

            serviceRequest.CurrentStatus = StatusEnum.Complete;
            serviceRequest.LastModifiedDate = DateTime.Now;

            await _repository.UpdateAsync(serviceRequest);

            await _notificationService.SendNotificationAsync(serviceRequest.UserEmail, "Your service request has been closed.","",serviceRequest);

            return serviceRequest;
        }

    }
}
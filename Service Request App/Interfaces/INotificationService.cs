using Service_Request_App.Model;

namespace Service_Request_App.Interfaces
{
    public interface INotificationService
    {
        Task SendNotificationAsync(string email, string message, string subject, ServiceRequest request);
    }
}

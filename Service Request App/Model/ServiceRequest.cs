using System.Text.Json.Serialization;

namespace Service_Request_App.Model
{
    public class ServiceRequest
    {
        public Guid Id { get; set; }
        public string BuildingCode { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public StatusEnum CurrentStatus { get; set; } = StatusEnum.Created;
        public string UserEmail { get; set; }

    }
}

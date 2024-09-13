using Moq;
using Service_Request_App.Interfaces;
using Service_Request_App.Model;
using Xunit;
using Service_Request_App.Services;

namespace ServiceRequestTest
{
    [TestClass]
    public class ServiceRequestServiceTests
    {
        private readonly Mock<IServiceRequestRepository> _mockRepository;
        private readonly Mock<INotificationService> _mockNotificationService;
        private readonly ServiceRequestService _service;

        public ServiceRequestServiceTests()
        {
            _mockRepository = new Mock<IServiceRequestRepository>();
            _mockNotificationService = new Mock<INotificationService>();
            _service = new ServiceRequestService(_mockRepository.Object, _mockNotificationService.Object);
        }

        [Fact]
        public async Task CloseServiceRequest_ShouldSendNotification()
        {
            var serviceRequest = new ServiceRequest { Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), UserEmail = "shan@test.com", CurrentStatus = StatusEnum.InProgress };
            _mockRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(serviceRequest);

            var result = await _service.CloseServiceRequest(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"));

            _mockNotificationService.Verify(n => n.SendNotificationAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), result), Times.Once);
            Assert.AreEqual(StatusEnum.Complete, result.CurrentStatus);
        }
    }
}
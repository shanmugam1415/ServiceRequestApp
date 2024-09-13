using Microsoft.AspNetCore.Mvc;
using Service_Request_App.Interfaces;
using Service_Request_App.Model;

namespace Service_Request_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceRequestController : ControllerBase
    {
        private readonly IServiceRequestRepository _repository;
        private readonly INotificationService _notificationService;
        private readonly IServiceRequestService _reqServoce;

        public ServiceRequestController(IServiceRequestRepository repository, INotificationService notificationService, IServiceRequestService reqServoce)
        {
            _repository = repository;
            _notificationService = notificationService;
            _reqServoce = reqServoce;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var requests = await _repository.GetAllAsync();
            return Ok(requests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var request = await _repository.GetByIdAsync(id);
            if (request == null) return NotFound();
            return Ok(request);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServiceRequest request)
        {
            await _repository.AddAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = request.Id }, request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, ServiceRequest request)
        {
            if (id != request.Id) return BadRequest();
            var existingRequest = await _repository.GetByIdAsync(id);
            if (existingRequest == null) return NotFound();

            await _repository.UpdateAsync(request);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("closerequest/{id}")]
        public async Task<IActionResult> CloseRequest(Guid id)
        {
            await _reqServoce.CloseServiceRequest(id);
            return NoContent();
        }
    }
}

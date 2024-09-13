using Microsoft.EntityFrameworkCore;
using Service_Request_App.Data;
using Service_Request_App.Interfaces;
using Service_Request_App.Model;

namespace Service_Request_App.Repository
{
    public class ServiceRequestRepository : IServiceRequestRepository
    {
        private readonly AppDbContext _context;

        public ServiceRequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceRequest>> GetAllAsync()
        {
            return await _context.ServiceRequests.ToListAsync();
        }

        public async Task<ServiceRequest> GetByIdAsync(Guid id)
        {
            return await _context.ServiceRequests.FindAsync(id);   
        }

        public async Task AddAsync(ServiceRequest serviceRequest)
        {
            serviceRequest.Id=Guid.NewGuid();
            _context.ServiceRequests.Add(serviceRequest);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ServiceRequest serviceRequest)
        {
            _context.ServiceRequests.Update(serviceRequest);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var serviceRequest = await _context.ServiceRequests.FindAsync(id);
            if (serviceRequest != null)
            {
                _context.ServiceRequests.Remove(serviceRequest);
                await _context.SaveChangesAsync();
            }
        }
    }
}

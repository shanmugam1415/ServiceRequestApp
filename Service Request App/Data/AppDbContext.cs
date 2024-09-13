using Microsoft.EntityFrameworkCore;
using Service_Request_App.Model;
using System.Collections.Generic;

namespace Service_Request_App.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ServiceRequest> ServiceRequests { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using WebApplication.Data.Models;

namespace WebApplication.Data
{
    public class ApplicContext : DbContext
    {
        public DbSet<Event> Event { get; set; }
        public ApplicContext(DbContextOptions<ApplicContext> options)
        : base(options)
        {
            Database.EnsureCreated();   
        }
    }
}
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DigitalAfterlife2._0.Models;

namespace DigitalAfterlife2._0.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DigitalAfterlife2._0.Models.NextOfKin> NextOfKin { get; set; } = default!;
        public DbSet<DigitalAfterlife2._0.Models.Perished> Perished { get; set; } = default!;
        public DbSet<DigitalAfterlife2._0.Models.File> File { get; set; }
        public DbSet<DigitalAfterlife2._0.Models.ServiceToDelete> ServiceToDelete { get; set; }
    }
}
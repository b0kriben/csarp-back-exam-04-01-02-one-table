using Kreta.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.Context
{
    public class KretaContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public KretaContext(DbContextOptions<KretaContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}

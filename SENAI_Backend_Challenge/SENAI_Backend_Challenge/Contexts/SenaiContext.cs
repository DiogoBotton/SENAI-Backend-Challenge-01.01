using Microsoft.EntityFrameworkCore;
using SENAI_Backend_Challenge.Domains.Event;
using SENAI_Backend_Challenge.Domains.User;
using SENAI_Backend_Challenge.EntityTypeConfigurations.EventEntityTypeConfiguration;
using SENAI_Backend_Challenge.EntityTypeConfigurations.UserEntityTypeConfiguration;
using SENAI_Backend_Challenge.SeedWork;

namespace SENAI_Backend_Challenge.Contexts
{
    public class SenaiContext : DbContext, IUnitOfWork
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public SenaiContext(DbContextOptions<SenaiContext> options) : base(options)
        {
        }

        public SenaiContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EventEntityTypeConfiguration());
        }

        public async Task SaveDbChanges(CancellationToken cancellationToken = default)
        {
            await base.SaveChangesAsync();
        }
    }
}

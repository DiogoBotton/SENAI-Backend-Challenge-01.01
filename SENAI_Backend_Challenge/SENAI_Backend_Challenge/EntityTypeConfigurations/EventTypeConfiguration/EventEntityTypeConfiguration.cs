using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SENAI_Backend_Challenge.Domains.Event;
using SENAI_Backend_Challenge.Domains.User;

namespace SENAI_Backend_Challenge.EntityTypeConfigurations.EventEntityTypeConfiguration
{
    public class EventEntityTypeConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events");

            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey("UserId")
                .IsRequired();
        }
    }
}

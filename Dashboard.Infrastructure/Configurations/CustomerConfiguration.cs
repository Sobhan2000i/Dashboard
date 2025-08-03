using Dashboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dashboard.Infrastructure.Configurations
{
    public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

            builder.Property(x => x.TimeSinceLastPurchase)
                .HasConversion(
                    v => v.Ticks,
                    v => TimeSpan.FromTicks(v));

            builder.HasMany(x => x.ExpertNotes)
                .WithOne() 
                .HasForeignKey(n => n.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Tickets)
                .WithOne()
                .HasForeignKey(t => t.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

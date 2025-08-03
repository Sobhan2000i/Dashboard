using Dashboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dashboard.Infrastructure.Configurations
{
    public sealed class ExpertConfiguration : IEntityTypeConfiguration<ExpertNote>
    {
        public void Configure(EntityTypeBuilder<ExpertNote> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne<Customer>() 
                   .WithMany(x => x.ExpertNotes!)
                   .HasForeignKey(x => x.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

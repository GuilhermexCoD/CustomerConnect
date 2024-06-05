using CustomerConnect.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CustomerConnect.Infrastructure.Mapping
{
    public class PhoneMap : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.ToTable("Phone");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ClientId).IsRequired();
            builder.Property(x => x.Type).HasMaxLength(100).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(15).IsRequired();

        }
    }
}

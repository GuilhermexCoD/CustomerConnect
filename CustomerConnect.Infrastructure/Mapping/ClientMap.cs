using CustomerConnect.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerConnect.Infrastructure.Mapping
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.CPF).IsRequired().HasMaxLength(11);
            builder.Property(x => x.RG).IsRequired().HasMaxLength(9);
        }
    }
}

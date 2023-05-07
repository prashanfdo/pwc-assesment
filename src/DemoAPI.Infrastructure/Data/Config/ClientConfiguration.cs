using DemoAPI.Core.ClientAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoAPI.Infrastructure.Data.Config;
public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
  public void Configure(EntityTypeBuilder<Client> builder)
  {
    builder.Property(p => p.Name)
        .HasMaxLength(250)
        .IsRequired();
    builder.Property(p => p.DateJoinedAsCustomer)
        .HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
  }
}

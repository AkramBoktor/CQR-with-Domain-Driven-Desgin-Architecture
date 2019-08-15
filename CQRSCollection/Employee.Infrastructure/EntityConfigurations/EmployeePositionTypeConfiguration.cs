using Microsoft.EntityFrameworkCore;
using Emp.Domain.AggregatesModel.EmployeeAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emp.Infrastructure.EntityConfigurations
{
   public class EmployeePositionTypeConfiguration : IEntityTypeConfiguration<EmployeePosition>
    {
        public void Configure(EntityTypeBuilder<EmployeePosition> _empPositionConfiguration)
        {
            _empPositionConfiguration.ToTable("EmployeePosition", EmployeeContext.DEFAULT_SCHEMA);

            _empPositionConfiguration.HasKey(o => o.Id);

            _empPositionConfiguration.Property(o => o.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            _empPositionConfiguration.Property(o => o.Name)
                .HasMaxLength(200)
                .IsRequired();
        }


    }
}

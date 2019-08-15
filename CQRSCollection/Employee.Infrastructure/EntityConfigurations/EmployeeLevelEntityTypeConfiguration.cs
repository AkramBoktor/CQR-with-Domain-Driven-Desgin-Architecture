using System;
using System.Collections.Generic;
using System.Text;
using Emp.Domain.AggregatesModel.EmployeeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emp.Infrastructure.EntityConfigurations
{
    public class EmployeeLevelEntityTypeConfiguration
        : IEntityTypeConfiguration<EmployeeLevel>
    {
        public void Configure(EntityTypeBuilder<EmployeeLevel> _empLevelConfiguration)
        {
            _empLevelConfiguration.ToTable("Employeelevel", EmployeeContext.DEFAULT_SCHEMA);

            _empLevelConfiguration.HasKey(o => o.Id);

            _empLevelConfiguration.Property(o => o.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            _empLevelConfiguration.Property(o => o.Name)
                .HasMaxLength(200)
                .IsRequired();
        }

      
    }
}

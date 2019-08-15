using Microsoft.EntityFrameworkCore;
using Emp.Domain.AggregatesModel.EmployeeAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emp.Infrastructure.EntityConfigurations
{
   public class EmployeeEntityTypeConfiguration: IEntityTypeConfiguration<Domain.AggregatesModel.EmployeeAggregate.Employee>
    {
        public void Configure(EntityTypeBuilder<Domain.AggregatesModel.EmployeeAggregate.Employee> EmpConfiguration)
        {
            EmpConfiguration.ToTable("Employees", EmployeeContext.DEFAULT_SCHEMA);
            EmpConfiguration.HasKey(o => o.Id);

            EmpConfiguration.Ignore(b => b.DomainEvents);

            EmpConfiguration.Property(o => o.Id).ForSqlServerUseSequenceHiLo("EmployeeDb", EmployeeContext.DEFAULT_SCHEMA);

            //Address value object persisted as owned entity type supported since EF Core 2.0
            EmpConfiguration.OwnsOne(o => o.Address);

            EmpConfiguration.Property<string>("Name").IsRequired();
            EmpConfiguration.Property<int>("EmployeeLevelId").IsRequired();
            EmpConfiguration.Property<int>("EmployeePositionId").IsRequired();
            EmpConfiguration.Property<string>("ImagePath").IsRequired(false);
            EmpConfiguration.Property<string>("Phone").IsRequired(false);

            EmpConfiguration.HasOne(o => o.EmployeeLevel)
                .WithMany()
                .HasForeignKey("EmployeeLevelId");

            EmpConfiguration.HasOne(o => o.EmployeePosition)
                .WithMany()
                .HasForeignKey("EmployeePositionId");
        }


    }
}

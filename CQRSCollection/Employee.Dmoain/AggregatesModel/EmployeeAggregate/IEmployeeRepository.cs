using Emp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Domain.AggregatesModel.EmployeeAggregate
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee Add(Employee employee);

        void Update(Employee employee);

        Task<Employee> GetAsync(int employeeId);

        void Delete(int id);

    }
}

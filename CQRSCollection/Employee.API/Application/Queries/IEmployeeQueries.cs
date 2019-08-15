using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emp.Domain.AggregatesModel.EmployeeAggregate;
namespace Emp.API.Application.Queries
{
    public interface IEmployeeQueries
    {
        Task<IEnumerable<EmployeeViewModel>> GetEmployeeByID(int id);

        Task<IEnumerable<EmployeeViewModel>> GetAllEmployee();



    }
}

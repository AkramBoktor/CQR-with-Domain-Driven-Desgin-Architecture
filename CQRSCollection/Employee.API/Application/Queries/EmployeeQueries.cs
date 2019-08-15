using Emp.API.Application.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using Emp.Domain.AggregatesModel.EmployeeAggregate;

namespace Employee.API.Application.Queries
{
    public class EmployeeQueries : IEmployeeQueries
    {
        private string _connectionString = string.Empty;

        public EmployeeQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));

        }

        public async Task<IEnumerable<EmployeeViewModel>> GetAllEmployee()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var res = connection.QueryAsync<EmployeeViewModel>(" SELECT TOP (100) *  FROM [EmployeeDb].[emp].[Employees]");
                return await res;

            }
        }

     

       

        public async Task<IEnumerable<EmployeeViewModel>> GetEmployeeByID(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<EmployeeViewModel>
                    (@"Select * from [EmployeeDb].[emp].[Employees] where Id = @id", new { id });


            }
        }
      
    }

}


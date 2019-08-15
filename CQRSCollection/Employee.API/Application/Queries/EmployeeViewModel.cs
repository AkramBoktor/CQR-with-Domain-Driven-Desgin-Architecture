using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emp.API.Application.Queries
{
    public class EmployeeViewModel
    {

        public int Id { get; set; }

        public string Address_Street { get; set; }

        public string Address_City { get; set; }

        public string Address_Country { get; set; }

        public int EmployeeLevelId { get; set; }

        public int EmployeePositionId { get; set; }

        public string ImagePath { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Emp.API.Application.Commands
{
    [DataContract]
    public class UpdateEmployeeCommand : IRequest<bool>
    {
        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public string Street { get; private set; }

        [DataMember]
        public string City { get; private set; }

        [DataMember]
        public string Country { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public string Phone { get; private set; }

        [DataMember]
        public int EmployeeLevelId { get; private set; }

        [DataMember]
        public int EmployeePositionId { get; private set; }

        [DataMember]
        public string ImagePath { get; private set; }

        public UpdateEmployeeCommand()
        {

        }
        public UpdateEmployeeCommand(int id,string street, string city, string country ,string name, string phone, int employeeLevelId, int employeePositionId, string imagePath):this()
        {
            Id = id;
            Street = street;
            City = city;
            Country = country;
            Name = name;
            Phone = phone;
            EmployeeLevelId = employeeLevelId;
            EmployeePositionId = employeePositionId;
            ImagePath = imagePath;
        }
    }
}

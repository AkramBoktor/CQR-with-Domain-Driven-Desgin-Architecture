using MediatR;
using System.Runtime.Serialization;

namespace Emp.API.Application.Commands
{
    [DataContract]
    public class CreateEmployeeCommand : IRequest<bool>
    {
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


        public CreateEmployeeCommand()
        {
                
        }

        public CreateEmployeeCommand(string street, string country, string city, string name, string phone, int employeeLevelId, int employeePositionId, string imagePath) : this()
        {
            Street = street;
            Country = country;
            City = city;
            Name = name;
            Phone = phone;
            EmployeeLevelId = employeeLevelId;
            EmployeePositionId = employeePositionId;
            ImagePath = imagePath;
        }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Emp.API.Application.Commands
{
    [DataContract]
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        [DataMember]
        public int Id { get; private set; }


        public DeleteEmployeeCommand()
        {

        }

        public DeleteEmployeeCommand(int id) : this()
        {
            Id = id;
        }
    }
    
}

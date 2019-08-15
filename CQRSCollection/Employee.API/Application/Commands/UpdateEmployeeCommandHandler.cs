using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Emp.Domain.AggregatesModel.EmployeeAggregate;

namespace Emp.API.Application.Commands
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {

        private readonly IEmployeeRepository _empRepository;
        private readonly IMediator _mediator;

        public UpdateEmployeeCommandHandler(IMediator mediator, IEmployeeRepository employeeRepository)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _empRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }


        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeInDb = await _empRepository.GetAsync(request.Id);

            Address address = new Address(request.Street, request.City, request.Country);
            //var employeeToUpdate = new Emp.Domain.AggregatesModel.EmployeeAggregate.Employee(request.Name, address, request.Phone, request.EmployeePositionId, request.EmployeeLevelId, request.ImagePath);
            //var employeeToUpdate = new Emp.Domain.AggregatesModel.EmployeeAggregate.Employee(request.Id,request.Name, address, request.Phone, request.EmployeePositionId, request.EmployeeLevelId, request.ImagePath);
            employeeInDb.UpdateEmployee(request.Name, address, request.Phone, request.EmployeePositionId, request.EmployeeLevelId, request.ImagePath);
            if (employeeInDb == null)
            {
                return false;
            }

            //employeeInDb = employeeToUpdate;
            _empRepository.Update(employeeInDb);
            return await _empRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}

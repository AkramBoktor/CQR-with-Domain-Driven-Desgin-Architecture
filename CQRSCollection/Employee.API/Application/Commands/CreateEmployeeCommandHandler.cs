using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Emp.Domain.AggregatesModel.EmployeeAggregate;
using Employee.API.Application.Queries;

namespace Emp.API.Application.Commands
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, bool>
    {


        private readonly IEmployeeRepository _empRepository;
        private readonly IMediator _mediator;

        // Using DI to inject infrastructure persistence Repositories
        public CreateEmployeeCommandHandler(IMediator mediator , IEmployeeRepository employeeRepository)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _empRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<bool> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Address address = new Address(request.Street, request.City, request.Country);
            var employeeToCreate = new Emp.Domain.AggregatesModel.EmployeeAggregate.Employee(request.Name, address, request.Phone, request.EmployeePositionId, request.EmployeeLevelId, request.ImagePath);
            _empRepository.Add(employeeToCreate);

            return await _empRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }

        // Use for Idempotency in Command process
        //public class CreateEmployeeCommandHandler : IdentifiedCommandHandler<CreateOrderCommand, bool>
        //{
        //    public CreateOrderIdentifiedCommandHandler(
        //        IMediator mediator,
        //        IRequestManager requestManager,
        //        ILogger<IdentifiedCommandHandler<CreateOrderCommand, bool>> logger)
        //        : base(mediator, requestManager, logger)
        //    {
        //    }

        //    protected override bool CreateResultForDuplicateRequest()
        //    {
        //        return true;                // Ignore duplicate requests for creating order.
        //    }
        //}
    }
}

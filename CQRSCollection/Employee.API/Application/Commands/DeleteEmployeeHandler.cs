using Emp.Domain.AggregatesModel.EmployeeAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Emp.API.Application.Commands
{
    public class DeleteEmployeeHandler :IRequestHandler<DeleteEmployeeCommand, bool>
    {


        private readonly IEmployeeRepository _empRepository;
    private readonly IMediator _mediator;

    // Using DI to inject infrastructure persistence Repositories
    public DeleteEmployeeHandler(IMediator mediator, IEmployeeRepository employeeRepository)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _empRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
    }

    public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
            var employeeInDb = await _empRepository.GetAsync(request.Id);

            _empRepository.Delete(request.Id);

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
 
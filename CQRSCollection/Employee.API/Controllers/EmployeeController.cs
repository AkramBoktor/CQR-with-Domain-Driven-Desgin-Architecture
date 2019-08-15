using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Emp.API.Application.Queries;
using Emp.API.Application.Commands;

namespace Emp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IEmployeeQueries _empqueries;

        public EmployeeController(IMediator mediator, IEmployeeQueries EmpQueries)
        {
            _empqueries = EmpQueries;
            _mediator = mediator;

        }
        // GET api/Employee
        [HttpGet]
        public async Task <ActionResult> Get()
        {

            var result = await _empqueries.GetAllEmployee();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        // GET api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {

            var result = await _empqueries.GetEmployeeByID(id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        // POST api/Employee
        [HttpPost]
        public async Task<ActionResult> Post(CreateEmployeeCommand createEmployee)
        {
            return Ok(await _mediator.Send(createEmployee));

        }

        // PUT api/Employee/5
        [HttpPut]
        public async Task<ActionResult> Put(UpdateEmployeeCommand updateEmployee)
        {

            return Ok(await _mediator.Send(updateEmployee));
        }

        // DELETE api/Employee in the body give it id and then it will be deleted
        [HttpDelete]
        public async Task<ActionResult> Delete(DeleteEmployeeCommand EmployeeId)
        {
            return Ok(await _mediator.Send(EmployeeId));
        }
    }
}

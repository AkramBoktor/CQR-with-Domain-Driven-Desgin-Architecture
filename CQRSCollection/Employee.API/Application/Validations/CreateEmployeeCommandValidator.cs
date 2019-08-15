using Emp.API.Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emp.API.Application.Validations
{
    public class CreateEmployeeCommandValidator:AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(command => command.Name).Length(10, 20).NotEmpty().WithMessage("The Name Can't be Empty");
            RuleFor(command => command.Phone).Length(11, 12).NotEmpty();
            RuleFor(command => command.EmployeeLevelId).NotEmpty();
            RuleFor(command => command.EmployeePositionId).NotEmpty();
            RuleFor(command => command.ImagePath).NotEmpty();

        }
    }
}

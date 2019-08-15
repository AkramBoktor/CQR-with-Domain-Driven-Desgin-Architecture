using System;
using System.Collections.Generic;
using System.Text;

namespace Emp.Domain.Exceptions
{
    /// <summary>
    /// Exception type for domain exceptions
    /// </summary>
    public class EmployeeDomainException : Exception
    {
        public EmployeeDomainException()
        { }

        public EmployeeDomainException(string message)
            : base(message)
        { }

        public EmployeeDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

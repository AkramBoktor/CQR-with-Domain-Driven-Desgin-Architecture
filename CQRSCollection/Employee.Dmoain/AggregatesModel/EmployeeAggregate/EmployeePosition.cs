namespace Emp.Domain.AggregatesModel.EmployeeAggregate
{
    using global::Emp.Domain.SeedWork;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EmployeePosition
        : Enumeration
    {
        public static EmployeePosition Developer = new EmployeePosition(1, nameof(Developer).ToLowerInvariant());
        public static EmployeePosition Tester = new EmployeePosition(2, nameof(Tester).ToLowerInvariant());
        public static EmployeePosition Manager = new EmployeePosition(3, nameof(Manager).ToLowerInvariant());

        public EmployeePosition(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<EmployeePosition> List() =>
            new[] { Developer, Tester, Manager };

        public static EmployeePosition FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            //if (state == null)
            //{
            //    throw new OrderingDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            //}

            return state;
        }

        public static EmployeePosition From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            //if (state == null)
            //{
            //    throw new OrderingDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            //}

            return state;
        }
    }
}

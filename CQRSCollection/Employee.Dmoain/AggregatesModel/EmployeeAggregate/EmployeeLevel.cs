namespace Emp.Domain.AggregatesModel.EmployeeAggregate
{
    //using global::Ordering.Domain.Exceptions;
    using global::Emp.Domain.SeedWork;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EmployeeLevel
        : Enumeration
    {
        public static EmployeeLevel Junior = new EmployeeLevel(1, nameof(Junior).ToLowerInvariant());
        public static EmployeeLevel Mid = new EmployeeLevel(2, nameof(Mid).ToLowerInvariant());
        public static EmployeeLevel Senior = new EmployeeLevel(3, nameof(Senior).ToLowerInvariant());

        public EmployeeLevel(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<EmployeeLevel> List() =>
            new[] { Junior, Mid, Senior };

        public static EmployeeLevel FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            //if (state == null)
            //{
            //    throw new OrderingDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            //}

            return state;
        }

        public static EmployeeLevel From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            ////if (state == null)
            ////{
            ////    throw new OrderingDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            ////}

            return state;
        }
    }
}

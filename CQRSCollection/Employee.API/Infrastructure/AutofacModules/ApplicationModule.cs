using Autofac;
using Emp.API.Application.Queries;
using Emp.Domain.AggregatesModel.EmployeeAggregate;
using Emp.Infrastructure.Repository;
using Employee.API.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new EmployeeQueries(QueriesConnectionString))
                .As<IEmployeeQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EmployeeRepository>()
               .As<IEmployeeRepository>()
               .InstancePerLifetimeScope();
           
        }

    }
}

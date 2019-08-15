﻿using Emp.Domain.AggregatesModel.EmployeeAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using Emp.Domain.SeedWork;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Emp.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {


        private readonly EmployeeContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public Domain.AggregatesModel.EmployeeAggregate.Employee Add(Domain.AggregatesModel.EmployeeAggregate.Employee employee)
        {
            return _context.Employees.Add(employee).Entity;
        }

        public async Task<Domain.AggregatesModel.EmployeeAggregate.Employee> GetAsync(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee != null)
            {

                await _context.Entry(employee)
                    .Reference(i => i.Address).LoadAsync();
                await _context.Entry(employee)
                       .Reference(i => i.EmployeeLevel).LoadAsync();
                await _context.Entry(employee)
                    .Reference(i => i.EmployeePosition).LoadAsync();
            }

            return employee;
        }

        public void Update(Domain.AggregatesModel.EmployeeAggregate.Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
        }


        public void Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            _context.Employees.Remove(employee);
        }
    }
}

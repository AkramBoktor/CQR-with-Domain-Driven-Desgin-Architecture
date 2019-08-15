using Emp.Domain.SeedWork;
using Emp.Domain.AggregatesModel.EmployeeAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emp.Domain.AggregatesModel.EmployeeAggregate
{
    public class Employee : Entity, IAggregateRoot
    {
        public Address Address { get; private set; }

        private string Name;

        private string Phone;

        public EmployeeLevel EmployeeLevel { get; private set; }
        private int _employeeLevelId;

        public EmployeePosition EmployeePosition { get; private set; }
        private int _employeePositionId;

        private string ImagePath;

        public Employee()
        {

        }

   



        public Employee( string _Name, Address _Address, string _Phone, int _EmployeePositionId, int _EmployeeLevelId, string _ImagePath)
        {
            Name = _Name;
            Phone = _Phone;
            Address = _Address;
            _employeeLevelId = _EmployeePositionId;
            _employeePositionId = _EmployeeLevelId;
            ImagePath = _ImagePath;
        }

        public void  UpdateEmployee(string _Name, Address _Address, string _Phone, int _EmployeePositionId, int _EmployeeLevelId, string _ImagePath)
        {
            Name = _Name;
            Phone = _Phone;
            Address = _Address;
            _employeeLevelId = _EmployeePositionId;
            _employeePositionId = _EmployeeLevelId;
            ImagePath = _ImagePath;
        }

        public void SetJuniorLevel()
        {
            _employeeLevelId = EmployeeLevel.Junior.Id;
        }

        public void SetMidLevel()
        {
            _employeeLevelId = EmployeeLevel.Mid.Id;
        }

        public void SetSeniorLevel()
        {
            _employeeLevelId = EmployeeLevel.Senior.Id;
        }

        public void SetTesterPosition()
        {
            _employeePositionId = EmployeePosition.Tester.Id;
        }

        public void SetDeveloperPosition()
        {
            _employeePositionId = EmployeePosition.Developer.Id;
        }

        public void SetManagerPosition()
        {
            _employeePositionId = EmployeePosition.Manager.Id;
        }

    }
}

using CrudRestApiApp.Models;
using CrudRestApiApp.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudRestApiApp.EmployeeData
{
    public class SqlEmolyeeData:IEmployeeData
    {
        private SD_CompanyContext _employeeContext;
        public SqlEmolyeeData(SD_CompanyContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public Employee AddEmployee(Employee employee)
        {
            employee.EmpNo = new Random().Next();
            _employeeContext.Employee.Add(employee);
            _employeeContext.SaveChanges();
            return employee;
        }

        public void DeletEmployee(Employee employee)
        {
            _employeeContext.Employee.Remove(employee);
            _employeeContext.SaveChanges();
        }

        public Employee EditEmployee(Employee employee)
        {

            var existingEmployee = _employeeContext.Employee.Find(employee.EmpNo);

            if (existingEmployee != null)
            {
                existingEmployee.EmpNo = employee.EmpNo;
                existingEmployee.Fname = employee.Fname;
                existingEmployee.Lname = employee.Lname;
                existingEmployee.Salary = employee.Salary;
                existingEmployee.DeptNo = employee.DeptNo;
                _employeeContext.Employee.Update(existingEmployee);
                _employeeContext.SaveChanges();
            }

            return employee;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeContext.Employee.SingleOrDefault(x => x.EmpNo == id);
        }

        public List<Employee> GetEmployees()
        {
            return _employeeContext.Employee.ToList();
        }
    }
}

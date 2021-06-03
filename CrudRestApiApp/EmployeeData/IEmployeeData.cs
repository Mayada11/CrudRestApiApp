using CrudRestApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudRestApiApp.NewFolder
{
   public interface IEmployeeData
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(int id);
        Employee AddEmployee(Employee employee);
        void DeletEmployee(Employee employee);
        Employee EditEmployee(Employee employee);
    }
}

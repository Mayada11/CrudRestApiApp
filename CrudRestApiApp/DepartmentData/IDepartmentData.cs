using CrudRestApiApp.Models;
using System;
using System.Collections.Generic;


namespace CrudRestApiApp.DepartmentData
{
   public interface IDepartmentData
    {
        List<Department> GetDepartments();
        Department GetDepartment(int id);
        Department AddDepartment(Department department);
        void DeletDepartment(Department department);
        Department EditDepartment(Department department);
    }
}

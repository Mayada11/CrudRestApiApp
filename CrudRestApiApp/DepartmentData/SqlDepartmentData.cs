using CrudRestApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrudRestApiApp.DepartmentData
{
    public class SqlDepartmentData : IDepartmentData
    {
        private SD_CompanyContext _departmentContext;
        public SqlDepartmentData(SD_CompanyContext departmentContext)
        {
            _departmentContext = departmentContext;
        }
        public Department AddDepartment(Department department)
        {
            department.DeptNo = new Random().Next();
            _departmentContext.Department.Add(department);
            _departmentContext.SaveChanges();
            return department;
        }

        public void DeletDepartment(Department department)
        {
            _departmentContext.Department.Remove(department);
            _departmentContext.SaveChanges();
        }

        public Department EditDepartment(Department department)
        {

            var existingDepartment = _departmentContext.Department.Find(department.DeptNo);

            if (existingDepartment != null)
            {
                existingDepartment.DeptNo = department.DeptNo;
                existingDepartment.DeptName = department.DeptName;
                existingDepartment.Location = department.Location;
                _departmentContext.Department.Update(existingDepartment);
                _departmentContext.SaveChanges();
            }

            return department;
        }

        public Department GetDepartment(int id)
        {
            return _departmentContext.Department.SingleOrDefault(x => x.DeptNo == id);
        }

        public List<Department> GetDepartments()
        {
            return _departmentContext.Department.ToList();
        }

     
    }
}

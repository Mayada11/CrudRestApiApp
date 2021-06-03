using CrudRestApiApp.DepartmentData;
using CrudRestApiApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudRestApiApp.Controllers
{
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private IDepartmentData _departmentData;
        public DepartmentController(IDepartmentData departmentData)
        {
            _departmentData = departmentData;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetDepartment()
        {
            return Ok(_departmentData.GetDepartments());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetDepartment(int id)
        {
            var department = _departmentData.GetDepartment(id);

            if (department != null)
            {
                return Ok(department);
            }
            return NotFound($"depatrment with id : {id} not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult addDepartment(Department department)
        {
            _departmentData.AddDepartment(department);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + department.DeptNo, department.DeptNo);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var department = _departmentData.GetDepartment(id);

            if (department != null)
            {
                _departmentData.DeletDepartment(department);
                return Ok();
            
            }
            return NotFound($"Department with id : {id} not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditDepartment(int id, Department department)
        {
            var existingDepartment = _departmentData.GetDepartment(id);
            if (existingDepartment != null)
            {
                department.DeptNo = existingDepartment.DeptNo;
                _departmentData.EditDepartment(department);

            }
            return Ok(department);
        }
    }
}

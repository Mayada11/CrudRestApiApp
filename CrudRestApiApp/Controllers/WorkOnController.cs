using CrudRestApiApp.Models;
using CrudRestApiApp.WorksOnData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudRestApiApp.Controllers
{
    [ApiController]
    public class WorkOnController : ControllerBase
    {
        private IWorksOnData _worksOnData;
        public WorkOnController(IWorksOnData worksOnData)
        {
            _worksOnData = worksOnData;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmpsWorkOnProj()
        {
            return Ok(_worksOnData.GetEmployeesWorkOnProj());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmpWorksOnProj(int id)
        {
            var workOn = _worksOnData.GetEmployeeWorksOnProj(id);

            if (workOn != null)
            {
                return Ok(workOn);
            }
            return NotFound($"No Employee Works on this Proj with id : {id} not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult addEmpWorksOnProj(WorksOn worksOn)
        {
            worksOn.EnterDate = DateTime.Now;
            _worksOnData.AddEmployeeWorksOnProj(worksOn);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + worksOn.EmpNo, worksOn.EmpNo);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmpWorksOnProj(int id)
        {
            var workOn = _worksOnData.GetEmployeeWorksOnProj(id);

            if (workOn != null)
            {
                _worksOnData.DeleteEmployeeWorksOnProj(workOn);
                return Ok();

            }
            return NotFound($"employee works on this proj with id : {id} not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditEmpWorksOnProj(int id, WorksOn worksOn)
        {
            var existingWorkOn = _worksOnData.GetEmployeeWorksOnProj(id);
            if (existingWorkOn != null)
            {
                worksOn.EmpNo = existingWorkOn.EmpNo;
                _worksOnData.EditEmployeeWorksOnProj(worksOn);

            }
            return Ok(worksOn);
        }
    }
}

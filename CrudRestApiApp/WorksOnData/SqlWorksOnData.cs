using CrudRestApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudRestApiApp.WorksOnData
{
    public class SqlWorksOnData : IWorksOnData
    {
        private SD_CompanyContext _worksOnContext;
        public SqlWorksOnData(SD_CompanyContext worksOnContext)
        {
            _worksOnContext = worksOnContext;
        }
        public WorksOn AddEmployeeWorksOnProj(WorksOn workOn)
        {
            
            _worksOnContext.WorksOn.Add(workOn);
            _worksOnContext.SaveChanges();
            return workOn;
        }

        public void DeleteEmployeeWorksOnProj(WorksOn worksOn)
        {
            _worksOnContext.WorksOn.Remove(worksOn);
            _worksOnContext.SaveChanges();
        }

        public WorksOn EditEmployeeWorksOnProj(WorksOn worksOn)
        {
            var existingWorkOn = _worksOnContext.WorksOn.Find(worksOn.EmpNo);

            if (existingWorkOn != null)
            {
                existingWorkOn.EmpNo = worksOn.EmpNo;
                existingWorkOn.ProjectNo = worksOn.ProjectNo;
                existingWorkOn.Job = worksOn.Job;
                existingWorkOn.EnterDate = worksOn.EnterDate;
                _worksOnContext.WorksOn.Update(existingWorkOn);
                _worksOnContext.SaveChanges();
            }

            return worksOn;
        }

        public List<WorksOn> GetEmployeesWorkOnProj()
        {
            return _worksOnContext.WorksOn.ToList();
        }

        public WorksOn GetEmployeeWorksOnProj(int id)
        {
            return _worksOnContext.WorksOn.SingleOrDefault(x => x.EmpNo == id);
        }
    }
}

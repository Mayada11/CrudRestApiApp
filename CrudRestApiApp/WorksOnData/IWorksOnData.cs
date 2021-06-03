using CrudRestApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudRestApiApp.WorksOnData
{
   public interface IWorksOnData
    {
        List<WorksOn> GetEmployeesWorkOnProj();
        WorksOn GetEmployeeWorksOnProj(int id);
        WorksOn AddEmployeeWorksOnProj(WorksOn workOn);
        void DeleteEmployeeWorksOnProj(WorksOn worksOn);
        WorksOn EditEmployeeWorksOnProj(WorksOn worksOn);
    }
}

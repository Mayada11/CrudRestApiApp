using CrudRestApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudRestApiApp.ProjectData
{
  public interface IProjectData
    {
        List<Project> GetProjects();
        Project GetProject(int id);
        Project AddProject(Project project);
        void DeletProject(Project project);
        Project EditProject(Project project);
       
    }
}

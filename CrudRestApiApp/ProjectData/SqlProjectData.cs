using CrudRestApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudRestApiApp.ProjectData
{
    public class SqlProjectData :IProjectData
    {
        private SD_CompanyContext _projectContext;
        public SqlProjectData(SD_CompanyContext projectContext)
        {
            _projectContext = projectContext;
        }
        public Project AddProject(Project project)
        {
            project.ProjectNo = new Random().Next();
            _projectContext.Project.Add(project);
            _projectContext.SaveChanges();
            return project;
        }

        public void DeletProject(Project project)
        {
            _projectContext.Project.Remove(project);
            _projectContext.SaveChanges();
        }

        public Project EditProject(Project project)
        {

            var existingProject = _projectContext.Project.Find(project.ProjectNo);

            if (existingProject != null)
            {
                existingProject.ProjectNo = project.ProjectNo;
                existingProject.ProjectName = project.ProjectName;
                existingProject.Budget = project.Budget;
                _projectContext.Project.Update(existingProject);
                _projectContext.SaveChanges();
            }

            return project;
        }

        public Project GetProject(int id)
        {
            return _projectContext.Project.SingleOrDefault(x => x.ProjectNo == id);
        }

        public List<Project> GetProjects()
        {
            return _projectContext.Project.ToList();
        }

    }
}

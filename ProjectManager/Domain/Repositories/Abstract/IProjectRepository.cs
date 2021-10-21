using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Domain.Repositories.Abstract
{
    public interface IProjectRepository
    {
        IQueryable<Project> getProjects();
        IQueryable<Column> getColumnsByProjectId(Guid id);
        Project getProjectById(Guid id);
        void saveProject(Project project);
        void deleteProject(Guid id);
        void addProject(Project project);

        void addColumnToProject(Column column,Project project);

        Project getProjectByTask(Task task);
      
    }
}

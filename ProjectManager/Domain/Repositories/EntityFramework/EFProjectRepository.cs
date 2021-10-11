using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Repositories.Abstract;

namespace ProjectManager.Domain.Repositories.EntityFramework
{
    public class EFProjectRepository : IProjectRepository
    {
        private readonly ProjectManagerDBContext context;

        public EFProjectRepository(ProjectManagerDBContext context)
        {
            this.context = context;
        }

        void IProjectRepository.deleteProject(Guid id)
        {
            context.Projects.Remove(new Project() { Id = id });
            context.SaveChanges();
        }

        IQueryable<Column> IProjectRepository.getColumnsByProjectId(Guid id)
        {
            var items = context.ProjectColumns.Where(x => x.Projectid == id);
            var r = new List<Column>();
            foreach (var item in items)
            {
                r.Add(context.Columns.FirstOrDefault(x => x.Id == item.Columnid));
            }
            return r.AsQueryable();
        }

        Project IProjectRepository.getProjectById(Guid id)
        {
            return context.Projects.FirstOrDefault(x => x.Id == id);
        }

        IQueryable<Project> IProjectRepository.getProjects()
        {
            return context.Projects;
        }

        void IProjectRepository.saveProject(Project project)
        {
            if (project.Id == default)
            {
                context.Entry(project).State = EntityState.Added;
                context.SaveChanges();
            }
            else
            {
                context.Entry(project).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        void  IProjectRepository.addProject(Project project)
        {
            context.Projects.Add(project);
            context.SaveChanges();
        }

        void IProjectRepository.addColumnToProject(Column column, Project project)
        {
            ProjectColumns projectcolumn = new ProjectColumns
            {
                Id = new Guid(),
                Projectid = project.Id,
                Columnid = column.Id
            };

            context.ProjectColumns.Add(projectcolumn);
            context.SaveChanges();
        }
    }
}

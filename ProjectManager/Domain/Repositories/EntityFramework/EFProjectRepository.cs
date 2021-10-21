﻿using System;
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
        Project IProjectRepository.getProjectByTask(Task task)
        {
            var columntask = context.ColumnTasks.FirstOrDefault(t => t.Taskid == task.Id);
            var projectcolumn = context.ProjectColumns.FirstOrDefault(c => c.Columnid == columntask.Columnid);
            return context.Projects.Where(c => c.Id == projectcolumn.Projectid).First();
        }
        void IProjectRepository.deleteProject(Guid id)
        {
            Project prj = context.Projects.Where(p => p.Id == id).First();
            var pjcols = context.ProjectColumns.Where(x => x.Projectid == id);
            foreach (var pjcol in pjcols)
            {
                var col = context.Columns.Where(x => x.Id == pjcol.Columnid).First();
                var coltsks = context.ColumnTasks.Where(x => x.Columnid == col.Id);
                foreach (var coltsk in coltsks)
                {
                    var task = context.Tasks.Where(x => x.Id == coltsk.Taskid).First();
                    context.Tasks.Remove(task);
                    context.ColumnTasks.Remove(coltsk);
                }
                context.Columns.Remove(col);
                context.ProjectColumns.Remove(pjcol);
            }
            
            context.Projects.Remove(prj);
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
            ProjectColumn projectcolumn = new ProjectColumn
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

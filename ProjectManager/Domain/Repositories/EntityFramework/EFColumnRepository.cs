using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Repositories.Abstract;

namespace ProjectManager.Domain.Repositories.EntityFramework
{
    public class EFColumnRepository : IColumnsRepository
    {
        private readonly ProjectManagerDBContext context;

        public EFColumnRepository(ProjectManagerDBContext context)
        {
            this.context = context;
        }

        void IColumnsRepository.DeleteColumn(Guid id)
        {
            context.Columns.Remove(new Column() { Id = id });


            var items = context.ProjectColumns.Where(x => x.Columnid == id);
            foreach (var item in items)
            {
                context.ProjectColumns.Remove(item);
            }
            context.SaveChanges();
        }

        Column IColumnsRepository.getColumnsById(Guid id)
        {
            return context.Columns.FirstOrDefault(x => x.Id == id);
        }

        IQueryable<Column> IColumnsRepository.getColumns()
        {
            return context.Columns;
        }

        IQueryable<Task> IColumnsRepository.getTasksByColumnId(Guid id)
        {
            var items = context.ColumnTasks.Where(x => x.Columnid == id);
            var r = new List<Task>();
            foreach (var item in items)
            {
                r.Add(context.Tasks.FirstOrDefault(x => x.Id == item.Taskid));
            }
            return r.AsQueryable();
        }

        void IColumnsRepository.saveColumns(Column column)
        {
            if (column.Id == default)
            {
                context.Entry(column).State = EntityState.Added;
            }
            else
            {
                context.Entry(column).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        void IColumnsRepository.addColumn(Column column)
        {
            context.Columns.Add(column);
            context.SaveChanges();
        }

        void IColumnsRepository.addTaskToColumn(Task task, Column column)
        {
            ColumnTasks columnTasks = new ColumnTasks
            {
                Id = new Guid(),
                Taskid = task.Id,
                Columnid = column.Id
            };

            context.ColumnTasks.Add(columnTasks);
            context.SaveChanges();
        }

    }
}


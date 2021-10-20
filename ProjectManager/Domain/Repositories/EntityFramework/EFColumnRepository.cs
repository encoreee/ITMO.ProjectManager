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
            
            var pjcols = context.ProjectColumns.Where(x => x.Columnid == id);
            foreach (var pjcol in pjcols)
            {
                context.ProjectColumns.Remove(pjcol);
            }
            var cols = context.Columns.Where(x => x.Id == id);
            foreach (var col in cols)
            {
                context.Columns.Remove(col);
            }

            var coltsks = context.ColumnTasks.Where(x => x.Columnid == id);
            var tsks = new List<Task>();
            foreach (var coltsk in coltsks)
            {
                tsks.Add(context.Tasks.FirstOrDefault(x => x.Id == coltsk.Taskid));
                context.ColumnTasks.Remove(coltsk);
            }
            foreach (var tsk in tsks)
            {
                context.Tasks.Remove(tsk);
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

        void IColumnsRepository.changeTaskColmun(Task task, Column column)
        {
            var items = context.ColumnTasks.Where(x => x.Taskid == task.Id);
            foreach (var item in items)
            {
                context.ColumnTasks.Remove(item);
            }

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


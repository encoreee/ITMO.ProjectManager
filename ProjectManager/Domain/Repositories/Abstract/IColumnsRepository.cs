using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Domain.Repositories.Abstract
{
    public interface IColumnsRepository
    {
        IQueryable<Column> getColumns();
        Column getColumnsById(Guid id);
        void saveColumns(Column column);
        void DeleteColumn(Guid id);
        IQueryable<Task> getTasksByColumnId(Guid id);
        void addColumn(Column column);
        void addTaskToColumn(Task task, Column column);

    }
}

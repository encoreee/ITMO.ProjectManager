using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Domain.Repositories.Abstract
{
    public interface ITaskRepository
    {
        IQueryable<Task> getTasks();
        IQueryable<Task> getTasksByUserId(Guid userid);
        Task getTaskById(Guid id);
        void saveTask(Task task);
        void DeleteTask(Guid id);
        void addTask(Task task);
    }
}

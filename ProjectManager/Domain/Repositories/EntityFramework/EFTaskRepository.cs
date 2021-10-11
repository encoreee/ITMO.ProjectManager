using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Repositories.Abstract;

namespace ProjectManager.Domain.Repositories.EntityFramework
{
    public class EFTaskRepository : ITaskRepository
    {
        private readonly ProjectManagerDBContext context;

        public EFTaskRepository(ProjectManagerDBContext context)
        {
            this.context = context;
        }

        void ITaskRepository.DeleteTask(Guid id)
        {
            context.Tasks.Remove(new Task() { Id = id });
        }

        Task ITaskRepository.getTaskById(Guid id)
        {
            return context.Tasks.FirstOrDefault(x => x.Id == id);
        }

        IQueryable<Task> ITaskRepository.getTasks()
        {
            return context.Tasks;
        }

        void ITaskRepository.saveTask(Task task)
        {
            if (task.Id == default)
            {
                context.Entry(task).State = EntityState.Added;
            }
            else
            {
                context.Entry(task).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        void ITaskRepository.addTask(Task task)
        {
            context.Tasks.Add(task);
            context.SaveChanges();
        }


    }
}

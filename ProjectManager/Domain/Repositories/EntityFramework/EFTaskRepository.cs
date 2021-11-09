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
        IQueryable<Task> ITaskRepository.getTasksByUserId(Guid userid) 
        {
            var tasks = context.Tasks.Where(x => x.Userid == userid.ToString());

            return tasks;
        }
        void ITaskRepository.DeleteTask(Guid id)
        {

            var coltsks = context.ColumnTasks.Where(x => x.Taskid == id);
            foreach (var coltsk in coltsks)
            {
                context.ColumnTasks.Remove(coltsk);
            }
            var tsks = context.Tasks.Where(x => x.Id == id);

            foreach (var tsk in tsks)
            {
                var chat = context.Chats.FirstOrDefault(x => x.Id == tsk.Chatid);
                var messegies = context.Messages.Where(x => x.Chatid == chat.Id);
                foreach (var msg in messegies)
                {
                    context.Remove(msg);
                }
                context.Remove(chat);
                context.Tasks.Remove(tsk);
            }
            context.SaveChanges();
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

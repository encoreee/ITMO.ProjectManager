using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Repositories.Abstract;

namespace ProjectManager.Domain.Repositories.EntityFramework
{
    public class EFChatRepository : IChatRepository
    {
        private readonly ProjectManagerDBContext context;

        public EFChatRepository(ProjectManagerDBContext context)
        {
            this.context = context;
        }

        void IChatRepository.deleteChat(Guid id)
        {
            context.Chats.Remove(new Chat() { Id = id });
        }
        void IChatRepository.addChat(Chat chat)
        {
            context.Chats.Add(chat);
            context.SaveChanges();
        }
        IQueryable<Chat> IChatRepository.getChat()
        {
            return context.Chats;
        }

        Chat IChatRepository.getChatById(Guid id)
        {
            return context.Chats.FirstOrDefault(x => x.Id == id);
        }
        Chat IChatRepository.getChatByTaskId(Guid taskid)
        {
            var task = context.Tasks.Where(x => x.Id == taskid).FirstOrDefault();
            return context.Chats.Where(x => x.Id == task.Chatid).FirstOrDefault();
        }

        void IChatRepository.saveChat(Chat chat)
        {
            if (chat.Id == default)
            {
                context.Entry(chat).State = EntityState.Added;
            }
            else
            {
                context.Entry(chat).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}


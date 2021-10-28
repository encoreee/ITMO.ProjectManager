using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Repositories.Abstract;

namespace ProjectManager.Domain.Repositories.EntityFramework
{
    public class EFMessageRepository : IMessageRepository
    {
        private readonly ProjectManagerDBContext context;

        public EFMessageRepository(ProjectManagerDBContext context)
        {
            this.context = context;
        }

        void IMessageRepository.addMessage(Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();
        }
        void IMessageRepository.deleteMessage(Guid id)
        {
            context.Messages.Remove(new Message() { Id = id });
        }

        Message IMessageRepository.getMessageById(Guid id)
        {
            return context.Messages.FirstOrDefault(x => x.Id == id);
        }
        IQueryable<Message> IMessageRepository.getMessagiesByChatId(Guid chatid)
        {
            var chat = context.Chats.FirstOrDefault(x => x.Id == chatid);

            return context.Messages.Where(x => x.Chatid == chat.Id);
        }

        IQueryable<Message> IMessageRepository.getMessages()
        {
            return context.Messages;
        }

        void IMessageRepository.saveMessage(Message message)
        {
            if (message.Id == default)
            {
                context.Entry(message).State = EntityState.Added;
            }
            else
            {
                context.Entry(message).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
      
    }
}

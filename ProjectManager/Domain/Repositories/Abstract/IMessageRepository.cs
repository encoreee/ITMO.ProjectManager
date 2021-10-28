using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Domain.Repositories.Abstract
{
    public interface IMessageRepository
    {
        IQueryable<Message> getMessages();

        void addMessage(Message message);
        Message getMessageById(Guid id);
        IQueryable<Message> getMessagiesByChatId(Guid chatid);
        void saveMessage(Message message);
        void deleteMessage(Guid id);
    }
}

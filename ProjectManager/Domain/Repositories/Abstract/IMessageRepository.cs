using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Domain.Repositories.Abstract
{
    public interface IMessageRepository
    {
        IQueryable<Message> getMessages();
        Message getMessageById(Guid id);
        void saveMessage(Message message);
        void deleteMessage(Guid id);
    }
}

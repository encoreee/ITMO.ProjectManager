using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Domain.Repositories.Abstract
{
    public interface IChatRepository
    {
        void addChat(Chat chat);
        IQueryable<Chat> getChat();
        Chat getChatById(Guid id);
        Chat getChatByTaskId(Guid taskid);
        void saveChat(Chat chat);
        void deleteChat(Guid id);
    }
}

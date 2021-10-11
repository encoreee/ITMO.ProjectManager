using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Domain.Repositories.Abstract
{
    public interface IChatRepository
    {
        IQueryable<Chat> getChat();
        Chat getChatById(Guid id);
        void saveChat(Chat chat);
        void deleteChat(Guid id);
    }
}

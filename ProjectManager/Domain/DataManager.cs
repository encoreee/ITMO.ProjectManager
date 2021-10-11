using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Domain.Repositories.Abstract;

namespace ProjectManager.Domain
{
    public class DataManager
    {

        public IAcsessLevelsRepository acsessLevels { get; set; }
        public IChatRepository chats { get; set; }
        public IMessageRepository messages { get; set; }
        public IProjectRepository projects { get; set; }
        public ITaskRepository tasks { get; set; }
        public IColumnsRepository columns { get; set; }

        public DataManager(IAcsessLevelsRepository acsessLevelsRepository,
            IChatRepository chatRepository,
            IMessageRepository messageRepository,
            IProjectRepository projectRepository,
            ITaskRepository taskRepository,
            IColumnsRepository columnsRepository)
        {
            acsessLevels = acsessLevelsRepository;
            chats = chatRepository;
            messages = messageRepository;
            projects = projectRepository;
            tasks = taskRepository;
            columns = columnsRepository;
        }
    }
}

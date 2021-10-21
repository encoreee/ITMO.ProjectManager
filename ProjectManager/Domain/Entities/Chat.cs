using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectManager
{
    public partial class Chat
    {
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<Message> Messagies { get; set; }
    }
}

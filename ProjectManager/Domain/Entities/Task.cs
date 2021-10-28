using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProjectManager
{
    public partial class Task
    {
   
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public string Userid { get; set; }

        public Guid Chatid { get; set; }
        public virtual ICollection<ColumnTask> ColumnTasks { get; set; }

    }
}

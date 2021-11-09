using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ProjectManager
{
    public partial class Task
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        [ForeignKey("User")]
        public string Userid { get; set; }
        
        [ForeignKey("Chat")]
        public Guid Chatid { get; set; }
        public virtual ICollection<ColumnTask> ColumnTasks { get; set; }

    }
}

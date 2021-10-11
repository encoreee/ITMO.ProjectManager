using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectManager
{
    public partial class Task
    {
   
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Starttime { get; set; }
        public TimeSpan Endtime { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public Guid Columnid { get; set; }
        public string Description { get; set; }

  
    }
}

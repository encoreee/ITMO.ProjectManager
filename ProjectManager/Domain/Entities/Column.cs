﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectManager
{
    public partial class Column
    {
  

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ColumnTask> ColumnTasks { get; set; }
        public virtual ICollection<ProjectColumn> ProjectColumns { get; set; }


    }
}
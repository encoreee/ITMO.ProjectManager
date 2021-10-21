using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectManager
{
    public partial class ProjectUser
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public User User { get; set; }



    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectManager
{
    public partial class ProjectUser
    {
        public Guid Id { get; set; }

        public  Guid Projectid { get; set; }
        public Guid userid { get; set; }
    }
}

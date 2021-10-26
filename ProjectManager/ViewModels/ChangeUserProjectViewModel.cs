using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.ViewModels
{
    public class ChangeUserProjectViewModel
    {

        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<Project> AllProjects { get; set; }
        public List<string> UserPojects { get; set; }
        public ChangeUserProjectViewModel()
        {
            AllProjects = new List<Project>();
            UserPojects = new List<string>();
        }

    }
}

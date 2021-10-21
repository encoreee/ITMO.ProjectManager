using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.ViewModels
{
    public class EditTaskViewModel
    {
        public Guid Id { get; set; }
        public Guid Projectid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public int Priority { get; set; }
        public String Userid { get; set; }
        public List<SelectListItem> ListOfUsers { get; set; }
    }
}

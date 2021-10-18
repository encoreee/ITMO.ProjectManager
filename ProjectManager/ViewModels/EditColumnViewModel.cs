using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.ViewModels
{
    public class EditColumnViewModel
    {
        public Guid Id { get; set; }
        public Guid Projectid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
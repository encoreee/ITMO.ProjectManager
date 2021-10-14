using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Models
{
    [JsonArray]
    public class Project
    {
        public String projectid { get; set; }
        public IEnumerable<Column> columns { get; set; }
    }
}

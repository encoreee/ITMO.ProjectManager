using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Models
{
    [JsonArray]

    public class Column
    {
        public String columnid { get; set; }
        public IEnumerable<Task> tasks { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Models
{
    [JsonArray]
    public class Task
    {
        public String taskid { get; set; }
    }
}

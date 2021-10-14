using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectManager.Controllers
{
    
    public class ServicesController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> makeSequence([FromBody] Models.Project project)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            Directory.CreateDirectory(Environment.CurrentDirectory + "//" + project.projectid);
            string writePath = System.IO.Path.Combine(Environment.CurrentDirectory + "//" + project.projectid, project.projectid + ".json");

            using (FileStream fs = new FileStream(writePath, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<Models.Project>(fs, project, options);
                Console.WriteLine("Data has been saved to file");
            }

            return RedirectToAction("Index", "Project", new
            {
                projectid = project.projectid
            }); 
        }
    }
}

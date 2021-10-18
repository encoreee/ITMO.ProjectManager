using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectManager.Controllers
{
    
    public class ServicesController : Controller
    {
        private readonly UserManager<User> _userManager;

        public ServicesController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }




        [HttpPost]
        public async Task<IActionResult> makeSequence([FromBody] Models.Project project)
        {
            var userid = _userManager.GetUserId(User);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            String path = Directory.CreateDirectory(Environment.CurrentDirectory + "//UserData//" + userid).ToString();
            string writePath = System.IO.Path.Combine(path, project.projectid + ".json");

            using (FileStream fs = new FileStream(writePath, FileMode.Create))
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

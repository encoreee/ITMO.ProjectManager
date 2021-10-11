using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Domain;
using ProjectManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly DataManager dataManager;

        public ProjectsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public ActionResult Index()
        {
            return View(dataManager.projects.getProjects());
        }
    
        public IActionResult CreateProject()
        {
            Project project = new Project
            {
                Id = Guid.NewGuid(),
                Name = "Project name",
                Description = "Project description"
            };

            dataManager.projects.addProject(project);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProject(String id)
        {
            dataManager.projects.deleteProject(new Guid(id));
            return RedirectToAction("Index");
        }

    }
}

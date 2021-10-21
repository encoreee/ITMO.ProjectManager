using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Domain;
using ProjectManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.ViewModels;

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
            ViewBag.dataManager = dataManager;
            return View(dataManager);
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

        public IActionResult EditProject(String projectid)
        {

            Project project = dataManager.projects.getProjectById(new Guid(projectid));
            if (project == null)
            {
                return NotFound();
            }
            EditProjectViewModel model = new EditProjectViewModel
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditProject(EditProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                Project project = dataManager.projects.getProjectById(model.Id);

                if (project != null)
                {
                    project.Id = model.Id;
                    project.Name = model.Name;
                    project.Description = model.Description;
                    dataManager.projects.saveProject(project);

                    return RedirectToAction("Index", new
                    {
                        projectid = model.Id
                    });
                }
            }
            return RedirectToAction("Index", new
            {
                projectid = model.Id
            });
        }

    }
}

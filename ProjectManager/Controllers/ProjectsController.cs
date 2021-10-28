using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Domain;
using ProjectManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace ProjectManager.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly UserManager<User> _userManager;
        public ProjectsController(DataManager dataManager, UserManager<User> userManager)
        {
            this.dataManager = dataManager;
            _userManager = userManager;
        }
        public ActionResult Index()
        {
            ViewBag.dataManager = dataManager;
            return View(dataManager);
        }
        public IActionResult CreateProject()
        {
            ;

            if (User.IsInRole("Admin"))
            {
                Project project = new Project
                {
                    Id = Guid.NewGuid(),
                    Name = "Project name",
                    Description = "Project description"
                };
                dataManager.projects.addProject(project);
            }
            else
            {
                Project project = new Project
                {
                    Id = Guid.NewGuid(),
                    Name = "Project name",
                    Description = "Project description"
                };
                List<Project> query = new List<Project>();
                query.Add(project);
                dataManager.projects.addProject(project);
                dataManager.projects.addProjectToUser(_userManager.GetUserAsync(User).GetAwaiter().GetResult(), query.AsQueryable());
            }

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

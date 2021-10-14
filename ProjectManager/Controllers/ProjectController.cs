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
    public class ProjectController : Controller
    {
        private readonly DataManager dataManager;

        public ProjectController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public ActionResult Index(String projectid)
        {
            ViewData["projectid"] = projectid;
            return View(dataManager);
        }

        public IActionResult CreateColumn(String projectid)
        {
            Guid guid = Guid.NewGuid();
            Column column = new Column
            {
                Id = guid,
                Name = "Column name",
                Description = "Column description"
            };
            Project project = dataManager.projects.getProjectById(new Guid(projectid));
            dataManager.columns.addColumn(column);
            dataManager.projects.addColumnToProject(column, project);
            return RedirectToAction("Index", new
            {
                projectid = projectid
            });
        }

        public IActionResult DeleteColumn(String id)
        {
            dataManager.columns.DeleteColumn(new Guid(id));
            return RedirectToAction("Index");
        }

        public IActionResult CreateTask(String projectid, String columnid)
        {
            Guid guid = Guid.NewGuid();
            Task task = new Task
            {
                Id = guid,
                Name = "Task name",
                Description = "Task description"
            };


            Column column = dataManager.columns.getColumnsById(new Guid(columnid));
            dataManager.tasks.addTask(task);
            dataManager.columns.addTaskToColumn(task, column);
            return RedirectToAction("Index", new
            {
                projectid = projectid
            });
        }

        public IActionResult EditTask(String projectid, String taskid)
        {

            Task task = dataManager.tasks.getTaskById(new Guid(taskid));
            if (task == null)
            {
                return NotFound();
            }
            EditTaskViewModel model = new EditTaskViewModel
            {
                Id = task.Id,
                Projectid = new Guid(projectid),
                Name = task.Name,
                Description = task.Description
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditTaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                Task task = dataManager.tasks.getTaskById(model.Id);

                if (task != null)
                {
                    task.Id = model.Id;
                    task.Name = model.Name;
                    task.Description = model.Description;
                    dataManager.tasks.saveTask(task);

                    return RedirectToAction("Index", new
                    {
                        projectid = model.Projectid
                    });
                }
            }
            return RedirectToAction("Index", new
            {
                projectid = model.Projectid
            });
        }
    }
}
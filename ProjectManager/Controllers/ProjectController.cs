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
    public class ProjectController : Controller
    {
        private readonly DataManager dataManager;

        public ProjectController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public ActionResult Index(String id)
        {
            ViewData["projectid"] = id;
            return View(dataManager);
        }

        public IActionResult CreateColumn(String id)
        {
            Guid guid = Guid.NewGuid();
            Column column = new Column
            {
                Id = guid,
                Name = "Column name",
                Description = "Column description"
            };
            Project project = dataManager.projects.getProjectById(new Guid(id));
            dataManager.columns.addColumn(column);
            dataManager.projects.addColumnToProject(column, project);
            return RedirectToAction("Index", new
            {
                id = id
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
                id = projectid
            });
        }









    }

}
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
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjectManager.Controllers
{
    public class ProjectController : Controller
    {
        private readonly DataManager dataManager;
        private readonly UserManager<User> _userManager;
        public ProjectController(DataManager dataManager, UserManager<User> userManager)
        {
            this.dataManager = dataManager;
            _userManager = userManager;
        }

        public async Task <ActionResult> Index(String projectid)
        {
            ViewData["userid"] = _userManager.GetUserId(User);
            ViewData["projectid"] = projectid;
            ViewBag.dataManager = dataManager;
            return View(dataManager);
        }

        public IActionResult CreateTask(String projectid, String columnid)
        {
            Guid guid = Guid.NewGuid();

            Task task = new Task
            {
                Id = guid,
                Name = "Task name",
                Description = "Task description",
                Startdate = DateTime.Now,
                Enddate = DateTime.Now,
                Priority = 0
            };

            Column column = dataManager.columns.getColumnsById(new Guid(columnid));
            dataManager.tasks.addTask(task);
            dataManager.columns.addTaskToColumn(task, column);
            return RedirectToAction("Index", new
            {
                projectid = projectid
            });
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

        public IActionResult DeleteColumn(String projectid, String columnid)
        {
            dataManager.columns.DeleteColumn(new Guid(columnid));
            return RedirectToAction("Index", new
            {
                projectid = projectid
            });
        }

        public IActionResult DeleteTask(String projectid, String taskid)
        {
            dataManager.tasks.DeleteTask(new Guid(taskid));
            return RedirectToAction("Index", new
            {
                projectid = projectid
            });
        }

        public  IActionResult ChangeColumn(String projectid, String columnid, String taskid)
        {

            Column column = dataManager.columns.getColumnsById(new Guid(columnid));
            Task task = dataManager.tasks.getTaskById(new Guid(taskid));
            dataManager.columns.changeTaskColmun(task, column);
            //return new EmptyResult();
            return RedirectToAction("Index", new
            {
                projectid = projectid
            });
        }

        public IActionResult EditTask(String projectid, String taskid)
        {
            ViewBag.dataManager = dataManager;
            Task task = dataManager.tasks.getTaskById(new Guid(taskid));
            if (task == null)
            {
                return NotFound();
            }
            var users = _userManager.Users;
            var productsList = (from user in users
                                select new SelectListItem()
                                {
                                    Text = user.UserName,
                                    Value = user.Id.ToString(),

                                }).ToList();
            EditTaskViewModel model = new EditTaskViewModel();
            model.Id = task.Id;
            model.Projectid = new Guid(projectid);
            model.Name = task.Name;
            model.Description = task.Description;
            model.Startdate = task.Startdate;
            model.Enddate = task.Enddate;
            model.Priority = task.Priority;
            model.ListOfUsers = productsList;
            if (task.Userid != null)
            {
                model.Userid = task.Userid;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditTask(EditTaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                Task task = dataManager.tasks.getTaskById(model.Id);

                if (task != null)
                {
                    task.Id = model.Id;
                    task.Name = model.Name;
                    task.Description = model.Description;
                    task.Enddate = model.Enddate;
                    task.Startdate = model.Startdate;
                    task.Priority = model.Priority;

                    User user = _userManager.FindByIdAsync(model.Userid).GetAwaiter().GetResult();

                    task.Userid = user.Id;

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

        public IActionResult EditColumn(String projectid, String Columnid)
        {
            Column column = dataManager.columns.getColumnsById(new Guid(Columnid));
            if (column == null)
            {
                return NotFound();
            }
            EditColumnViewModel model = new EditColumnViewModel
            {
                Id = column.Id,
                Projectid = new Guid(projectid),
                Name = column.Name,
                Description = column.Description
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditColumn(EditColumnViewModel model)
        {
            if (ModelState.IsValid)
            {
                Column column = dataManager.columns.getColumnsById(model.Id);

                if (column != null)
                {
                    column.Id = model.Id;
                    column.Name = model.Name;
                    column.Description = model.Description;
                    dataManager.columns.saveColumns(column);

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
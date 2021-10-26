using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProjectManager.ViewModels;
using Microsoft.AspNetCore.Authorization;
using ProjectManager.Domain;
using System.Collections.Generic;
using System;

namespace ProjectManager.Controllers
{
    [Authorize(Roles = "admin")]
    public class UsersController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly UserManager<User> _userManager;
        public UsersController(DataManager dataManager, UserManager<User> userManager)
        {
            _dataManager = dataManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {

            return View(_userManager.Users.ToList());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Username };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { Id = user.Id, Username = user.UserName, Email = user.Email, Year = user.Year };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Username;
                    user.Year = model.Year;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }
        public async Task<IActionResult> EditFromPersonal(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { Id = user.Id, Username = user.UserName, Email = user.Email, Year = user.Year };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditFromPersonal(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Username;
                    user.Year = model.Year;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Projects");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return RedirectToAction("Index", "Projects");
        }
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ChangePassword(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    var _passwordValidator =
                        HttpContext.RequestServices.GetService(typeof(IPasswordValidator<User>)) as IPasswordValidator<User>;
                    var _passwordHasher =
                        HttpContext.RequestServices.GetService(typeof(IPasswordHasher<User>)) as IPasswordHasher<User>;

                    IdentityResult result =
                        await _passwordValidator.ValidateAsync(_userManager, user, model.NewPassword);
                    if (result.Succeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user, model.NewPassword);
                        await _userManager.UpdateAsync(user);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User Not Found");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> AddProjectToUser(string Id)
        {
            // получаем пользователя
            User user = await _userManager.FindByIdAsync(Id);

            if (user != null)
            {

                var userProjects = _dataManager.projects.findProjectsByUserId(new System.Guid(Id));
                var allProjects = _dataManager.projects.getProjects();
                List<string> proj = new List<string>();

                foreach (var item in userProjects)
                {
                    proj.Add(item.Id.ToString());
                }
    
                ChangeUserProjectViewModel model = new ChangeUserProjectViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    UserPojects = proj,
                    AllProjects = allProjects.ToList()
                };
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AddProjectToUser(string userId, List<string> projects)
        {
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
      

                var userProjects = _dataManager.projects.findProjectsByUserId(new System.Guid(userId)).AsEnumerable();
                List<Project> listofproj = new List<Project>();
                foreach (var item in projects)
                {
                    listofproj.Add(_dataManager.projects.getProjectById(new Guid(item)));
                }

                var addedProjects = listofproj.Except(userProjects);
                var removedProjects = userProjects.Except(listofproj);
                
                List<string> rp = new List<string>();
                foreach (var item in removedProjects)
                {
                    rp.Add(item.Id.ToString());
                }

                _dataManager.projects.addProjectToUser(user, addedProjects.AsQueryable());
                _dataManager.projects.removeProjectFromUser(user, rp.AsQueryable());

                return RedirectToAction("Index");
            }

            return NotFound();
        }





    }


}

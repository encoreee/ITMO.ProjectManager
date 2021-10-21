using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using ProjectManager.Domain;

namespace ProjectManager.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<User> _userManager;
        //private readonly User _user;
        private readonly DataManager _dataManager;
        


        public HomeController(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, DataManager dataManager, ILogger<HomeController> logger)
        {
            _httpContext = httpContextAccessor;
            _userManager = userManager;
           // _user = _userManager.Users.Single(u => u.Id == _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            _dataManager = dataManager;
            _logger = logger;
        }



        public IActionResult Index()
        {
            ViewBag.dataManager = _dataManager;
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

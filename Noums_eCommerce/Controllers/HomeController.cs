using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Noums_eCommerce.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Domains;

namespace Noums_eCommerce.Controllers
{
    public class HomeController : Controller
    {
         readonly ILogger<HomeController> _logger;
         readonly UserManager<Domains.AppUser> CustomerManager;
 
        public HomeController(ILogger<HomeController> logger, UserManager<Domains.AppUser> CustomerManager)
        {
            _logger = logger;
            this.CustomerManager = CustomerManager;
          }

        public IActionResult Index()
        {

 

            return View();
        }
        public IActionResult Order()
        {

            return View();
        }
        public IActionResult Privacy()
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

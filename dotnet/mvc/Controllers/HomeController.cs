using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace mvc.Controllers {
    public class HomeController : Controller {
        private readonly IRepository repo;
        private readonly IConfiguration config;
        private string message;

        public HomeController (IRepository repo, IConfiguration config) {
            this.repo = repo;
            this.config = config;
            message = config["MESSAGE"] ?? "Essential Docker";
        }
        public IActionResult Index () {

            ViewBag.Message = message;
            return View (repo.Products);
        }

        public IActionResult Privacy () {
            return View ();
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
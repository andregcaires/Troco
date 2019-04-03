using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Troco.Domain.Models;
using Troco.Service.Abstractions;
using Troco.Web.Models;

namespace Troco.Web.Controllers
{
    public class HomeController : Controller
    {
        private IChangeService _service;

        public HomeController(IChangeService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalculateChange(Change change)
        {
            _service.calculateChange(change);
            return View(change);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

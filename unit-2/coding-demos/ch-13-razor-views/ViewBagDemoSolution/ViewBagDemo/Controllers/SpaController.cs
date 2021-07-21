using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


//Microsoft.Hosting.Lifetime: Information: Now listening on: https://localhost:5001


namespace ViewBagDemo.Controllers
{
    public class SpaController : Controller
    {
        public string Name { get; set; } = "Roger";

        public double Add()
        {
            return 2.99 + 2;
        }

        // GET: /<controller>/

        [Route("spa/homepage")]
        public IActionResult Index()
        {
            ViewBag.storedName = this.Name;

            return View(); // "~/Views/Spa/Index"
        }

        [HttpPost]
        [HttpGet]
        [Route("spa/person")]
        public IActionResult RenderFormData(string fname)
        {
            ViewBag.storedName = fname;

            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RoutingDemo.Controllers
{
    [Route("hello/")]
    public class HelloController : Controller
    {

        public IActionResult Index()
        {
            string html = @"
                <form method='post' >
                    <label for='fname'>First name:</label><br>
                    <input type='text' name='fname'><br>

                    <label for='lname'>Last name:</label><br>
                    <input type='text' name='lname'><br><br>

                     <input type='submit' value='Submit'>
                </form>
                ";

            return Content(html, "text/html");
        }

        [HttpPost("")]
        public IActionResult RenderFormData(string fname, string lname)
        {

            string html = $"Hello {fname} {lname}";
            return Content(html, "text/html");
        }

    }
}

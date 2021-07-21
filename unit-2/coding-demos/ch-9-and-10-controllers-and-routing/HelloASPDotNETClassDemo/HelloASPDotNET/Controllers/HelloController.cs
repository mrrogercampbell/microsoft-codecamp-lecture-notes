using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloASPDotNET.Controllers
{
    [Route("/hello")]
    public class HelloController : Controller
    {
        // GET: localHost:5001/<controller>/
        [HttpGet("/index")]
        public IActionResult Index()
        {
            string html = "<h1>Hello World</h1>";

            return Content(html, "text/html");
        }

        [HttpPost]
        [HttpGet]
        [Route("/saymyname/{name?}")]
        public IActionResult SayMyName(string name, int num)
        {
            int sum = num + 2;

            string html = $"<h1>Hello {name}! Welcome to the show!! {sum}</h1>";

            return Content(html, "text/html");
        }

        public IActionResult Form()
        {
            string openingFormTag = "<form method='post' action='/hello/saymyname'>";

            string closingFormTag = "</form>";

            string nameInputTag = "<input type='text' name='name'/>";

            string submitInputTag = "<input type='submit' value='Greet Me!'/>";


            string html = openingFormTag + nameInputTag + submitInputTag + closingFormTag;


            return Content(html, "text/html");
        }


    }
}

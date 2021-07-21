using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RazorViewsDemo.Controllers
{
    [Route("/hello")]
    public class HelloController : Controller
    {
        public Dictionary<int, List<string>> peopleDictionary { get; set; }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //string name = "Muri";

            string[] people = { "Han", "John", "Jane", "Jacky" };


            //ViewBag.storedName = name;
            ViewBag.storedPeople = people;

            return View();
        }


        [HttpGet("images/")]
        public IActionResult Image()
        {
            return View();
        }






        [HttpPost]
        public IActionResult HandleFormSubmission(string fname)
        {
            Dictionary<string, string> people = new Dictionary<string, string>
            {
                {"Muri", "HAHAHAH" },
                {"John", "YESSSSSSS" }
            };

            ViewBag.person = people[fname];
            ViewBag.number = 22;

            return View("~/Views/Hello/FormRender.cshtml");
        }


        //[HttpPost("/")]
        //public IActionResult DictionaryForm(string fname, string lname, string email)
        //{
        //    var _random = new Random();
        //    int num = _random.Next(); // gives me a random number
        //                              // Want to take user input getting three pieces of data:
        //                              // fname, lname, email
        //                              // From the data I get I want to added each persons data into the dict
        //                              // Dict stores Key:in|Value: List<strings>
        //                              //In order to store a person I need to generate a random numebr
        //                              // Then use the random and add the date to the list

        //    List<string> personData = new List<string> { fname, lname, email };

        //    peopleDictionary.Add(num, personData);

        //    ViewBag.person = personData;

        //    // Now have the user data it is in a list and I want to render it in the view
        //        // ?? How to pass the data to the view??
        //            // I could use a ViewBag.PersonData = Dictionary

        //    return View();
        //}

    }
}

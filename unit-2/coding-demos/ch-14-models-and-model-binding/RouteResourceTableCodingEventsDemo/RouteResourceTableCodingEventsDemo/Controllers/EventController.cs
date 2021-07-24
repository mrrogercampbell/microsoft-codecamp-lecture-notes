using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteResourceTableCodingEventsDemo.DataLayer;
using RouteResourceTableCodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc;

// You can find the Route Resource Table I created here: https://docs.google.com/spreadsheets/d/1bZh760bT5MGoov6HbLqOoWXgPhGiPu4ypyQJO-fjdl8/edit?usp=sharing

namespace RouteResourceTableCodingEventsDemo.Controllers
{
    public class EventController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {

            ViewBag.events = EventDataLayer.GetAll();

            return View();
        }

        // GET: /Event/Add
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("/Event/Add")]
        public IActionResult AddNewEvent(string name, string description)
        {
            EventDataLayer.Create(name, description);

            return Redirect("/Event");
        }

        //[HttpPost("/Event/Add")]
        //public IActionResult AddNewEvent(Event newEvent)
        //    // Event newEvent = new Event(request.name, request.description)
        //{
        //    EventDataLayer.Create(newEvent);

        //    return Redirect("/Event");
        //}
    }
}

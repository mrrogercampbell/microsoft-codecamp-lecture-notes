using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {
    

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }

        // GET: /<controller>/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // POST: /<controller>/
        [HttpPost("/Events/Add")]
        public IActionResult AddNewEvent(Event newEvent)
        {
            //Event newEvent = new Event(eventName, eventDescription);

            EventData.Add(newEvent);

            return Redirect("/Events");
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }


        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }

        
        public IActionResult GetSingleEvent()
        {
            ViewBag.events = EventData.GetAll();

            return View("~/Views/Events/GetSingleEventForm.cshtml");
        }

        [HttpPost]
        public IActionResult GetSingleEvent(int eventId)
        {
            ViewBag.events = EventData.GetById(eventId);

            return View("~/Views/Events/Index.cshtml");
        }
    }
}

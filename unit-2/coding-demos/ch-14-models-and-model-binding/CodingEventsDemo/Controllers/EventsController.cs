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


        // GET: /<controller>/Index
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


        [HttpPost("/Events/Add")]
        public IActionResult AddNewEvent(Event newEvent)
        {

            EventData.Add(newEvent);

            return Redirect("/Events");
        }

        // GET: /<controller>/Delete
        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }


        // POST: /<controller>/Delete
        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                EventData.Remove(eventId);
        }

            return Redirect("/Events");
        }

        // GET: /<controller>/GetSingleEvent
        public IActionResult GetSingleEvent(int eventId)
        {
            ViewBag.evt = EventData.GetById(eventId);

            return View();
        }
    }
}

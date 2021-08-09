using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        private EventDbContext _context;

        public EventsController(EventDbContext dbContext)
        {
            _context = dbContext;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            //List<Event> events = new List<Event>(EventData.GetAll());

            List<Event> events = _context.Events
                .Include(e => e.Category)
                .ToList();

            return View(events);
        }

        // GET: /<controller>/Add
        [HttpGet]
        public IActionResult Add()
        {
            List<EventCategory> categories = _context.Categories.ToList();

            AddEventViewModel addEventViewModel = new AddEventViewModel(categories);

            return View(addEventViewModel);
        }

        // POST: /<controller
        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if(ModelState.IsValid)
            {
                EventCategory theCategory = _context.Categories.Find(addEventViewModel.CategoryId);

                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    Category = theCategory
                };

                _context.Events.Add(newEvent);
                _context.SaveChanges();

                return Redirect("/Events");
            }

            return View(addEventViewModel);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            //ViewBag.events = EventData.GetAll();
            ViewBag.events = _context.Events.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int eventId in eventIds)
            {
                //EventData.Remove(eventId);
                Event theEvent = _context.Events.Find(eventId);

                _context.Events.Remove(theEvent);
            }

            _context.SaveChanges();

            return Redirect("/Events");
        }
    }
}

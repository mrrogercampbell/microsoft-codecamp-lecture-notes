using System;
using System.Collections.Generic;
using RouteResourceTableCodingEventsDemo.Models;

namespace RouteResourceTableCodingEventsDemo.DataLayer
{
    public class EventDataLayer
    {
        private static Dictionary<int, Event> _events = new Dictionary<int, Event>();

        public static IEnumerable<Event> GetAll()
        {
            //Event[] events = { new Event(), new Event(), new Event() };

            return _events.Values;
        }

        public static void Create(string name, string description)
        {
            Event newEvent = new Event(name, description);

            //newEvent.Id // 1
            //newEvent.Name // Name came from the form
            //newEvent.Description // Description came from the form


            _events.Add(newEvent.Id, newEvent);

            //1, newEvent

        }

        //public static void Create(Event passedEvent)
        //{
        //    _events.Add(passedEvent.Id, passedEvent);

        //}
    }
}

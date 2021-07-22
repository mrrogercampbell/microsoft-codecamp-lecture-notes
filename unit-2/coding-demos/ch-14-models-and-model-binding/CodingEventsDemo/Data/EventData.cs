using System;
using System.Collections.Generic;
using CodingEventsDemo.Models;

namespace CodingEventsDemo.Data
{
    public class EventData
    {
        //static private List<Event> events = new List<Event>();

        static private Dictionary<int, Event> _events = new Dictionary<int, Event>();

        // Add
        public static void Add(Event newEvent)
        {
            _events.Add(newEvent.Id, newEvent);
        }


        // GetAll
        public static IEnumerable<Event> GetAll()
        {
            return _events.Values;
        }


        //// Remove
        public static void Remove(int id)
        {
            _events.Remove(id);
        }


        // GetById
        public static Event GetById(int id)
        {

            return _events[id];
        }

    }
}

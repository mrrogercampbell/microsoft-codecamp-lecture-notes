using System;
using System.Collections.Generic;

namespace CodingEvents.Models
{
    public class EventCategory
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public List<Event> Events { get; set; }

        public EventCategory(string name)
        {
            this.Name = name;
        }

        public EventCategory()
        {
        }
    }
}

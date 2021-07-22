using System;
namespace CodingEventsDemo.Models
{
    public class Event
    {
        private static int _nextId = 1;

        public int Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Event()
        {
            this.Id = _nextId;

            _nextId++;
        }

        public Event(string name, string description)
            : this()
        {
            this.Name = name;
            this.Description = description;
            this.Id = _nextId;

            _nextId++;
        }
    }
}

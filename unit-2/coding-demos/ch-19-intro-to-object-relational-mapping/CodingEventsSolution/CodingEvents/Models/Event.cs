using System;
namespace CodingEvents.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }

        public EventType Type { get; set; }

        public Event()
        {
        }

        public Event(string name, string description, string contactEmail)
        {
            this.Name = name;
            this.Description = description;
            this.ContactEmail = contactEmail;
        }

        public override string ToString()
        {
            return Name;
        }


        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   Id == @event.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id);
        }
    }
}

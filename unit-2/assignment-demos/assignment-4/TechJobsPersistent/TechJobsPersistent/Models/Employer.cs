using System;
namespace TechJobsPersistent.Models
{
    public class Employer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public Employer()
        {
        }

        public Employer(string name, string location)
        {
            Name = name;
            Location = location;
        }
    }
}

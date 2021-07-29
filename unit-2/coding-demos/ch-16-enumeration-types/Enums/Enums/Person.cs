using System;
namespace Enums
{
    public class Person
    {
        public string Name { get; set; }

        public Person() { }

        public Person(string name)
        {
            this.Name = name;

        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}

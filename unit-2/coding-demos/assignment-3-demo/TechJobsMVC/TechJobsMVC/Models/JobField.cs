using System;
namespace TechJobsMVC.Models
{
    public abstract class JobField
    {
        public int Id { get; }
        static private int nextId = 1;
        public string Value { get; set; }

        public JobField()
        {
            Id = nextId;
            nextId++;
        }

        public JobField(string value) : this()
        {
            Value = value;

        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object obj)
        {
            return obj is JobField field &&
                   Id == field.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}

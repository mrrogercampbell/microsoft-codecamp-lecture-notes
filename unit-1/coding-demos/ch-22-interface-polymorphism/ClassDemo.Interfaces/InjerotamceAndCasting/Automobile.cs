using System;
namespace InheritanceAndCasting
{
    public class Automobile
    {
        public int NumberOfDoors { get; set; }
        public int NumberOfWheels { get; set; }

        public string Color { get; set; }


        public Automobile(int numberOfDoors, int numberOfWheels, string color)
        {
            this.NumberOfDoors = numberOfDoors;
            this.NumberOfWheels = numberOfWheels;
            this.Color = color;
        }

        public static double GiveMeANumber(int number)
        {
            return number;
        }
    }
}

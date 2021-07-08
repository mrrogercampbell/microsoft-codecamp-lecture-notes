using System;
namespace InheritanceAndCasting
{
    public class Motorcycle : Automobile
    {
        public Motorcycle(int numberOfDoors, int numberOfWheels, string color)
            : base(numberOfDoors, numberOfWheels, color)
        {

        }

        public void DoAPopAWheelie()
        {
            Console.WriteLine("Vroom! Vroom! Vroom! Vroom!");
            Console.WriteLine("*Pops a wheelie*");
        }

        public override string ToString()
        {
            DoAPopAWheelie();

            return $"This is a {this.Color} Motorcycle that has {this.NumberOfDoors} doors and {this.NumberOfWheels} wheels";
        }
    }
}

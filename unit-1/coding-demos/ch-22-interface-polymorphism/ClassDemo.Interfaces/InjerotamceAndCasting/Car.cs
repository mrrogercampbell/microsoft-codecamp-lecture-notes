using System;
namespace InheritanceAndCasting
{
    public class Car : Automobile
    {
        public Car(int numberOfDoors, int numberOfWheels, string color)
            : base(numberOfDoors, numberOfWheels, color)
        {

        }

        public void DoDonuts()
        {
            Console.WriteLine("Vroom! Vroom!");
            Console.WriteLine("Skert! Skertttt!!!");
            Console.WriteLine("*Makes a donut*");
        }

        public override string ToString()
        {
            DoDonuts();

            return $"This is a {this.Color} Car that has {this.NumberOfDoors} doors and {this.NumberOfWheels} wheels";
        }
    }
}

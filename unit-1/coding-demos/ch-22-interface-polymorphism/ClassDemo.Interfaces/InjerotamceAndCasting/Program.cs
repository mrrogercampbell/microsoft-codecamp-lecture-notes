using System;

namespace InheritanceAndCasting
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car(4, 4, "Red");

            //Console.WriteLine(car1.ToString());

            //Console.WriteLine("<------->");



            Motorcycle motorcycle1 = new Motorcycle(0, 2, "Black");

            //Console.WriteLine(motorcycle1.ToString());

            //Console.WriteLine("<------->");


            string name;

            name = "Roger";
     

            Automobile car2 = new Car(4, 4, "Orange");

            //double number = 4;

            //int number2 = 1000000.9;


            //Console.WriteLine(car2.ToString());

            //Console.WriteLine("<------->");


            Automobile motorcycle2 = new Motorcycle(0, 2, "Hot Pink");
            //Console.WriteLine(motorcycle2.ToString());

            double number = 1;

            Automobile[] automobiles = { motorcycle2, car2 };


            Car[] cars = { motorcycle2, car2 };

            

        }
    }
}

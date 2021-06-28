using System;

namespace demo_classes_pt_1_project
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            person1.Birthdate = new DateTime(1990, 5, 27);
            Console.WriteLine(person1.Age);
            person1.ShowBirthday();

        }
    }

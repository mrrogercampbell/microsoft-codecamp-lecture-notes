using System;

namespace ch_19_prep
{
    class Program
    {
        static void Main(string[] args)
        {
            FinalFields demo = new FinalFields();

            //These are not allowed:
            //demo.intValue = 6;

            //demo.doubleValue = 42.0;

            //demo.doubleValue = 6.0;

            //demo.objectValue = new FortyTwo();

            //However, this is allowed: Why is that ?
           //Console.WriteLine(demo.objectValue.intValue);

           // demo.objectValue.intValue = 6;

           // Console.WriteLine(demo.objectValue.intValue);


            // Books example for a static feild
            //Student student1 = new Student("Roger");
            //Console.WriteLine(student1.studentId);

            //Student student2 = new Student("Doc");
            //Console.WriteLine(student2.studentId);

            //Student student3 = new Student("Jimbo");
            //Console.WriteLine(student3.studentId);


            // My example for a static feild
            Static InstanceOfTheStaticClass = new Static();

            //Console.WriteLine($"Non-Static ID: {InstanceOfTheStaticClass.nonStaticId}");

            //Console.WriteLine($"Non-Static ID: {InstanceOfTheStaticClass.staticId}");

            //Console.WriteLine($"Static ID: {Static.staticId}");

            //Console.WriteLine(Static.nonStaticId);

            //Console newConsole = new Console();

            //newConsole.WriteLine("Hello");




            //Console.WriteLine($"Non-Static ID: {InstanceOfTheStaticClass.ToString()}");



            //Static.GetStaticID();
            //Static.GetNonStaticId();

            //InstanceOfTheStaticClass.GetNonStaticID();
            //InstanceOfTheStaticClass.GetStaticID();


            // ToString example:
            //Student student1 = new Student("Roger");
            //Static static1 = new Static();
            // Show the default ToString():
            // Be sure you comment out the custom version in the class
            //Console.WriteLine(student1.ToString());

            //Console.WriteLine(static1.ToString());

            // Show the custom ToString():
            //Console.WriteLine(student1.ToString());

            // Show the implicitly called ToString():
            //Console.WriteLine(student1);





            Student student1 = new Student("Roger");
            // Memory location: 0001

            Student student2 = new Student("Roger");
            // Memory location: 0002


            Console.WriteLine(student1 == student2);

            if(student1.Equals(null))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }







        }
    }
}

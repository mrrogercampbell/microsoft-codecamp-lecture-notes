using System;
namespace demo_classes_pt_1_project
{
    public class Person
    {
        // Here we are creating private Fields
        private string _name;
        public string CountryOfOrigin;


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // This is an Auto-Implemented Property
        // We are performing the same actions as done on lines 11-15
        public DateTime Birthdate { get; set; }

        // If you notice we never create a feild for _age or Age
        // This is because we only need a property for Age
        public int Age
        {
            // Our get method is doing quite a bit for us:
            get
            {
                // 1. We create a variable called timeSpan which store a data type of TimeSpan
                TimeSpan timeSpan = DateTime.Today - Birthdate;
                // 2. We set the value of timeSpan = today's date - the value we set for the Birthdate property
                // This gives us how many days have passed sense the Date of birth
                // timeSpan = Today's date - Birthdate

                // 3. We create a variable called years which stores an int
                int years = timeSpan.Days / 365;
                // 4. We then set the value of years = the amount of days stored in the timeSpan variable divided by 365 days
                // years = amount of days / 365 (days in a year)
                // This gives us the amount of years that have passed since the person was born

                // 5. We then return the number of years which becomes the value of the Age property we declared on line 23
                return years;
                // Age = years
            }
        }

        public void ShowBirthday()
        {
            Console.WriteLine(this.Birthdate);
        }


        // This is the constructor for our Class
        // It allows us to initialize an instance of a class without providing any arguments 
        public Person()
        {
        }

        // We can Overload a constructor to allow it to accept arugments that can be utilized in the initialization of a class
        public Person(string name)
        {
            // This line of code is doing the same things as our Name property on line 11
            this._name = name;
            // The only difference is if we removed the Name property on line 11 we would ONLY EVER be able to set the value of _name when we create an instance of the class
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarClass;


namespace CarTest
{
    [TestClass]
    public class PersonTest
    {
        Person person1 = null;

        [TestInitialize]
        public void TestInitilier()
        {
            person1 = new Person("Jon", 35);
            Console.WriteLine("Ran the initilier");
        }

        [TestMethod]
        public void TestPersonName()
        {
            //Person person1 = new Person("Jon", 35);

            Assert.IsTrue(person1.Name == "Jon");
        }

        [TestMethod]
        public void TestPersonAge()
        {
            //Person person1 = new Person("Jon", 35);

            Assert.IsTrue(person1.Age == 35);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

// This is like an excel reference to the Car project
using CarClass;

namespace CarTest
{
    //[TestClass] // Loads the Test Class into the test runner
    public class UnitTest1
    {
        Car car1;
        Car car2;
        Car car3;
        string carName;

        [TestInitialize] // Run this method before every unit test (method)
            // This allows us to define logic we want to happen before any of our test run 
        public void CreateAInstanceOfCar()
        {
            car1 = new Car();
            car2 = new Car();
            car3 = new Car();
        }

        [TestCleanup]
        public void CleanUpTestLogic()
        {
            car1 = null;
            car2 = null;
        }

        [TestMethod] // Loads the unit test into the test runner
        public void TestVroomMethod()
        {
            string expectedOutout = "vroom vroom";

            Assert.IsTrue(car1.Vroom() == expectedOutout);
        }

        [TestMethod] // Loads the unit test into the test runner
        public void TestVroomMethod2()
        {
            string expectedOutout = "vroom vroom";

            car1.GasTankLevel = 5;

            Assert.IsTrue(car1.Vroom() == expectedOutout);
        }

        [TestMethod]
        public void TestMethod3()
        {
 
        }


        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(4, 4, 0.1); // postive test case
            //Assert.AreEqual(4, 10, 0.1); // negative test case
            Assert.AreEqual(4, 4.2, .5); // edge test case
        }

        [TestMethod]
        public void IsValidSSN()
        {
            // I want to expect a SSN that should look like ###-##-####
            // #########
            // ###.##.####
            // ### ## ####

        }

    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Car;
using System.Collections.Generic;

namespace CarTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EmptyTest()
        {
            Assert.AreEqual(1, 1, .1);
        }

        [TestMethod]
        public void TestGasTankLevel()
        {
            CarClass car1 = new
           CarClass("Honda", "Accord", 12, 44.5, 4);

            Assert.AreEqual(12, car1.GasTankSize, 1);
        }

        [TestMethod]
        public void TestGiveMaxDistance()
        {
            CarClass car1 = new
           CarClass("Honda", "Accord", 12, 44.5, 4);

            double maxDistance = car1.GiveMaxDistance();

            //Assert.AreEqual(534, maxDistance, 1);

            Assert.IsFalse(maxDistance > 677);
        }
    }
}

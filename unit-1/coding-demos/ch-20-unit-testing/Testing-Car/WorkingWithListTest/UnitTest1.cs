using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkingWithList;

namespace WorkingWithListTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestContentsOfAList()
        {
            // I want to create a method that take a array and stores each item in a list
            ListClass newlyCreatedList = new
           ListClass();

            string[] names = { "Jon", "Jane", "James", "Jacky" };

            List<string> totalCountOfList = newlyCreatedList.AddToListMethod(names);

            Assert.AreEqual(names.Length, totalCountOfList.Count, .1);

            // I then want to test if the total Count of the List is eqaul to the Length of the Array
        }

        [TestMethod]
        public void TestToSeeIfConentOfListMatches()
        {
            // I want to test to see if the AddToListMethod actually stores the correct names from the array that is passed as an argument

            //I will need to envoke the method and store it in a var
            // I will then need to reurn the actually List that is created
            // I will then need to iterate over the returned List and compare each item in the List to each item in the provided Array
            ListClass newlyCreatedList = new
            ListClass();

            string[] names = { "Jon", "Jane", "James", "Jacky" };

            List<string> CreatedListFromMethod = newlyCreatedList.AddToListMethod(names);

            int i = 0;
            foreach (string item in CreatedListFromMethod)
            {
                Assert.AreEqual(item, names[i]);
                i++;
            }

        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using BalancedBrackets;

namespace BalancedBracketsTest
{
    [TestClass]
    public class UnitTest1
    {
        // We need to test to see if a string contains []
        // The [ bracket must come before the ] bracket in order for the program to be valid

        // Any other order of the brackets is invalid
        // ie: "][", "[", "]", etc

        // I must have at least 12 test
        // Test 1: Does the string contain just a "[]"?
        // Test 2: Does the String Just contain a [

        string testString;
        bool checkTestString;

        [TestCleanup]
        public void CleanUpVariables()
        {
            testString = "";
        }

        [TestMethod]
        public void TestDoesStringContainJustBrackets()
        {
            testString = "[]";
            checkTestString = BalancedBracketsClass.HasBalancedBrackets(testString);

            Assert.IsTrue(checkTestString);
        }


        [TestMethod]

        public void TestIfStringContainsOnlyLeftbracket()
        {
            testString = "[";
            checkTestString = BalancedBracketsClass.HasBalancedBrackets(testString);

            Assert.IsFalse(checkTestString);
        }


        // Expecting true results
        [TestMethod]
        public void EmptyTest()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void OnlyBracketsReturnsTrue()
        {
            Assert.IsTrue(BalancedBracketsClass.HasBalancedBrackets("[]"));
        }

        [TestMethod]
        public void InitTest()
        {
            Assert.AreEqual(true, BalancedBracketsClass.HasBalancedBrackets(""));
        }

        [TestMethod]
        public void StringInBracketsReturnsTrue()
        {
            Assert.IsTrue(BalancedBracketsClass.HasBalancedBrackets("[LaunchCode]"));
        }

        [TestMethod]
        public void StringAndBracketsReturnsTrue()
        {
            Assert.IsTrue(BalancedBracketsClass.HasBalancedBrackets("Launch[Code]"));
        }

        [TestMethod]
        public void BracketsAndStringReturnsTrue()
        {
            Assert.IsTrue(BalancedBracketsClass.HasBalancedBrackets("[]LaunchCode"));
        }


        [TestMethod]
        public void TwoSetsReturnsTrue()
        {
            Assert.IsTrue(BalancedBracketsClass.HasBalancedBrackets("[]LaunchCode[]"));
        }

        [TestMethod]
        public void NestedReturnsTrue()
        {
            Assert.IsTrue(BalancedBracketsClass.HasBalancedBrackets("[[LaunchCode]]"));
        }

        [TestMethod]
        public void DoubleNestedReturnsTrue()
        {
            Assert.IsTrue(BalancedBracketsClass.HasBalancedBrackets("[[LaunchCode]] [hello] [hello]"));
        }

        // Expected false results
        [TestMethod]
        public void ReverseOnlyBracketsReturnsFalse()
        {
            Assert.IsFalse(BalancedBracketsClass.HasBalancedBrackets("]["));
        }

        [TestMethod]
        public void OnlyLeftBracketsReturnsFalse()
        {
            Assert.IsFalse(BalancedBracketsClass.HasBalancedBrackets("[LaunchCode"));
        }

        [TestMethod]
        public void WrongOrderBracketsReturnsFalse()
        {
            Assert.IsFalse(BalancedBracketsClass.HasBalancedBrackets("Launch]Code["));
        }

        [TestMethod]
        public void LeftBracketReturnsFalse()
        {
            Assert.IsFalse(BalancedBracketsClass.HasBalancedBrackets("["));
        }

        [TestMethod]
        public void MismatchReturnsFalse()
        {
            Assert.IsFalse(BalancedBracketsClass.HasBalancedBrackets("[launch[]"));
        }

        [TestMethod]
        public void otherMismatchReturnsFalse()
        {
            Assert.IsFalse(BalancedBracketsClass.HasBalancedBrackets("]launch[]"));
        }


    }
}

using System;

namespace BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string testString5 = "[Launch [Code] ]";
            BalancedBracketsClass.HasBalancedBrackets(testString5);

            string testString6 = "[Launch [Code] ";
            BalancedBracketsClass.HasBalancedBrackets(testString6);

            string testString = "]Launch [Code ";
            BalancedBracketsClass.HasBalancedBrackets(testString);
        }
    }
}

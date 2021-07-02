using System;
namespace BalancedBrackets
{
    public class BalancedBracketsClass
    {
        /**
         * The function BalancedBrackets should return true if and only if
         * the input string has a set of "balanced" brackets.
         *
         * That is, whether it consists entirely of pairs of opening/closing
         * brackets (in that order), none of which mis-nest. We consider a bracket
         * to be square-brackets: [ or ].
         *
         * The string may contain non-bracket characters as well.
         *
         * These strings have balanced brackets:
         *  "[LaunchCode]", "Launch[Code]", "[]LaunchCode", "", "[]"
         *
         * While these do not:
         *   "[LaunchCode", "Launch]Code[", "[", "]["
         *
         * parameter str - to be validated
         * returns true if balanced, false otherwise
         *
        */

        string testString = "][";
        string testString2 = "[]";
        string testString4 = "[[]]";
        string testString5 = "[Launch [Code] ]";

        public static bool HasBalancedBrackets(String str)
        {
            int brackets = 0; // counting how many brakets are in the string

            foreach (char ch in str.ToCharArray())
            {
                //Console.WriteLine(ch);

                if (brackets >= 0)
                {
                    if (ch == '[')
                    {
                        brackets++;
                    }
                    else if (ch == ']')
                    {
                        brackets--;
                    }
                }
                else
                {
                    return false;
                }
            }

            Console.WriteLine(brackets);

            return brackets == 0;

        }
    }
}

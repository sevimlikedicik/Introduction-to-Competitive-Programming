using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_13
{
    class AmbiguousCoordinates
    {
        static void Main(string[] args)
        {
            string paragraph = "a,b,c  ?c?c?a";
            string[] banned = new string[1] { "a" };

            Console.WriteLine(FindAmbiguousCoordinates(paragraph));

            Console.ReadKey();
        }

        public static IList<string> FindAmbiguousCoordinates(string S)
        {
            string nums = S.Substring(1, S.Length - 2);
            List<string> allStrings = new List<string>();

            for (int i = 1; i < nums.Length; i++)
            {
                string s1 = nums.Substring(0, i);
                string s2 = nums.Substring(i, nums.Length - i);

                List<string> validS1 = FindValid(s1);
                List<string> validS2 = FindValid(s2);

                foreach (string s1Combination in validS1)
                {
                    foreach (string s2Combination in validS2)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("(");
                        sb.Append(s1Combination);
                        sb.Append(", ");
                        sb.Append(s2Combination);
                        sb.Append(")");
                        allStrings.Add(sb.ToString());
                    }
                }
            }

            return allStrings;
        }

        static List<string> FindValid(string s)
        {
            if (s.Length == 1)
                return new List<string>() { s };

            bool leftSide = s[0] == '0';
            bool rightSide = s[s.Length - 1] == '0';

            if (leftSide && rightSide)
                return new List<string>();
            else if (leftSide)
                return new List<string>() { s[0] + "." + s.Substring(1, s.Length - 1) };
            else if (rightSide)
                return new List<string>() { s };
            else
            {
                List<string> list = new List<string>() { s };
                for (int i = 1; i < s.Length; i++)
                    list.Add(s.Substring(0, i) + "." + s.Substring(i, s.Length - i));

                return list;
            }
        }
    }
}

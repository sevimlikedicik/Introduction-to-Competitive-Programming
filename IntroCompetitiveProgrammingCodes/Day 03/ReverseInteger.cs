using System;

namespace IntroCompetitiveProgrammingCodes.Day_03
{
    class ReverseInteger
    {
        static void Main(string[] args)
        {
            string phrase = Console.ReadLine();

            int x = Convert.ToInt32(phrase);

            Console.WriteLine(Reverse(x));

            Console.ReadKey();
        }

        public static int Reverse(int x)
        {
            string s = x.ToString();
            string reverseString = "";

            if (s[0] == '-')
            {
                reverseString += "-";
                for (int i = s.Length - 1; i > 0; i--)
                    reverseString += s[i];
            }
            else
            {
                for (int i = s.Length - 1; i >= 0; i--)
                    reverseString += s[i];
            }

            long reverseNumber = Convert.ToInt64(reverseString);

            if (reverseNumber > Int32.MaxValue || reverseNumber < Int32.MinValue)
                return 0;

            return (int)reverseNumber;
        }
    }
}

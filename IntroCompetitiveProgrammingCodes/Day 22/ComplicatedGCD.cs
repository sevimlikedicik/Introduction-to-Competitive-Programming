using System;

namespace IntroCompetitiveProgrammingCodes.Day_22
{
    class ComplicatedGCD
    {
        static void Main(string[] args)
        {
            string[] phrase = Console.ReadLine().Split(' ');

            if (phrase[0].Equals(phrase[1]))
                Console.WriteLine(phrase[0]);
            else
                Console.WriteLine("1");
        }
    }
}

using System;

namespace IntroCompetitiveProgrammingCodes.Day_01
{
    class Triangle1
    {
        static void Main(string[] args)
        {
            string phrase = Console.ReadLine();
            int size = Convert.ToInt32(phrase);

            for (int i = 1; i <= size; i++)
            {
                string line = "";

                for (int j = 1; j <= i; j++)
                {
                    line += "*";
                }
                Console.WriteLine(line);
            }

            Console.ReadKey();
        }
    }
}

using System;

namespace IntroCompetitiveProgrammingCodes.Day_01
{
    class Triangle2
    {
        static void Main(string[] args)
        {
            string phrase = Console.ReadLine();
            int rows = Convert.ToInt32(phrase);

            int lineSize = 2 * rows + 1;

            for (int i = 0; i < rows; i++)
            {
                char[] line = new char[lineSize];

                for (int j = rows - i; j <= rows + i; j++)
                    line[j] = '*';

                Console.WriteLine(line);
            }

            Console.ReadKey();

        }
    }
}

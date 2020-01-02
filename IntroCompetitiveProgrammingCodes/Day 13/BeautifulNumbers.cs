using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_13
{
    class BeautifulNumbers
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                Dictionary<int, int> indexes = new Dictionary<int, int>();

                int n = Convert.ToInt32(Console.ReadLine());
                string[] phrase = Console.ReadLine().Split(' ');

                for (int j = 0; j < n; j++)
                    indexes[Convert.ToInt32(phrase[j])] = j;

                int l = int.MaxValue, r = int.MinValue;
                StringBuilder result = new StringBuilder();

                for (int j = 1; j <= n; j++)
                {
                    if (indexes[j] > r)
                        r = indexes[j];

                    if (indexes[j] < l)
                        l = indexes[j];

                    if (r - l + 1 == j)
                        result.Append("1");
                    else
                        result.Append("0");
                }

                Console.WriteLine(result);
            }
        }
    }
}

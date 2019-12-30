using System;

namespace IntroCompetitiveProgrammingCodes.Day_21
{
    class NewYearGarland
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] results = new string[n];

            for (int i = 0; i < n; i++)
            {
                string[] phrase = Console.ReadLine().Split(' ');
                int a = Convert.ToInt32(phrase[0]);
                int b = Convert.ToInt32(phrase[1]);
                int c = Convert.ToInt32(phrase[2]);

                if (a > b)
                {
                    if (a > c)
                    {
                        if (a > b + c + 1)
                            results[i] = "NO";
                        else
                            results[i] = "YES";
                    }
                    else
                    {
                        if (c > b + a + 1)
                            results[i] = "NO";
                        else
                            results[i] = "YES";
                    }
                }
                else
                {
                    if (b > c)
                    {
                        if (b > a + c + 1)
                            results[i] = "NO";
                        else
                            results[i] = "YES";
                    }
                    else
                    {
                        if (c > b + a + 1)
                            results[i] = "NO";
                        else
                            results[i] = "YES";
                    }
                }
            }

            foreach (var result in results)
                Console.WriteLine(result);
        }
    }
}

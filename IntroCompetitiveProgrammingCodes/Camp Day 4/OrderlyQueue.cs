using System;
using System.Linq;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_4
{
    class OrderlyQueue
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Order("zzzzz", 1));

            Console.ReadKey();
        }

        public static string Order(string S, int K)
        {
            if (K == 1)
            {
                string min = string.Concat(Enumerable.Repeat("z", S.Length + 1));

                for (int i=0; i<S.Length; i++)
                {
                    string s = S.Substring(i, S.Length - i) + S.Substring(0, i);
                    if (string.Compare(s, min) == -1)
                        min = s;
                }

                return min;
            }
            else
            {
                var chars = S.ToCharArray();
                Array.Sort(chars);
                return new string(chars);
            }
        }
    }
}

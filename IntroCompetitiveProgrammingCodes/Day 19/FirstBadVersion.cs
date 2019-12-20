using System;

namespace IntroCompetitiveProgrammingCodes.Day_19
{
    class FirstBadVersion
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(FirstBad(n));

            Console.ReadKey();
        }

        public static int FirstBad(int n)
        {
            int l = 1;
            int r = n;
            int m = -1;

            while (l <= r)
            {
                m = (int)(((long)l + (long)r) / 2);

                if (IsBadVersion(m))
                {
                    if ((m == 1 || !IsBadVersion(m - 1)))
                        return m;
                    else
                        r = m - 1;
                }
                else
                {
                    if (IsBadVersion(m + 1))
                        return m + 1;
                    else
                        l = m + 1;
                }
            }

            return -1;
        }

        private static bool IsBadVersion(int m)
        {
            throw new NotImplementedException();
        }
    }
}

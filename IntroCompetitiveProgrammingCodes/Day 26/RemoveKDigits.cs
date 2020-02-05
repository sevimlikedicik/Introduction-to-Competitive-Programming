using System;
using System.Linq;

namespace IntroCompetitiveProgrammingCodes.Day_26
{
    class RemoveKDigits
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RemoveKdigits("100", 1));

            Console.ReadKey();
        }

        public static string RemoveKdigits(string num, int k)
        {
            if (k == num.Length)
                return "0";

            var list = num.ToCharArray().ToList();
            int index = 0;

            while (k > 0)
            {
                index = 0;

                while (index < list.Count - 1 && list[index] <= list[index + 1])
                    index++;

                list.RemoveAt(index);
                k--;
            }

            var ret = new string(list.ToArray());
            index = ret.Length - 1;

            for (int i = 0; i < ret.Length; i++)
            {
                if (ret[i] != '0')
                {
                    index = i;
                    break;
                }
            }

            return ret.Substring(index);
        }
    }
}

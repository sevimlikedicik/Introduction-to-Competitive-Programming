using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_1
{
    class RemoveAllAdjacentDuplicatesInStringII
    {
        static void Main(string[] args)
        {
            string a = "pbbcggttciiippooaais";

            Console.WriteLine(RemoveDuplicates(a, 2));

            Console.ReadKey();
        }

        public static string RemoveDuplicates(string s, int k)
        {
            var chars = s.ToCharArray();

            Purify(chars, k);
            StringBuilder str = new StringBuilder();

            for(int i=0; i<chars.Length; i++)
            {
                if (chars[i] != '*')
                    str.Append(chars[i]);
            }

            return str.ToString();
        }

        private static void Purify(char[] chars, int k)
        {
            char lastChar = ' ';
            int lastInd = 0;
            bool dupFound = false;

            for (int i = 0; i < chars.Length - 1; i++)
            {
                if (chars[i] != '*')
                {
                    lastChar = chars[i];
                    lastInd = i;
                }

                if (lastChar == chars[i + 1])
                {
                    int count = 2;
                    int index = i + 1;

                    while (index < chars.Length -1 && count < k)
                    {
                        if (lastChar == chars[index + 1])
                        {
                            index++;
                            count++;
                        }
                        else if (chars[index + 1] == '*')
                            index++;
                        else
                            break;
                    }

                    if(count == k)
                    {
                        dupFound = true;
                        for (int j = lastInd; j <= index; j++)
                            chars[j] = '*';
                    }

                    i = index;
                }
            }

            if (dupFound)
                Purify(chars, k);
        }
    }
}

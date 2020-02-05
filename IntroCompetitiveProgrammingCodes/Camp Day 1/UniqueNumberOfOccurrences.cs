using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_1
{
    class UniqueNumberOfOccurrences
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 2, 1, 1, 3 };

            Console.WriteLine(UniqueOccurrences(arr));

            Console.ReadKey();
        }

        public static bool UniqueOccurrences(int[] arr)
        {
            // 2001 is the range of numbers in array
            int[] count = new int[2001];

            for(int i=0; i<arr.Length; i++)
                count[arr[i] + 1000]++;

            // max occurence can be 1001
            bool[] occurence = new bool[1001];

            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] != 0 && occurence[count[i]])
                    return false;
                else
                    occurence[count[i]] = true;
            }

            return true;
        }
    }
}

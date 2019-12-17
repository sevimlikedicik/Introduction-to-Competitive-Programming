using System;

namespace IntroCompetitiveProgrammingCodes.Day_05
{
    class EfficientRandomization
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[n];

            for(int i=0; i<n; i++)
                arr[i] = i + 1;

            for (int pos = n-1; pos >= 1; pos--)
            {
                int rn = rnd.Next(0, pos - 1);
                int temp = arr[pos];
                arr[pos] = arr[rn];
                arr[rn] = temp;
            }

            foreach (int num in arr)
                Console.Write($"{num} ");

            Console.ReadKey();
        }
    }
}

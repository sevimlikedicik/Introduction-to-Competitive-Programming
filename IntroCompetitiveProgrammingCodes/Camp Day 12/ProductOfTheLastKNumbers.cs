using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_12
{
    class ProductOfTheLastKNumbers
    {
        static void Main(string[] args)
        {
            ProductOfNumbers pon = new ProductOfNumbers();
            pon.Add(3);
            pon.Add(2);

            Console.WriteLine(pon.GetProduct(2));

            Console.ReadKey();
        }
    }

    public class ProductOfNumbers
    {
        int[] arr;
        int lastIndex = 0;

        public ProductOfNumbers()
        {
            arr = new int[1000000];
        }

        public void Add(int num)
        {
            arr[lastIndex++] = num;
        }

        public int GetProduct(int k)
        {
            int mult = 1;
            for (int i = lastIndex - 1; i > lastIndex - 1 - k; i--)
                mult *= arr[i];

            return mult;
        }
    }
}

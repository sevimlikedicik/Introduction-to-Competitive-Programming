using System;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_05
{
    class UniqueBinarySearchTrees
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NumTrees(5));

            Console.ReadKey();
        }

        public static int NumTrees(int n)
        {
            int[] treeNums = new int[n + 1];
            treeNums[0] = 1;
            treeNums[1] = 1;

            return FindTreeNum(treeNums, n);
        }

        static int FindTreeNum(int[] treeNums, int n)
        {
            if (treeNums[n] != 0)
                return treeNums[n];

            int total = 0;
            for (int i = 0; i <= n - 1; i++)
                total += FindTreeNum(treeNums, i) * FindTreeNum(treeNums, n - 1 - i);

            treeNums[n] = total;

            return treeNums[n];
        }
    }
}

using System;

namespace IntroCompetitiveProgrammingCodes.Day_26
{
    class DeleteColumnsToMakeSorted
    {
        static void Main(string[] args)
        {
            string[] arr = new string[] { "a", "b" };

            Console.WriteLine(MinDeletionSize(arr));

            Console.ReadKey();
        }

        public static int MinDeletionSize(string[] A)
        {
            char[][] columns = new char[A[0].Length][];

            for (int i = 0; i < columns.Length; i++)
                columns[i] = new char[A.Length];

            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < columns.Length; j++)
                    columns[j][i] = A[i][j];
            }

            int deleteCount = 0;

            for (int i = 0; i < columns.Length; i++)
            {
                for (int j = 1; j < columns[i].Length; j++)
                {
                    if(columns[i][j] < columns[i][j - 1])
                    {
                        deleteCount++;
                        break;
                    }
                }
            }

            return deleteCount;
        }
    }
}

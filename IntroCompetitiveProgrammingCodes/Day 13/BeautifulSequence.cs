using System;

namespace IntroCompetitiveProgrammingCodes.Day_13
{
    class BeautifulSequence
    {

        static void Main(string[] args)
        {
            string[] phrase = ReadLineAsArray();
            int[] numbers = new int[phrase.Length];
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = Convert.ToInt32(phrase[i]);

            string answer1 = "";
            string answer2 = "";
            string answer3 = "";

            int len = Math.Min(numbers[0], numbers[1]);

            for (int i = 0; i < len; i++)
            {
                numbers[0]--;
                numbers[1]--;
                answer1 += "0 1 ";
            }

            if (numbers[0] != 0)
            {
                numbers[0]--;
                answer1 += "0 ";
            }

            len = Math.Min(numbers[2], numbers[3]);
            for (int i = 0; i < len; i++)
            {
                numbers[3]--;
                numbers[2]--;
                answer3 += "2 3 ";
            }

            if (numbers[3] != 0)
            {
                numbers[3]--;
                answer3 = "3 " + answer3;
            }

            len = Math.Min(numbers[1], numbers[2]);
            for (int i = 0; i < len; i++)
            {
                numbers[1]--;
                numbers[2]--;
                answer2 += "2 1 ";
            }

            if (numbers[1] != 0)
            {
                numbers[1]--;
                answer1 = "1 " + answer1;
            }

            if (numbers[2] != 0)
            {
                numbers[2]--;
                answer3 = answer3 + "2 ";
            }

            var answer = answer1 + answer2 + answer3;

            bool isPossible = true;

            if ((!(answer1.Length == 0 || answer2.Length == 0) && Math.Abs(answer1[answer1.Length - 2] - answer2[0]) != 1)
                || (!(answer2.Length == 0 || answer3.Length == 0) && Math.Abs(answer2[answer2.Length - 2] - answer3[0]) != 1)
                || (!(answer2.Length != 0 || answer1.Length == 0 || answer3.Length == 0) && Math.Abs(answer1[answer1.Length - 2] - answer3[0]) != 1))
                isPossible = false;

            for (int i = 0; i < 4; i++)
            {
                if (numbers[i] != 0)
                    isPossible = false;
            }

            if (isPossible)
            {
                Console.WriteLine("YES");
                Console.WriteLine(answer);
            }
            else
                Console.WriteLine("NO");
        }

        private static string ReadLine() => Console.ReadLine();

        private static string[] ReadLineAsArray() => Console.ReadLine().Split(' ');

        private static int ReadInt() => Convert.ToInt32(Console.ReadLine());

        private static long ReadLong() => Convert.ToInt64(Console.ReadLine());

        private static int ConvertInt(string s) => Convert.ToInt32(s);

        private static long ConvertLong(string s) => Convert.ToInt64(s);

        private static char ConvertChar(string s) => Convert.ToChar(s);
    }
}

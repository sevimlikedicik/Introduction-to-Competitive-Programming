using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Day_19
{
    class FindPositiveIntegerSolution
    {
        public class CustomFunction
        {
            int f(int a, int b)
            {
                return 0;
            }
        }

        public IList<IList<int>> FindSolution(CustomFunction customfunction, int z)
        {
            List<IList<int>> positiveSolutions = new List<IList<int>>();

            for (int i = 1; i <= z; i++)
            {
                for (int j = 1; j <= z; j++)
                {
                    if (customfunction.f(i, j) == z)
                    {
                        positiveSolutions.Add(new List<int>() { i, j });
                    }
                }
            }

            return positiveSolutions;
        }
    }
}

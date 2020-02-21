using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_13
{
    class RaceCar
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Racecar(1000));

            Console.ReadKey();
        }

        public static int Racecar(int target)
        {
            // Item1 is position, Item2 is speed.
            Tuple<int, int> startState = new Tuple<int, int>(0, 1);
            Dictionary<Tuple<int, int>, int> dp = new Dictionary<Tuple<int, int>, int>() { { startState, 0 } };
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(startState);

            while (true)
            {
                var currState = queue.Dequeue();

                if (currState.Item1 == target)
                    return dp[currState];

                // R move
                Tuple<int, int> rState = new Tuple<int, int>(currState.Item1, currState.Item2 > 0 ? -1 : 1);
                if (!dp.ContainsKey(rState))
                {
                    dp.Add(rState, dp[currState] + 1);
                    queue.Enqueue(rState);
                }
                // A move
                Tuple<int, int> aState = new Tuple<int, int>(currState.Item1 + currState.Item2, currState.Item2 * 2);
                if (!dp.ContainsKey(aState) && aState.Item1 < 10001 && aState.Item1 > -1)
                {
                    dp.Add(aState, dp[currState] + 1);
                    queue.Enqueue(aState);
                }
            }
        }
    }
}

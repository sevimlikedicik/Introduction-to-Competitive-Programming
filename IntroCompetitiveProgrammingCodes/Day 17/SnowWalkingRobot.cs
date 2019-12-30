using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Day_17
{
    class SnowWalkingRobot
    {
        public static void Main()
        {
            string phase = Console.ReadLine();
            int q = Convert.ToInt32(phase);

            List<string> newInstructions = new List<string>();

            for (int i = 0; i < q; i++)
            {

                phase = Console.ReadLine();
                Dictionary<char, int> directionCounts = new Dictionary<char, int>();

                directionCounts.Add('U', 0);
                directionCounts.Add('D', 0);
                directionCounts.Add('L', 0);
                directionCounts.Add('R', 0);

                foreach (char c in phase)
                {
                    directionCounts[c]++;
                }

                int minVertical = Math.Min(directionCounts['U'], directionCounts['D']);
                int minHorizontal = Math.Min(directionCounts['L'], directionCounts['R']);

                string newInstruction = "";

                if (minVertical != 0 && minHorizontal != 0)
                {
                    for (int j = 0; j < minVertical; j++)
                    {
                        newInstruction += "U";
                    }

                    for (int j = 0; j < minHorizontal; j++)
                    {
                        newInstruction += "L";
                    }

                    for (int j = 0; j < minVertical; j++)
                    {
                        newInstruction += "D";
                    }

                    for (int j = 0; j < minHorizontal; j++)
                    {
                        newInstruction += "R";
                    }
                }
                else
                {
                    if (minVertical == 0)
                    {
                        if (minHorizontal != 0)
                        {
                            newInstruction = "LR";
                        }
                    }

                    if (minHorizontal == 0)
                    {
                        if (minVertical != 0)
                        {
                            newInstruction = "UD";
                        }
                    }
                }


                newInstructions.Add(newInstruction);
            }

            foreach (var instruction in newInstructions)
            {
                Console.WriteLine(instruction.Length);
                Console.WriteLine(instruction);
            }
        }
    }
}

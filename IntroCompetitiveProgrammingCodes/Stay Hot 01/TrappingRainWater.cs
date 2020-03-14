using System;

namespace IntroCompetitiveProgrammingCodes.Stay_Hot_01
{
    class TrappingRainWater
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 15, 13, 5, 3, 15 };

            Console.WriteLine(Trap(arr));

            Console.ReadKey();
        }

        public static int Trap(int[] height)
        {
            int total = 0;
            int max = 0;
            int maxInd = 0;

            for (int i = 0; i < height.Length; i++) {
                if (height[i] > max) {
                    max = height[i];
                    maxInd = i;
                }
            }

            int left = 0;
            int right = height.Length - 1;
            int currMax = 0;

            while (left < maxInd) {
                if (height[left] > currMax) {
                    currMax = height[left++];
                }
                else {
                    total += currMax - height[left++];
                }
            }

            currMax = 0;

            while (right > maxInd) {
                if (height[right] > currMax) {
                    currMax = height[right--];
                }
                else {
                    total += currMax - height[right--];
                }
            }

            return total;
        }
    }
}

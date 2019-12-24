using System;

namespace IntroCompetitiveProgrammingCodes.Day_19.KthLargestElementInAStream
{
    class KthLargestElementInAStream
    {
        static void Main(string[] args)
        {
            int[] nums = { -10, 1, 3, 1, 4, 10, 3, 9, 4, 5, 1 };
            int k = 7;

            KthLargest kthLargest = new KthLargest(k, nums);

            Console.WriteLine(kthLargest.Add(3));   // returns 4
            Console.WriteLine(kthLargest.Add(2));   // returns 5
            Console.WriteLine(kthLargest.Add(3));  // returns 5
            Console.WriteLine(kthLargest.Add(9));   // returns 8
            Console.WriteLine(kthLargest.Add(4));   // returns 8

            //MinHeap mh = new MinHeap(nums);
            //mh.Print();
            //mh.Insert(31);
            //mh.Print();
            //mh.Remove();
            //mh.Print();

            Console.ReadKey();
        }
    }
}

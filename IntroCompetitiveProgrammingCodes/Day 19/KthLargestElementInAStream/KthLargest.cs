using System;

namespace IntroCompetitiveProgrammingCodes.Day_19.KthLargestElementInAStream
{
    public class MaxHeap
    {
        public int[] arr = new int[100000];
        private int size = 0;

        public MaxHeap(int[] nums)
        {
            foreach (int num in nums)
                Insert(num);
        }

        public void Insert(int num)
        {
            int walk = size;
            arr[size++] = num;

            while (walk != 0 && arr[walk] > arr[(walk - 1) / 2])
            {
                int temp = arr[walk];
                arr[walk] = arr[(walk - 1) / 2];
                arr[(walk - 1) / 2] = temp;
                walk = (walk - 1) / 2;
            }
        }

        public int Remove()
        {
            int output = arr[0];
            arr[0] = arr[size-- - 1];
            int walk = 0;

            while ((2 * walk + 1 < size && 2 * walk + 2 < size) && arr[walk] < Math.Max(arr[2 * walk + 1], arr[2 * walk + 2]))
            {
                int temp = arr[walk];
                if (arr[2 * walk + 1] > arr[2 * walk + 2])
                {
                    arr[walk] = arr[2 * walk + 1];
                    arr[2 * walk + 1] = temp;
                    walk = 2 * walk + 1;
                }
                else
                {
                    arr[walk] = arr[2 * walk + 2];
                    arr[2 * walk + 2] = temp;
                    walk = 2 * walk + 2;
                }
            }

            if (2 * walk + 2 >= size)
            {
                if (2 * walk + 1 < size)
                {
                    if (arr[walk] < arr[2 * walk + 1])
                    {
                        int temp = arr[walk];
                        arr[walk] = arr[2 * walk + 1];
                        arr[2 * walk + 1] = temp;
                    }
                }
            }

            return output;
        }

        public void Print()
        {
            for (int i = 0; i < size; i++)
                Console.Write($"{arr[i]} ");

            Console.WriteLine();
        }
    }

    public class MinHeap
    {
        public int[] arr = new int[100000];
        private int size = 0;

        public MinHeap(int[] nums)
        {
            foreach (int num in nums)
                Insert(num);
        }

        public void Insert(int num)
        {
            int walk = size;
            arr[size++] = num;

            while (walk != 0 && arr[walk] < arr[(walk - 1) / 2])
            {
                int temp = arr[walk];
                arr[walk] = arr[(walk - 1) / 2];
                arr[(walk - 1) / 2] = temp;
                walk = (walk - 1) / 2;
            }
        }

        public int Remove()
        {
            int output = arr[0];
            arr[0] = arr[size-- - 1];
            int walk = 0;

            while ((2 * walk + 1 < size && 2 * walk + 2 < size) && arr[walk] > Math.Min(arr[2 * walk + 1], arr[2 * walk + 2]))
            {
                int temp = arr[walk];
                if (arr[2 * walk + 1] < arr[2 * walk + 2])
                {
                    arr[walk] = arr[2 * walk + 1];
                    arr[2 * walk + 1] = temp;
                    walk = 2 * walk + 1;
                }
                else
                {
                    arr[walk] = arr[2 * walk + 2];
                    arr[2 * walk + 2] = temp;
                    walk = 2 * walk + 2;
                }
            }

            if (2 * walk + 2 >= size)
            {
                if (2 * walk + 1 < size)
                {
                    if(arr[walk] > arr[2 * walk + 1])
                    {
                        int temp = arr[walk];
                        arr[walk] = arr[2 * walk + 1];
                        arr[2 * walk + 1] = temp;
                    }
                }
            }

            return output;
        }

        public void Print()
        {
            for (int i = 0; i < size; i++)
                Console.Write($"{arr[i]} ");

            Console.WriteLine();
        }
    }

    public class KthLargest
    {
        int[] arr = new int[100000];
        int k;
        int end = 0;
        private MinHeap minHeap;

        public KthLargest(int k, int[] nums)
        {
            this.k = k;

            Array.Sort(nums);
            Array.Reverse(nums);

            if (nums.Length >= k)
            {
                int[] firstKElements = new int[k];
                Array.Copy(nums, firstKElements, k);

                minHeap = new MinHeap(firstKElements);
            }
            // nums length can be at least k - 1, mentioned in the question.
            else
            {
                int[] newNums = new int[nums.Length + 1];
                Array.Copy(nums, newNums, nums.Length);
                newNums[newNums.Length - 1] = int.MinValue;

                minHeap = new MinHeap(newNums);
            }
        }

        public int Add(int val)
        {
            minHeap.Insert(val);
            minHeap.Remove();

            return minHeap.arr[0];
        }
    }

    /**
     * Your KthLargest object will be instantiated and called as such:
     * KthLargest obj = new KthLargest(k, nums);
     * int param_1 = obj.Add(val);
     */
}

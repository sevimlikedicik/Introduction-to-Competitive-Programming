using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_24
{
    public class RandomizedSet
    {
        List<int> list = new List<int>();
        Dictionary<int, int> listIndexes = new Dictionary<int, int>();
        Random rnd = new Random(DateTime.Now.GetHashCode());

        /** Initialize your data structure here. */
        public RandomizedSet()
        {

        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            if (listIndexes.ContainsKey(val))
                return false;

            listIndexes.Add(val, list.Count);
            list.Add(val);

            return true;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if (!listIndexes.ContainsKey(val))
                return false;

            int index = listIndexes[val];

            listIndexes.Remove(val);
            Swap(list, index, list.Count - 1);

            return true;
        }

        private void Swap(List<int> list, int index1, int index2)
        {
            if(index1 == index2)
            {
                list.RemoveAt(list.Count - 1);
            }
            else
            {
                int temp = list[index2];
                list[index2] = list[index1];
                list[index1] = temp;
                listIndexes[temp] = index1;
                list.RemoveAt(list.Count - 1);
            }
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            return list[rnd.Next(list.Count)];
        }
    }

    class InsertDeleteGetRandomO1
    {
        static void Main(string[] args)
        {
            RandomizedSet rs = new RandomizedSet();

            rs.Remove(0);
            rs.Remove(0);
            rs.Insert(0);
            int rn = rs.GetRandom();
            rs.Remove(0);
            bool a = rs.Insert(0);
        }
    }
}

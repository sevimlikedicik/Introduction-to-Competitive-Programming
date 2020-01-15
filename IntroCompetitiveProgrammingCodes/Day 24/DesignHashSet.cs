namespace IntroCompetitiveProgrammingCodes.Day_24
{
    class DesignHashSet
    {
        public class MyHashSet
        {
            bool[] keys = new bool[1000001];

            /** Initialize your data structure here. */
            public MyHashSet()
            {

            }

            public void Add(int key)
            {
                keys[key] = true;
            }

            public void Remove(int key)
            {
                keys[key] = false;
            }

            /** Returns true if this set contains the specified element */
            public bool Contains(int key)
            {
                return keys[key];
            }
        }
    }
}

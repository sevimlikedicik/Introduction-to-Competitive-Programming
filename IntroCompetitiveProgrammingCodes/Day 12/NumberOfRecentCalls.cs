namespace IntroCompetitiveProgrammingCodes.Day_12
{
    class NumberOfRecentCalls
    {
        int[] pings = new int[20000];
        int size = 0;

        public NumberOfRecentCalls()
        {

        }

        public int Ping(int t)
        {
            pings[size] = t;
            int backwardCounter = size;

            while (backwardCounter > -1 && pings[backwardCounter] + 3000 >= pings[size])
                backwardCounter--;

            size++;

            return size - backwardCounter - 1;
        }
    }
}

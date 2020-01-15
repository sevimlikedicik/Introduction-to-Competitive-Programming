using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_24
{
    class TimeBasedKeyValueStore
    {
        static void Main(string[] args)
        {
            TimeMap tm = new TimeMap();

            tm.Set("love", "high", 10);
            tm.Set("love", "low", 20);

            Console.WriteLine(tm.Get("love", 5));
            Console.WriteLine(tm.Get("love", 10));
            Console.WriteLine(tm.Get("love", 15));
            Console.WriteLine(tm.Get("love", 20));
            Console.WriteLine(tm.Get("love", 25));

            Console.ReadKey();
        }

        public class TimeMap
        {
            public class TimeStamp
            {
                public int[] Timestamps;
                public int LastIndex = 0;
                public Dictionary<int, string> TimeValuePairs;

                public TimeStamp(int timestamp, string val)
                {
                    Timestamps = new int[120000];
                    Timestamps[LastIndex++] = timestamp;
                    TimeValuePairs = new Dictionary<int, string>() { { timestamp, val } };
                }

                public void Add(int timestamp, string val)
                {
                    Timestamps[LastIndex++] = timestamp;

                    TimeValuePairs.Add(timestamp, val);
                }

                public string Get(int timestamp)
                {
                    if (timestamp >= Timestamps[LastIndex - 1])
                        return TimeValuePairs[Timestamps[LastIndex - 1]];

                    if (timestamp < Timestamps[0])
                        return "";

                    int answer = BinarySearch(Timestamps, timestamp);

                    return TimeValuePairs[Timestamps[answer]];
                }

                private int BinarySearch(int[] Timestamps, int timestamp)
                {
                    int l = 0;
                    int r = LastIndex - 1;
                    int mid = (l + r) / 2;

                    while (l < r)
                    {
                        if (Timestamps[mid] < timestamp)
                            l = mid + 1;
                        else if (Timestamps[mid] == timestamp)
                            return mid;
                        else
                            r = mid - 1;

                        mid = (l + r) / 2;
                    }

                    return (Timestamps[mid] < timestamp) ? mid : mid - 1;
                }
            }

            Dictionary<string, TimeStamp> timeValue = new Dictionary<string, TimeStamp>();

            /** Initialize your data structure here. */
            public TimeMap()
            {

            }

            public void Set(string key, string val, int timestamp)
            {
                if (timeValue.ContainsKey(key))
                    timeValue[key].Add(timestamp, val);
                else
                    timeValue.Add(key, new TimeStamp(timestamp, val));
            }

            public string Get(string key, int timestamp)
            {
                if (!timeValue.ContainsKey(key))
                    return "";

                return timeValue[key].Get(timestamp);
            }
        }
    }
}

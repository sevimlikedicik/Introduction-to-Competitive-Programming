using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroCompetitiveProgrammingCodes.Day_19
{
    class TopKFrequentWords
    {
        static void Main(string[] args)
        {
            string[] arr = { "the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is" };
            int k = 4;

            var list = TopKFrequent(arr, k);

            foreach (string num in list)
                Console.Write($"{num} ");

            Console.ReadKey();
        }

        public static IList<string> TopKFrequent(string[] words, int k)
        {
            Array.Sort(words);

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (!wordCounts.ContainsKey(word))
                    wordCounts.Add(word, 1);
                else
                    wordCounts[word]++;
            }

            var sortedDict = from entry in wordCounts orderby entry.Value descending select entry;

            List<string> mostFrequentWords = new List<string>();
            int walk = 0;

            foreach (var kvp in sortedDict)
            {
                if (walk == k)
                    break;

                mostFrequentWords.Add(kvp.Key);
                walk++;
            }

            return mostFrequentWords;
        }
    }
}

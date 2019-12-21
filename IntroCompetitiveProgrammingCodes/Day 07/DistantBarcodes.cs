using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroCompetitiveProgrammingCodes.Day_07
{
    class DistantBarcodes
    {
        static void Main(string[] args)
        {
            int[] arr = new int[3] { 1, 1, 2 };

            var result = RearrangeBarcodes(arr);

            foreach (int num in result)
                Console.Write($"{num} ");

            Console.ReadKey();
        }

        public static int[] RearrangeBarcodes(int[] barcodes)
        {
            Dictionary<int, int> barcodeCounts = new Dictionary<int, int>();

            foreach (int barcode in barcodes)
            {
                if (barcodeCounts.ContainsKey(barcode))
                    barcodeCounts[barcode]++;
                else
                    barcodeCounts.Add(barcode, 1);
            }

            var sortedDict = from entry in barcodeCounts orderby entry.Value descending select entry;

            int[] organizedBarcodes = new int[barcodes.Length];
            int walk_organizedBarcodes = 0;

            foreach (var kvp in sortedDict)
            {
                int barcode = kvp.Key;

                for (int i = 0; i < kvp.Value; i++)
                {
                    if (walk_organizedBarcodes >= barcodes.Length)
                        walk_organizedBarcodes = 1;

                    organizedBarcodes[walk_organizedBarcodes] = barcode;
                    walk_organizedBarcodes += 2;
                }
            }

            return organizedBarcodes;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    class CheapestFlightsWithinKStops
    {
        internal class Flight
        {
            public int City;
            public int Price;

            public Flight(int city, int price)
            {
                City = city;
                Price = price;
            }
        }

        internal class CityDistance
        {
            public int City;
            public int TotalDistance;

            public CityDistance(int city, int distance)
            {
                City = city;
                TotalDistance = distance;
            }
        }

        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 0, 1, 1 }, new int[] { 1, 2, 1 }, new int[] { 0, 2, 5 }, new int[] { 2, 3, 1 } };
            int[][] mtr2 = new int[][] { new int[] { 0, 1, 1 }, new int[] { 1, 2, 1 }, new int[] { 0, 2, 5 } };
            int[][] mtr3 = new int[][] { new int[] { 0, 1, 1 }, new int[] { 0, 2, 3 }, new int[] { 0, 3, 5 }, new int[] { 1, 2, 1 }, new int[] { 2, 3, 1 } };

            Console.WriteLine(FindCheapestPrice(4, mtr, 0, 3, 2));
            Console.WriteLine(FindCheapestPrice(3, mtr2, 0, 2, 1));
            Console.WriteLine(FindCheapestPrice(4, mtr3, 0, 3, 1));

            Console.ReadKey();
        }

        public static int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
        {
            Dictionary<int, List<Flight>> allFlights = new Dictionary<int, List<Flight>>();
            Dictionary<int, int> lowestPrice = new Dictionary<int, int>();
            bool[] visited = new bool[n];

            for (int i = 0; i < flights.Length; i++)
            {
                int sourceCity = flights[i][0];
                int destCity = flights[i][1];
                int price = flights[i][2];

                if (allFlights.ContainsKey(sourceCity))
                    allFlights[sourceCity].Add(new Flight(destCity, price));
                else
                    allFlights.Add(sourceCity, new List<Flight>() { new Flight(destCity, price) });
            }

            for (int i = 0; i < n; i++)
                lowestPrice.Add(i, int.MaxValue);

            Queue<CityDistance> queue = new Queue<CityDistance>();
            Queue<int> bfsDepth = new Queue<int>();
            lowestPrice[src] = 0;
            queue.Enqueue(new CityDistance(src, 0));
            bfsDepth.Enqueue(0);
            int depth = -1;
            CityDistance city;
            
            while (queue.Count != 0 )
            {
                city = queue.Dequeue();
                depth = bfsDepth.Dequeue();
                
                if (allFlights.ContainsKey(city.City))
                {
                    foreach (var flight in allFlights[city.City])
                    {
                        if (depth <= K)
                        {
                            int destCity = flight.City;
                            int price = city.TotalDistance + flight.Price;

                            if (price < lowestPrice[destCity])
                            {
                                lowestPrice[destCity] = price;
                                queue.Enqueue(new CityDistance(destCity, price));
                                bfsDepth.Enqueue(depth + 1);
                            }
                        }
                    }
                }
            }

            if (lowestPrice[dst] == int.MaxValue)
                return -1;

            return lowestPrice[dst];
        }
    }
}

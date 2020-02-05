using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_1
{
    class MinimumMovesToReachTargetWithRotations
    {
        internal class SnakeCoordinate
        {
            public int I;
            public int J;
            public bool IsHorizontal;

            public SnakeCoordinate(int i, int j, bool isHorizontal)
            {
                I = i;
                J = j;
                IsHorizontal = isHorizontal;
            }
        }

        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 1, 1 } };

            Console.WriteLine(MinimumMoves(mtr));

            Console.ReadKey();
        }

        public static int MinimumMoves(int[][] grid)
        {
            // 0 is unvisited, 1 is visited horizontally, 2 vertically, 3 both.
            int[,] visited = new int[grid.Length, grid[0].Length];
            int[,] shortestPathHorizontal = new int[grid.Length, grid[0].Length];
            int[,] shortestPathVertical = new int[grid.Length, grid[0].Length];

            for (int i = 0; i < shortestPathHorizontal.GetLength(0); i++)
            {
                for (int j = 0; j < shortestPathHorizontal.GetLength(1); j++)
                {
                    shortestPathHorizontal[i, j] = int.MaxValue;
                    shortestPathVertical[i, j] = int.MaxValue;
                }
            }

            SnakeCoordinate start = new SnakeCoordinate(0, 1, true);
            Queue<SnakeCoordinate> queue = new Queue<SnakeCoordinate>();
            queue.Enqueue(start);
            visited[0, 1] = 1;
            shortestPathHorizontal[0, 1] = 0;

            while (queue.Count != 0)
            {
                var coord = queue.Dequeue();

                if (coord.IsHorizontal)
                    MoveHorizontal(grid, queue, coord, shortestPathHorizontal, shortestPathVertical, visited);
                else
                    MoveVertical(grid, queue, coord, shortestPathHorizontal, shortestPathVertical, visited);
            }

            if (shortestPathHorizontal[grid.Length - 1, grid.Length - 1] == int.MaxValue)
                return -1;

            return shortestPathHorizontal[grid.Length - 1, grid.Length - 1];
        }

        private static void MoveHorizontal(int[][] grid, Queue<SnakeCoordinate> queue, SnakeCoordinate coord, int[,] shortestPathHorizontal, int[,] shortestPathVertical, int[,] visited)
        {
            // Move right
            int nxHead = coord.I;
            int nyHead = coord.J + 1;
            int nxBody = coord.I;
            int nyBody = coord.J;

            if (nyHead >= 0 && nyHead < grid.Length && (visited[nxHead, nyHead] == 0 || visited[nxHead, nyHead] == 2) && grid[nxHead][nyHead] == 0)
            {
                SnakeCoordinate coordinate = new SnakeCoordinate(nxHead, nyHead, true);
                queue.Enqueue(coordinate);
                if (shortestPathHorizontal[coord.I, coord.J] + 1 < shortestPathHorizontal[nxHead, nyHead])
                    shortestPathHorizontal[nxHead, nyHead] = shortestPathHorizontal[coord.I, coord.J] + 1;

                if (visited[nxHead, nyHead] == 0)
                    visited[nxHead, nyHead] = 1;
                else
                    visited[nxHead, nyHead] = 3;
            }

            // Move down
            nxHead = coord.I + 1;
            nyHead = coord.J;
            nxBody = coord.I + 1;
            nyBody = coord.J - 1;

            if (nxHead >= 0 && nxHead < grid.Length && (visited[nxHead, nyHead] == 0 || visited[nxHead, nyHead] == 2) && grid[nxHead][nyHead] == 0 && grid[nxBody][nyBody] == 0)
            {
                SnakeCoordinate coordinate = new SnakeCoordinate(nxHead, nyHead, true);
                queue.Enqueue(coordinate);
                if (shortestPathHorizontal[coord.I, coord.J] + 1 < shortestPathHorizontal[nxHead, nyHead])
                    shortestPathHorizontal[nxHead, nyHead] = shortestPathHorizontal[coord.I, coord.J] + 1;

                if (visited[nxHead, nyHead] == 0)
                    visited[nxHead, nyHead] = 1;
                else
                    visited[nxHead, nyHead] = 3;
            }

            // Rotate clockwise
            nxHead = coord.I + 1;
            nyHead = coord.J - 1;
            nxBody = coord.I;
            nyBody = coord.J - 1;

            if (nxHead >= 0 && nxHead < grid.Length && nyHead + 1 >= 0 && nyHead + 1 < grid.Length && (visited[nxHead, nyHead] == 0 || visited[nxHead, nyHead] == 1) && grid[nxHead][nyHead] == 0 && grid[nxHead][nyHead + 1] == 0)
            {
                SnakeCoordinate coordinate = new SnakeCoordinate(nxHead, nyHead, false);
                queue.Enqueue(coordinate);
                if (shortestPathHorizontal[coord.I, coord.J] + 1 < shortestPathVertical[nxHead, nyHead])
                    shortestPathVertical[nxHead, nyHead] = shortestPathHorizontal[coord.I, coord.J] + 1;

                if (visited[nxHead, nyHead] == 0)
                    visited[nxHead, nyHead] = 2;
                else
                    visited[nxHead, nyHead] = 3;
            }
        }

        private static void MoveVertical(int[][] grid, Queue<SnakeCoordinate> queue, SnakeCoordinate coord, int[,] shortestPathHorizontal, int[,] shortestPathVertical, int[,] visited)
        {
            // Move right
            int nxHead = coord.I;
            int nyHead = coord.J + 1;
            int nxBody = coord.I - 1;
            int nyBody = coord.J + 1;

            if (nyHead >= 0 && nyHead < grid.Length && (visited[nxHead, nyHead] == 0 || visited[nxHead, nyHead] == 1) && grid[nxHead][nyHead] == 0 && grid[nxBody][nyBody] == 0)
            {
                SnakeCoordinate coordinate = new SnakeCoordinate(nxHead, nyHead, false);
                queue.Enqueue(coordinate);
                if (shortestPathVertical[coord.I, coord.J] + 1 < shortestPathVertical[nxHead, nyHead])
                    shortestPathVertical[nxHead, nyHead] = shortestPathVertical[coord.I, coord.J] + 1;

                if (visited[nxHead, nyHead] == 0)
                    visited[nxHead, nyHead] = 2;
                else
                    visited[nxHead, nyHead] = 3;
            }

            // Move down
            nxHead = coord.I + 1;
            nyHead = coord.J;
            nxBody = coord.I;
            nyBody = coord.J;

            if (nxHead >= 0 && nxHead < grid.Length && (visited[nxHead, nyHead] == 0 || visited[nxHead, nyHead] == 1) && grid[nxHead][nyHead] == 0)
            {
                SnakeCoordinate coordinate = new SnakeCoordinate(nxHead, nyHead, false);
                queue.Enqueue(coordinate);
                if (shortestPathVertical[coord.I, coord.J] + 1 < shortestPathVertical[nxHead, nyHead])
                    shortestPathVertical[nxHead, nyHead] = shortestPathVertical[coord.I, coord.J] + 1;

                if (visited[nxHead, nyHead] == 0)
                    visited[nxHead, nyHead] = 2;
                else
                    visited[nxHead, nyHead] = 3;
            }

            // Rotate counterclockwise
            nxHead = coord.I - 1;
            nyHead = coord.J + 1;
            nxBody = coord.I - 1;
            nyBody = coord.J;

            if (nxHead + 1 >= 0 && nxHead + 1 < grid.Length && nyHead >= 0 && nyHead < grid.Length && (visited[nxHead, nyHead] == 0 || visited[nxHead, nyHead] == 1) && grid[nxHead][nyHead] == 0 && grid[nxHead + 1][nyHead] == 0)
            {
                SnakeCoordinate coordinate = new SnakeCoordinate(nxHead, nyHead, true);
                queue.Enqueue(coordinate);
                if (shortestPathVertical[coord.I, coord.J] + 1 < shortestPathHorizontal[nxHead, nyHead])
                    shortestPathHorizontal[nxHead, nyHead] = shortestPathVertical[coord.I, coord.J] + 1;

                if (visited[nxHead, nyHead] == 0)
                    visited[nxHead, nyHead] = 2;
                else
                    visited[nxHead, nyHead] = 3;
            }
        }
    }
}

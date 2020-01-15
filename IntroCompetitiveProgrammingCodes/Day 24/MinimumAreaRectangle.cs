using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Day_24
{
    class MinimumAreaRectangle
    {
        static void Main(string[] args)
        {
            Console.WriteLine(-11 % 3);

            Console.ReadKey();
        }

        public static int MinAreaRect(int[][] points)
        {
            Sort(points);

            Dictionary<int, List<int>> coordinates = new Dictionary<int, List<int>>();

            int x1, y1, x2, y2;
            Line line;
            Dictionary<Line, List<int>> lines = new Dictionary<Line, List<int>>();

            for (int i = 0; i < points.Length; i++)
            {
                x1 = points[i][0];
                y1 = points[i][1];

                for (int j = i + 1; j < points.Length; j++)
                {
                    x2 = points[j][0];
                    y2 = points[j][1];

                    if (x1 == x2)
                    {
                        line = new Line(y1, y2);
                        if (lines.ContainsKey(line))
                            lines[line].Add(x1);
                        else
                            lines.Add(new Line(line.Y1, line.Y2), new List<int>() { x1 });
                    }
                }
            }

            int minRectangleArea = int.MaxValue;

            foreach (var kvp in lines)
            {
                int lineSize = kvp.Key.LineSize;
                var xArr = kvp.Value.ToArray();

                for (int i = 0; i < xArr.Length - 1; i++)
                {
                    int rectangleArea = lineSize * (xArr[i + 1] - xArr[i]);
                    if (rectangleArea < minRectangleArea)
                        minRectangleArea = rectangleArea;
                }
            }

            return minRectangleArea == int.MaxValue ? 0 : minRectangleArea;
        }

        private static void Sort(int[][] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                int index = i - 1;
                int[] point = new int[2] { points[i][0], points[i][1] };

                while (index >= 0 && IsSmaller(point, points[index]))
                {
                    points[index + 1][0] = points[index][0];
                    points[index + 1][1] = points[index][1];
                    points[index][0] = point[0];
                    points[index--][1] = point[1];
                }
            }
        }

        private static bool IsSmaller(int[] point1, int[] point2)
        {
            if (point1[0] < point2[0])
                return true;

            if (point1[0] == point2[0] && point1[1] < point2[1])
                return true;

            return false;
        }

        private static void MakeLines(Dictionary<Line, List<int>> lines, KeyValuePair<int, List<int>> kvp)
        {
            // need at least 2 points to make a line
            if (kvp.Value.Count < 2)
                return;

            var arr = kvp.Value.ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    Line line = new Line(arr[i], arr[j]);
                    AddLine(lines, line, kvp.Key);
                }
            }
        }

        private static void AddLine(Dictionary<Line, List<int>> lines, Line line, int key)
        {
            foreach (var kvp in lines)
            {
                if ((kvp.Key.Y1 == line.Y1 && kvp.Key.Y2 == line.Y2) || (kvp.Key.Y1 == line.Y2 && kvp.Key.Y2 == line.Y1))
                {
                    kvp.Value.Add(key);
                    return;
                }
            }

            lines.Add(new Line(line.Y1, line.Y2), new List<int>() { key });
        }
    }

    internal class Line
    {
        public int Y1;
        public int Y2;

        public Line(int y1, int y2)
        {
            Y1 = y1;
            Y2 = y2;
        }

        public int LineSize => Math.Abs(Y2 - Y1);

        public override int GetHashCode()
        {
            return Y1.GetHashCode() + Y2.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (Line)obj;
            return (Y1 == other.Y1 && Y2 == other.Y2) || (Y2 == other.Y1 && Y1 == other.Y2);
        }
    }
}

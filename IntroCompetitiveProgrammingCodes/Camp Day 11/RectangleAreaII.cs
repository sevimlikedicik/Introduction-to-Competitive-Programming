using System;
using System.Collections.Generic;

namespace IntroCompetitiveProgrammingCodes.Camp_Day_11
{
    class RectangleAreaII
    {
        static void Main(string[] args)
        {
            int[][] mtr = new int[][] { new int[] { 0, 0, 3, 3 }, new int[] { 2, 0, 5, 3 }, new int[] { 1, 1, 4, 4 } };

            Console.WriteLine(RectangleArea(mtr));

            Console.ReadKey();
        }

        internal class RectCoordinates
        {
            public int X1;
            public int X2;
            public int Y1;
            public int Y2;

            public RectCoordinates(int x1, int x2, int y1, int y2)
            {
                X1 = x1;
                X2 = x2;
                Y1 = y1;
                Y2 = y2;
            }

            public override int GetHashCode()
            {
                return X1.GetHashCode() + X2.GetHashCode() + Y1.GetHashCode() + Y2.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                    return false;

                var other = (RectCoordinates)obj;
                return (X1 == other.X1 && X2 == other.X2) && (Y1 == other.Y1 && Y2 == other.Y2);
            }
        }

        public static int RectangleArea(int[][] rectangles)
        {
            HashSet<int> reducedCoordinatesHsX = new HashSet<int>();
            HashSet<int> reducedCoordinatesHsY = new HashSet<int>();
            long totalArea = 0;

            for (int i = 0; i < rectangles.Length; i++)
            {
                reducedCoordinatesHsX.Add(rectangles[i][0]);
                reducedCoordinatesHsX.Add(rectangles[i][2]);
                reducedCoordinatesHsY.Add(rectangles[i][1]);
                reducedCoordinatesHsY.Add(rectangles[i][3]);
            }

            int[] reducedCoordinatesX = new int[reducedCoordinatesHsX.Count];
            int[] reducedCoordinatesY = new int[reducedCoordinatesHsY.Count];
            int count = 0;

            foreach (int xCoordinate in reducedCoordinatesHsX)
                reducedCoordinatesX[count++] = xCoordinate;

            count = 0;
            foreach (int yCoordinate in reducedCoordinatesHsY)
                reducedCoordinatesY[count++] = yCoordinate;

            Array.Sort(reducedCoordinatesX);
            Array.Sort(reducedCoordinatesY);

            HashSet<RectCoordinates> exists = new HashSet<RectCoordinates>();

            for (int i = 0; i < rectangles.Length; i++)
                Fill(rectangles[i], exists, reducedCoordinatesX, reducedCoordinatesY);

            for (int i = 0; i < reducedCoordinatesX.Length - 1; i++)
            {
                for (int j = 0; j < reducedCoordinatesY.Length - 1; j++)
                {
                    totalArea = exists.Contains(new RectCoordinates(reducedCoordinatesX[i], reducedCoordinatesX[i + 1], reducedCoordinatesY[j], reducedCoordinatesY[j + 1])) ? ((totalArea + ((((reducedCoordinatesX[i + 1] - reducedCoordinatesX[i]) % ((long)Math.Pow(10, 9) + 7)) * ((reducedCoordinatesY[j + 1] - reducedCoordinatesY[j]) % ((long)Math.Pow(10, 9) + 7))) % ((long)Math.Pow(10, 9) + 7))) % ((long)Math.Pow(10, 9) + 7)) : totalArea;
                }
            }

            return (int)(totalArea);
        }

        static void Fill(int[] rec, HashSet<RectCoordinates> exists, int[] reducedCoordinatesX, int[] reducedCoordinatesY)
        {
            int xStartIndex = 0;
            while (reducedCoordinatesX[xStartIndex] != rec[0])
                xStartIndex++;
            int xEndIndex = xStartIndex;
            while (reducedCoordinatesX[xEndIndex] != rec[2])
                xEndIndex++;
            int yStartIndex = 0;
            while (reducedCoordinatesY[yStartIndex] != rec[1])
                yStartIndex++;
            int yEndIndex = yStartIndex;
            while (reducedCoordinatesY[yEndIndex] != rec[3])
                yEndIndex++;

            int prevX = xStartIndex;
            int prevY = yStartIndex;
            for (int i = xStartIndex; i <= xEndIndex; i++)
            {
                for (int j = yStartIndex; j <= yEndIndex; j++)
                {
                    exists.Add(new RectCoordinates(reducedCoordinatesX[prevX], reducedCoordinatesX[i], reducedCoordinatesY[prevY], reducedCoordinatesY[j]));
                    prevY = j;
                }
                prevX = i;
            }
        }
    }
}

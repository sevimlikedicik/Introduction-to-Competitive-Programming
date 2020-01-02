using System;

namespace IntroCompetitiveProgrammingCodes.Day_22
{
    class ComplexNumberMultiplication
    {
        static void Main(string[] args)
        {
            string a = "1+1i";
            string b = "1+1i";

            Console.WriteLine(ComplexNumberMultiply(a, b));

            Console.ReadKey();
        }

        public static string ComplexNumberMultiply(string a, string b)
        {
            var aParts = a.Split('+');
            var bParts = b.Split('+');

            int aReal = Convert.ToInt32(aParts[0]);
            int aComplex = Convert.ToInt32(aParts[1].Substring(0, aParts[1].Length - 1));
            int bReal = Convert.ToInt32(bParts[0]);
            int bComplex = Convert.ToInt32(bParts[1].Substring(0, bParts[1].Length - 1));

            int cReal = aReal * bReal - aComplex * bComplex;
            int cComplex = aReal * bComplex + aComplex * bReal;

            return cReal + "+" + cComplex + "i";
        }
    }
}

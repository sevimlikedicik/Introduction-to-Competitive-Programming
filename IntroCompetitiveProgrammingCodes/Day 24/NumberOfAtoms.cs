using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroCompetitiveProgrammingCodes.Day_24
{
    class NumberOfAtoms
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountOfAtoms("(NB3)33"));

            Console.ReadKey();
        }

        public static string CountOfAtoms(string formula)
        {
            var chars = formula.ToCharArray();

            CountElements(AllElements, chars, 0);

            string result = "";
            var sortedDict = AllElements.OrderBy(kvp => kvp.Key);

            foreach (var element in sortedDict)
            {
                result += element.Key;
                if (element.Value != 1)
                    result += element.Value;
            }

            return result;
        }

        static Dictionary<string, int> AllElements = new Dictionary<string, int>();

        private static int CountElements(Dictionary<string, int> upperLevelElements, char[] chars, int index)
        {
            Dictionary<string, int> elements = new Dictionary<string, int>();

            char c = chars[index++];

            while (index <= chars.Length && c != ')')
            {
                if (index == chars.Length && (c == '(' || Char.IsNumber(c)))
                    break;

                string element = "";

                if (Char.IsUpper(c))
                {
                    element += c;

                    if (index == chars.Length)
                    {
                        if (elements.ContainsKey(element))
                            elements[element] += 1;
                        else
                            elements.Add(element, 1);
                        break;
                    }
                    else
                        c = chars[index++];

                    if (Char.IsLower(c))
                    {
                        element += c;
                        c = chars[index++];
                    }

                    if (Char.IsNumber(c))
                    {
                        string num = "" + c;

                        while (index < chars.Length && Char.IsNumber(c = chars[index++]))
                            num += c;

                        if (elements.ContainsKey(element))
                            elements[element] += int.Parse(num);
                        else
                            elements.Add(element, int.Parse(num));
                    }
                    else
                    {
                        if (elements.ContainsKey(element))
                            elements[element] += 1;
                        else
                            elements.Add(element, 1);
                    }
                }
                else if (c == '(')
                {
                    index = CountElements(elements, chars, index);
                    if (index < chars.Length)
                        c = chars[index++];
                }
            }

            return AddElements(elements, upperLevelElements, chars, index);
        }

        private static int AddElements(Dictionary<string, int> elements, Dictionary<string, int> upperLevelElements, char[] chars, int index)
        {
            int startingIndex = index;
            char c;
            string num = "";

            while (index < chars.Length && Char.IsNumber(c = chars[index++]))
                num += "" + c;

            int multiplier;

            if (num.Length == 0)
                multiplier = 1;
            else
                multiplier = int.Parse(num);

            foreach (var element in elements)
            {
                string elementName = element.Key;
                int elementCount = element.Value * multiplier;

                if (upperLevelElements.ContainsKey(elementName))
                    upperLevelElements[elementName] += elementCount;
                else
                    upperLevelElements.Add(elementName, elementCount);
            }

            return startingIndex + num.Length;
        }
    }
}

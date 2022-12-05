using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day03
{
    class Day03
    {
        static char FindPart1(string s1, string s2)
        {
            foreach (var c1 in s1)
            {
                foreach (var c2 in s2)
                {
                    if (c1 == c2)
                    {
                        return c1;
                    }
                }
            }
            return '\0';
        }

        static char FindPart2(string s1, string s2, string s3)
        {
            string[] s = { s1, s2, s3 };
            s.OrderByDescending(x => x.Length);
            foreach (var c1 in s[0])
            {
                foreach (var c2 in s[1])
                {
                    if (c1 == c2)
                    {
                        foreach (var c3 in s[2])
                        {
                            if (c1 == c3) return c1;
                        }
                    }
                }
            }
            return '\0';
        }

        static int CalculateSum(List<char> items)
        {
            int sum = 0;
            foreach (char c in items)
            {
                if (char.IsLower(c))
                {
                    sum += (int)c - 96;
                }
                else
                {
                    sum += (int)c - 38;
                }
            }
            return sum;
        }

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../Day03/Day03.txt");
            List<char> sharedItems = new List<char>();
            foreach (var line in lines)
            {
                string part1 = line.Substring(0, line.Length / 2);
                string part2 = line.Substring(line.Length / 2);
                sharedItems.Add(FindPart1(part1, part2));
            }
            Console.WriteLine(CalculateSum(sharedItems));
            sharedItems = new List<char>();
            for (int i = 0; i < lines.Length; i+=3)
            {
                sharedItems.Add(FindPart2(lines[i], lines[i+1], lines[i+2]));
            }
            Console.WriteLine(CalculateSum(sharedItems));
        }
    }
}

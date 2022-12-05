using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day01
{
    class Day01
    {
        static void Main(string[] args)
        {           
            string[] lines = File.ReadAllLines("../../../Day01/Day01.txt");
            List<int> calories = new List<int>();
            int cal = 0;
            foreach (var line in lines)
            {
                if(line == string.Empty)
                {
                    calories.Add(cal);
                    cal = 0;
                    continue;
                }
                cal += int.Parse(line);
            }
            var sorted = calories.OrderByDescending(x => x);
            Console.WriteLine(sorted.ElementAt(0));
            Console.WriteLine(sorted.Take(3).Sum());
        }
    }
}

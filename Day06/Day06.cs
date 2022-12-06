using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day06
{
    class Day06
    {
        static int Solve(string data, int packetSize)
        {
            HashSet<char> set = new HashSet<char>();
            int firstMarker = 0;
            for (int i = 0; i < data.Length - packetSize - 1; i++)
            {
                set.Clear();
                firstMarker = i;
                for (int j = i; j != i + packetSize; j++)
                {
                    set.Add(data[j]);
                    firstMarker++;
                }
                if (set.Count == packetSize)
                    break;
            }
            return firstMarker;
        }

        static void Main(string[] args)
        {
            string line = File.ReadAllText("../../../Day06/Day06.txt");    
            Console.WriteLine(Solve(line, 4));
            Console.WriteLine(Solve(line, 14));
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day12
{
    class Day12
    {
        //Copied algorithm
        static int Bfs(List<List<int>> heightmapNumbers, List<List<char>> heightmap, int part)
        {
            HashSet<(int, int)> set = new HashSet<(int, int)>();
            Queue<((int, int), int)> q = new Queue<((int, int), int)>();
            for (int row = 0; row < heightmapNumbers.Count; row++)
            {
                for (int col = 0; col < heightmapNumbers[row].Count; col++)
                {
                    if (heightmapNumbers[row][col] == 1 && (part==2 || heightmap[row][col] == 'S'))
                        q.Enqueue(((row, col), 0));
                }
            }

            while (q.Count > 0)
            {
                ((int row, int col) ver, int d) = q.Dequeue();
                if (set.Contains((ver.row, ver.col)))
                    continue;
                set.Add((ver.row, ver.col));
                if (heightmap[ver.row][ver.col] == 'E')
                    return d;

                int currentHeight = heightmapNumbers[ver.row][ver.col];

                int down = ver.row + 1;
                int up = ver.row + -1;
                int left = ver.col + -1;
                int right = ver.col + 1;
                if (0 <= up && up < heightmapNumbers.Count && heightmapNumbers[up][ver.col] <= 1 + currentHeight)
                    q.Enqueue(((up, ver.col), d + 1));

                if (0 <= right && right < heightmapNumbers[ver.row].Count && heightmapNumbers[ver.row][right] <= 1 + currentHeight)
                    q.Enqueue(((ver.row, right), d + 1));

                if (0 <= down && down < heightmapNumbers.Count && heightmapNumbers[down][ver.col] <= 1 + currentHeight)
                    q.Enqueue(((down, ver.col), d + 1));

                if (0 <= left && left < heightmapNumbers[ver.row].Count && heightmapNumbers[ver.row][left] <= 1 + currentHeight)
                    q.Enqueue(((ver.row, left), d + 1));
            }

            return 0;
        }

        static int ConvertToNumber(char c)
        {
            if (c == 'S')
                return 1;
            else if (c == 'E')
                return 26;
            else
                return (int)(c - 96);
        }

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../Day12/Day12.txt");
            List<List<char>> heightmap = new List<List<char>>();
            foreach (var line in lines)
            {
                List<char> list = new List<char>();
                for (int i = 0; i < line.Length; i++)
                {
                    list.Add(line[i]);
                }
                heightmap.Add(list);
            }
            List<List<int>> heightmapNumbers = new List<List<int>>();
            foreach (var row in heightmap)
            {
                List<int> list = new List<int>();
                foreach (var col in row)
                {
                    list.Add(ConvertToNumber(col));
                }
                heightmapNumbers.Add(list);
            }
            Console.WriteLine(Bfs(heightmapNumbers, heightmap, 1));
            Console.WriteLine(Bfs(heightmapNumbers, heightmap, 2));
        }
    }
}

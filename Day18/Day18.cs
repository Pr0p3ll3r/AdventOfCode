using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day18
{
    class Day18
    {
        static bool Dfs((int x, int y, int z) cube, Stack<(int x, int y, int z)> cubes, int min, int max)
        {
            Stack<(int x, int y, int z)> stack = new Stack<(int x, int y, int z)>();
            stack.Push(cube);
            HashSet<(int x, int y, int z)> visited = new HashSet<(int x, int y, int z)>();

            if (cubes.Contains(cube))
                return false;

            while (stack.Count > 0)
            {
                (int x, int y, int z) c = stack.Pop();

                if (cubes.Contains(c))
                    continue;

                if (c.x < min || c.x > max)
                    return true;
                if (c.y < min || c.y > max)
                    return true;
                if (c.z < min || c.z > max)
                    return true;

                if (visited.Contains(c))
                    continue;

                visited.Add(c);

                stack.Push((c.x + 1, c.y, c.z));
                stack.Push((c.x - 1, c.y, c.z));
                stack.Push((c.x, c.y + 1, c.z));
                stack.Push((c.x, c.y - 1, c.z));
                stack.Push((c.x, c.y, c.z + 1));
                stack.Push((c.x, c.y, c.z - 1));
            }

            return false;
        }


        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../Day18/Day18.txt");
            Stack<(int x, int y, int z)> cubes = new Stack<(int, int, int)>();
            foreach(var line in lines)
            {
                string[] cords = line.Split(',');
                cubes.Push((int.Parse(cords[0]), int.Parse(cords[1]), int.Parse(cords[2])));
            }
            int part1 = 0;
            foreach(var c in cubes)
            {
                if (!cubes.Contains((c.x + 1, c.y, c.z)))
                    part1++;
                if (!cubes.Contains((c.x - 1, c.y, c.z)))
                    part1++;
                if (!cubes.Contains((c.x, c.y + 1, c.z)))
                    part1++;
                if (!cubes.Contains((c.x, c.y - 1, c.z)))
                    part1++;
                if (!cubes.Contains((c.x, c.y, c.z + 1)))
                    part1++;
                if (!cubes.Contains((c.x, c.y, c.z - 1)))
                    part1++;
            }
            Console.WriteLine(part1);

            int part2 = 0;
            int min = cubes.Min(c => c.x);
            int max = cubes.Max(c => c.x);
            foreach (var c in cubes)
            {
                //Console.WriteLine(c);
                if (Dfs((c.x + 1, c.y, c.z), cubes, min, max))
                    part2++;
                if (Dfs((c.x - 1, c.y, c.z), cubes, min, max))
                    part2++;
                if (Dfs((c.x, c.y + 1, c.z), cubes, min, max))
                    part2++;
                if (Dfs((c.x, c.y - 1, c.z), cubes, min, max))
                    part2++;
                if (Dfs((c.x, c.y, c.z + 1), cubes, min, max))
                    part2++;
                if (Dfs((c.x, c.y, c.z - 1), cubes, min, max))
                    part2++;
            }
            Console.WriteLine(part2);
        }
    }
}

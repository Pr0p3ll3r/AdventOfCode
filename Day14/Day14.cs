using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day14
{
    class Day14
    {
        static bool SimulateSand(int maxY, ref HashSet<(int, int)> scan, int part)
        {
            (int x, int y) newSand = (500, 0);
            if (scan.Contains(newSand))
            {
                return false;
            }
            while (newSand.y < maxY)
            {
                if (part == 2 && newSand.y + 1 == maxY)
                {
                    scan.Add(newSand);
                    return true;
                }
                if(!scan.Contains((newSand.x,newSand.y + 1)))
                {
                    newSand.y++;
                    continue;
                }
                else if(!scan.Contains((newSand.x - 1, newSand.y + 1)))
                {
                    newSand.x--;
                    newSand.y++;
                    continue;
                }
                else if (!scan.Contains((newSand.x + 1, newSand.y + 1)))
                {
                    newSand.x++;
                    newSand.y++;
                    continue;
                }
                scan.Add(newSand);
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../Day14/Day14.txt");
            HashSet<(int, int)> scan = new HashSet<(int, int)>();
            foreach(var line in lines) 
            {
                string[] coordinates = line.Split(" -> ");
                (int x, int y) prevCord = default;
                foreach(var cord in coordinates)
                {
                    string[] rockCord = cord.Split(',');
                    (int x, int y) newCord = (int.Parse(rockCord[0]), int.Parse(rockCord[1]));                  
                    if(prevCord != default)
                    {
                        if(newCord.x < prevCord.x)
                        {
                            for (int i = prevCord.x - 1; i >= newCord.x; i--)
                            {
                                scan.Add((i, newCord.y));
                            }
                        }
                        else if (newCord.x > prevCord.x)
                        {
                            for (int i = prevCord.x + 1; i <= newCord.x; i++)
                            {
                                scan.Add((i, newCord.y));
                            }
                        }
                        else if (newCord.y < prevCord.y)
                        {
                            for (int i = prevCord.y - 1; i >= newCord.y; i--)
                            {
                                scan.Add((newCord.x, i));
                            }
                        }
                        else
                        {
                            for (int i = prevCord.y + 1; i <= newCord.y; i++)
                            {
                                scan.Add((newCord.x, i));
                            }
                        }
                    }
                    else
                        scan.Add((newCord.x, newCord.y));
                    prevCord = newCord;
                }              
            }
            int maxY = scan.Max(x => x.Item2);
            HashSet<(int, int)> scanPart1 = new HashSet<(int, int)>();
            HashSet<(int, int)> scanPart2 = new HashSet<(int, int)>();
            foreach (var c in scan)
            {
                scanPart1.Add(c);
                scanPart2.Add(c);
            }
            int part1 = 0;
            while(SimulateSand(maxY, ref scanPart1, 1))
            {
                part1++;
            }
            Console.WriteLine(part1);                   
            int floorY = maxY + 2;
            int part2 = 0;
            while (SimulateSand(floorY, ref scanPart2, 2))
            {
                part2++;
            }
            Console.WriteLine(part2);
        }
    }
}

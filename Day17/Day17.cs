using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day17
{
    class Day17
    {
        static HashSet<(int, int)> Rock(int type, int y)
        {
            HashSet<(int, int)> newRock = new HashSet<(int, int)>();
            if(type == 0)
            {
                newRock.Add((2, y));
                newRock.Add((3, y));
                newRock.Add((4, y));
                newRock.Add((5, y));
            }
            else if (type == 1)
            {
                newRock.Add((3, y + 2));
                newRock.Add((2, y + 1));
                newRock.Add((3, y + 1));
                newRock.Add((4, y + 1));
                newRock.Add((3, y));
            }
            else if (type == 2)
            {
                newRock.Add((4, y + 2));
                newRock.Add((4, y + 1));
                newRock.Add((2, y));
                newRock.Add((3, y));
                newRock.Add((4, y));
            }
            else if (type == 3)
            {
                newRock.Add((2, y));
                newRock.Add((2, y + 1));
                newRock.Add((2, y + 2));
                newRock.Add((2, y + 3));
            }
            else if (type == 4)
            {
                newRock.Add((2, y));
                newRock.Add((3, y));
                newRock.Add((2, y + 1));
                newRock.Add((3, y + 1));
            }
            return newRock;
        }

        static bool MoveDown(ref HashSet<(int x, int y)> rock, HashSet<(int x, int y)> rocks)
        {
            foreach (var r in rock)
            {
                if (rocks.Contains((r.x, r.y - 1)))
                {
                    //Console.WriteLine("Stop");
                    return false;
                }             
            }
            HashSet<(int x, int y)> rockNewPos = new HashSet<(int x, int y)>();
            foreach (var r in rock)
            {
                rockNewPos.Add((r.x, r.y - 1));
            }
            rock = rockNewPos;
            //Console.WriteLine("Down");
            return true;
        }

        static void MoveLeft(ref HashSet<(int x, int y)> rock, HashSet<(int x, int y)> rocks)
        {
            foreach (var r in rock)
            {
                if (r.x - 1 < 0 || rocks.Contains((r.x - 1, r.y)))
                {
                    //Console.WriteLine("Left, wall");
                    return;
                }
            }
            HashSet<(int x, int y)> rockNewPos = new HashSet<(int x, int y)>();
            foreach (var r in rock)
            {
                rockNewPos.Add((r.x - 1, r.y));
            }
            rock = rockNewPos;
            //Console.WriteLine("Left");
        }

        static void MoveRight(ref HashSet<(int x, int y)> rock, HashSet<(int x, int y)> rocks)
        {
            foreach (var r in rock)
            {
                if (r.x + 1 > 6 || rocks.Contains((r.x + 1, r.y)))
                {
                    //Console.WriteLine("Right, wall");
                    return;
                }
            }
            HashSet<(int x, int y)> rockNewPos = new HashSet<(int x, int y)>();
            foreach (var r in rock)
            {
                rockNewPos.Add((r.x + 1, r.y));
            }
            rock = rockNewPos;
            //Console.WriteLine("Right");
        }

        static void ShowRocks(HashSet<(int x, int y)> rocks, int maxY)
        {
            for (int y = maxY; y >= 0; y--)
            {
                for (int x = 0; x <= 6; x++)
                {
                    if (rocks.Contains((x, y)))
                        Console.Write('#');
                    else
                        Console.Write('.');
                }
                Console.WriteLine();
            }
        }

        static void ShowRockPos(HashSet<(int x, int y)> rock)
        {
            foreach (var r in rock)
            {
                Console.WriteLine(r);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            string moves = File.ReadAllText("../../../Day17/Day17.txt").Trim();
            HashSet<(int x, int y)> rocks = new HashSet<(int, int)>();
            for (int x = 0; x < 7; x++)
            {
                rocks.Add((x, 0));
            }
            int maxY = 0;
            int i = 0;
            int type = 0;
            int rocksAmount = 0;
            while (rocksAmount < 2022)
            {
                rocksAmount++;
                maxY = rocks.Max(r => r.y);
                var newRock = Rock(type, maxY + 4);
                while (true)
                {
                    if (moves[i] == '<')
                        MoveLeft(ref newRock, rocks);
                    else
                        MoveRight(ref newRock, rocks);
                    i++;
                    if (i > moves.Length - 1) i = 0;
                    if (!MoveDown(ref newRock, rocks))
                        break;
                }
                //ShowRockPos(newRock);
                foreach (var r in newRock)
                {
                    rocks.Add(r);
                }                              
                type++;
                if (type > 4)
                    type = 0;
            }
            maxY = rocks.Max(r => r.y);
            //ShowRocks(rocks, maxY + 4);
            Console.WriteLine(maxY);
        }
    }
}

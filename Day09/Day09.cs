using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day09
{
    class Day09
    {
        static void MoveTail((int x, int y) head, ref (int x, int y) tail)
        {
            if (Math.Abs(head.x - tail.x) <= 1 && Math.Abs(head.y - tail.y) <= 1)
            {
                return;
            }
            if (head.x == tail.x && head.y > tail.y)
                tail.y = head.y - 1;
            else if (head.x == tail.x && head.y < tail.y)
                tail.y -= 1;
            else if (head.y == tail.y && head.x > tail.x)
                tail.x = head.x - 1;
            else if (head.y == tail.y && head.x < tail.x)
                tail.x = head.x + 1;
            else if (head.x > tail.x && head.y > tail.y)
            {
                tail.x += 1;
                tail.y += 1;
            }
            else if (head.x > tail.x && head.y < tail.y)
            {
                tail.x += 1;
                tail.y -= 1;
            }
            else if (head.x < tail.x && head.y > tail.y)
            {
                tail.x -= 1;
                tail.y += 1;
            }
            else if (head.x < tail.x && head.y < tail.y)
            {
                tail.x -= 1;
                tail.y -= 1;
            }
        }

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../Day09/Day09.txt");
            HashSet<(int, int)> visited1 = new HashSet<(int, int)>() { (0, 0) };
            (int x, int y) head1 = (0, 0);
            (int x, int y) tail1 = (0, 0);
            HashSet<(int, int)> visited2 = new HashSet<(int, int)>() { (0, 0) };
            (int x, int y)[] knots = new (int x, int y)[10];
            foreach (var line in lines)
            {
                string[] split = line.Split();
                for (int i = 0; i < int.Parse(split[1]); i++)
                {
                    if (split[0] == "U")
                    {
                        head1.y++;
                        knots[0].y++;
                    }
                    else if (split[0] == "D")
                    {
                        head1.y--;
                        knots[0].y--;
                    }
                    else if (split[0] == "R")
                    {
                        head1.x++;
                        knots[0].x++;
                    }
                    else
                    {
                        head1.x--;
                        knots[0].x--;
                    }
                    MoveTail(head1, ref tail1);
                    visited1.Add(tail1);

                    for (int j = 1; j < 10; j++)
                    {
                        MoveTail(knots[j - 1], ref knots[j]);                           
                    }
                    visited2.Add(knots.Last());
                }           
            }
            Console.WriteLine(visited1.Count);
            Console.WriteLine(visited2.Count);
        }
    }
}

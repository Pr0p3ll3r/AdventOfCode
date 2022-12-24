using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day23
{
    class Elf
    {
        public int id;
        public (int x, int y) pos;
        public (int x, int y) proposeMove;
        public Elf(int id, (int x, int y) pos)
        {
            this.id = id;
            this.pos = pos;
            proposeMove = (-100, -100);
        }
        public (int x, int y) CheckAdjacentPositions(List<Elf> elves, List<char> directions)
        {
            (int x, int y) N = (pos.x, pos.y - 1);
            (int x, int y) NE = (pos.x + 1, pos.y - 1);
            (int x, int y) NW = (pos.x - 1, pos.y - 1);
            (int x, int y) S = (pos.x, pos.y + 1);
            (int x, int y) SE = (pos.x + 1, pos.y + 1);
            (int x, int y) SW = (pos.x - 1, pos.y + 1);
            (int x, int y) W = (pos.x - 1, pos.y);
            (int x, int y) E = (pos.x + 1, pos.y);

            proposeMove = (-100, -100);
            bool canMove = false;
            foreach (Elf elf in elves)
            {
                if (elf.pos == N || elf.pos == NE || elf.pos == NW || elf.pos == S || elf.pos == SE || elf.pos == SW || elf.pos == W || elf.pos == E)
                {
                    canMove = true;
                    break;
                }
                    
            }
            if (!canMove) 
                return proposeMove;

            for (int i = 0; i < directions.Count; i++)
            {
                if (directions[i] == 'N')
                {
                    if (!elves.Any(elf => elf.pos == N) && !elves.Any(elf => elf.pos == NE) && !elves.Any(elf => elf.pos == NW))
                    {
                        proposeMove = N;
                        return proposeMove;
                    }
                }
                else if (directions[i] == 'S')
                {
                    if (!elves.Any(elf => elf.pos == S) && !elves.Any(elf => elf.pos == SE) && !elves.Any(elf => elf.pos == SW))
                    {
                        proposeMove = S;
                        return proposeMove;
                    }
                }
                else if (directions[i] == 'W')
                {
                    if (!elves.Any(elf => elf.pos == W) && !elves.Any(elf => elf.pos == NW) && !elves.Any(elf => elf.pos == SW))
                    {
                        proposeMove = W;
                        return proposeMove;
                    }
                }
                else
                {
                    if (!elves.Any(elf => elf.pos == E) && !elves.Any(elf => elf.pos == NE) && !elves.Any(elf => elf.pos == SE))
                    {
                        proposeMove = E;
                        return proposeMove;
                    }
                }
            }
            return proposeMove;
        }
    }

    class Day23
    {
        static void Part1(List<Elf> elves)
        {
            int groundTiles = 0;
            int maxX = elves.Max(elf => elf.pos.x);
            int minX = elves.Min(elf => elf.pos.x);
            int maxY = elves.Max(elf => elf.pos.y);
            int minY = elves.Min(elf => elf.pos.y);
            groundTiles = (maxX - minX + 1) * (maxY - minY + 1) - elves.Count;
            Console.WriteLine(groundTiles);
        }
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../Day23/Day23.txt");
            List<Elf> elves = new List<Elf>();
            int id = 0;
            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[0].Length; x++)
                {
                    if (lines[y][x] == '#')
                    {
                        elves.Add(new Elf(id, (x, y)));
                        id++;
                    }
                }
            }
            List<char> directions = new List<char>() { 'N', 'S', 'W', 'E' };
            int round = 1;
            for (int i = 0; i < 10000; i++)
            {
                List<(int id, (int x, int y) pos)> proposeMoves = new List<(int id, (int x, int y) pos)>();
                foreach (var elf in elves)
                {
                    (int x, int y) proposeMove = elf.CheckAdjacentPositions(elves, directions);
                    if (proposeMove != (-100, -100))
                        proposeMoves.Add((elf.id, proposeMove));
                }
                directions.Add(directions[0]);
                directions.RemoveAt(0);
                if (proposeMoves.Count == 0)
                    break;
                foreach (var elf in elves)
                {
                    bool canMove = true;
                    foreach (var move in proposeMoves)
                    {
                        if (move.id == elf.id)
                            continue;
                        if (move.pos == elf.proposeMove)
                        {
                            canMove = false;
                            break;
                        }
                    }
                    if (canMove && elf.proposeMove != (-100, -100))
                    {
                        elf.pos = elf.proposeMove;
                        elf.proposeMove = (-100, -100);
                    }

                }
                if (round == 10)
                    Part1(elves);
                round++;
            }
            Console.WriteLine(round);
        }
    }
}

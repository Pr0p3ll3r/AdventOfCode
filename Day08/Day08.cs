using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day08
{
    class Day08
    {
        static bool CheckFromLeft(int row, int col, List<List<int>> list, ref int canSee)
        {
            for (int i = col - 1; i >= 0; i--)
            {
                canSee++;
                if (list[row][i] >= list[row][col])
                    return false;
            }
            return true;
        }

        static bool CheckFromRight(int row, int col, List<List<int>> list, ref int canSee)
        {
            for (int i = col + 1; i < list.Count; i++)
            {
                canSee++;
                if (list[row][i] >= list[row][col])
                    return false;
            }
            return true;
        }

        static bool CheckFromAbove(int row, int col, List<List<int>> list, ref int canSee)
        {
            for (int i = row - 1; i >= 0; i--)
            {
                canSee++;
                if (list[i][col] >= list[row][col])
                    return false;
            }
            return true;
        }

        static bool CheckFromBelow(int row, int col, List<List<int>> list, ref int canSee)
        {
            for (int i = row + 1; i < list.Count; i++)
            {
                canSee++;
                if (list[i][col] >= list[row][col])
                    return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../Day08/Day08.txt");
            List<List<int>> list = new List<List<int>>();
            foreach (var line in lines)
            {
                List<int> l = new List<int>();
                for (int i = 0; i < line.Length; i++)
                {
                    l.Add(int.Parse(line[i].ToString()));
                }
                list.Add(l);
            }
            int counter = list.Count * 2 + list[0].Count * 2 - 4;
            bool added;
            int highestScore = 0;
            for (int i = 1; i < list.Count - 1; i++)
            {
                for (int j = 1; j < list[i].Count - 1; j++)
                {
                    added = false;
                    int currentScore, left=0, right=0, above=0, below=0;
                    if (CheckFromLeft(i, j, list, ref left))
                        if (!added)
                        {
                            counter++;
                            added = true;
                        }
                    if (CheckFromRight(i, j, list, ref right))
                        if (!added)
                        {
                            counter++;
                            added = true;
                        }
                    if (CheckFromAbove(i, j, list, ref above))
                        if (!added)
                        {
                            counter++;
                            added = true;
                        }
                    if (CheckFromBelow(i, j, list, ref below))
                        if (!added)
                        {
                            counter++;
                            added = true;
                        }
                    currentScore = left * right * above * below;
                    if (currentScore > highestScore)
                        highestScore = currentScore;
                }
            }
            Console.WriteLine(counter);
            Console.WriteLine(highestScore);
        }
    }
}

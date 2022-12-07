using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day05
{
    class Day05
    {
        static void CrateMover9000(int howMany, List<char> from, List<char> to)
        {
            for (int i = 0; i < howMany; i++)
            {
                to.Insert(0, from.First());
                from.RemoveAt(0);
            }
        }

        static void CrateMover9001(int howMany, List<char> from, List<char> to)
        {
            List<char> list = new List<char>();
            for (int i = 0; i < howMany; i++)
            {
                list.Add(from.First());
                from.RemoveAt(0);
            }
            list.Reverse();
            foreach (var crate in list)
            {
                to.Insert(0, crate);
            }
        }

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../Day05/Day05.txt");
            List<List<char>> stacks = new List<List<char>>();
            for (int i = 0; i < 9; i++)
                stacks.Add(new List<char>());
            for (int i = 0; i < lines.Length; i++)
            {
                if (i < 8)
                {
                    string crate = lines[i];
                    int stackNumber = -1;
                    for (int j = 0; j < crate.Length; j += 4)
                    {
                        stackNumber++;
                        string x = "" + crate[j] + crate[j + 1] + crate[j + 2];
                        x = x.Trim(new char[] { '[', ']', ' ' });
                        if (x != string.Empty)
                        {
                            stacks[stackNumber].Add(char.Parse(x));
                        }
                    }
                }           
                else if (i > 9)
                {

                    string[] strings = lines[i].Split(' ');
                    int howMany = int.Parse(strings[1]);
                    int from = int.Parse(strings[3]);
                    int to = int.Parse(strings[5]);
                    //CrateMover9000(howMany, stacks[from - 1], stacks[to - 1]);
                    CrateMover9001(howMany, stacks[from - 1], stacks[to - 1]);
                }
            }
            string result = "";
            foreach (var stack in stacks) 
            {
                result += stack.First();
            }
            Console.WriteLine(result);
        }
    }
}

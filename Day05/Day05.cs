using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day05
{
    class Day05
    {
        static void CrateMover9000(int howMany, Stack<char> from, Stack<char> to)
        {
            for (int i = 0; i < howMany; i++)
            {
                to.Push(from.Pop());
            }
        }

        static void CrateMover9001(int howMany, Stack<char> from, Stack<char> to)
        {
            List<char> list = new List<char>();
            for (int i = 0; i < howMany; i++)
            {
                list.Add(from.Pop());
            }
            list.Reverse();
            foreach (var crate in list)
            {
                to.Push(crate);
            }
        }

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../Day05/Day05.txt");
            Stack<char> s1 = new Stack<char>(new[] { 'L', 'N', 'W', 'T', 'D'});
            Stack<char> s2 = new Stack<char>(new[] { 'C', 'P', 'H'});
            Stack<char> s3 = new Stack<char>(new[] { 'W', 'P', 'H', 'N', 'D', 'G', 'M', 'J'});
            Stack<char> s4 = new Stack<char>(new[] { 'C', 'W', 'S', 'N', 'T', 'Q', 'L'});
            Stack<char> s5 = new Stack<char>(new[] { 'P', 'H', 'C', 'N'});
            Stack<char> s6 = new Stack<char>(new[] { 'T', 'H', 'N', 'D', 'M', 'W', 'Q', 'B'});
            Stack<char> s7 = new Stack<char>(new[] { 'M', 'B', 'R', 'J', 'G', 'S', 'L'});
            Stack<char> s8 = new Stack<char>(new[] { 'Z', 'N', 'W', 'G', 'V', 'B', 'R', 'T'});
            Stack<char> s9 = new Stack<char>(new[] { 'W', 'G', 'D', 'N', 'P', 'L'});
            List<Stack<char>> stacks = new List<Stack<char>>() {s1,s2,s3,s4,s5,s6,s7,s8,s9};
            foreach (var line in lines)
            {
                string[] strings = line.Split(' ');
                int howMany = int.Parse(strings[1]);
                int from = int.Parse(strings[3]);
                int to = int.Parse(strings[5]);
                //CrateMover9000(howMany, stacks[from - 1], stacks[to - 1]);
                CrateMover9001(howMany, stacks[from - 1], stacks[to - 1]);
            }
            string result = "";
            foreach (var stack in stacks) 
            {
                result += stack.Pop();
            }
            Console.WriteLine(result);
        }
    }
}

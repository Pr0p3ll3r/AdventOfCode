using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day04
{
    class Day04
    {
        static void AssignSections(string[] elf, ref List<int> sections)
        {
            for (int i = int.Parse(elf[0]); i <= int.Parse(elf[1]); i++)
            {
                sections.Add(i);
            }
        }

        static bool CheckPart1(List<int> sectionsElf1, List<int> sectionsElf2)
        {
            bool contains;
            if (sectionsElf1.Count < sectionsElf2.Count)
            {
                foreach (var section1 in sectionsElf1)
                {
                    contains = false;
                    foreach (var section2 in sectionsElf2)
                    {
                        if (section1 == section2)
                        {
                            contains = true;
                            break;
                        }                           
                    }
                    if (!contains)
                        return false;
                }
            }
            else
            {
                foreach (var section2 in sectionsElf2)
                {
                    contains = false;
                    foreach (var section1 in sectionsElf1)
                    {
                        if (section2 == section1)
                        {
                            contains = true;
                            break;
                        }
                    }
                    if (!contains)
                        return false;
                }
            }
            return true;
        }

        static bool CheckPart2(List<int> sectionsElf1, List<int> sectionsElf2)
        {
            if (sectionsElf1.Count < sectionsElf2.Count) 
            { 
                foreach (var section1 in sectionsElf1)
                    foreach (var section2 in sectionsElf2)
                        if (section1 == section2) return true; 
            }
            else
            {
                foreach (var section2 in sectionsElf2)
                    foreach (var section1 in sectionsElf1)
                        if (section2 == section1) return true;      
            }
            return false;
        }

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("F:\\AdventOfCode\\Day04\\Day04.txt");
            int part1 = 0;
            int part2 = 0;
            foreach (var line in lines)
            {
                string[] elves = line.Split(',');
                string[] elf1 = elves[0].Split('-');
                string[] elf2 = elves[1].Split('-');
                List<int> sectionsElf1 = new List<int>();
                List<int> sectionsElf2 = new List<int>();
                AssignSections(elf1, ref sectionsElf1);
                AssignSections(elf2, ref sectionsElf2);
                if (CheckPart1(sectionsElf1, sectionsElf2))
                    part1++;
                if (CheckPart2(sectionsElf1, sectionsElf2))
                    part2++;
            }
            Console.WriteLine(part1);
            Console.WriteLine(part2);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day11
{
    class Monkey
    {
        public List<long> items;
        public long inspection;
        public Monkey()
        {
            items = new List<long>();
            inspection = 0;
        }
    }

    class Day11
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../Day11/Day11.txt");
            List<Monkey> monkeys = new List<Monkey>();
            for (int i = 1, currentMonkey = 0; i < lines.Length; i += 7, currentMonkey++)
            {
                monkeys.Add(new Monkey());
                string[] items = lines[i].Trim().Split(' ');
                for (int j = 2; j < items.Length; j++)
                {
                    string item = items[j];
                    item = item.Trim(',');
                    monkeys[currentMonkey].items.Add(long.Parse(item));
                }
            }

            int mod = 1;
            for (int j = 2, currentMonkey = 0; j < lines.Length; j += 7, currentMonkey++)
            {
                int divisibleValue = int.Parse(lines[j + 1].Trim().Split(' ')[3]);
                mod *= divisibleValue;  
            }

            for (int i = 0; i < 10000; i++)
            {
                for (int j = 2, currentMonkey = 0; j < lines.Length; j += 7, currentMonkey++)
                {
                    string operation = lines[j].Trim().Split(' ')[4];
                    string operationValue = lines[j].Trim().Split(' ')[5];
                    for (int k = 0; k < monkeys[currentMonkey].items.Count; k++)
                    {
                        //change worry level
                        monkeys[currentMonkey].inspection++;
                        if (operation == "*")
                        { 
                            if (operationValue == "old")
                                monkeys[currentMonkey].items[k] *= monkeys[currentMonkey].items[k];
                            else 
                                monkeys[currentMonkey].items[k] *= long.Parse(operationValue);
                        }
                        else
                        {
                            monkeys[currentMonkey].items[k] += long.Parse(operationValue);
                        }

                        //divide by three and round down to the nearest integer
                        //monkeys[currentMonkey].items[k] = (long)(Math.Floor(monkeys[currentMonkey].items[k] / 3.0));
                        monkeys[currentMonkey].items[k] %= mod;

                        //check if item is divisible
                        int divisibleValue = int.Parse(lines[j + 1].Trim().Split(' ')[3]);
                        if (monkeys[currentMonkey].items[k] % divisibleValue == 0)
                        {
                            monkeys[int.Parse(lines[j + 2].Trim().Split(' ')[5])].items.Add(monkeys[currentMonkey].items[k]);
                        }
                        else
                        {
                            monkeys[int.Parse(lines[j + 3].Trim().Split(' ')[5])].items.Add(monkeys[currentMonkey].items[k]);
                        }
                    }
                    monkeys[currentMonkey].items.Clear();
                }
            }
            foreach(var monkey in monkeys)
            {
                Console.WriteLine(monkey.inspection);
            }
            var sorted = monkeys.OrderByDescending(x => x.inspection);
            Console.WriteLine(sorted.ElementAt(0).inspection * sorted.ElementAt(1).inspection);
        }
    }
}

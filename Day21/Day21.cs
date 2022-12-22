using AdventOfCode.Day11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day21
{
    class Monkey
    {
        public string name;
        public long number;
        public string operation;
        public string monkey1name;
        public string monkey2name;
        public Monkey monkey1;
        public Monkey monkey2;
        public Monkey(string name, long number, string operation, string monkey1name, string monkey2name)
        {
            this.name = name;
            this.number = number;
            this.operation = operation;
            this.monkey1name = monkey1name;
            this.monkey2name = monkey2name;
        }
        public Monkey()
        {

        }
        public void FindMonkeys(List<Monkey> monkeys)
        {
            monkey1 = monkeys.Find(x => x.name == monkey1name);
            monkey2 = monkeys.Find(x => x.name == monkey2name);
        }
        public void Work()
        {
            if(number == 0)
            {
                if(monkey1.number == 0)
                {
                    monkey1.Work();
                }
                if(monkey2.number == 0)
                {
                    monkey2.Work();
                }
                switch (operation)
                {
                    case "+":
                        number = monkey1.number + monkey2.number;
                        break;
                    case "-":
                        number = monkey1.number - monkey2.number;
                        break;
                    case "*":
                        number = monkey1.number * monkey2.number;
                        break;
                    case "/":
                        number = monkey1.number / monkey2.number;
                        break;
                }
            }
        }
    }

    class Day21
    {
        static void Part1(string[] lines)
        {
            List<Monkey> monkeys = new List<Monkey>();
            Monkey root = new Monkey();
            Monkey humn = new Monkey();
            foreach (var line in lines)
            {
                string[] split = line.Split(':');
                string name = split[0];
                if (char.IsDigit(split[1][1]))
                {
                    string number = split[1].Trim();
                    int num = int.Parse(number);
                    monkeys.Add(new Monkey(name, num, "", "", ""));
                }
                else
                {
                    string[] requireMonkeys = split[1].Split(' ');
                    string monkey1 = requireMonkeys[1];
                    string monkey2 = requireMonkeys[3];
                    string operation = requireMonkeys[2];
                    Monkey monkey = new Monkey(name, 0, operation, monkey1, monkey2);
                    if (name == "root")
                        root = monkey;
                    monkeys.Add(monkey);
                }
            }
            foreach (var monkey in monkeys)
            {
                monkey.FindMonkeys(monkeys);
            }
            root.Work();
            Console.WriteLine(root.number);
        }

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../Day21/Day21.txt");
            Part1(lines);
        }
    }
}

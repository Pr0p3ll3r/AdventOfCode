using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day10
{
    class Day10
    {
        static void DrawPixel(char[,] sprite, ref int col, ref int row, int register, int cycle)
        {
            if (col == register - 1 || col == register || col == register + 1)
                sprite[row, col] = '#';
            else
                sprite[row, col] = '.';
            if (cycle % 40 == 0)
            {
                row++;
                col = 0;
            }
            else
                col++;
        }

        static void GetSignalStrength(int cycle, ref int signalStrength, int register)
        {
            if ((cycle - 20) % 40 == 0)
                signalStrength += register * cycle;
        }

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../Day10/Day10.txt");
            int register = 1, signalStrength = 0, cycle = 0;
            char[,] sprite = new char[6, 40];
            int row = 0, col = 0;
            foreach (var line in lines)
            {
                string[] split = line.Split(' ');
                cycle++;
                DrawPixel(sprite, ref col, ref row, register, cycle);
                GetSignalStrength(cycle, ref signalStrength, register);
                if (split[0] == "addx")
                {                   
                    cycle++;
                    DrawPixel(sprite, ref col, ref row, register, cycle);
                    GetSignalStrength(cycle, ref signalStrength, register);
                    register += int.Parse(split[1]);                  
                }
            }
            Console.WriteLine(signalStrength);
            for (int i = 0; i < sprite.GetLength(0); i++)
            {
                for (int j = 0; j < sprite.GetLength(1); j++)
                {
                    Console.Write(sprite[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

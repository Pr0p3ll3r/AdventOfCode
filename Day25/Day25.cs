using AdventOfCode.Day23;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day25
{
    class Day25
    {
        static long SnafuToDecimal(string number)
        {
            long converted = 0;
            long multiplier = 1;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                if (number[i] == '-')
                {
                    converted += -1 * multiplier;
                }
                else if (number[i] == '=')
                {
                    converted += -2 * multiplier;
                }
                else
                {
                    converted += (number[i] - '0') * multiplier;
                }
                multiplier *= 5;
            }
            return converted;
        }

        static string DecimalToSnafu(long number)
        {
            string converted = "";
            while(number > 0)
            {
                long digit = ((number+2) % 5) - 2;
                if (digit == -1) converted += '-';
                else if (digit == -2) converted += '=';
                else converted += digit;
                number -= digit;
                number /= 5;
            }
            char[] reversed = converted.ToCharArray();
            Array.Reverse(reversed);
            return new string(reversed);
        }

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../Day25/Day25.txt");
            long sum = 0;
            foreach (var line in lines)
            {
                sum += SnafuToDecimal(line);               
            }
            Console.WriteLine(DecimalToSnafu(sum));
        }
    }
}

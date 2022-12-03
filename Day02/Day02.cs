using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day02
{
    class Day02
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("F:\\AdventOfCode\\Day02\\Day02.txt");
            int score1 = 0;
            foreach (var line in lines)
            {
                if (line[2] == 'X') //You chose rock
                {
                    score1 += 1;
                    if (line[0] == 'A') score1 += 3; //Draw
                    else if (line[0] == 'C') score1 += 6; //Win
                }               
                else if (line[2] == 'Y') //You chose paper
                {
                    score1 += 2;
                    if (line[0] == 'B') score1 += 3; //Draw
                    else if (line[0] == 'A') score1 += 6; //Win
                }
                else //You chose scissors
                {
                    score1 += 3;
                    if (line[0] == 'C') score1 += 3; //Draw
                    else if (line[0] == 'B') score1 += 6; //Win
                }                 
            }
            Console.WriteLine(score1);
            int score2 = 0;
            foreach (var line in lines)
            {
                if (line[0] == 'A') //Opponent chose rock
                {
                    if (line[2] == 'Y') score2 += 4; //Draw, You have to choose rock, 3+1
                    else if (line[2] == 'Z') score2 += 8; //Win, You have to choose paper, 6+2
                    else score2 += 3; //Loss, You have to choose scissors, 3
                }
                else if (line[0] == 'B') //Opponent chose paper
                {
                    if (line[2] == 'Y') score2 += 5; //Draw, You have to choose paper, 3+2
                    else if (line[2] == 'Z') score2 += 9; //Win, You have to choose scissors, 6+3
                    else score2 += 1; //Loss, You have to choose rock, 1
                }
                else //Opponent chose scissors
                {
                    if (line[2] == 'Y') score2 += 6; //Draw, You have to choose scissors, 3+3
                    else if (line[2] == 'Z') score2 += 7;//Win, You have to choose rock, 6+1
                    else score2 += 2; //Loss, You have to choose paper, 2
                }
            }
            Console.WriteLine(score2);
        }
    }
}

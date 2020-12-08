using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Advent_of_code.Day8
{
    class Day8
    {
        public int AccumulatorValue { get; set; }
        List<int> actionsVisited = new List<int>();


        public Day8()
        {
            string[] input = ParseDataToStringArray();
            PartOne(input, 0);
        }
        private string[] ParseDataToStringArray()
        {
            return File.ReadAllLines("C:\\Users\\marte\\source\\repos\\AdventOfCode2020\\Advent of code\\Day8\\data.txt");
        }

        

        private void PartOne(string[] input, int index)
        {
            for (int i = index; i < input.Length; i++)
            {
                input[i] = String.Concat(input[i].Where(c => !Char.IsWhiteSpace(c)));
                if (!actionsVisited.Contains(i))
                {
                    if (input[i].StartsWith('a'))
                    {
                        char test = input[i][4];
                        AccumulatorValue += int.Parse(input[i][3].ToString() + input[i][4..]);
                        actionsVisited.Add(i);
                    }

                    else if (input[i].StartsWith('j'))
                    {
                        actionsVisited.Add(i);
                        i += int.Parse(input[i][3].ToString() + input[i][4..]) - 1;
                    }
                }
                else
                {
                    //if (input[i].StartsWith('j'))
                    //{
                    //    input[i].Replace("jmp", "nop");
                    //    PartOne(input, i - 1);
                    //}
                    //else if (input[i].StartsWith('n'))
                    //{
                    //    input[i].Replace("nop", "jmp");
                    //    PartOne(input, i - 1);
                    //}

                   


                }
            }
            Console.WriteLine(AccumulatorValue);
        }

        
    }
}

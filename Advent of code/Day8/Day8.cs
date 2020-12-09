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
        public int AccumulatorValue2 { get; set; }



        public Day8()
        {
            string[] input = ParseDataToStringArray();
            PartOne(input, 0);
            PartTwo(input, 0);
        }
        private string[] ParseDataToStringArray()
        {
            return File.ReadAllLines("C:\\Users\\marte\\source\\repos\\AdventOfCode2020\\Advent of code\\Day8\\data.txt");
        }



        private void PartOne(string[] input, int index)
        {
            List<int> actionsVisited = new List<int>();
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
                    break;
                }
            }

        }

        private bool RunCheck(int index, string[] _input)
        {
            AccumulatorValue2 = 0;
            List<int> actionsVisited = new List<int>();
            string[] input = _input;
            for (int i = 0; i < input.Length; i++) //Start over the loop again.
            {
                input[i] = String.Concat(input[i].Where(c => !Char.IsWhiteSpace(c)));
                if (!actionsVisited.Contains(i))
                {
                    if (input[i].StartsWith('a')) //If its an accumulator - run as in Pt: 1
                    {
                        AccumulatorValue2 += int.Parse(input[i][3].ToString() + input[i][4..]);
                        actionsVisited.Add(i);
                    }
                    //If this loops index is the same as the mainmethods loop-index
                    //and its a nop, "transform" to a jmp. If index = i and its a jmp = do nothing (i.e tranfsorm to nop)
                    else if (i == index && input[i].StartsWith('n') || i != index && input[i].StartsWith('j'))
                    {
                        actionsVisited.Add(i);
                        i += int.Parse(input[i][3].ToString() + input[i][4..]) - 1;
                    }

                    else { }
                }
                else
                {
                    string show = input[i];
                    return false;
                }

            }

            return true;

        }
        //NOTE: Initially, i though i should alter the string from nop => jmp and vice versa.
        //Obviously wrong, since what i have to do is to check for the last nop / jmp that breaks the loop.
        //Final solutions changes for what conditions nop and jmp change the loop-iteration.
        private void PartTwo(string[] input, int index)
        {
            // We modify the rules for each nop or jmp, one at a time.
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].StartsWith('j') || input[i].StartsWith('n')) {
                    if (RunCheck(i, input)) break;
                    
                }

            }

        }



    }
}

    





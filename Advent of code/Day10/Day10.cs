using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
namespace Advent_of_code.Day10
{
    public class Day10
    {
        public int AnswerOne { get; set; }
        public ulong AnswerTwo { get; set; }

        public Day10()
        {
            var input = ParseDataToStringArray();
            
            AnswerOne = (int)PartOne(input);
            AnswerTwo = PartTwo(input);
        }

        private List<ulong> ParseDataToStringArray()
        {
            string[] data = File.ReadAllLines("C:\\Users\\marte\\source\\repos\\AdventOfCode2020\\Advent of code\\Day10\\data.txt");
           
            return data.Select(x => ulong.Parse(x)).OrderBy(x => x).ToList();
        }
        List<ulong> differences = new List<ulong>();
       public ulong counter = 0;
        public int PartOne(List<ulong> input)
        {

            ulong joltageToCheckAgainst = (ulong)input.FindAll(x => x > 0 && x <= 3).Min();
            differences.Add(joltageToCheckAgainst);
            for (int i = 0; i < input.Count - 1; i++)
            {
                ulong newAdapter = (ulong)input.FindAll(x => x > joltageToCheckAgainst && x <= joltageToCheckAgainst + 3).Min();
                differences.Add((newAdapter - joltageToCheckAgainst));
                joltageToCheckAgainst = newAdapter;

            }
            return differences.FindAll(x => x == 1).Count * (differences.FindAll(x => x == 3).Count + 1);
        }

        public ulong PartTwo(List<ulong> input)
        {
            //Code inspo from reddit \AdventOfCode

            input.Insert(0, 0);
            input.Add(input[^1] + 3);
            var steps = new ulong[input.Count - 1]; // There are 100 adapters in total.
            steps[0] = 1; // Theres always only 1 way of reaching the 2nd item in the list.
            foreach (var adapter in Enumerable.Range(1, input.Count - 2)) //We want to check all items in the input, starting at index 1 (value = 1)
            {
                foreach (var j in Enumerable.Range(0, adapter)) //We check every index in the list. If the if-statement returns true, we know
                    //that the adapter is within range. Therefore we can sum the ways of getting to that adapter.
                {

                    if (input[adapter] - input[j] <= 3)
                    {
                        steps[adapter] += steps[j];
                    }
                }
            }
            return steps.Last();
        }
      
       
    }


    
}

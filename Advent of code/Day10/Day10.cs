using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
namespace Advent_of_code.Day10
{
    public class Day10
    {


        public Day10()
        {
            var input = ParseDataToStringArray();
            
            PartOne(input);
            PartTwo(input);
        }

        private List<ulong> ParseDataToStringArray()
        {
            string[] data = File.ReadAllLines("C:\\Users\\marte\\source\\repos\\AdventOfCode2020\\Advent of code\\Day10\\data.txt");
           
            return data.Select(x => ulong.Parse(x)).OrderBy(x => x).ToList();
        }
        List<ulong> differences = new List<ulong>();
       public ulong counter = 0;
        public void PartOne(List<ulong> input)
        {

            ulong joltageToCheckAgainst = (ulong)input.FindAll(x => x > 0 && x <= 3).Min();
            differences.Add(joltageToCheckAgainst);
            for (int i = 0; i < input.Count - 1; i++)
            {
                ulong newAdapter = (ulong)input.FindAll(x => x > joltageToCheckAgainst && x <= joltageToCheckAgainst + 3).Min();
                differences.Add((newAdapter - joltageToCheckAgainst));
                joltageToCheckAgainst = newAdapter;

            }
            var sum = differences.FindAll(x => x == 1).Count * (differences.FindAll(x => x == 3).Count + 1);
        }

        public void PartTwo(List<ulong> input)
        {
            input.Insert(0, 0);
            input.Add(input[^1] + 3);
            Check(input);

       
            
        }
        HashSet<ulong> solution = new HashSet<ulong>();
        public ulong Check(List<ulong> input)

        {
            foreach (var inta in input) {
                Console.WriteLine(inta + "   Index: " + input.IndexOf(inta));
            }
                var steps = new ulong[input.Count-1]; // There are 100 adapters in total.
                steps[0] = 1; // Theres always only 1 way of reaching the 2nd item in the list.
                foreach (var adapter in Enumerable.Range(1, input.Count - 2))
                {
                    foreach (var j in Enumerable.Range(0, adapter))
                    {
                    ulong test1 = input[adapter];
                    ulong test2 = input[j];

                        if (input[adapter] - input[j] <= 3)
                        {
                            steps[adapter] += steps[j];
                        }
                    }
                }
                return steps.Last();

           

            //if (index < 0) return false;
            //{


            //if (input.Contains(input[index] - 1))
            //{
            //        solution.Add(input[index] - 1);
            //    counter++;
            //    Check(input.IndexOf(input[index] - 1), input);
            //}
            //else if (input.Contains(input[index] - 2))
            //{
            //        solution.Add(input[index] - 2);
            //        counter++;
            //    Check(input.IndexOf(input[index] - 2), input);
            //}
            //else if (input.Contains(input[index] - 3))
            //{
            //        solution.Add(input[index] - 3);
            //        counter++;
            //    Check(input.IndexOf(input[index] - 3), input);
            //}
            //}
            //return true;


        }
    }


    
}

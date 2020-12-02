using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent_of_code.Day1
{
    public class Day1
    {
        public int[] Numbers { get; set; }
        public int SolutionPartOne { get; set; }
        public int SolutionPartTwo { get; set; }
        public Day1()
        {
            Numbers = ParseStringToIntArr();
            SolutionPartOne = SolutionPtOne();
            SolutionPartTwo = SolutionPtTwo();
        }

        public int[] ParseStringToIntArr()
        {
            string stringOfNumbers = File.ReadAllText("C:\\Users\\Marten\\source\\repos\\Advent of code\\Advent of code\\Day1\\listofnumbers.txt");
            int[] array = Array.ConvertAll(stringOfNumbers.Split(','), int.Parse);
            return array;
        }
       
        public int SolutionPtOne()
        {
            int solution = 0;
            for (var i = 0; i < Numbers.Length; i++)
            {
                for (var j = 0; j < Numbers.Length; j++) {
                if ((Numbers[i]+Numbers[j]) == 2020)
                    {
                       return Numbers[i] * Numbers[j];
                        
                    }                   
                }
  
            }
            return solution;   
        }

        public int SolutionPtTwo()
        {
            int solution = 0;
            for (var i = 0; i < Numbers.Length; i++)
            {
                for (var j = 0; j < Numbers.Length; j++)
                {
                    for (var k = 0; k < Numbers.Length; k++)
                    if ((Numbers[i] + Numbers[j] + Numbers[k]) == 2020)
                    {
                            return Numbers[i] * Numbers[j] * Numbers[k];
                            
                    }
                }
            }
            return solution;
        }


    }
}

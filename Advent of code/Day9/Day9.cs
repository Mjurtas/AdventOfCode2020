using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Advent_of_code.Day9
{
    class Day9
    {
        public ulong PartOneAnswer { get; set; }
        public ulong PartTwoAnswer { get; set; }
        public Day9()
        {
            var input = ParseDataToIntArray();
            PartOneAnswer = PartOne(input);
            PartTwoAnswer = PartTwo(PartOne(input), input);
        }


        private List<ulong> ParseDataToIntArray()
        {
            List<ulong> input = new List<ulong>();
            string[] data = File.ReadAllLines("C:\\Users\\marte\\source\\repos\\AdventOfCode2020\\Advent of code\\Day9\\data.txt");
            foreach(var line in data)
            {
                input.Add(ulong.Parse(line));
            }
            return input;
        }
        private ulong PartOne(List<ulong> input)
        {
            int startIndex = -1;
           for (int i = 25; i < input.Count-1; i++)
            {
                startIndex++;
                if(!IsValidNumber(input[i], i, input, startIndex))
                {
                 return input[i];
                }
            }
            return 0;
        }
        private bool IsValidNumber(ulong valueToCheck, int indexToCheck, List<ulong> input, int startIndex)
        {
            for (int j = startIndex; j < indexToCheck; j++)
            {
                for (int k = startIndex; k < indexToCheck; k++)
                {
                    if ((input[j] + input[k]) == valueToCheck && input[j] != input[k])
                    {
                        return true;
                    }       
                }
            }
            return false;
        }
        public ulong PartTwo(ulong expectedSum, List<ulong> input)
        {
            List<int> numbers = new List<int>();
          
            for (int i = 0; i < input.Count - 1; i++)
            {
                int tempSum = 0;
                numbers.Clear();
                for (int j = i; j < input.Count; j++)
                {
                    if ( tempSum == (int)expectedSum)
                    {
                        var orderedList = numbers.OrderBy(x => x);
                        return (ulong)(numbers[0] + orderedList.Last());
                    }
                    else if (tempSum > (int)expectedSum)
                    { 
                        break; 
                    }
                    else {
                        numbers.Add((int)input[j]);
                        tempSum = numbers.Sum();
                    }
                }
                //while(tempSum != (int)expectedSum && tempSum < (int)expectedSum && j < input.Count - 1)
                //{
                //    numbers.Add((int)input[j]);
                //    tempSum = numbers.Sum();
                //    j++;

                //}
                

            }
            return expectedSum;
        }
    }
}

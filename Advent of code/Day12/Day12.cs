using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent_of_code.Day12
{
    class Day12
    {


        public int AnswerPartOne { get; set; }
        public int AnswerPartTwo { get; set; }

        public Day12()
        {
            string[] input = ParseDataToStringArray();
            PartOne(input);
        }
        private string[] ParseDataToStringArray()
        {
            string[] data = File.ReadAllLines("C:\\Users\\marte\\source\\repos\\AdventOfCode2020\\Advent of code\\Day12\\data.txt");
            return data;
        }


        
        int[] values = new int[] { 0, 0, 0, 0 };
        int[] facing = new int[] { 0, 1, 2, 3 };
        int currentDirection = 1;

        


        public void PartOne(string[] input)
        {
            foreach (var direction in input)
            { 

                char dir = direction[0];
                int value = int.Parse(direction.Substring(1));

                switch (dir)
                {
                    case 'F':
                        values[facing[currentDirection]] += value;
                        break;
                    case 'N':
                        values[0] += value;
                        break;
                    case 'E':
                        values[1] += value;
                        break;
                    case 'S':
                        values[2] += value;
                        break;
                    case 'W':
                        values[3] += value;
                        break;
                    case 'R':
                        int turnright = value / 90;
                        currentDirection = (currentDirection + turnright) % 4;
                        break;
                    case 'L':
                        TurnLeft(value);
                        break;
                    default:
                        Console.WriteLine("Error");
                    break;
                }
            }

            AnswerPartOne = (int)Math.Abs(values[0] - values[2]) + Math.Abs(values[1] - values[3]);
        }
        public void TurnLeft(int value)
        {
            int turnleft = value / 90;
            for (int i = 0; i < turnleft; i++)
            {

                switch (currentDirection)
                {
                    case 0:
                        currentDirection = 3;
                        break;
                    case 1:
                        currentDirection = 0;
                        break;
                    case 2:
                        currentDirection = 1;
                        break;
                    case 3:
                        currentDirection = 2;
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;

                }
            }

        }

    }
}

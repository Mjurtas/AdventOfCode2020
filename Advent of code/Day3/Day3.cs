using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent_of_code.Day3
{
    class Day3
    {

        public string[] Layout { get; set; }
        public int TreeCountPartOne { get; set; }
        public ulong TreeCountPartTwo { get; set; }

        public Day3()
        {
            Layout = ParseDataToStringArray();
            TreeCountPartOne = SolutionPartOne(Layout, 1, 3);
            TreeCountPartTwo = SolutionPartTwo();

        }
       
        private string[] ParseDataToStringArray()
        {
            string data = File.ReadAllText("C:\\Users\\marte\\source\\repos\\AdventOfCode2020\\Advent of code\\Day3\\slopelayout.txt");
            return data.Split(Environment.NewLine);
        }

        private int SolutionPartOne(string[] slope, int down, int right)
        {
            
            int trees = 0;
            int column = 0;
            int width = slope[0].Length;

            for (int i = down; i < slope.Length; i += down)
            {
                column += right;
                if (column >= width) column %= width;
                
                if (slope[i][column] == '#')  trees++;
                
            }
            return trees;
        }

        private ulong SolutionPartTwo()
        {
            int[,] slopes = new int[,] { { 1, 1 }, { 1, 3 }, { 1, 5 }, { 1, 7 }, { 2, 1 } };
            ulong result = 1;
            for (int i = 0; i < slopes.Length / 2; i++)
            {
                result *= (ulong)SolutionPartOne(Layout, slopes[i, 0], slopes[i, 1]);

            };
            return result;
        }
            
            

    }
}

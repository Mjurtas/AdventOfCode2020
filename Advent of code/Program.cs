using System;
using System.IO;

namespace Advent_of_code
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Day1.Day1 day1 = new Day1.Day1();
            Console.WriteLine("1th December Pt.1 = " + day1.SolutionPartOne);
            Console.WriteLine("1th December Pt.2 = " + day1.SolutionPartTwo);

            Day2.Day2 day2 = new Day2.Day2();
            Console.WriteLine("2nd December Pt.1   " + day2.NumberOfValidPasswordsPartOne);
            Console.WriteLine("2nd December Pt.2   " + day2.NumberOfValidPasswordsPartTwo);
        }
    }
}

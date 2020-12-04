using System;
using System.IO;

namespace Advent_of_code
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Day1.Day1 day1 = new Day1.Day1();
            Console.WriteLine("1th December Pt.1 = " + day1.SolutionPartOne + " is the product of the two numbers.");
            Console.WriteLine("1th December Pt.2 = " + day1.SolutionPartTwo + " is the product of the three numbers.");
          
            Day2.Day2 day2 = new Day2.Day2();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("2nd December Pt.1   " + day2.NumberOfValidPasswordsPartOne + " valid passwords.");
            Console.WriteLine("2nd December Pt.2   " + day2.NumberOfValidPasswordsPartTwo + " valid passwords.");
            Console.WriteLine("------------------------------");

            Day3.Day3 day3 = new Day3.Day3();
            Console.WriteLine("3rd December Pt.1    "+ day3.TreeCountPartOne + " trees were hit in the slope of 1 down and 3 right.");
            Console.WriteLine("3rd December Pt.2    "+ day3.TreeCountPartTwo + " trees were hit when multiplying all of the given slopes.");
            Console.WriteLine("------------------------------");
            Day4.Day4 day4 = new Day4.Day4();
            Console.WriteLine("4th December Pt.1    " + day4.NumberOfValidPassportsPartOne + " passports were valid according to the initial rules.");
            Console.WriteLine("4th December Pt.2    " + day4.NumberOfValidPassportsPartTwo + " passports were valid according to the new rules in part two.");
        }
    }
}

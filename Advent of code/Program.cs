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
            Console.WriteLine("------------------------------");
            Day7.Day7 day7 = new Day7.Day7();
            Console.WriteLine("7th December Pt.1    " + day7.ShinyGoldBags + " bags can hold goldbags.");
            Console.WriteLine("7th December Pt.2    " + day7.BagsInShinyGoldBag + " bags can be held by a goldsack.");
            Console.WriteLine("------------------------------");
            Day8.Day8 day8 = new Day8.Day8();
            Console.WriteLine("8th December Pt.1    " + day8.AccumulatorValue + " is the accumulated value before the loop hits a already fired command.");
            Console.WriteLine("8th December Pt.2    " + day8.AccumulatorValue2 + " is the accumulated value when the loop gets to run til end.");
            Console.WriteLine("------------------------------");
            Day9.Day9 day9 = new Day9.Day9();
            Console.WriteLine("9th December Pt.1    " + day9.PartOneAnswer + " is the malfunctioning number.");
            Console.WriteLine("9th December Pt.2    " + day9.PartTwoAnswer + " is the sum of the two requested numbers.");
            Console.WriteLine("------------------------------");
        }
    }
}

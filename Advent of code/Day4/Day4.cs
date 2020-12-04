using Advent_of_code.Day2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Advent_of_code.Day4
{
    class Day4
    {
        public List<string> FullListOfPassports { get; set; }
        public int NumberOfValidPassportsPartOne { get; set; }
        public int NumberOfValidPassportsPartTwo { get; set; }
        string[] mandatoryKeys = new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
        
       
        public Day4()
        {
            string [] input = ParseDataToStringArray();
            FullListOfPassports = OrganizePassports(input);
            NumberOfValidPassportsPartOne = ValidPassports(FullListOfPassports).Count;
            NumberOfValidPassportsPartTwo = ValidPassportsPartTwo(ValidPassports(FullListOfPassports));



        }
        private string[] ParseDataToStringArray()
        {
           string[] data = File.ReadAllLines("C:\\Users\\Marten\\source\\repos\\Advent of code\\Advent of code\\Day4\\data.txt");
            return data;
        }
       
        public List<string> OrganizePassports(string[] data)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != "") { 
                    for (int j = i +1; j < data.Length; j++)
                    { 
                        if (data[j] != "")
                        {
                            
                            data[i] += " " + data[j];
                            data[j] = "";
                        }
                        else {        
                            break; 
                        }
                    }
                }
            }
            foreach (var line in data)
            {
                if (line != "")
                {
                    list.Add(line);
                }
            }

            return list;
        }
        public List<string> ValidPassports (List<string> data)
        {
            List<string> validPassports = new List<string>();
            int counter = 0;
            foreach (var pass in data)
            {
                counter = 0;
                for (int i = 0; i < mandatoryKeys.Length; i++)
                {
                    if (pass.Contains(mandatoryKeys[i])) { counter++; };
                }
                if (counter == 7) { validPassports.Add(pass); };
            }
            return validPassports;
        } 

        public int ValidPassportsPartTwo(List<string> data)
        {
            List<string> listOfValidPassportsPtTwo = new List<string>();
            
            Regex byr = new Regex(@"byr:19[2-9][0-9]\s|byr:200[0-2]\s");
            Regex iyr = new Regex(@"iyr:201[0-9]\s|iyr:2020\s");
            Regex eyr = new Regex(@"eyr:202[0-9]\s|eyr:2030\s");
            Regex hgt = new Regex(@"hgt:1[5-8][0-9]cm\s|hgt:19[0-3]cm\s|hgt:59in\s|hgt:6[0-9]in\s|hgt:7[0-6]in\s");
            Regex hcl = new Regex(@"hcl:#[a-f0-9]{6}\s");
            Regex ecl = new Regex(@"ecl:brn\s|ecl:blu\s|ecl:amb\s|ecl:gry\s|ecl:hzl\s|ecl:oth\s|ecl:grn\s");
            Regex pid = new Regex(@"pid:\d{9}\s");

            for (int i = 0; i < data.Count; i++)
            {
                data[i] += " ";
                if (byr.IsMatch(data[i]) && iyr.IsMatch(data[i]) && eyr.IsMatch(data[i]) && hgt.IsMatch(data[i]) && hcl.IsMatch(data[i]) && ecl.IsMatch(data[i]) && pid.IsMatch(data[i])) {
                    listOfValidPassportsPtTwo.Add(data[i]);
                };
                        

            }
            return listOfValidPassportsPtTwo.Count;
        }
    }


}

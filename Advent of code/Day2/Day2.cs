using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Advent_of_code.Day2
{
    class Day2
    {

        public string[] Data { get; set; }
        public int NumberOfValidPasswordsPartOne { get; set; }
        public int NumberOfValidPasswordsPartTwo { get; set; }
        public List<Password> List { get; set; } = new List<Password>();
        

        public Day2()
        {
            Data = ParseDataToStringArray();
            List = OrganizePasswords(Data);
            NumberOfValidPasswordsPartOne = CountNumberOfValidPasswordsPartOne();
            NumberOfValidPasswordsPartTwo = CountNumberOfValidPasswordsPartTwo();
        }

        private string[] ParseDataToStringArray()
        {
            string data = File.ReadAllText("C:\\Users\\marte\\source\\repos\\AdventOfCode2020\\Advent of code\\Day2\\listofpasswords.txt");
            return data.Split(Environment.NewLine);
            
        }

        public List<Password> OrganizePasswords(string[] data)
        {

            
            for (int i = 0; i < Data.Length; i++)
            {
                string pass = data[i];
                Password password = new Password();
                password.MinChar = GetMinChar(pass);
                password.MaxChar = GetMaxChar(pass);
                password.CharToTest = GetCharToTest(pass);
                password.PasswordString = GetStringToTest(pass);
                List.Add(password);
            }
            return List;
        }
        #region Assigning different properties via substrings
        /*Could have done it in the constructor for password in one line ofc..but more readable this way imo.*/
        private string GetStringToTest(string data)
        {
            return data.Substring(data.IndexOf(':') + 2, (data.Length -((data.IndexOf(':') + 2))));
        }

        private int GetMinChar(string data)
        {
            return int.Parse(data.Substring(0, data.IndexOf('-')));
        }
        private int GetMaxChar(string data)
        {
            return int.Parse(data.Substring((data.IndexOf('-') + 1), (data.IndexOf(' ') - data.IndexOf('-'))));
        }

        private string GetCharToTest(string data)
        {
            return data.Substring((data.IndexOf(':') - 1), 1);
        }
        #endregion

        public int CountNumberOfValidPasswordsPartOne()
        {
            int characterCounter = 0;
            foreach (var password in List)
            {
                characterCounter = password.PasswordString.Count(chars => chars.ToString() == password.CharToTest);
                if (characterCounter >= password.MinChar && characterCounter <= password.MaxChar)
                {
                    password.Valid = true;
                }
            }
            return List.Count(pass => pass.Valid == true);
        }

        public int CountNumberOfValidPasswordsPartTwo()
        {
            foreach (var pw in List)
            {
                if (pw.PasswordString[pw.MinChar-1].ToString() == pw.CharToTest && pw.PasswordString[pw.MaxChar - 1].ToString() == pw.CharToTest)
                {
                    pw.Valid = false;
                }
                else if (pw.PasswordString[pw.MinChar - 1].ToString() != pw.CharToTest && pw.PasswordString[pw.MaxChar - 1].ToString() != pw.CharToTest)
                {
                    pw.Valid = false;
                }

                else
                {
                    pw.Valid = true;
                }
            }

            return List.Count(Password => Password.Valid == true);
        }
        
    }
}

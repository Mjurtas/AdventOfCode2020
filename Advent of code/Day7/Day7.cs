using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_code.Day7
{
    class Day7
    {
        public int ShinyGoldBags { get; set; }
        public Day7()
        {
            string[] input = ParseDataToStringArray();
            ShinyGoldBags = NumberOfShinyBags(input);
        }
        private string[] ParseDataToStringArray()
        {
            string[] data = File.ReadAllLines("C:\\Users\\marte\\source\\repos\\AdventOfCode2020\\Advent of code\\Day7\\data.txt");
            return data;
        }

        public int NumberOfShinyBags(string[] input)
        {
            List<Bag> listOfBags = new List<Bag>();
            for (int i = 0; i < input.Length; i++)
            {
                
                Bag bag = new Bag();
                string[] extractColors = input[i].Split(" ");
                bag.BagColor = extractColors[0]+ " " +extractColors[1]+" ";
                listOfBags.Add(bag);
            }

            for (int i = 0; i < input.Length; i++)
            {
                foreach (var bag in listOfBags)
                {
                    if (input[i].Contains(bag.BagColor) && input[i].IndexOf(bag.BagColor) != 0)
                    { 
                        string numberOf = input[i][input[i].IndexOf(bag.BagColor) - 2].ToString();
                        listOfBags[i].CanContain.Add(new Bag { BagColor = bag.BagColor, TotalBags = int.Parse(numberOf)  /*numberOf, bag.BagColor*/ }); ;
                        listOfBags[i].ContainInfo += bag.BagColor;
                        listOfBags[i].TotalBags += int.Parse(numberOf);
                    }
                }
            }
            List<Bag> containsShinyBags = new List<Bag>();
            // Adding all the bags that carries shiny bags in to a new list.

            for (int i = 0; i < listOfBags.Count-1; i++)
            {
                if (listOfBags[i].ContainInfo.Contains("shiny gold"))
                {
                    containsShinyBags.Add(listOfBags[i]);
                }
            }

            // For all the bags in the full list, that carries bagcolors included in the list that carries shiny bags. Bag-ception...
           
            for (int i = 0; i < containsShinyBags.Count; i++)
            {
                List<Bag> tempList = listOfBags.FindAll(x => x.ContainInfo.Contains(containsShinyBags[i].BagColor));
                //If the bag in the tempList doesnt exist in the list of bags that carries shiny bags.
                // We get the "parent" of every bag.
                foreach (var tempbag in tempList)
                {
                    if (!containsShinyBags.Contains(tempbag))
                    {
                        containsShinyBags.Add(tempbag);
                    }
                }
            }

            PartTwo(listOfBags);

            return containsShinyBags.Count;

        }

        

        public int PartTwo(List<Bag> listOfBags)
        {
            var shinyBag = listOfBags.FindAll(x => x.BagColor == "shiny gold ");

           int count = 0;

            for (int i = 0; i < shinyBag.Count; i++)
            {
                foreach (var bag in shinyBag[i].CanContain)
                {
                    for (int j = 0; j < bag.TotalBags ; j++ )
                    shinyBag.Add(listOfBags.Find(x => x.BagColor == bag.BagColor));
                    
                }
            } 
            foreach (var bag in shinyBag)
            {
                count += bag.TotalBags;
            }

            return count;
        }
      
    }
}

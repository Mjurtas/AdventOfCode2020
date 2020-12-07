using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_code.Day7
{
    public class Bag
    {
        public string BagColor { get; set; }
        public List<string[]> CanContain { get; set; } = new List<string[]>();
        public string ContainInfo { get; set; } = " ";
    }
}

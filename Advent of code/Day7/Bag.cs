using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_code.Day7
{
    public class Bag
    {
        public string BagColor { get; set; }
        public List<Bag> CanContain { get; set; } = new List<Bag>();
        public string ContainInfo { get; set; } = " ";
        public int TotalBags { get; internal set; }

       
    }
}

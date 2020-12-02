using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_code.Day2
{
    public class Password
    {
        public int MinChar { get; set; }
        public int MaxChar { get; set; }
        public string PasswordString { get; set; }
        public string CharToTest { get; set;}
        public bool Valid { get; set; } = false;
    }
}

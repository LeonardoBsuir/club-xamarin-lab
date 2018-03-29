using System;
using System.Collections.Generic;
using System.Text;

namespace Club
{
    class Team : BaseItem
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Stadium { get; set; }
        public string Coach { get; set; }
        public int Cost { get; set; }

        public override string ToString()
        {
            return $"{ID}, {Name}, {City}, {Country}, {Stadium}, {Coach}, {Cost}";
        }
    }
}
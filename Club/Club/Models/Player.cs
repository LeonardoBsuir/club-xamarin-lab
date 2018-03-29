using System;
using System.Collections.Generic;
using System.Text;

namespace Club
{
    class Player : BaseItem
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Team { get; set; }
        public int Cost { get; set; }

        public override string ToString()
        {
            return $"{ID}, {FirstName}, {LastName}, {Position}, {Team}, {Cost}";
        }
    }
}

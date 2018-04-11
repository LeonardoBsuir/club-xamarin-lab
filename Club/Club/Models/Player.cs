using System;
using System.Collections.Generic;
using System.Text;

namespace Club
{
    public class Player : BaseItem
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public int Cost { get; set; }
        public bool IsVisible { get; set; }

        public override string ToString()
        {
            return $"{ID}, {FirstName}, {LastName}, {Position}, {PhoneNumber}, {Cost}";
        }
    }
}

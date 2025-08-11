using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel : IProduct
    {
        public Dictionary<string, double> _prices = new Dictionary<string, double>()
        {
            {"Onion", 0.49},
            {"Plain", 0.39},
            {"Everything", 0.49},
            {"Sesame", 0.49},
        };
        public double Price { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }
       
        public Bagel(string variant) 
        {
            Name = "Bagel";
            Variant = variant;
            Price = _prices[variant];

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public static class ProductCatalog
    {
        private static readonly Dictionary<string, (string Name, double Price, string Variant)> _products = new()
        {
            { "BGLO", ("Bagel", 0.49, "Onion") },
            { "BGLP", ("Bagel", 0.39, "Plain") },
            { "BGLE", ("Bagel", 0.49, "Everything") },
            { "BGLS", ("Bagel", 0.49, "Sesame") },
            { "COFB", ("Coffee", 0.99, "Black") },
            { "COFW", ("Coffee", 1.19, "White") },
            { "COFC", ("Coffee", 1.29, "Capuccino") },
            { "COFL", ("Coffee", 1.29, "Latte") },
            { "FILB", ("Filling", 0.12, "Bacon") },
            { "FILE", ("Filling", 0.12, "Egg") },
            { "FILC", ("Filling", 0.12, "Cheese") },
            { "FILX", ("Filling", 0.12, "Cream Cheese") },
            { "FILS", ("Filling", 0.12, "Smoked Salmon") },
            { "FILH", ("Filling", 0.12, "Ham") }
        };

        public static (string Name, double Price, string Variant) GetProductInfo(string code)
        {
            if (_products.TryGetValue(code, out var product))
            {
                return product;
            }
            throw new KeyNotFoundException($"Product code '{code}' not found");
        }
    }
}

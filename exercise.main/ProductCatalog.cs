using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public static class ProductCatalog
    {
        private static readonly Dictionary<string, (string Name, decimal Price, string Variant)> _products = new()
        {
            { "BGLO", ("Bagel", 0.49m, "Onion") },
            { "BGLP", ("Bagel", 0.39m, "Plain") },
            { "BGLE", ("Bagel", 0.49m, "Everything") },
            { "BGLS", ("Bagel", 0.49m, "Sesame") },
            { "COFB", ("Coffee", 0.99m, "Black") },
            { "COFW", ("Coffee", 1.19m, "White") },
            { "COFC", ("Coffee", 1.29m, "Capuccino") },
            { "COFL", ("Coffee", 1.29m, "Latte") },
            { "FILB", ("Filling", 0.12m, "Bacon") },
            { "FILE", ("Filling", 0.12m, "Egg") },
            { "FILC", ("Filling", 0.12m, "Cheese") },
            { "FILX", ("Filling", 0.12m, "Cream Cheese") },
            { "FILS", ("Filling", 0.12m, "Smoked Salmon") },
            { "FILH", ("Filling", 0.12m, "Ham") }
        };

        public static (string Name, decimal Price, string Variant) GetProductInfo(string code)
        {
            if (_products.TryGetValue(code, out var product))
            {
                return product;
            }
            throw new KeyNotFoundException($"Product code '{code}' not found");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Filling : IProduct
    {
        public double Price { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }

        public Filling(string SKU) 
        {
            var info = ProductCatalog.GetProductInfo(SKU);
            Price = info.Price;
            Name = info.Name;
            Variant = info.Variant;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel : IProduct
    {
        public double Price { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }

        public int _fillingPrice;
       
        public Bagel(string SKU) 
        {
            //Name = "Bagel";
            //Variant = variant;
            //Price = _prices[variant];
            //_fillingPrice = 0;
            var info = ProductCatalog.GetProductInfo(SKU);
            Price = info.Price;
            Name = info.Name;
            Variant = info.Variant;

        }
    }
}

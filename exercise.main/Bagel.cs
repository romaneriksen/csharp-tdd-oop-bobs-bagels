using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel : IProduct
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }

        public decimal _fillingPrice { get; set; } = 0;

        public List<Filling> fillings { get; set; }
       
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
            fillings = new List<Filling>();

        }

        public void AddFilling(Filling filling)
        {
            fillings.Add(filling);
            //_fillingPrice += filling.Price;
            Price += filling.Price;
        }

        public List<Filling> GetFillings() {return fillings;}
    }
}

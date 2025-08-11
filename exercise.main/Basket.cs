using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<IProduct>_basket { get; }
        private static int _capacity { get; set; } = 3;

        public Basket() 
        {
            _basket = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            _basket.Add(product);
        }


        public int Count()
        {
            return _basket.Count;
        }

        public List<IProduct> GetBasket { get { return _basket; } }
    }
}

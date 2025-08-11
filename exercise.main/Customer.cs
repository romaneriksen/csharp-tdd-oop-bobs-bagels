using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Customer
    {
        private Basket _basket { get; set; }

        public Customer()
        {
            _basket = new Basket();
        }

        public void AddProduct(IProduct product)
        {
            _basket.AddProduct(product);
        }

        public Basket GetBasket {  get { return _basket; } }
    }


}

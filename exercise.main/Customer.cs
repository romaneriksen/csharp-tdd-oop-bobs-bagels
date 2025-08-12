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

        public void RemoveProduct(IProduct product)
        {
            _basket.RemoveProduct(product);
        }

        public decimal BasketCost()
        {
            return _basket.ComputeCost();
        }

        public Basket GetBasket {  get { return _basket; } }
    }


}

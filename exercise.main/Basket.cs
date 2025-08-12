using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<IProduct> _basket { get; }
        public static int Capacity = 3;

        public Basket() 
        {
            _basket = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            if (_basket.Count() == Capacity)
            {
                throw new InvalidOperationException("Basket capacity full - you can not add more items");
            }
            else
            {
                _basket.Add(product);
            }
        }

        public void RemoveProduct(IProduct product)
        {
            //_basket.Remove(product);
            if (_basket.Contains(product))
            {
                _basket.Remove(product);
            }
            else
            {
                throw new InvalidOperationException("Product does not exist in basket");
            }
        }

        public double ComputeCost()
        {
            return _basket.Sum(x => x.Price);

        }

        public int Count()
        {
            return _basket.Count;
        }

        public List<IProduct> GetBasket { get { return _basket; } }
    }
}

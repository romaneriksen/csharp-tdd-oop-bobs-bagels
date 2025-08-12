using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        public decimal ComputeCost()
        {
            //return _basket.Sum(x => x.Price) - this.ComputeDiscounts();
            var info = this.ComputeDiscounts();
            decimal total = info.Discounts + info.RemainingItems.Sum(x => x.Price);
            return total;
        }

        public (decimal Discounts, List<IProduct> RemainingItems) ComputeDiscounts()
        {
            List<IProduct> bagels = _basket.Where(x => x is Bagel).OrderBy(v => v.Price).ToList();
            List<IProduct> coffees = _basket.Where(x => x is Coffee).OrderBy(v => v.Price).ToList();

            decimal sixBagels = 0m;
            decimal twelveBagels = 0m;
            decimal coffeeBagels = 0m;

            int remainingBagels = 0;
            int mod = bagels.Count % 12;

            if (bagels.Count > 11)
            {
                // USe list List.RemoveRange() starting at zero
                int val = bagels.Count - mod;
                twelveBagels = val * 3.99m / (12m);
                bagels.RemoveRange(0,val);
            }
            if (mod > 5)
            {
                sixBagels = 2.49m;
                remainingBagels = mod - 6;
                bagels.RemoveRange(0, 6);
            }
            else
            {
                remainingBagels = mod;
            }

            foreach (IProduct coffee in coffees)
            {
                if (coffee.Variant == "Black" && remainingBagels > 0)
                {
                    coffeeBagels += 1.25m;
                    remainingBagels--;
                    bagels.RemoveAt(0);
                    //coffees.Remove(coffee);
                    coffee.Price = 0m;
                }
            }

            decimal discounts = twelveBagels + sixBagels + coffeeBagels;
            List<IProduct> remainingItems = bagels.Concat(coffees).ToList();

            return (discounts, remainingItems);
        }

        public int Count()
        {
            return _basket.Count;
        }

        public List<IProduct> GetBasket { get { return _basket; } }
    }
}

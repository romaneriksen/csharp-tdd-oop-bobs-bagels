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
        private List<Filling> _bagelFillings { get; } = new List<Filling>();
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
                if (product is Bagel)
                {
                    Bagel bagel = (Bagel)product;
                    bagel.GetFillings().ForEach(x => _bagelFillings.Add(x));
                }
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
            decimal total = info.Discounts + info.RemainingItems.Sum(x => x.Price) + _bagelFillings.Sum(x => x.Price);
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

        public string GetReceipt()
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, (string Name, int count, decimal priceTotal)> productCount = new();
            foreach (IProduct item in _basket)
            {
                if (productCount.ContainsKey(item.Variant))
                {
                    int val = productCount[item.Variant].count + 1;
                    decimal price = productCount[item.Variant].priceTotal;
                    productCount[item.Variant] = (item.Name, val, price+item.Price);
                }
                else
                {
                    productCount[item.Variant] = (item.Name, 1, item.Price);
                }
            }
            int totalWidth = 30;
            string title = "~~~ Bob's Bagels ~~~";
            string time = DateTime.Now.ToString();
            string end = "Thank you for your order!";

            sb.AppendFormat("{0," + (((totalWidth - title.Length) / 2) + title.Length) + "}", title);
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendFormat("{0," + (((totalWidth - time.Length) / 2) + time.Length) + "}", time);
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine(new String('-', 30));
            sb.AppendLine();
            //sb.AppendLine();

            foreach (var item in productCount)
            {
                sb.AppendFormat("{0,-20}{1,-5}{2,-5}", item.Key, item.Value.count, item.Value.priceTotal);
                sb.AppendLine();    
            }

            sb.AppendLine();
            sb.AppendLine(new String('-', 30));
            sb.AppendLine();
            sb.AppendFormat("{0," + (((totalWidth - end.Length) / 2) + end.Length) + "}", end);

            return sb.ToString();
        }


        public int Count()
        {
            return _basket.Count;
        }

        public List<IProduct> GetBasket { get { return _basket; } }
    }
}

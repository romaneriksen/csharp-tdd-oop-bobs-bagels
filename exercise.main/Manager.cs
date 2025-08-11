using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Manager
    {
        public Manager() 
        { 
        }

        public void ChangeBasketCapacity(int newCapacity)
        {
            Basket.Capacity = newCapacity;
        }
    }
}

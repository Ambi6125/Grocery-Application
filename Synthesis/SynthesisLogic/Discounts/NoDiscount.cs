using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisLogic.Discounts
{
    public class NoDiscount : IDiscount
    {
        public double Apply(double price) => price;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisLogic.Discounts
{
    internal interface IDiscount
    {
        double Apply(double price);
    }
}

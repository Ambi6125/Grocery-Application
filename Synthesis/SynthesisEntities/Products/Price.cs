using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisEntities.Products
{
    public class Price
    {
        private static readonly char[] allowedPrefixes = { '€', '$' };
        private double price;
        private char prefix;
        public char Valuta
        {
            get => prefix;
            set
            {
                if (allowedPrefixes.Contains(value))
                {
                    prefix = value;
                }
                else
                {
                    throw new ArgumentException("Not an accepted currency");
                }
            }
        }

        public double Value
        {
            get => price;
            set
            {
                if(value > 0)
                {
                    price = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }

        public override string ToString() => $"{Valuta}{Value}";
    }
}

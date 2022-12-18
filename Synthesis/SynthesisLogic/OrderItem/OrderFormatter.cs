using SynthesisEntities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisLogic.Cart
{
    public class OrderFormatter
    {
        
        public static string Format(IEnumerable<OrderItem> orderItems)
        {
            ArgumentNullException.ThrowIfNull(orderItems);
            if(!orderItems.Any())
                throw new ArgumentOutOfRangeException(nameof(orderItems));
            var sb = new StringBuilder($"{orderItems.First().Product.Name}/{orderItems.First().Quantity}");
            int count = orderItems.Count();
            for(int i = 1; i < count; i++)
            {
                var orderItem = orderItems.ElementAt(i);
                sb.Append($"&{orderItem.Product.Name}/{orderItem.Quantity}");
            }
            return sb.ToString();
        }

        public static IDictionary<string, int> Deformat(string cookieString)
        {
            var dict = new Dictionary<string, int>();
            if (!cookieString.Contains('&') || !cookieString.Contains('/'))
                throw new ArgumentException("Invalid string format");
            string[] cookieItems = cookieString.Split('&');

            foreach(string cookieItem in cookieItems)
            {
                string[] cookieValues = cookieItem.Split('/');
                
                try
                {
                    if (dict.ContainsKey(cookieValues[0]))
                    {
                        dict[cookieValues[0]] += int.Parse(cookieValues[1]);
                    }
                    else
                    {
                        dict.Add(cookieValues[0], int.Parse(cookieValues[1]));
                    }
                }
                catch (FormatException innerException)
                {
                    throw new InvalidOperationException("Invalid quantity", innerException);
                }
            }
            return dict;
        }
    }
}

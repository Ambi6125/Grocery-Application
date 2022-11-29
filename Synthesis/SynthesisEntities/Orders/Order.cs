using SynthesisEntities.Accounts;
using SynthesisEntities.Products;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisEntities.Orders
{
    public class Order : IEnumerable<OrderItem>, ICollection<OrderItem>, IReadOnlyCollection<OrderItem>
    {
        private readonly int? id;
        private List<OrderItem> items;
        private readonly Account orderPlacer;

        public int Count => items.Count;

        public bool IsReadOnly => false;

        public OrderItem this[int index] => index > 0 && index < items.Count ? items[index] : throw new IndexOutOfRangeException();
        public OrderItem? this[Product product] => items.FirstOrDefault(x => x.Product == product, null);

        public Order(Account placer)
        {
            id = null;
            items = new List<OrderItem>();
            orderPlacer = placer;
        }

        public Order(int id, Account placer, ICollection<OrderItem> items)
        {
            this.id = id;
            this.items = items.ToList();
            orderPlacer = placer;
        }

        public IEnumerator<OrderItem> GetEnumerator()
        {
            return new OrderEnumerator(this);
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(OrderItem item)
        {
            items.Add(item);
        }

        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(OrderItem item)
        {
            return items.Contains(item);
        }

        public void CopyTo(OrderItem[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public bool Remove(OrderItem item)
        {
            return items.Remove(item);
        }
    }


    public class OrderEnumerator : IEnumerator<OrderItem>
    {
        private readonly OrderItem[] array;
        private int target;
        public OrderItem Current => array[target];
        object IEnumerator.Current => Current;

        public void Dispose()
        {
            return;
        }
        public void Reset()
        {
            target = 0;
        }

        public bool MoveNext()
        {
            if(target + 1 >= array.Length)
            {
                return false;
            }
            else
            {
                target++;
                return true;
            }
        }

        public OrderEnumerator(IEnumerable<OrderItem> enumeration)
        {
            array = enumeration.ToArray();
            target = 0;
        }
    }
}

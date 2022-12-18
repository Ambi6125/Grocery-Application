using SynthesisEntities.Bonuscards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisLogic.Discounts
{
    public class BonusCartDiscount : IDiscount
    {
        private const int POINTMONEYRATIO = 1; //How many euros every 1 point saves
        private BonusCard card;

        public int UserSpending { get; set; }

        public BonusCartDiscount(BonusCard card)
        {
            this.card = card;
        }

        public double Apply(double price)
        {
            return price - (card.SpendPoints(UserSpending) * POINTMONEYRATIO);
        }
    }
}

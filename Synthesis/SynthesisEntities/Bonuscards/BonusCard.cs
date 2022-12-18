using SynthesisEntities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisEntities.Bonuscards
{
    public class BonusCard
    {
        private CustomerAccount owner;

        private int points;

        public BonusCard(CustomerAccount owner, int points)
        {
            this.owner = owner ?? throw new ArgumentNullException(nameof(owner));
            this.points = points;
        }
        public int Points => points;

        public int SpendPoints(int points)
        {
            if(points > this.points)
            {
                throw new ArgumentOutOfRangeException("Points withdrawn exceed available points");
            }
            this.points -= points;
            return points;
        }
    }
}

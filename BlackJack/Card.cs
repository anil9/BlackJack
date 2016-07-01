using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Card
    {
        public static readonly String KNIGHT = "J";
        public static readonly String QUEEN = "Q";
        public static readonly String KING = "K";
        public static readonly String ACE = "A";
        private readonly int value;
        private readonly String name;
        public Card(int value)
        {
            this.value = value;
            name = value + "";
        }
        public Card(int value, String name)
        {
            this.value = value;
            this.name = name;
        }
        
        public override String ToString()
        {
            return name;
        }
        public int getValue()
        {
            return value;
        }
    }
}

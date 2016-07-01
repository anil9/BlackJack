using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Card
    {
        public static readonly string KNIGHT = "J";
        public static readonly string QUEEN = "Q";
        public static readonly string KING = "K";
        public static readonly string ACE = "A";
        private readonly int value;
        private readonly string name;
        public Card(int value)
        {
            this.value = value;
            name = value + "";
        }
        public Card(int value, string name)
        {
            this.value = value;
            this.name = name;
        }
        
        public override string ToString()
        {
            return name;
        }
        public int GetValue()
        {
            return value;
        }
    }
}

using BlackJack.Enums;

namespace BlackJack
{
    public class Card
    {
        public readonly string Name;
        public readonly int Value;
        

        public Card(int value) : this(value, value+"")
        {
        }

        public Card(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
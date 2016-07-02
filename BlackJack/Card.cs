namespace BlackJack
{
    public class Card
    {
        public static readonly string Knight = "J";
        public static readonly string Queen = "Q";
        public static readonly string King = "K";
        public static readonly string Ace = "A";
        public readonly string Name;
        public readonly int Value;

        public Card(int value)
        {
            Value = value;
            Name = value + "";
        }

        public Card(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
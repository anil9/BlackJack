using System;

namespace BlackJack.Enums
{
    [Flags]
    public enum Suit
    {
        Unknown = 0x01,
        Club = 0x02,
        Heart = 0x03,
        Spade = 0x04,
        Diamond = 0x05,
    }
}
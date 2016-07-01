using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BlackJack
{
    internal class Player
    {
        public readonly bool Dealer;
        private int _bestValue;
        private bool _hasAce;
        private int _maxValue;


        public Player() : this(99999, "player", false)
        {
        }

        public Player(int startingMoney) : this(startingMoney, "player", false)
        {
        }


        public Player(int startingMoney, string name, bool dealer)
        {
            Money = startingMoney;
            Name = name;
            Dealer = dealer;
        }

        public string Name { get; }
        public int Money { get; private set; }
        public LinkedList<Card> Hand { get; private set; }


        public bool Bet(int amount)
        {
            if (Money - amount >= 0)
            {
                SubtractMoney(amount);
                Program.Window.AddToHistoryLog(Name + " BET " + amount);

                return true;
            }
            return false;
        }


        public void PutInHand(Card card)
        {
            Hand.AddLast(card);
            if (card.ToString().Equals(Card.Ace)) _hasAce = true;
            Update(card);
        }

        private void Update(Card card)
        {
            _maxValue += card.Value;
            _bestValue = CalcBestValue();
            if (Dealer)
            {
                Program.Window.AddDealerCard(card.ToString());
                Program.Window.SetDealerValue(_bestValue);
            }
            else
            {
                Program.Window.AddPlayerCard(card.ToString());
                Program.Window.SetPlayerValue(_bestValue);
            }
        }


        /// <summary>
        ///     Try to achieve a hand below blackjack value by replacing Aces 11's with 1's until below value 22 OR until no more
        ///     aces.
        /// </summary>
        /// <param name="maxValue">The value when all the aces has been counted as 11's</param>
        /// <param name="numAces">Number of aces on hand</param>
        /// <returns></returns>
        private int CalcWithLowerValueAces(int maxValue, int numAces)
        {
            var tmpValue = maxValue;
            for (var i = 0; i < numAces; i++)
            {
                tmpValue -= 10;
                if (tmpValue <= Game.BlackJackValue)
                {
                    return tmpValue;
                }
            }
            // more than 21
            return tmpValue;
        }


        private void AddMoney(int amount)
        {
            Money += amount;
            if (!Dealer)
            {
                Program.Window.UpdatePlayerMoney(Money);
            }
        }

        private void SubtractMoney(int amount)
        {
            Money -= amount;
            Program.Window.UpdatePlayerMoney(Money);
        }

        public int GetMinimumValue()
        {
            if (!_hasAce) return _bestValue;
            var min = 0;
            foreach (var card in Hand)
            {
                if (card.ToString().Equals(Card.Ace)) min += 1;
                else min += card.Value;
            }
            return min;
        }

        public void NewRound()
        {
            _bestValue = 0;
            _maxValue = 0;
            Hand = new LinkedList<Card>();
            _hasAce = false;
            if (Dealer) Program.Window.NewRound();
        }

        public int CalcBestValue()
        {
            if (!_hasAce) return _maxValue;
            if (_maxValue <= Game.BlackJackValue)
            {
                return _maxValue;
            }
            var numAces = Hand.Count(card => card.ToString().Equals(Card.Ace));

            return CalcWithLowerValueAces(_maxValue, numAces);
        }

        public void Hit()
        {
            Program.Window.AddToHistoryLog(Name + " HIT");
        }

        public void Tie(int moneyBack)
        {
            AddMoney(moneyBack);
            Program.Window.AddToHistoryLog("TIE");
        }


        public void Stand()
        {
            Program.Window.AddToHistoryLog(Name + " STAND");
        }

        public bool AboveBlackJackValue()
        {
            return _bestValue > Game.BlackJackValue;
        }

        public void Win(int amount)
        {
            AddMoney(amount);
            Program.Window.AddToHistoryLog(Name + " wins. (" + amount + ")");

            Thread.Sleep(2000);
        }
    }
}
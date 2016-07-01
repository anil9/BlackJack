using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Player
    {
        private GameWindow gameWindow;
        private string name;
        private int money;
        private LinkedList<Card> hand = new LinkedList<Card>();
        private readonly bool dealer;
        private int maxValue = 0;
        private int bestValue = 0;
        private bool hasAce = false;


        public Player(GameWindow gameWindow)
        {
            // Used for dealer
            this.gameWindow = gameWindow;
            name = "Dealer";
            dealer = true;
        }

        public Player(int startingMoney, GameWindow gameWindow)
        {
            money = startingMoney;
            this.gameWindow = gameWindow;
            name = "Player1";
            dealer = false;
        }

        public bool IsDealer()
        {
            return dealer;
        }
        public bool Bet(int amount)
        {

            if (money - amount >= 0)
            {
                SubtractMoney(amount);
                gameWindow.previousAction(name + " BET " + amount);
                return true;
            }
            else
            {
                return false;
            }
        }


        public void PutInHand(Card card)
        {
            hand.AddLast(card);
            if (card.ToString().Equals(Card.ACE)) hasAce = true;
            Update(card);
        }
        private void Update(Card card)
        {
            maxValue += card.GetValue();
            bestValue = CalcBestValue();
            if (dealer)
            {
                gameWindow.addDealerCard(card.ToString());
                gameWindow.setDealerValue(bestValue);
            }
            else
            {
                gameWindow.addPlayerCard(card.ToString());
                gameWindow.setPlayerValue(bestValue);
            }

        }

        public int GetMinimumValue()
        {
            if (hasAce)
            {
                int min = 0;
                foreach (Card card in hand)
                {
                    if (card.ToString().Equals(Card.ACE)) min += 1;
                    else min += card.GetValue();
                }
                return min;
            }
            else return bestValue;
        }

        public int getValue()
        {
            return bestValue;
        }

        public void NewRound()
        {
            bestValue = 0;
            maxValue = 0;
            hand = new LinkedList<Card>();
            hasAce = false;
            if (dealer) gameWindow.newRound();
        }

        public int CalcBestValue()
        {
            if (hasAce)
            {
                if (maxValue <= Game.BLACKJACK)
                {
                    return maxValue;
                }
                else
                {
                    int numAces = 0;
                    foreach (Card card in hand)
                    {
                        if (card.ToString().Equals(Card.ACE)) numAces += 1;
                    }
                    int tmpValue = maxValue;
                    // replace 11's with 1's until below value 22 OR until no more aces.
                    for (int i = 0; i < numAces; i++)
                    {
                        tmpValue -= 10;
                        if (tmpValue <= Game.BLACKJACK)
                        {
                            return tmpValue;
                        }
                    }
                    // more than 21
                    return tmpValue;

                }
            }
            else return maxValue;
        }

        public void Hit() { gameWindow.previousAction(name + " HIT"); }

        public void Tie(int moneyBack)
        {
            AddMoney(moneyBack);
            gameWindow.previousAction("TIE");
        }
        private void AddMoney(int amount)
        {
            money += amount;
            gameWindow.updatePlayerMoney(money);
        }
        private void SubtractMoney(int amount)
        {
            money -= amount;
            gameWindow.updatePlayerMoney(money);
        }
        public void Stand() { gameWindow.previousAction(name + " STAND"); }
        public bool Above21()
        {
            return bestValue > 21;
        }
        public void Win(int amount)
        {
            AddMoney(amount);
            gameWindow.previousAction(name + " wins");

            System.Threading.Thread.Sleep(2000);
        }

    }
}

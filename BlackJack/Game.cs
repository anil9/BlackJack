using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public static class Game
    {
        private static readonly int STARTING_MONEY = 500;
        private static readonly int BET_AMOUNT = 100;
        public static readonly int BLACKJACK = 21;
        private static Player player1;
        private static Player dealer;
        private static Deck deck = new Deck();
        private static bool finished = false;

        public static void Run(GameWindow gameWindow)
        {
            player1 = new Player(STARTING_MONEY, gameWindow);
            dealer = new Player(gameWindow);
            finished = true;    // required to start the first round
            StartRound();
        }

        public static void StartRound()
        {
            if (finished)
            {
                NewRound();
                if (player1.Bet(BET_AMOUNT))
                {
                    dealer.PutInHand(drawCard());
                    player1.PutInHand(drawCard());
                    player1.PutInHand(drawCard());
                }
                else
                {
                    System.Windows.Forms.Application.Exit();
                }
            }
        }

        private static void NewRound()
        {
            finished = false;
            player1.NewRound();
            dealer.NewRound();
            deck = new Deck();
            
        }

        private static Card drawCard()
        {
            return deck.Draw();
        }

        public static void playerHit()
        {
            if (!finished)
            {
                Hit(player1);
                if (player1.Above21())
                {
                    Win(dealer);
                }
            } else
            {
                StartRound();
            }
            
        }
        private static void Hit(Player player)
        {

            player.Hit();
            player.PutInHand(drawCard());
        }
       
        public static void PlayerStand()
        {
            if (!finished)
            {
                Stand(player1);
                PlayDealer();
            }
            else
            {
                StartRound();
            }
            
        }
        private static void Stand(Player player)
        {
            player.Stand();
        }
        private static void PlayDealer()
        {
            while (dealer.GetMinimumValue() < 17)
            {
                Hit(dealer);
                System.Threading.Thread.Sleep(2000);
            }
            if (dealer.Above21()) Win(player1);
            else
            {
                Stand(dealer);
                System.Threading.Thread.Sleep(2000);
                CheckWin();
            }

        }
        private static void CheckWin()
        {
            if (player1.CalcBestValue() > dealer.CalcBestValue()) Win(player1);
            else if (player1.CalcBestValue() < dealer.CalcBestValue()) Win(dealer);
            else
            {
                Tie();
            }
        }
        private static void Tie()
        {
            player1.Tie(BET_AMOUNT);
            finished = true;
            
        }
        private static void Win(Player player)
        {
            player.Win(BET_AMOUNT*2);
            finished = true;
            
        }
    }
}

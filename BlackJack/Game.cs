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

        public static void run(GameWindow gameWindow)
        {
            player1 = new Player(STARTING_MONEY, gameWindow);
            dealer = new Player(gameWindow);
            finished = true;    // required to start the first round
            startRound();
        }

        public static void startRound()
        {
            if (finished)
            {
                newRound();
                if (player1.bet(BET_AMOUNT))
                {
                    dealer.putInHand(drawCard());
                    player1.putInHand(drawCard());
                    player1.putInHand(drawCard());
                }
                else
                {
                    System.Windows.Forms.Application.Exit();
                }
            }
        }

        private static void newRound()
        {
            finished = false;
            player1.newRound();
            dealer.newRound();
            deck = new Deck();
            
        }

        private static Card drawCard()
        {
            return deck.draw();
        }

        public static void playerHit()
        {
            if (!finished)
            {
                hit(player1);
                if (player1.above21())
                {
                    win(dealer);
                }
            } else
            {
                startRound();
            }
            
        }
        private static void hit(Player player)
        {

            player.hit();
            player.putInHand(drawCard());
        }
       
        public static void playerStand()
        {
            if (!finished)
            {
                stand(player1);
                playDealer();
            }
            else
            {
                startRound();
            }
            
        }
        private static void stand(Player player)
        {
            player.stand();
        }
        private static void playDealer()
        {
            while (dealer.getMinimumValue() < 17)
            {
                hit(dealer);
                System.Threading.Thread.Sleep(2000);
            }
            if (dealer.above21()) win(player1);
            else
            {
                stand(dealer);
                System.Threading.Thread.Sleep(2000);
                checkWin();
            }

        }
        private static void checkWin()
        {
            if (player1.calcBestValue() > dealer.calcBestValue()) win(player1);
            else if (player1.calcBestValue() < dealer.calcBestValue()) win(dealer);
            else
            {
                tie();
            }
        }
        private static void tie()
        {
            player1.tie(BET_AMOUNT);
            finished = true;
            
        }
        private static void win(Player player)
        {
            player.win(BET_AMOUNT*2);
            finished = true;
            
        }
    }
}

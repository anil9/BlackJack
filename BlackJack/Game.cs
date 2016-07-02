using System.Threading;
using System.Windows.Forms;

namespace BlackJack
{
    public static class Game
    {
        private const int StartingMoney = 500;
        private const int BetAmount = 100;

        internal static Player Player1 { get; set; }

        internal static Player Dealer { get; set; }

        internal static Deck Deck { get; set; } = new Deck();

        public static int BlackJackValue { get; } = 21;


        public static bool Finished { get; set; }

        public static void Run()
        {
            Player1 = new Player(StartingMoney, "player1", false);
            Dealer = new Player(StartingMoney, "Dealer", true);
            Finished = true; // required to start the first round
            StartRound();
        }

        public static void StartRound()
        {
            if (!Finished) return;
            NewRound();
            if (Player1.Bet(BetAmount))
            {
                Dealer.PutInHand(DrawCard());
                Player1.PutInHand(DrawCard());
                Player1.PutInHand(DrawCard());
            }
            else
            {
                Application.Exit();
            }
        }

        private static void NewRound()
        {
            Finished = false;
            Player1.NewRound();
            Dealer.NewRound();
            Deck = new Deck();
        }

        private static Card DrawCard()
        {
            return Deck.Draw();
        }

        public static void PlayerHit()
        {
            if (Finished)
            {
                StartRound();
            }
            else
            {
                Hit(Player1);
                if (Player1.AboveBlackJackValue())
                {
                    Win(Dealer);
                }
            }
        }

        private static void Hit(Player player)
        {
            player.Hit();
            player.PutInHand(DrawCard());
        }

        public static void PlayerStand()
        {
            if (!Finished)
            {
                Stand(Player1);
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
            while (Dealer.CalcBestValue() < 17)
            {
                Hit(Dealer);
                ShortDelay();
            }
            if (Dealer.AboveBlackJackValue()) Win(Player1);
            else
            {
                Stand(Dealer);
                ShortDelay();
                CheckWin();
            }
        }

        private static void ShortDelay()
        {
            Thread.Sleep(1000);
        }

        private static void CheckWin()
        {
            if (Player1.CalcBestValue() > Dealer.CalcBestValue()) Win(Player1);
            else if (Player1.CalcBestValue() < Dealer.CalcBestValue()) Win(Dealer);
            else
            {
                Tie();
            }
        }

        private static void Tie()
        {
            Player1.Tie(BetAmount);
            Finished = true;
        }

        private static void Win(Player player)
        {
            player.Win(BetAmount*2);
            Finished = true;
        }
    }
}
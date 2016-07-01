using System;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class GameWindow : Form
    {
        public GameWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void PlayerHitButton_Click(object sender, EventArgs e)
        {
            Game.PlayerHit();
        }

        private void PlayerStandButton_Click(object sender, EventArgs e)
        {
            Game.PlayerStand();
        }

        private void NextRoundButton_Click(object sender, EventArgs e)
        {
            Game.StartRound();
        }

        public void AddToHistoryLog(string text)
        {
            textBoxPreviousActions.AppendText(text + Environment.NewLine);
        }

        public void AddPlayerCard(string card)
        {
            if (labelPlayerCards.Text.Equals("-"))
            {
                labelPlayerCards.Text = card;
            }
            else
            {
                labelPlayerCards.Text += ", " + card;
            }
            labelPlayerCards.Refresh();
        }

        public void SetPlayerValue(int value)
        {
            labelPlayerValue.Text = value + "";
            labelPlayerValue.Refresh();
        }

        public void AddDealerCard(string card)
        {
            if (labelDealerCards.Text.Equals("-"))
            {
                labelDealerCards.Text = card;
            }
            else
            {
                labelDealerCards.Text += ", " + card;
            }
            labelDealerCards.Refresh();
        }

        public void SetDealerValue(int value)
        {
            labelDealerValue.Text = value + "";
            labelDealerValue.Refresh();
        }

        public void UpdatePlayerMoney(int value)
        {
            labelPlayerMoney.Text = value + "";
        }

        public void NewRound()
        {
            labelPlayerCards.Text = "-";
            labelDealerCards.Text = "-";
            labelPlayerValue.Text = "0";
            labelDealerValue.Text = "0";
            AddToHistoryLog("== New Round ==");
        }
    }
}
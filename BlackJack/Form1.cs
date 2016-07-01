using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class GameWindow : Form
    {
        public GameWindow()
        {
            InitializeComponent();
            Game.run(this);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Player hit
            Game.playerHit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Player stand
            Game.playerStand();
        }

        public void previousAction(String text) {
            textBoxPreviousActions.AppendText(text + Environment.NewLine);
        }

        public void addPlayerCard(String card)
        {
            if (labelPlayerCards.Text.Equals("-"))
            {
                labelPlayerCards.Text = card;
            }
            else
            {
                labelPlayerCards.Text +=", "+ card;
            }
            labelPlayerCards.Refresh();
        }

        public void setPlayerValue(int value)
        {
            labelPlayerValue.Text = value + "";
            labelPlayerValue.Refresh();
        }

        public void addDealerCard(String card)
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

        public void setDealerValue(int value)
        {
            labelDealerValue.Text = value + "";
            labelDealerValue.Refresh();
        }

        public void updatePlayerMoney(int value)
        {
            labelPlayerMoney.Text =  value + "";
        }

        public void newRound()
        {
            labelPlayerCards.Text = "-";
            labelDealerCards.Text = "-";
            labelPlayerValue.Text = "0";
            labelDealerValue.Text = "0";
            previousAction("== New Round ==");
        }

        private void buttonNextRound_Click(object sender, EventArgs e)
        {
            Game.startRound();
        }
    }
}

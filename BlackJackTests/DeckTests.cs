using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackJack;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace BlackJack.Tests
{
    [TestClass()]
    public class DeckTests
    {
        [TestMethod()]
        public void DrawCapacityTest()
        {
            //Setup
            Deck deck = new Deck();
            int target = 52;
            int actual = 0;

            //Act
            try
            {
                while (actual < target)
                {
                    deck.Draw();
                    actual++;
                }
            }
            catch (Exception)
            {
                // ignored
            }
            actual.ShouldBe(target);
        }

        [TestMethod()]
        public void DeckBalanceTest()
        {
            //Setup
            Deck deck = new Deck();
            int[] targetBalance = {0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 16, 4};
            int[] balance = new int[12];

            for (int i = 0; i < 52; i++)
            {
                balance[deck.Draw().Value]++;
            }
            balance.ShouldBe(targetBalance);

        }
    }
}
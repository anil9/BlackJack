using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Deck
    {
        
        private readonly int DECK_SIZE = 52;
        private Card[] deckArray;
        private LinkedList<Card> deck; 
        private int currentIndex = 0;
        public Deck()
        {
            deckArray = new Card[DECK_SIZE];
            GenerateDeck();
            Shuffle();
            deck = new LinkedList<Card>(deckArray);
            
        }
        private void GenerateDeck()
        {
            // add non-face cards
            for (int i = 2; i < 11; i++) {
                Insert4Cards(i);
            }
            // add face cards
            Insert4Cards(10, Card.KNIGHT);
            Insert4Cards(10, Card.QUEEN);
            Insert4Cards(10, Card.KING);
            Insert4Cards(11, Card.ACE);
        }
        private void Insert4Cards(int value)
        {
            for(int i = 0; i < 4; i++)
            {
                deckArray[currentIndex] = new Card(value);
                currentIndex++;
            }
        }
        private void Insert4Cards(int value, string name)
        {
            for (int i = 0; i < 4; i++)
            {
                deckArray[currentIndex] = new Card(value, name);
                currentIndex++;
            }
        }
        private void Shuffle()
        {
            Random rand = new Random();
            for(int i = 0; i < DECK_SIZE; i++)
            {
                int randIndex = rand.Next(52);
                Card temp = deckArray[randIndex];
                deckArray[randIndex] = deckArray[i];
                deckArray[i] = temp;
            }

        }
        private void PrintDeck()
        {
            foreach(Card card in deckArray)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine(deckArray.Length);
        }
        public Card Draw()
        {
            Card card = deck.Last();
            deck.RemoveLast();
            return card;
        }
    }
}

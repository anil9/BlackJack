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
            generateDeck();
            shuffle();
            deck = new LinkedList<Card>(deckArray);
            
        }
        private void generateDeck()
        {
            // add non-face cards
            for (int i = 2; i < 11; i++) {
                insert4Cards(i);
            }
            // add face cards
            insert4Cards(10, Card.KNIGHT);
            insert4Cards(10, Card.QUEEN);
            insert4Cards(10, Card.KING);
            insert4Cards(11, Card.ACE);
        }
        private void insert4Cards(int value)
        {
            for(int i = 0; i < 4; i++)
            {
                deckArray[currentIndex] = new Card(value);
                currentIndex++;
            }
        }
        private void insert4Cards(int value, String name)
        {
            for (int i = 0; i < 4; i++)
            {
                deckArray[currentIndex] = new Card(value, name);
                currentIndex++;
            }
        }
        private void shuffle()
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
        private void printDeck()
        {
            foreach(Card card in deckArray)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine(deckArray.Length);
        }
        public Card draw()
        {
            Card card = deck.Last();
            deck.RemoveLast();
            return card;
        }
    }
}

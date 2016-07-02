using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Deck
    {
        private const int DeckSize = 52;
        private readonly LinkedList<Card> _deck;
        private readonly Card[] _deckArray;
        private int _currentIndex;

        public Deck()
        {
            _deckArray = new Card[DeckSize];
            GenerateDeck();
            Shuffle();
            _deck = new LinkedList<Card>(_deckArray);
        }


        private void GenerateDeck()
        {
            // add non-face cards
            for (var i = 2; i < 11; i++)
            {
                Insert4Cards(i);
            }
            // add face cards
            Insert4Cards(10, Card.Knight);
            Insert4Cards(10, Card.Queen);
            Insert4Cards(10, Card.King);
            Insert4Cards(11, Card.Ace);
        }

        private void Insert4Cards(int value)
        {
            for (var i = 0; i < 4; i++)
            {
                _deckArray[_currentIndex] = new Card(value);
                _currentIndex++;
            }
        }

        private void Insert4Cards(int value, string name)
        {
            for (var i = 0; i < 4; i++)
            {
                _deckArray[_currentIndex] = new Card(value, name);
                _currentIndex++;
            }
        }

        private void Shuffle()
        {
            var rand = new Random();
            for (var i = 0; i < DeckSize; i++)
            {
                var randIndex = rand.Next(52);
                var temp = _deckArray[randIndex];
                _deckArray[randIndex] = _deckArray[i];
                _deckArray[i] = temp;
            }
        }

        private void PrintDeck()
        {
            foreach (var card in _deckArray)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine(_deckArray.Length);
        }

        public Card Draw()
        {
            var card = _deck.Last();
            _deck.RemoveLast();
            return card;
        }
    }
}
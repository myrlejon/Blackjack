using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Models
{
    class Deck
    {
        private Card[] deck;
        private int currentCard;
        private const int deckSize = 52;
        private Random rand;

        // Here we build our deck
        public Deck()
        {
            string[] suits = { "♣", "♠", "♦", "♥" }; 
            string[] faces = { "Ace     ", "Two     ", "Three   ", "Four    ", "Five    ", "Six     ",
                               "Seven   ", "Eight   ", "Nine    ", "Ten     ", "Jack    ", "Queen   ", "King    " };

            deck = new Card[deckSize];
            currentCard = 0;
            rand = new Random();
            var card = new Card();
            for (int count = 0; count < deck.Length; count++)
            {
                var face = faces[count % 11];

                deck[count] = new Card(face, suits[count / 13], card.ConvertCardToInt(face));

                //deck[count] = new Card(faces[count % 11], suits[count / 13]);

            }
        }

        public void Shuffle()
        {
            currentCard = 0;
            for (int first = 0; first < deck.Length; first++)
            {
                int second = rand.Next(deckSize);
                Card temp = deck[first];
                deck[first] = deck[second];
                deck[second] = temp;
            }
        }

        public Card DealCard()
        {
            if (currentCard < deck.Length)
                return deck[currentCard++];
            else
                return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Models
{
    // This class is for the carddeck. 
    class Deck
    {
        private Card[] deck;
        private int currentCard;
        private const int deckSize = 52;
        private Random rand;

        public Deck()
        {
            string[] suits = { "♣", "♠", "♦", "♥" }; 
            // Each face has 8 rows just so it wont mess up the graphics
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
            }
        }
        
        // This method shuffles the cards in the deck.
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

        // This method deals a card.
        public Card DealCard()
        {
            if (currentCard < deck.Length)
                return deck[currentCard++];
            else
                return null;
        }
    }
}

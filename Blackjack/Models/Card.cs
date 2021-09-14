using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Models
{
    // This is the class a card in the deck.
    class Card
    {
        public string face;
        public string suit;
        public int value;

        public Card(string cardFace, string cardSuit, int cardValue)
        {
            face = cardFace;
            suit = cardSuit;
            value = cardValue;
        }

        public Card()
        {

        }

        // Returns the value of a card.
        public string CardValue()
        {
            return face + suit + value;
        }

        // Converts the face of a card into an value of an integer.
        public int ConvertCardToInt(string face)
        {
            int value = 0;

            if (face == "Ace     ") { value = 11; }
            else if (face == "Two     ") { value = 2; }
            else if (face == "Three   ") { value = 3; }
            else if (face == "Four    ") { value = 4; }
            else if (face == "Five    ") { value = 5; }
            else if (face == "Six     ") { value = 6; }
            else if (face == "Seven   ") { value = 7; }
            else if (face == "Eight   ") { value = 8; }
            else if (face == "Nine    ") { value = 9; }
            else if (face == "Ten     " || face == "Jack    " || face == "Queen   " || face == "King    ") { value = 10; }

            return value;
        }
    }
}

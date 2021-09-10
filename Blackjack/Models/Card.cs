using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Models
{
    class Card
    {
        public string face;
        public string suit;
        public string royal;
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
        
        /*
        public override string ToString()
        {
            return face + suit;
        }
        */

        public string CardValue()
        {
            return face + suit + value;
        }

        // La till mellanrum så alla ord är 8 mellanslag långa
        public int ConvertCardToInt(string face)
        {
            int value = 0;

            if (face == "Ace     ")
            {
                value = 11;
            }
            else if (face == "Two     ")
            {
                value = 2;
            }
            else if (face == "Three   ")
            {
                value = 3;
            }
            else if (face == "Four    ")
            {
                value = 4;
            }
            else if (face == "Five    ")
            {
                value = 5;
            }
            else if (face == "Six     ")
            {
                value = 6;
            }
            else if (face == "Seven   ")
            {
                value = 7;
            }
            else if (face == "Eight   ")
            {
                value = 8;
            }
            else if (face == "Nine    ")
            {
                value = 9;
            }
            else if (face == "Ten     " || face == "Jack    " || face == "Queen   " || face == "King    ")
            {
                value = 10;
            }

            return value;
        }
    }
}

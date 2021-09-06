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

        public Card(string cardFace, string cardSuit)
        {
            face = cardFace;
            suit = cardSuit;
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
            return face + suit;
        }
    }
}

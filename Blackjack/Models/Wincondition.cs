using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Models
{
    class Wincondition : Card
    {
        // 1 = win, 2 = loss, 3 = even
        /*
             string[] faces = { "Ace     ", "Two     ", "Three   ", "Four    ", "Five    ", "Six     ",
                               "Seven   ", "Eight   ", "Nine    ", "Ten     ", "Jack    ", "Queen   ", "King    " };
            */

        public bool TwoCardBlackjack(Card card1, Card card2)
        {
            bool blackjack = false;

            if(card1.face == "Ace     " && card2.face == "Ace     " || card1.face == "Ace     " && card2.value == 10)
            {
                blackjack = true;
            }
            return blackjack;
        }
    }
}

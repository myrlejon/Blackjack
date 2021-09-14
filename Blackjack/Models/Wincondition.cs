using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Models
{
    // This class checks for certain winconditions in GameController.
    class Wincondition : Card
    {
        // This method checks if the player has a two card blackjack.
        public bool TwoCardBlackjack(Card card1, Card card2)
        {
            bool blackjack = false;

            if(card1.face == "Ace     " && card2.face == "Ace     " || card1.face == "Ace     " && card2.value == 10 || card2.face == "Ace     " && card1.value == 10)
            {
                blackjack = true;
            }
            return blackjack;
        }

        // This method converts the ace value if the player hand is more than 21.
        public int ConvertAceValue(int value, string[] faces)
        {
            for (int i = 0; i < faces.Length; i++)
            {
                if (value > 21 && faces[i] == "Ace     ")
                {
                    value -= 10;
                }
            }
            return value;
        }

        // This method checks if the dealer is gonna take another card or not.
        public bool CheckValueDealer(int value)
        {
            bool hit = false;
            if (value < 17)
            {
                hit = true;
            }
            return hit;
        }
    }
}

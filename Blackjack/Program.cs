using System;
using System.Collections.Generic;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Controllers.GameController();
            game.Game();


            /*
            var deck = new Models.Deck();
            var card = new Models.Card();

            deck.Shuffle();

            var card1 =  deck.DealCard();
            var card2 = deck.DealCard();
            var card3 = deck.DealCard();
            var card4 = deck.DealCard();
            var card5 = deck.DealCard();

            string[] cardList = new string[] { card1.face, card2.face, card3.face, card4.face, card5.face };

            var win = new Models.Wincondition();
            int value = card1.value + card2.value + card3.value +  card4.value + card5.value;

            Console.WriteLine(card1.face + card2.face + card3.face + card4.face + card5.face + "    " + value);

            value = win.ConvertAceValue(value, cardList);

            Console.WriteLine(card1.face + card2.face + card3.face + card4.face + card5.face + "    " + value);
            
            */
        }
    }
}

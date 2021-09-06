using System;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Views.Menu();
            var card = new Views.CardDisplay();
            var deck = new Models.Deck();
            deck.Shuffle();

            var testcard = deck.DealCard();

            var newFace = card.ConvertCardToInt(testcard.face);

            card.PrintCard(testcard.suit, newFace, testcard.face);

            //menu.Intro();
            //card.PrintCard(suit, value);
            //card.PrintCardBack();

            //Console.WriteLine(Console.LargestWindowHeight);
            //Console.WriteLine(Console.LargestWindowWidth);
        }
    }
}

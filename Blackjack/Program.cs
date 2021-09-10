using System;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Controllers.GameController();

            game.Game();


            /*

            for (int i = 0; i < 52; i++)
            {
                //Console.Write("{0,-19}", deck.DealCard());
                var dealCard = deck.DealCard();
                card.PrintCard(dealCard.suit, dealCard.value, dealCard.face);

                if ((i + 1) % 4 == 0)
                    Console.WriteLine();
            }
            Console.ReadLine();

            */


            //var testcard = deck.DealCard();

            //card.PrintCard(testcard.suit, testcard.value, testcard.face);

            //menu.Intro();
            //card.PrintCard(suit, value);
            //card.PrintCardBack();

            //Console.WriteLine(Console.LargestWindowHeight);
            //Console.WriteLine(Console.LargestWindowWidth);
        }
    }
}

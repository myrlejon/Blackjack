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

            var menu = new Views.Menu();
            var deck = new Models.Deck();
            var card = new Models.Card();

            deck.Shuffle();

            var card1 = deck.DealCard();
            var card2 = deck.DealCard();
            var card3 = deck.DealCard();
            var card4 = deck.DealCard();
            var card5 = deck.DealCard();
            var dcard1 = deck.DealCard();
            var dcard2 = deck.DealCard();
            var dcard3 = deck.DealCard();
            var dcard4 = deck.DealCard();
            var dcard5 = deck.DealCard();

            Console.SetWindowSize(160, 40);

            menu.FiveCardDealer(dcard1.suit, dcard1.value, dcard1.face,
dcard2.suit, dcard2.value, dcard2.face,
dcard3.suit, dcard3.value, dcard3.face,
dcard4.suit, dcard4.value, dcard4.face,
dcard5.suit, dcard5.value, dcard5.face);

            menu.FiveCardPlayer(card1.suit, card1.value, card1.face,
                card2.suit, card2.value, card2.face,
                card3.suit, card3.value, card3.face,
                card4.suit, card4.value, card4.face,
                card5.suit, card5.value, card5.face);

            */


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

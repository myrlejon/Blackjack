using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Blackjack.Controllers
{
    public class GameController
    {
        public void Game()
        {
            var menu = new Views.Menu();
            var card = new Views.CardDisplay();
            var deck = new Models.Deck();
            deck.Shuffle();

            menu.Intro();


            Console.SetWindowSize(160, 40);

            //var dealCard = deck.DealCard();
            //menu.OneCardPlayer(dealCard.suit, dealCard.value, dealCard.face);

            bool round = true;

            while (round)
            {
                // Korten laddas in som i traditionell blackjack
                var playerCardOne = deck.DealCard();
                var dealerCardOne = deck.DealCard();

                var playerCardTwo = deck.DealCard();
                var dealerCardTwo = deck.DealCard();

                var playerCardThree = deck.DealCard();
                var dealerCardThree = deck.DealCard();

                var playerCardFour = deck.DealCard();
                var dealerCardFour = deck.DealCard();   

                var playerCardFive = deck.DealCard();
                var dealerCardFive = deck.DealCard();

                var input = Console.ReadLine();

                if (input == "p" || input == "P")
                {
                    menu.EmptyTable();
                    menu.OneCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face);
                    Thread.Sleep(5000);
                    menu.OneCardDealer(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face);
                    menu.OneCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face);
                    Console.Read();

                }

            }
            
        }
    }
}

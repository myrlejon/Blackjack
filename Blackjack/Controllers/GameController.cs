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
            var win = new Models.Wincondition();

            menu.Intro();


            Console.SetWindowSize(160, 40);

            //var dealCard = deck.DealCard();
            //menu.OneCardPlayer(dealCard.suit, dealCard.value, dealCard.face);

            bool round = true;
            bool inGame = true;
            int money = 1000;
            int roundCount = 0;

            while (inGame)
            {
                var input = Console.ReadLine();
                menu.Game();

                if (input == "p" || input == "P")
                {
                    round = true;

                    while (round)
                    {
                        var deck = new Models.Deck();
                        deck.Shuffle();

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



                        menu.EmptyTable();
                        menu.OneCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face);
                        Thread.Sleep(500);
                        menu.OneCardDealer(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face);
                        menu.OneCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face);
                        Thread.Sleep(500);
                        menu.OneCardDealer(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face);
                        menu.TwoCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face, 
                            playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face);
                        Thread.Sleep(500);
                        menu.OneCardDealerFaceDown(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face);
                        menu.TwoCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face, 
                            playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face);
                        Thread.Sleep(500);

                        if (win.TwoCardBlackjack(playerCardOne, playerCardTwo) == true)
                        {
                            Console.WriteLine("Blackjack!");
                            Console.Read();
                            round = false;
                        }

                        if (dealerCardOne.value == 10 || dealerCardOne.value == 11)
                        {
                            menu.OneCardDealerCardCheck(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face);
                            menu.TwoCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face,
                            playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face);
                            Thread.Sleep(2000);
                            if (dealerCardTwo.value == 10 || dealerCardTwo.value == 11)
                            {
                                menu.TwoCardDealer(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face,
                            dealerCardTwo.suit, dealerCardTwo.value, dealerCardTwo.face);
                                menu.TwoCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face,
                            playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face);
                                Console.WriteLine("Dealer got Blackjack! Busted.");
                            }
                            else
                            {
                                menu.OneCardDealerFaceDown(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face);
                                menu.TwoCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face,
                            playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face);
                            }

                        }
                        

                        if (round)
                        {
                            input = Console.ReadLine();

                            if (input == "H" || input == "h")
                            {
                                menu.ThreeCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face, 
                                    playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face, 
                                    playerCardThree.suit, playerCardThree.value, playerCardThree.face);
                                Console.ReadLine();
                                if (input == "H" || input == "h")
                                {
                                    // menu.FourCardPlayer
                                    // Console.ReadLine();
                                }
                            }
                            else if (input == "S" || input == "s")
                            {
                                Thread.Sleep(500);
                                int valueDealerTwoCards = menu.TwoCardDealer(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face,
                            dealerCardTwo.suit, dealerCardTwo.value, dealerCardTwo.face);
                                int valuePlayer = menu.TwoCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face,
                            playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face);

                                if (valueDealerTwoCards > valuePlayer)
                                {
                                    Console.WriteLine("Dealer wins!");
                                }
                                else if (win.CheckValueDealer(valueDealerTwoCards) == true)
                                {
                                    Thread.Sleep(500);
                                    int valueDealerThreeCards = menu.ThreeCardDealer(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face,
                            dealerCardTwo.suit, dealerCardTwo.value, dealerCardTwo.face,
                            dealerCardThree.suit, dealerCardThree.value, dealerCardThree.face);
                                    menu.TwoCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face,
                            playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face);
                                    if (valueDealerThreeCards > valuePlayer && valueDealerThreeCards <= 21)
                                    {
                                        Console.WriteLine("Dealer wins!");
                                    }
                                    else if (valueDealerThreeCards > 21)
                                    {
                                        Console.WriteLine("Dealer bust!");
                                    }
                                    else if (win.CheckValueDealer(valueDealerThreeCards) == true)
                                    {
                                        // menu.FourCardDealer...
                                    }
                                }
                                else if (win.CheckValueDealer(valueDealerTwoCards) == false && valueDealerTwoCards > valuePlayer)
                                {
                                    Console.WriteLine("Dealer wins!");
                                }
                                Console.ReadKey();
                            }
                        }
                        roundCount++;        
                    }

                }
            }
        }
    }
}

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
            int roundCount = 1;

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
                            if (dealerCardOne.value == 11 && dealerCardTwo.value == 10 ||
                                dealerCardOne.value == 11 && dealerCardTwo.value == 11 ||
                                dealerCardOne.value == 10 && dealerCardTwo.value == 11)
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
                                Thread.Sleep(500);
                                menu.OneCardDealerFaceDown(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face);
                                int valuePlayerThreeCards = menu.ThreeCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face,
                                    playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face,
                                    playerCardThree.suit, playerCardThree.value, playerCardThree.face);

                                if (valuePlayerThreeCards > 21)
                                {
                                    Console.WriteLine("Player busted!");
                                }
                                else if (valuePlayerThreeCards == 21)
                                {
                                    Console.WriteLine("Player wins!");
                                }
                                else if (valuePlayerThreeCards < 21)
                                {
                                    input = Console.ReadLine();

                                    if (input == "H" || input == "h")
                                    {
                                        Thread.Sleep(500);
                                        menu.OneCardDealerFaceDown(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face);
                                        int valuePlayerFourCards = menu.FourCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face,
                                    playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face,
                                    playerCardThree.suit, playerCardThree.value, playerCardThree.face,
                                    playerCardFour.suit, playerCardFour.value, playerCardFour.face);

                                        if (valuePlayerFourCards > 21)
                                        {
                                            Console.WriteLine("Player busted!");
                                        }
                                        else if (valuePlayerFourCards == 21)
                                        {
                                            Console.WriteLine("Player wins!");
                                        }
                                        else if (valuePlayerFourCards < 21)
                                        {
                                            input = Console.ReadLine();

                                            if (input == "H" || input == "h")
                                            {
                                                Thread.Sleep(500);
                                                menu.OneCardDealerFaceDown(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face);
                                                int valuePlayerFiveCards = menu.FiveCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face,
                                            playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face,
                                            playerCardThree.suit, playerCardThree.value, playerCardThree.face,
                                            playerCardFour.suit, playerCardFour.value, playerCardFour.face,
                                            playerCardFive.suit, playerCardFive.value, playerCardFive.face);

                                                if (valuePlayerFiveCards > 21)
                                                {
                                                    Console.WriteLine("Player busted!");
                                                }
                                                else if (valuePlayerFiveCards == 21)
                                                {
                                                    Console.WriteLine("Player wins!");
                                                }
                                                else if (valuePlayerFiveCards < 21)
                                                {
                                                    Console.WriteLine("Five card charlie! Player wins!");
                                                }
                                            }

                                            //Player stops at 4 cards
                                            else if (input == "S" || input == "s")
                                            {
                                                int valueDealerThreeCards = menu.ThreeCardDealer(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face,
                                     dealerCardTwo.suit, dealerCardTwo.value, dealerCardTwo.face,
                                     dealerCardThree.suit, dealerCardThree.value, dealerCardThree.face);
                                                menu.FourCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face,
                                           playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face,
                                           playerCardThree.suit, playerCardThree.value, playerCardThree.face,
                                           playerCardFour.suit, playerCardFour.value, playerCardFour.face);

                                                if (valueDealerThreeCards > valuePlayerFourCards && win.CheckValueDealer(valueDealerThreeCards) == false && valueDealerThreeCards <= 21)
                                                {
                                                    Console.WriteLine("Dealer wins!");
                                                }
                                                else if (valueDealerThreeCards == valuePlayerFourCards)
                                                {
                                                    Console.WriteLine("Split!");
                                                }
                                                else if (valueDealerThreeCards > 21)
                                                {
                                                    Console.WriteLine("Dealer bust!");
                                                }
                                                else if (win.CheckValueDealer(valueDealerThreeCards) == true)
                                                {
                                                    Thread.Sleep(500);
                                                    int valueDealerFourCards = menu.FourCardDealer(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face,
                                                dealerCardTwo.suit, dealerCardTwo.value, dealerCardTwo.face,
                                                dealerCardThree.suit, dealerCardThree.value, dealerCardThree.face,
                                                dealerCardFour.suit, dealerCardFour.value, dealerCardFour.face);
                                                    menu.FourCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face,
                                                playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face,
                                                playerCardThree.suit, playerCardThree.value, playerCardThree.face,
                                                playerCardFour.suit, playerCardFour.value, playerCardFour.face);

                                                    if (valueDealerFourCards > valuePlayerFourCards && win.CheckValueDealer(valueDealerFourCards) == false && valueDealerFourCards <= 21)
                                                    {
                                                        Console.WriteLine("Dealer wins!");
                                                    }
                                                    else if (valueDealerFourCards == valuePlayerFourCards)
                                                    {
                                                        Console.WriteLine("Split!");
                                                    }
                                                    else if (valueDealerFourCards > 21)
                                                    {
                                                        Console.WriteLine("Dealer bust!");
                                                    }
                                                    else if (win.CheckValueDealer(valueDealerFourCards) == true)
                                                    {
                                                        Thread.Sleep(500);
                                                        int valueDealerFiveCards = menu.FiveCardDealer(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face,
                                                dealerCardTwo.suit, dealerCardTwo.value, dealerCardTwo.face,
                                                dealerCardThree.suit, dealerCardThree.value, dealerCardThree.face,
                                                dealerCardThree.suit, dealerCardFour.value, dealerCardFour.face,
                                                dealerCardFive.suit, dealerCardFive.value, dealerCardFive.face);
                                                        menu.FourCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face,
                                                playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face,
                                                playerCardThree.suit, playerCardThree.value, playerCardThree.face,
                                                playerCardFour.suit, playerCardFour.value, playerCardFour.face);
                                                        if (valueDealerFiveCards > valuePlayerFourCards && win.CheckValueDealer(valueDealerThreeCards) == false && valueDealerFiveCards <= 21)
                                                        {
                                                            Console.WriteLine("Dealer wins!");
                                                        }
                                                        else if (valueDealerFiveCards == valuePlayerFourCards)
                                                        {
                                                            Console.WriteLine("Split!");
                                                        }
                                                        else if (valueDealerFiveCards < valuePlayerFourCards)
                                                        {
                                                            Console.WriteLine("Player wins!");
                                                        }
                                                        else if (valueDealerFiveCards > 21)
                                                        {
                                                            Console.WriteLine("Dealer bust!");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Dealer has pulled too many cards, player wins!");
                                                        }
                                                    }
                                                    else if (win.CheckValueDealer(valueDealerFourCards) == false && valueDealerFourCards > valuePlayerFourCards)
                                                    {
                                                        Console.WriteLine("Dealer wins!");
                                                    }
                                                }
                                                else if (win.CheckValueDealer(valueDealerThreeCards) == false && valueDealerThreeCards > valuePlayerFourCards)
                                                {
                                                    Console.WriteLine("Dealer wins!");
                                                }
                                            }
                                        }
                                    }

                                    // Player stops at 3 cards
                                    else if (input == "S" || input == "s")
                                    {
                                        int valueDealerThreeCards = menu.ThreeCardDealer(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face,
                             dealerCardTwo.suit, dealerCardTwo.value, dealerCardTwo.face,
                             dealerCardThree.suit, dealerCardThree.value, dealerCardThree.face);
                                        menu.ThreeCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face,
                                   playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face,
                                   playerCardThree.suit, playerCardThree.value, playerCardThree.face);

                                        if (valueDealerThreeCards > valuePlayerThreeCards && valueDealerThreeCards <= 21)
                                        {
                                            Console.WriteLine("Dealer wins!");
                                        }
                                        else if (valueDealerThreeCards == valuePlayerThreeCards)
                                        {
                                            Console.WriteLine("Split!");
                                        }
                                        else if (valueDealerThreeCards > 21)
                                        {
                                            Console.WriteLine("Dealer bust!");
                                        }
                                        else if (win.CheckValueDealer(valueDealerThreeCards) == true)
                                        {
                                            Thread.Sleep(500);
                                            int valueDealerFourCards = menu.FourCardDealer(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face,
                                        dealerCardTwo.suit, dealerCardTwo.value, dealerCardTwo.face,
                                        dealerCardThree.suit, dealerCardThree.value, dealerCardThree.face,
                                        dealerCardFour.suit, dealerCardFour.value, dealerCardFour.face);
                                            menu.ThreeCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face,
                                        playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face,
                                        playerCardThree.suit, playerCardThree.value, playerCardThree.face);

                                            if (valueDealerFourCards > valuePlayerThreeCards && win.CheckValueDealer(valueDealerFourCards) == false)
                                            {
                                                Console.WriteLine("Dealer wins!");
                                            }
                                            else if (valueDealerFourCards == valuePlayerThreeCards)
                                            {
                                                Console.WriteLine("Split!");
                                            }
                                            else if (valueDealerFourCards > 21)
                                            {
                                                Console.WriteLine("Dealer bust!");
                                            }
                                            else if (win.CheckValueDealer(valueDealerFourCards) == true)
                                            {
                                                Thread.Sleep(500);
                                                int valueDealerFiveCards = menu.FiveCardDealer(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face,
                                        dealerCardTwo.suit, dealerCardTwo.value, dealerCardTwo.face,
                                        dealerCardThree.suit, dealerCardThree.value, dealerCardThree.face,
                                        dealerCardThree.suit, dealerCardFour.value, dealerCardFour.face,
                                        dealerCardFive.suit, dealerCardFive.value, dealerCardFive.face);
                                                menu.ThreeCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face,
                                        playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face,
                                        playerCardThree.suit, playerCardThree.value, playerCardThree.face);
                                                if (valueDealerFiveCards > valuePlayerThreeCards && valueDealerThreeCards <= 21)
                                                {
                                                    Console.WriteLine("Dealer wins!");
                                                }
                                                else if (valueDealerFiveCards == valuePlayerThreeCards)
                                                {
                                                    Console.WriteLine("Split!");
                                                }
                                                else if (valueDealerFiveCards > 21)
                                                {
                                                    Console.WriteLine("Dealer bust!");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Dealer has pulled too many cards, player wins!");
                                                }
                                            }
                                            else if (win.CheckValueDealer(valueDealerThreeCards) == false && valueDealerThreeCards > valuePlayerThreeCards)
                                            {
                                                Console.WriteLine("Dealer wins!");
                                            }
                                            
                                        }
                                        else if (win.CheckValueDealer(valueDealerThreeCards) == false && valueDealerThreeCards > valuePlayerThreeCards)
                                        {
                                            Console.WriteLine("Dealer wins!");
                                        }
                                        else if (win.CheckValueDealer(valueDealerThreeCards) == false && valueDealerThreeCards < valuePlayerThreeCards)
                                        {
                                            Console.WriteLine("Player wins!");
                                        }
                                    }
                                }
                            }

                            // Player stops at 2 cards
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
                                else if (valueDealerTwoCards == valuePlayer)
                                {
                                    Console.WriteLine("Split!");
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
                                    else if (valueDealerThreeCards == valuePlayer)
                                    {
                                        Console.WriteLine("Split!");
                                    }
                                    else if (valueDealerThreeCards > 21)
                                    {
                                        Console.WriteLine("Dealer bust!");
                                    }
                                    else if (win.CheckValueDealer(valueDealerThreeCards) == true)
                                    {
                                        Thread.Sleep(500);
                                        int valueDealerFourCards = menu.FourCardDealer(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face,
                            dealerCardTwo.suit, dealerCardTwo.value, dealerCardTwo.face,
                            dealerCardThree.suit, dealerCardThree.value, dealerCardThree.face,
                            dealerCardFour.suit, dealerCardFour.value, dealerCardFour.face);
                                        menu.TwoCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face,
                            playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face);
                                        if (valueDealerFourCards > valuePlayer && valueDealerFourCards <= 21)
                                        {
                                            Console.WriteLine("Dealer wins!");
                                        }
                                        else if (valueDealerFourCards == valuePlayer)
                                        {
                                            Console.WriteLine("Split!");
                                        }
                                        else if (valueDealerFourCards > 21)
                                        {
                                            Console.WriteLine("Dealer bust!");
                                        }
                                        else if (win.CheckValueDealer(valueDealerFourCards) == true)
                                        {
                                            Thread.Sleep(500);
                                            int valueDealerFiveCards = menu.FiveCardDealer(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face,
                            dealerCardTwo.suit, dealerCardTwo.value, dealerCardTwo.face,
                            dealerCardThree.suit, dealerCardThree.value, dealerCardThree.face,
                            dealerCardFour.suit, dealerCardFour.value, dealerCardFour.face,
                            dealerCardFour.suit, dealerCardFour.value, dealerCardFour.face);
                                            menu.TwoCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face,
                            playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face);
                                            if (valueDealerFiveCards > valuePlayer && valueDealerFiveCards <= 21)
                                            {
                                                Console.WriteLine("Dealer wins!");
                                            }
                                            else if (valueDealerFiveCards == valuePlayer)
                                            {
                                                Console.WriteLine("Split!");
                                            }
                                            else if (valueDealerFiveCards > 21)
                                            {
                                                Console.WriteLine("Dealer bust!");
                                            }
                                            else if (win.CheckValueDealer(valueDealerFiveCards) == true)
                                            {
                                                Console.WriteLine("Dealer has pulled too many cards, player wins!");
                                            }
                                        }
                                    }
                                }
                                else if (win.CheckValueDealer(valueDealerTwoCards) == false && valueDealerTwoCards > valuePlayer)
                                {
                                    Console.WriteLine("Dealer wins!");
                                }
                            }
                            }
                        Console.Write($"Press any key to go to the next round...    Round: {roundCount}");
                        Console.ReadKey();
                            roundCount++;
                        }

                    }
                }
            }
        }
    }

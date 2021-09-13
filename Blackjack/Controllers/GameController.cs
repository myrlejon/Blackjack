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
            var win = new Models.Wincondition();

            menu.Intro();

            Console.SetWindowSize(160, 40);

            //var dealCard = deck.DealCard();
            //menu.OneCardPlayer(dealCard.suit, dealCard.value, dealCard.face);

            bool round = true;
            bool inGame = true;
            int money = 1000;
            int wins = 0;
            int splits = 0;
            int losses = 0;
            int bet = 0;
            int roundCount = 1;

            while (inGame)
            {
                if (money >= 10000) { menu.WinScreen(money, wins, splits, losses, roundCount); }

                if (money == 0) { menu.LoseScreen(money, wins, splits, losses, roundCount); }

                menu.EmptyTable();
                menu.Bet(money, bet);
                var input = Console.ReadLine();

                if (input == "B" || input == "b")
                {
                    bool betLoop = false;
                    while (betLoop == false)
                    {
                        Console.Write("Enter the amount: ");
                        string betInput = Console.ReadLine();
                        if (int.TryParse(betInput, out bet))
                        {
                            int betInputInt = Convert.ToInt32(betInput);
                            if (betInputInt <= money)
                            {
                                bet = betInputInt;
                                betLoop = true;
                            }
                        }
                        else
                        {
                            betLoop = true;
                        }
                    }
                }

                else if (input == "P" && bet > 0 || input == "p" && bet > 0)
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

                        string[] threeCardListPlayer = new string[] { playerCardOne.face, playerCardTwo.face, playerCardThree.face };
                        string[] fourCardListPlayer = new string[] { playerCardOne.face, playerCardTwo.face, playerCardThree.face,
                                                                               playerCardFour.face };
                        string[] fiveCardListPlayer = new string[] { playerCardOne.face, playerCardTwo.face, playerCardThree.face, 
                                                                               playerCardFour.face, playerCardFive.face };

                        string[] threeCardListDealer = new string[] { dealerCardOne.face, dealerCardTwo.face, dealerCardThree.face };
                        string[] fourCardListDealer = new string[] { dealerCardOne.face, dealerCardTwo.face, dealerCardThree.face, 
                                                                               dealerCardFour.face };
                        string[] fiveCardListDealer = new string[] { dealerCardOne.face, dealerCardTwo.face, dealerCardThree.face,
                                                                               dealerCardFour.face, dealerCardFive.face};

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
                            money = PlayerWinMoney(money, bet);
                            wins++;
                            round = false;
                        }

                        else if (dealerCardOne.value == 10 || dealerCardOne.value == 11)
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
                                money = PlayerLoseMoney(money, bet);
                                losses++;
                                round = false;
                            }
                            else
                            {
                                menu.OneCardDealerFaceDown(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face);
                                menu.TwoCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face,
                            playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face);
                                round = true;
                            }
                        }

                        // If the player doesn't win/lose directly, they're still in the round and will be able to input an option
                        if (round)
                        {
                            input = Console.ReadLine();

                            // TODO: Double down

                            if (input == "H" || input == "h")
                            {
                                Thread.Sleep(500);
                                menu.OneCardDealerFaceDown(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face);
                                int valuePlayerThreeCards = menu.ThreeCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face,
                                    playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face,
                                    playerCardThree.suit, playerCardThree.value, playerCardThree.face);

                                int valuePlayerThreeCardsAceCheck = win.ConvertAceValue(valuePlayerThreeCards, threeCardListPlayer);

                                if (valuePlayerThreeCardsAceCheck > 21)
                                {
                                    Console.WriteLine("Player busted!");
                                    money = PlayerLoseMoney(money, bet);
                                    losses++;
                                }
                                else if (valuePlayerThreeCardsAceCheck == 21)
                                {
                                    Console.WriteLine("Player wins!");
                                    money = PlayerWinMoney(money, bet);
                                    wins++;
                                }
                                else if (valuePlayerThreeCardsAceCheck < 21)
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

                                        int valuePlayerFourCardsAceCheck = win.ConvertAceValue(valuePlayerFourCards, fourCardListPlayer);

                                        if (valuePlayerFourCardsAceCheck > 21)
                                        {
                                            Console.WriteLine("Player busted!");
                                            money = PlayerLoseMoney(money, bet);
                                            losses++;
                                        }
                                        else if (valuePlayerFourCardsAceCheck == 21)
                                        {
                                            Console.WriteLine("Player wins!");
                                            money = PlayerWinMoney(money, bet);
                                            wins++;
                                        }
                                        else if (valuePlayerFourCardsAceCheck < 21)
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

                                                int valuePlayerFiveCardsAceCheck = win.ConvertAceValue(valuePlayerFiveCards, fiveCardListPlayer);

                                                if (valuePlayerFiveCardsAceCheck > 21)
                                                {
                                                    Console.WriteLine("Player busted!");
                                                    money = PlayerLoseMoney(money, bet);
                                                    losses++;
                                                }
                                                else if (valuePlayerFiveCardsAceCheck == 21)
                                                {
                                                    Console.WriteLine("Player wins!");
                                                    money = PlayerWinMoney(money, bet);
                                                    wins++;
                                                }
                                                else if (valuePlayerFiveCardsAceCheck < 21)
                                                {
                                                    Console.WriteLine("Five card charlie! Player wins!");
                                                    money = PlayerWinMoney(money, bet);
                                                    wins++;
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

                                                int valueDealerThreeCardsAceCheck = win.ConvertAceValue(valueDealerThreeCards, threeCardListDealer);

                                                if (valueDealerThreeCardsAceCheck > valuePlayerFourCardsAceCheck && win.CheckValueDealer(valueDealerThreeCardsAceCheck) == false && valueDealerThreeCardsAceCheck <= 21)
                                                {
                                                    Console.WriteLine("Dealer wins!");
                                                    money = PlayerLoseMoney(money, bet);
                                                    losses++;
                                                }
                                                else if (valueDealerThreeCardsAceCheck == valuePlayerFourCardsAceCheck && win.CheckValueDealer(valueDealerThreeCardsAceCheck) == false)
                                                {
                                                    Console.WriteLine("Split!");
                                                    money = PlayerSplitMoney(money);
                                                    splits++;
                                                }
                                                else if (valueDealerThreeCardsAceCheck > 21)
                                                {
                                                    Console.WriteLine("Dealer bust!");
                                                    money = PlayerWinMoney(money, bet);
                                                    wins++;
                                                }
                                                else if (win.CheckValueDealer(valueDealerThreeCardsAceCheck) == true)
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

                                                    int valueDealerFourCardsAceCheck = win.ConvertAceValue(valueDealerFourCards, fourCardListDealer);

                                                    if (valueDealerFourCardsAceCheck > valuePlayerFourCardsAceCheck && win.CheckValueDealer(valueDealerFourCardsAceCheck) == false && valueDealerFourCardsAceCheck <= 21)
                                                    {
                                                        Console.WriteLine("Dealer wins!");
                                                        money = PlayerLoseMoney(money, bet);
                                                        losses++;
                                                    }
                                                    else if (valueDealerFourCardsAceCheck == valuePlayerFourCardsAceCheck && win.CheckValueDealer(valueDealerFourCardsAceCheck) == false)
                                                    {
                                                        Console.WriteLine("Split!");
                                                        money = PlayerSplitMoney(money);
                                                        splits++;
                                                    }
                                                    else if (valueDealerFourCardsAceCheck > 21)
                                                    {
                                                        Console.WriteLine("Dealer bust!");
                                                        money = PlayerWinMoney(money, bet);
                                                        wins++;
                                                    }
                                                    else if (win.CheckValueDealer(valueDealerFourCardsAceCheck) == true)
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

                                                        int valueDealerFiveCardsAceCheck = win.ConvertAceValue(valueDealerFiveCards, fiveCardListDealer);

                                                        if (valueDealerFiveCardsAceCheck > valuePlayerFourCardsAceCheck && win.CheckValueDealer(valueDealerFiveCardsAceCheck) == false && valueDealerFiveCardsAceCheck <= 21)
                                                        {
                                                            Console.WriteLine("Dealer wins!");
                                                            money = PlayerLoseMoney(money, bet);
                                                            losses++;
                                                        }
                                                        else if (valueDealerFiveCardsAceCheck == valuePlayerFourCardsAceCheck && win.CheckValueDealer(valueDealerFiveCardsAceCheck) == false)
                                                        {
                                                            Console.WriteLine("Split!");
                                                            money = PlayerSplitMoney(money);
                                                            splits++;
                                                        }
                                                        else if (valueDealerFiveCardsAceCheck < valuePlayerFourCardsAceCheck)
                                                        {
                                                            Console.WriteLine("Player wins!");
                                                            money = PlayerWinMoney(money, bet);
                                                            wins++;
                                                        }
                                                        else if (valueDealerFiveCardsAceCheck > 21)
                                                        {
                                                            Console.WriteLine("Dealer bust!");
                                                            money = PlayerWinMoney(money, bet);
                                                            wins++;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Dealer has pulled too many cards, player wins!");
                                                            money = PlayerWinMoney(money, bet);
                                                            wins++;
                                                        }
                                                    }
                                                    else if (win.CheckValueDealer(valueDealerFourCardsAceCheck) == false && valueDealerFourCardsAceCheck > valuePlayerFourCardsAceCheck)
                                                    {
                                                        Console.WriteLine("Dealer wins!");
                                                        money = PlayerLoseMoney(money, bet);
                                                        losses++;
                                                    }
                                                }
                                                else if (win.CheckValueDealer(valueDealerThreeCardsAceCheck) == false && valueDealerThreeCardsAceCheck > valuePlayerFourCardsAceCheck)
                                                {
                                                    Console.WriteLine("Dealer wins!");
                                                    money = PlayerLoseMoney(money, bet);
                                                    losses++;
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

                                        int valueDealerThreeCardsAceCheck = win.ConvertAceValue(valueDealerThreeCards, threeCardListDealer);

                                        if (valueDealerThreeCardsAceCheck > valuePlayerThreeCardsAceCheck && win.CheckValueDealer(valueDealerThreeCardsAceCheck) == false && valueDealerThreeCardsAceCheck <= 21)
                                        {
                                            Console.WriteLine("Dealer wins!");
                                            money = PlayerLoseMoney(money, bet);
                                            losses++;
                                        }
                                        else if (valueDealerThreeCardsAceCheck == valuePlayerThreeCardsAceCheck && win.CheckValueDealer(valueDealerThreeCardsAceCheck) == false)
                                        {
                                            Console.WriteLine("Split!");
                                            money = PlayerSplitMoney(money);
                                            splits++;
                                        }
                                        else if (valueDealerThreeCardsAceCheck > 21)
                                        {
                                            Console.WriteLine("Dealer bust!");
                                            money = PlayerWinMoney(money, bet);
                                            wins++;
                                        }
                                        else if (valueDealerThreeCardsAceCheck < valuePlayerThreeCardsAceCheck && win.CheckValueDealer(valueDealerThreeCardsAceCheck) == false)
                                        {
                                            Console.WriteLine("Player wins!");
                                            money = PlayerWinMoney(money, bet);
                                            wins++;
                                        }
                                        else if (win.CheckValueDealer(valueDealerThreeCardsAceCheck) == true)
                                        {
                                            Thread.Sleep(500);
                                            int valueDealerFourCards = menu.FourCardDealer(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face,
                                        dealerCardTwo.suit, dealerCardTwo.value, dealerCardTwo.face,
                                        dealerCardThree.suit, dealerCardThree.value, dealerCardThree.face,
                                        dealerCardFour.suit, dealerCardFour.value, dealerCardFour.face);
                                            menu.ThreeCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face,
                                        playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face,
                                        playerCardThree.suit, playerCardThree.value, playerCardThree.face);

                                            int valueDealerFourCardsAceCheck = win.ConvertAceValue(valueDealerFourCards, fourCardListDealer);

                                            if (valueDealerFourCardsAceCheck > valuePlayerThreeCardsAceCheck && win.CheckValueDealer(valueDealerFourCardsAceCheck) == false && valueDealerFourCardsAceCheck <= 21)
                                            {
                                                Console.WriteLine("Dealer wins!");
                                                money = PlayerLoseMoney(money, bet);
                                                losses++;
                                            }
                                            else if (valueDealerFourCardsAceCheck == valuePlayerThreeCardsAceCheck && win.CheckValueDealer(valueDealerFourCardsAceCheck) == false)
                                            {
                                                Console.WriteLine("Split!");
                                                money = PlayerSplitMoney(money);
                                                splits++;
                                            }
                                            else if (valueDealerFourCardsAceCheck > 21)
                                            {
                                                Console.WriteLine("Dealer bust!");
                                                money = PlayerWinMoney(money, bet);
                                                wins++;
                                            }
                                            else if (valueDealerFourCardsAceCheck < valuePlayerThreeCardsAceCheck && win.CheckValueDealer(valueDealerFourCardsAceCheck) == false)
                                            {
                                                Console.WriteLine("Player wins!");
                                                money = PlayerWinMoney(money, bet);
                                                wins++;
                                            }
                                            else if (win.CheckValueDealer(valueDealerFourCardsAceCheck) == true)
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

                                                int valueDealerFiveCardsAceCheck = win.ConvertAceValue(valueDealerFiveCards, fiveCardListDealer);

                                                if (valueDealerFiveCardsAceCheck > valuePlayerThreeCardsAceCheck && valueDealerFiveCards <= 21)
                                                {
                                                    Console.WriteLine("Dealer wins!");
                                                    money = PlayerLoseMoney(money, bet);
                                                    losses++;
                                                }
                                                else if (valueDealerFiveCardsAceCheck == valuePlayerThreeCardsAceCheck)
                                                {
                                                    Console.WriteLine("Split!");
                                                    money = PlayerSplitMoney(money);
                                                    splits++;
                                                }
                                                else if (valueDealerFiveCardsAceCheck > 21)
                                                {
                                                    Console.WriteLine("Dealer bust!");
                                                    money = PlayerWinMoney(money, bet);
                                                    wins++;
                                                }
                                                else if (valueDealerFiveCardsAceCheck < valuePlayerThreeCardsAceCheck)
                                                {
                                                    Console.WriteLine("Player wins!");
                                                    money = PlayerWinMoney(money, bet);
                                                    wins++;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Dealer has pulled too many cards, player wins!");
                                                    money = PlayerWinMoney(money, bet);
                                                    wins++;
                                                }
                                            }
                                            else if (win.CheckValueDealer(valueDealerThreeCardsAceCheck) == false && valueDealerThreeCardsAceCheck > valuePlayerThreeCardsAceCheck)
                                            {
                                                Console.WriteLine("Dealer wins!");
                                                money = PlayerLoseMoney(money, bet);
                                                losses++;
                                            }

                                        }
                                        else if (win.CheckValueDealer(valueDealerThreeCardsAceCheck) == false && valueDealerThreeCardsAceCheck > valuePlayerThreeCardsAceCheck)
                                        {
                                            Console.WriteLine("Dealer wins!");
                                            money = PlayerLoseMoney(money, bet);
                                            losses++;
                                        }
                                        else if (win.CheckValueDealer(valueDealerThreeCardsAceCheck) == false && valueDealerThreeCardsAceCheck < valuePlayerThreeCardsAceCheck)
                                        {
                                            Console.WriteLine("Player wins!");
                                            money = PlayerLoseMoney(money, bet);
                                            losses++;
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

                                if (valueDealerTwoCards > valuePlayer && win.CheckValueDealer(valueDealerTwoCards) == false)
                                {
                                    Console.WriteLine("Dealer wins!");
                                    money = PlayerLoseMoney(money, bet);
                                    losses++;
                                }
                                else if (valueDealerTwoCards == valuePlayer && win.CheckValueDealer(valueDealerTwoCards) == false)
                                {
                                    Console.WriteLine("Split!");
                                    money = PlayerSplitMoney(money);
                                    splits++;
                                }
                                else if (valueDealerTwoCards < valuePlayer && win.CheckValueDealer(valueDealerTwoCards) == false)
                                {
                                    Console.WriteLine("Player wins!");
                                    money = PlayerWinMoney(money, bet);
                                    wins++;
                                }
                                else if (win.CheckValueDealer(valueDealerTwoCards) == true)
                                {
                                    Thread.Sleep(500);
                                    int valueDealerThreeCards = menu.ThreeCardDealer(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face,
                            dealerCardTwo.suit, dealerCardTwo.value, dealerCardTwo.face,
                            dealerCardThree.suit, dealerCardThree.value, dealerCardThree.face);
                                    menu.TwoCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face,
                            playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face);

                                    int valueDealerThreeCardsAceCheck = win.ConvertAceValue(valueDealerThreeCards, threeCardListDealer);

                                    if (valueDealerThreeCardsAceCheck > valuePlayer && valueDealerThreeCardsAceCheck <= 21)
                                    {
                                        Console.WriteLine("Dealer wins!");
                                        money = PlayerLoseMoney(money, bet);
                                        losses++;
                                    }
                                    else if (valueDealerThreeCardsAceCheck == valuePlayer && win.CheckValueDealer(valueDealerThreeCardsAceCheck) == false)
                                    {
                                        Console.WriteLine("Split!");
                                        money = PlayerSplitMoney(money);
                                        splits++;
                                    }
                                    else if (valueDealerThreeCardsAceCheck < valuePlayer && win.CheckValueDealer(valueDealerThreeCardsAceCheck) == false)
                                    {
                                        Console.WriteLine("Player wins!");
                                        money = PlayerWinMoney(money, bet);
                                        wins++;
                                    }
                                    else if (valueDealerThreeCardsAceCheck > 21)
                                    {
                                        Console.WriteLine("Dealer bust!");
                                        money = PlayerWinMoney(money, bet);
                                        wins++;
                                    }
                                    else if (win.CheckValueDealer(valueDealerThreeCardsAceCheck) == true)
                                    {
                                        Thread.Sleep(500);
                                        int valueDealerFourCards = menu.FourCardDealer(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face,
                            dealerCardTwo.suit, dealerCardTwo.value, dealerCardTwo.face,
                            dealerCardThree.suit, dealerCardThree.value, dealerCardThree.face,
                            dealerCardFour.suit, dealerCardFour.value, dealerCardFour.face);
                                        menu.TwoCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face,
                            playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face);

                                        int valueDealerFourCardsAceCheck = win.ConvertAceValue(valueDealerFourCards, fourCardListDealer);

                                        if (valueDealerFourCardsAceCheck > valuePlayer && valueDealerFourCardsAceCheck <= 21)
                                        {
                                            Console.WriteLine("Dealer wins!");
                                            money = PlayerLoseMoney(money, bet);
                                            losses++;
                                        }
                                        else if (valueDealerFourCardsAceCheck == valuePlayer && win.CheckValueDealer(valueDealerFourCardsAceCheck) == false)
                                        {
                                            Console.WriteLine("Split!");
                                            money = PlayerSplitMoney(money);
                                            splits++;
                                        }
                                        else if (valueDealerFourCardsAceCheck < valuePlayer && win.CheckValueDealer(valueDealerFourCardsAceCheck) == false)
                                        {
                                            Console.WriteLine("Player wins!");
                                            money = PlayerWinMoney(money, bet);
                                            wins++;
                                        }
                                        else if (valueDealerFourCardsAceCheck > 21)
                                        {
                                            Console.WriteLine("Dealer bust!");
                                            money = PlayerWinMoney(money, bet);
                                            wins++;
                                        }
                                        else if (win.CheckValueDealer(valueDealerFourCardsAceCheck) == true)
                                        {
                                            Thread.Sleep(500);
                                            int valueDealerFiveCards = menu.FiveCardDealer(dealerCardOne.suit, dealerCardOne.value, dealerCardOne.face,
                            dealerCardTwo.suit, dealerCardTwo.value, dealerCardTwo.face,
                            dealerCardThree.suit, dealerCardThree.value, dealerCardThree.face,
                            dealerCardFour.suit, dealerCardFour.value, dealerCardFour.face,
                            dealerCardFour.suit, dealerCardFour.value, dealerCardFour.face);
                                            menu.TwoCardPlayer(playerCardOne.suit, playerCardOne.value, playerCardOne.face,
                            playerCardTwo.suit, playerCardTwo.value, playerCardTwo.face);

                                            int valueDealerFiveCardsAceCheck = win.ConvertAceValue(valueDealerFiveCards, fiveCardListDealer);

                                            if (valueDealerFiveCardsAceCheck > valuePlayer && valueDealerFiveCardsAceCheck <= 21)
                                            {
                                                Console.WriteLine("Dealer wins!");
                                                money = PlayerLoseMoney(money, bet);
                                                losses++;
                                            }
                                            else if (valueDealerFiveCardsAceCheck == valuePlayer && win.CheckValueDealer(valueDealerFiveCardsAceCheck) == false)
                                            {
                                                Console.WriteLine("Split!");
                                                money = PlayerSplitMoney(money);
                                                splits++;
                                            }
                                            else if (valueDealerFiveCardsAceCheck < valuePlayer && win.CheckValueDealer(valueDealerFiveCardsAceCheck) == false)
                                            {
                                                Console.WriteLine("Player wins!");
                                                money = PlayerWinMoney(money, bet);
                                                wins++;
                                            }
                                            else if (valueDealerFiveCardsAceCheck > 21)
                                            {
                                                Console.WriteLine("Dealer bust!");
                                                money = PlayerWinMoney(money, bet);
                                                wins++;
                                            }
                                            else if (win.CheckValueDealer(valueDealerFiveCardsAceCheck) == true)
                                            {
                                                Console.WriteLine("Dealer has pulled too many cards, player wins!");
                                                money = PlayerWinMoney(money, bet);
                                                wins++;
                                            }
                                        }
                                    }
                                }
                                else if (win.CheckValueDealer(valueDealerTwoCards) == false && valueDealerTwoCards > valuePlayer)
                                {
                                    Console.WriteLine("Dealer wins!");
                                    money = PlayerLoseMoney(money, bet);
                                    losses++;
                                }
                            }
                        }

                        Console.Write($"Round: {roundCount} Wins: {wins} Losses: {losses} Money: {money}");
                        Console.Read();

                        round = false;
                        roundCount++;
                    }
                }
            }
        }

        public int PlayerWinMoney(int money, int bet)
        {
            int win = bet * 2;
            money = money + win;
            return money;
        }

        public int PlayerSplitMoney(int money)
        {
            return money;
        }

        public int PlayerLoseMoney(int money, int bet)
        {
            int loss = money - bet;
            return loss;
        }
    }
}
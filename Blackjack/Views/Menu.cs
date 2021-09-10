using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Views
{
    public class Menu
    {
        // Dessa strängar finns för att slippa behöva kopiera och klistra
        private string spacing40 = "                                        ";
        private string spacing10 = "          ";
        private string spacing5 = "     ";

        public bool Intro()
        {
            // Denna bool är för att eventuell implementera databas
            bool firstTime = false;
            bool menuLoop = true;

            SoundPlayer sound = new SoundPlayer("music.wav");

            Console.SetWindowSize(160, 40);
            // Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine(@"
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                 /$$$$$$$  /$$                     /$$                               /$$      
                                | $$__  $$| $$                    | $$                              | $$      
                                | $$  \ $$| $$  /$$$$$$   /$$$$$$$| $$   /$$ /$$  /$$$$$$   /$$$$$$$| $$   /$$
                                | $$$$$$$ | $$ |____  $$ /$$_____/| $$  /$$/|__/ |____  $$ /$$_____/| $$  /$$/
                                | $$__  $$| $$  /$$$$$$$| $$      | $$$$$$/  /$$  /$$$$$$$| $$      | $$$$$$/ 
                                | $$  \ $$| $$ /$$__  $$| $$      | $$_  $$ | $$ /$$__  $$| $$      | $$_  $$ 
                                | $$$$$$$/| $$|  $$$$$$$|  $$$$$$$| $$ \  $$| $$|  $$$$$$$|  $$$$$$$| $$ \  $$
                                |_______/ |__/ \_______/ \_______/|__/  \__/| $$ \_______/ \_______/|__/  \__/
                                                                       /$$  | $$                              
                                                                      |  $$$$$$/                              
                                                                       \______/                               
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

                                                                      (1) Play
                                                                      (2) Exit

                                  ");


            while (menuLoop == true)
            {
                Console.Write(spacing40 + spacing10 + spacing10 + spacing10 + spacing5);
                var input = Console.ReadLine();
                // int inputInt = Convert.ToInt32(input);
                
                switch (input)
                {
                    case "1":
                        GameIntro();
                        sound.Play();
                        Game();
                        menuLoop = false;
                        break;
                    case "2":
                        System.Environment.Exit(1);
                        break;
                    default:
                        Intro();
                        break;
                }
            }

            return firstTime;

        }

        public void Game()
        {
            EmptyTable();
            Bet();
        }

        public void GameIntro()
        {
            Console.Clear();
            Console.Write(
@" ______________________________________________________________________________________________________________________________________________________________ 
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                      ______________________________________________                                                          |
|                                                    /                                                \                                                        |
|                                                   |  ♦       Welcome to blackjack!                ♥  |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |          The rules are simple, you start off     |                                                       |
|                                                   |          with 1000$ and in order to beat the     |                                                       |
|                                                   |          game you need to win 10,000$.           |                                                       |
|                                                   |          Good luck on your task fresh one,       |                                                       |
|                                                   |          and please remember...                  |                                                       |
|                                                   |          the house always wins.                  |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |          Press any key to continue...            |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |  ♠                                            ♣  |                                                       |
|                                                    \ _______________________________________________/                                                        |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|______________________________________________________________________________________________________________________________________________________________|
");
            Console.ReadKey();
        }

            public void EmptyTable()
        {
            Console.Clear();
            Console.Write(
@" ______________________________________________________________________________________________________________________________________________________________ 
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|______________________________________________________________________________________________________________________________________________________________|
");
        }

        public void Bet()
        {
            Console.Write(
@"|                           ||                 ||                                                                                                              |
|                           ||   (B) Bet       ||                                                                                                              |
|                           ||                 ||                                                                                                              |
|                           ||                 ||                                                                                                              |
|                           ||   (R) Rebet     ||                (P) Play                                                                                      |
|                           ||                 ||                                                                                                              |
|                           ||                 ||                                                                                                              |
|___________________________||_________________||______________________________________________________________________________________________________________|
");
        }

        public void OneCardPlayer(string suit, int faceValue, string face)
        {
            int value = faceValue;
            var menuController = new Controllers.MenuController();
            string spacingValue = menuController.IsDoubleDigit(value);

            string faceDisplay = menuController.CardDisplay(face);
            Console.Write(
$@"|                                                                                                                                                              |
|                         _____                                                                                                                                |
|                        |    {suit}|                                                                                                                               |
|                        ");
            Console.WriteLine("|  " + faceDisplay + " |                                                                                                                               |");
            Console.WriteLine(
$@"|     Value: {value}" + spacingValue + $@"          |     |                                                                                                                               |
|                        |_____|                                                                                                                               |
|                        {face}                                                                                                                              |
|                                                                                                                                                              |
|______________________________________________________________________________________________________________________________________________________________|
");
        }

        public int TwoCardPlayer(string suit1, int faceValue1, string face1, string suit2, int faceValue2, string face2)
        {
            int value = faceValue1 + faceValue2;
            var menuController = new Controllers.MenuController();
            string spacingValue = menuController.IsDoubleDigit(value);
            string spacingCardOne = menuController.IsDoubleDigit(faceValue1);
            string spacingCardTwo = menuController.IsDoubleDigit(faceValue2);

            string faceDisplayOne = menuController.CardDisplay(face1);
            string faceDisplayTwo = menuController.CardDisplay(face2);

            Console.Write(
$@"|                                                                                                                                                              |
|                         _____    _____                                                                                                                       |
|                        |    {suit1}|  |    {suit2}|                                        (H) Hit                                                                       |
|                        ");
           Console.Write("|  " + faceDisplayOne+ " |");
           Console.WriteLine("  |  " + faceDisplayTwo + " |                                                                                                                      |");
           Console.Write(
$@"|     Value: {value}" + spacingValue + $@"          |     |  |     |                                        (S) Stand                                                                     |
|                        |_____|  |_____|                                                                                                                      |
|                         {face1} {face2}                                      (D) Double                                                                    |
|                                                                                                                                                              |
|______________________________________________________________________________________________________________________________________________________________|
");
            return value;
        }

        public void ThreeCardPlayer(string suit1, int faceValue1, string face1, string suit2, int faceValue2, string face2, string suit3, int faceValue3, string face3)
        {
            int value = faceValue1 + faceValue2 + faceValue3;
            var menuController = new Controllers.MenuController();
            string spacingValue = menuController.IsDoubleDigit(value);
            string spacingCardOne = menuController.IsDoubleDigit(faceValue1);
            string spacingCardTwo = menuController.IsDoubleDigit(faceValue2);
            string spacingCardThree = menuController.IsDoubleDigit(faceValue3);

            string faceDisplayOne = menuController.CardDisplay(face1);
            string faceDisplayTwo = menuController.CardDisplay(face2);
            string faceDisplayThree = menuController.CardDisplay(face3);

            Console.Write(
$@"|                                                                                                                                                              |
|                         _____    _____    _____                                                                                                              |
|                        |    {suit1}|  |    {suit2}|  |    {suit3}|                               (H) Hit                                                                       |
|                        ");
            Console.Write("|  " + faceDisplayOne + " |");
            Console.Write("  |  " + faceDisplayTwo + " |");
            Console.WriteLine("  |  " + faceDisplayThree + " |                                                                                                             |");
            Console.Write(
 $@"|     Value: {value}" + spacingValue + $@"          |     |  |     |  |     |                               (S) Stand                                                                     |
|                        |_____|  |_____|  |_____|                                                                                                             |
|                         {face1} {face2} {face3}                             (D) Double                                                                    |
|                                                                                                                                                              |
|______________________________________________________________________________________________________________________________________________________________|
");
        }

            public void OneCardDealer(string suit, int faceValue, string face)
        {
            int value = faceValue;
            var menuController = new Controllers.MenuController();
            string spacingValue = menuController.IsDoubleDigit(value);

            string faceDisplay = menuController.CardDisplay(face);
            Console.Clear();
            Console.Write(
$@" ______________________________________________________________________________________________________________________________________________________________
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                         _____                                                                                                                                |
|                        |    {suit}|                                                                                                                               |
|                        ");
            Console.WriteLine("|  " + faceDisplay + " |                                                                                                                               |");
            Console.Write(
$@"|     Value: {value}" + spacingValue + $@"          |     |                                                                                                                               |
|                        |_____|                                                                                                                               |
|                         {face}                                                                                                                             |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|______________________________________________________________________________________________________________________________________________________________|
");
        }

        public void OneCardDealerFaceDown(string suit, int faceValue, string face)
        {
            int value = faceValue;
            var menuController = new Controllers.MenuController();
            string spacingValue = menuController.IsDoubleDigit(value);

            string faceDisplay = menuController.CardDisplay(face);
            Console.Clear();
            Console.Write(
$@" ______________________________________________________________________________________________________________________________________________________________
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                         _____    _____                                                                                                                       |
|                        |    {suit}|  |<><><|                                                                                                                      |
|                        ");
            Console.WriteLine("|  " + faceDisplay + " |  |><><>|                                                                                                                      |");
            Console.Write(
$@"|     Value: {value}" + spacingValue + $@"          |     |  |<><><|                                                                                                                      |
|                        |_____|  |_____|                                                                                                                      |
|                         {face}                                                                                                                             |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|______________________________________________________________________________________________________________________________________________________________|
");
        }

        public void OneCardDealerCardCheck(string suit, int faceValue, string face)
        {
            int value = faceValue;
            var menuController = new Controllers.MenuController();
            string spacingValue = menuController.IsDoubleDigit(value);

            string faceDisplay = menuController.CardDisplay(face);
            Console.Clear();
            Console.Write(
$@" ______________________________________________________________________________________________________________________________________________________________
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                         _____    _____                                                                                                                       |
|                        |    {suit}|  |<><><|                                                                                                                      |
|                        ");
            Console.WriteLine("|  " + faceDisplay + " |  |><><>|   Dealer checks his card...                                                                                          |");
            Console.Write(
$@"|     Value: {value}" + spacingValue + $@"          |     |  |<><><|                                                                                                                      |
|                        |_____|  |_____|                                                                                                                      |
|                         {face}                                                                                                                             |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|______________________________________________________________________________________________________________________________________________________________|
");
        }

        public int TwoCardDealer(string suit1, int faceValue1, string face1, string suit2, int faceValue2, string face2)
        {
            int value = faceValue1 + faceValue2;
            var menuController = new Controllers.MenuController();
            string spacingValue = menuController.IsDoubleDigit(value);
            string spacingCardOne = menuController.IsDoubleDigit(faceValue1);
            string spacingCardTwo = menuController.IsDoubleDigit(faceValue2);

            string faceDisplayOne = menuController.CardDisplay(face1);
            string faceDisplayTwo = menuController.CardDisplay(face2);
            Console.Clear();
            Console.Write(
$@" ______________________________________________________________________________________________________________________________________________________________
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                         _____    _____                                                                                                                       |
|                        |    {suit1}|  |    {suit2}|                                                                                                                      |
|                        ");
            Console.Write("|  " + faceDisplayOne + " |");
            Console.WriteLine("  |  " + faceDisplayTwo + " |                                                                                                                      |");
            Console.Write(
$@"|     Value: {value}" + spacingValue + $@"          |     |  |     |                                                                                                                      |
|                        |_____|  |_____|                                                                                                                      |
|                         {face1} {face2}                                                                                                                    |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|______________________________________________________________________________________________________________________________________________________________|
");
            return value;
        }

        public int ThreeCardDealer(string suit1, int faceValue1, string face1, string suit2, int faceValue2, string face2, string suit3, int faceValue3, string face3)
        {
            int value = faceValue1 + faceValue2 + faceValue3;
            var menuController = new Controllers.MenuController();
            string spacingValue = menuController.IsDoubleDigit(value);
            string spacingCardOne = menuController.IsDoubleDigit(faceValue1);
            string spacingCardTwo = menuController.IsDoubleDigit(faceValue2);
            string spacingCardThree = menuController.IsDoubleDigit(faceValue3);

            string faceDisplayOne = menuController.CardDisplay(face1);
            string faceDisplayTwo = menuController.CardDisplay(face2);
            string faceDisplayThree = menuController.CardDisplay(face3);
            Console.Clear();
            Console.Write(
$@" ______________________________________________________________________________________________________________________________________________________________
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                         _____    _____    _____                                                                                                              |
|                        |    {suit1}|  |    {suit2}|  |    {suit3}|                                                                                                             |
|                        ");
            Console.Write("|  " + faceDisplayOne + " |");
            Console.Write("  |  " + faceDisplayTwo + " |");
            Console.WriteLine("  |  " + faceDisplayThree + " |                                                                                                             |");
            Console.Write(
$@"|     Value: {value}" + spacingValue + $@"          |     |  |     |  |     |                                                                                                             |
|                        |_____|  |_____|  |_____|                                                                                                             |
|                         {face1} {face2} {face3}                                                                                                           |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|______________________________________________________________________________________________________________________________________________________________|
");
            return value;
        }


    }
}

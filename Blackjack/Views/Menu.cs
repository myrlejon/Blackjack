using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.Write(
$@"|                                                                                                                                                              |
|                         _____                                                                                                                                |
|                        |    {suit}|                                                                                                                               |
|                        ");
            Console.WriteLine("|  " + faceValue + spacingValue + " |                                                                                                                               |");
            Console.WriteLine(
$@"|     Value: {value}" + spacingValue + $@"          |     |                                                                                                                               |
|                        |_____|                                                                                                                               |
|                        {face}                                                                                                                              |
|                                                                                                                                                              |
|______________________________________________________________________________________________________________________________________________________________|
");
        }

        public void TwoCardPlayer(string suit1, int faceValue1, string face1, string suit2, int faceValue2, string face2)
        {
            int value = faceValue1 + faceValue2;
            var menuController = new Controllers.MenuController();
            string spacingValue = menuController.IsDoubleDigit(value);
            string spacingCardOne = menuController.IsDoubleDigit(faceValue1);
            string spacingCardTwo = menuController.IsDoubleDigit(faceValue2);

            Console.Write(
$@"|                                                                                                                                                              |
|                         _____    _____                                                                                                                       |
|                        |    {suit1}|  |    {suit2}|                                        (H) Hit                                                                       |
|                        ");
           Console.Write("|  " + faceValue1 + spacingCardOne + " |");
           Console.WriteLine("  |  " + faceValue2 + spacingCardTwo + " |                                                                                                                      |");
           Console.Write(
$@"|     Value: {value}" + spacingValue + $@"          |     |  |     |                                        (S) Stand                                                                     |
|                        |_____|  |_____|                                                                                                                      |
|                         {face1} {face2}                                      (D) Double                                                                    |
|                                                                                                                                                              |
|______________________________________________________________________________________________________________________________________________________________|
");
        }

        public void OneCardDealer(string suit, int faceValue, string face)
        {
            int value = faceValue;
            var menuController = new Controllers.MenuController();
            string spacingValue = menuController.IsDoubleDigit(value);
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
            Console.WriteLine("|  " + faceValue + spacingValue + " |                                                                                                                               |");
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
            Console.WriteLine("|  " + faceValue + spacingValue + " |  |><><>|                                                                                                                      |");
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

        public void TwoCardDealer(string suit1, int faceValue1, string face1, string suit2, int faceValue2, string face2)
        {
            int value = faceValue1 + faceValue2;
            var menuController = new Controllers.MenuController();
            string spacingValue = menuController.IsDoubleDigit(value);
            string spacingCardOne = menuController.IsDoubleDigit(faceValue1);
            string spacingCardTwo = menuController.IsDoubleDigit(faceValue2);
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
            Console.Write("|  " + faceValue1 + spacingCardOne + " |");
            Console.WriteLine("  |  " + faceValue2 + spacingCardTwo + " |                                                                                                                      |");
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
        }


    }
}

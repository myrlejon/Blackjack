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
            Console.Write(
$@"|                                                                                                                                                              |
|                         _____                                                                                                                                |
|                        |    {suit}|                                                                                                                               |
|                        ");
            if (faceValue >= 10) { Console.WriteLine("|  " + faceValue + " |                                                                                                                               |"); }
            else { Console.WriteLine("|  " + faceValue + "  |                                                                                                                               |"); }
            Console.WriteLine(
$@"|                        |     |                                                                                                                               |
|                        |_____|                                                                                                                               |
|                        {face}                                                                                                                              |
|                                                                                                                                                              |
|______________________________________________________________________________________________________________________________________________________________|
");
        }

        public void OneCardDealer(string suit, int faceValue, string face)
        {
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
            if (faceValue >= 10) { Console.WriteLine("|  " + faceValue + " |                                                                                                                               |"); }
            else { Console.WriteLine("|  " + faceValue + "  |                                                                                                                               |"); }
            Console.Write(
$@"|                        |     |                                                                                                                               |
|                        |_____|                                                                                                                               |
|                        {face}                                                                                                                              |
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

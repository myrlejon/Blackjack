using System;
using System.Media;

namespace Blackjack.Views
{
    // This class contains the ASCII graphics for the game.
    public class Menu
    {
        // This method runs when the application is started.
        public void Intro()
        {
            bool menuLoop = true;

            SoundPlayer sound = new SoundPlayer("music.wav");

            Console.SetWindowSize(160, 40);
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
                Console.Write("                                                                           ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        GameIntro();
                        sound.Play();
                        MenuTable();
                        Bet(1000, 0);
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
|______________________________________________________________________________________________________________________________________________________________|
");
        }

        public void MenuTable()
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
|              `}$#@@@@QX_                 `rzEQ####Q9z*`      `rU$#@@@@BEy^                       qq                                     )BBr                 |
|             'B@@@@@@@@@@=              `U@@@@@@@@@@@@@#y`  `o#@@@@@@@@@@@@#}                   `O@@O`                                .lB@@@@Bl.              |
|             x@@@@@@@@@@@K             _B@@@@@@@@@@@@@@@@8-_Q@@@@@@@@@@@@@@@@g'                !Q@@@@Q!                            .x$@@@@@@@@@@$x.           |
|             ~@@@@@@@@@@@x             E@@@@@@@@@@@@@@@@@@d$@@@@@@@@@@@@@@@@@@d              -m@@@@@@@@m-                       'L$@@@@@@@@@@@@@@@@$L'        |
|              h@@@@@@@@@Z              @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@            >M@@@@@@@@@@@@M>                   !d@@@@@@@@@@@@@@@@@@@@@@d!      |
|          `:^r*K@@@@@@@Z*(*='          B@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@g        -)W#@@@@@@@@@@@@@@@@#W)-             `M@@@@@@@@@@@@@@@@@@@@@@@@@@M`    |
|        xQ@@@@@@@@@@@@@@@@@@@B}`       *@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#:   ,rVO#@@@@@@@@@@@@@@@@@@@@@@@@#OVr,        U@@@@@@@@@@@@@@@@@@@@@@@@@@@@I    |
|       Z@@@@@@@@@@@@@@@@@@@@@@@8        <#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@B,     ,rVO#@@@@@@@@@@@@@@@@@@@@@@@@#OVr,        B@@@@@@@@@@@@@@@@@@@@@@@@@@@@B    |
|       @@@@@@@@@@@@@@@@@@@@@@@@@-          ^0@@@@@@@@@@@@@@@@@@@@@@@@@@@@5,            -)W#@@@@@@@@@@@@@@@@#W)-             K@@@@@@@@@@@@@@@@@@@@@@@@@@@@P    |
|       V@@@@@@@@@@@@@@@@@@@@@@@Z             !P#@@@@@@@@@@@@@@@@@@@@@@#I,                  >M@@@@@@@@@@@@M>                  y#@@@@@@@@@#O@@O#@@@@@@@@@#z`    |
|        r0@@@@#R]v@@@|xd#@@@@0\                -V#@@@@@@@@@@@@@@@@@@B}'                      -m@@@@@@@@m-                      !xyhKmwi! V@@c !iwmKUyx!       |
|           '-`   Q@@@B`   ``                     `vg@@@@@@@@@@@@@@Rr                           !Q@@@@Q!                                  B@@B                 |
|                s@@@@@9`                            !K#@@@@@@@@#I_                              `O@@O`                                 `P@@@@3`               |
|              .O@@@@@@@#r                             `LQ@@@@BT`                                  qq                                `=V#@@@@@@#V=`            |
|              '----------                                r8Dr                                                                      .::::::::::::::.           |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|______________________________________________________________________________________________________________________________________________________________|
");
        }

        public void Bet(int money, int bet)
        {
            Console.Write(
@$"|                           ||                 ||                                                                                                              |
|                           ||                 ||                                                                                                              |
|                           ||   (B) Bet       ||                                                                                                              |
|                           ||                 ||                                                                                                              |
|                           ||                 ||                                                                                                              |
|                           ||   (P) Play      ||                                                                                                              |
|                           ||                 ||                                                                                                              |
|___________________________||_________________||______________________________________________________________________________________________________________|
                                                                    Money: {money} Bet: {bet}
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

        public int TwoCardPlayer(string suit1, int faceValue1, string face1,
            string suit2, int faceValue2, string face2)
        {
            int value = faceValue1 + faceValue2;
            var menuController = new Controllers.MenuController();
            string spacingValue = menuController.IsDoubleDigit(value);

            string faceDisplayOne = menuController.CardDisplay(face1);
            string faceDisplayTwo = menuController.CardDisplay(face2);

            Console.Write(
$@"|                                                                                                                                                              |
|                         _____    _____                                                                                                                       |
|                        |    {suit1}|  |    {suit2}|                                        (H) Hit                                                                       |
|                        ");
            Console.Write("|  " + faceDisplayOne + " |");
            Console.WriteLine("  |  " + faceDisplayTwo + " |                                                                                                                      |");
            Console.Write(
 $@"|     Value: {value}" + spacingValue + $@"          |     |  |     |                                                                                                                      |
|                        |_____|  |_____|                                                                                                                      |
|                         {face1} {face2}                                      (S) Stand                                                                     |
|                                                                                                                                                              |
|______________________________________________________________________________________________________________________________________________________________|
");
            return value;
        }

        public int ThreeCardPlayer(string suit1, int faceValue1, string face1,
            string suit2, int faceValue2, string face2,
            string suit3, int faceValue3, string face3)
        {
            var menu = new Controllers.MenuController();
            var win = new Models.Wincondition();
            int value = faceValue1 + faceValue2 + faceValue3;

            string[] threeCardListPlayer = new string[] { face1, face2, face3 };

            int valueAceCheck = win.ConvertAceValue(value, threeCardListPlayer);

            string spacingValue = menu.IsDoubleDigit(value);

            string faceDisplayOne = menu.CardDisplay(face1);
            string faceDisplayTwo = menu.CardDisplay(face2);
            string faceDisplayThree = menu.CardDisplay(face3);

            Console.Write(
$@"|                                                                                                                                                              |
|                         _____    _____    _____                                                                                                              |
|                        |    {suit1}|  |    {suit2}|  |    {suit3}|                               (H) Hit                                                                       |
|                        ");
            Console.Write("|  " + faceDisplayOne + " |");
            Console.Write("  |  " + faceDisplayTwo + " |");
            Console.WriteLine("  |  " + faceDisplayThree + " |                                                                                                             |");
            Console.Write(
 $@"|     Value: {valueAceCheck}" + spacingValue + $@"          |     |  |     |  |     |                                                                                                             |
|                        |_____|  |_____|  |_____|                                                                                                             |
|                         {face1} {face2} {face3}                             (S) Stand                                                                     |
|                                                                                                                                                              |
|______________________________________________________________________________________________________________________________________________________________|
");
            return value;
        }

        public int FourCardPlayer(string suit1, int faceValue1, string face1,
    string suit2, int faceValue2, string face2,
    string suit3, int faceValue3, string face3,
    string suit4, int faceValue4, string face4)
        {
            var menu = new Controllers.MenuController();
            var win = new Models.Wincondition();
            int value = faceValue1 + faceValue2 + faceValue3 + faceValue4;

            string[] fourCardListPlayer = new string[] { face1, face2, face3, face4 };

            int valueAceCheck = win.ConvertAceValue(value, fourCardListPlayer);

            string spacingValue = menu.IsDoubleDigit(value);

            string faceDisplayOne = menu.CardDisplay(face1);
            string faceDisplayTwo = menu.CardDisplay(face2);
            string faceDisplayThree = menu.CardDisplay(face3);
            string faceDisplayFour = menu.CardDisplay(face4);

            Console.Write(
$@"|                                                                                                                                                              |
|                         _____    _____    _____    _____                                                                                                     |
|                        |    {suit1}|  |    {suit2}|  |    {suit3}|  |    {suit4}|                      (H) Hit                                                                       |
|                        ");
            Console.Write("|  " + faceDisplayOne + " |");
            Console.Write("  |  " + faceDisplayTwo + " |");
            Console.Write("  |  " + faceDisplayThree + " |");
            Console.WriteLine("  |  " + faceDisplayFour + " |                                                                                                    |");
            Console.Write(
 $@"|     Value: {valueAceCheck}" + spacingValue + $@"          |     |  |     |  |     |  |     |                                                                                                    |
|                        |_____|  |_____|  |_____|  |_____|                                                                                                    |
|                         {face1} {face2} {face3} {face4}                    (S) Stand                                                                     |
|                                                                                                                                                              |
|______________________________________________________________________________________________________________________________________________________________|
");
            return value;
        }

        public int FiveCardPlayer(string suit1, int faceValue1, string face1,
string suit2, int faceValue2, string face2,
string suit3, int faceValue3, string face3,
string suit4, int faceValue4, string face4,
string suit5, int faceValue5, string face5)
        {
            var menu = new Controllers.MenuController();
            var win = new Models.Wincondition();
            int value = faceValue1 + faceValue2 + faceValue3 + faceValue4 + faceValue5;

            string[] fiveCardListPlayer = new string[] { face1, face2, face3, face4, face5 };

            int valueAceCheck = win.ConvertAceValue(value, fiveCardListPlayer);
            string spacingValue = menu.IsDoubleDigit(value);

            string faceDisplayOne = menu.CardDisplay(face1);
            string faceDisplayTwo = menu.CardDisplay(face2);
            string faceDisplayThree = menu.CardDisplay(face3);
            string faceDisplayFour = menu.CardDisplay(face4);
            string faceDisplayFive = menu.CardDisplay(face5);

            Console.Write(
$@"|                                                                                                                                                              |
|                         _____    _____    _____    _____    _____                                                                                            |
|                        |    {suit1}|  |    {suit2}|  |    {suit3}|  |    {suit4}|  |    {suit5}|             (H) Hit                                                                       |
|                        ");
            Console.Write("|  " + faceDisplayOne + " |");
            Console.Write("  |  " + faceDisplayTwo + " |");
            Console.Write("  |  " + faceDisplayThree + " |");
            Console.Write("  |  " + faceDisplayFour + " |");
            Console.WriteLine("  |  " + faceDisplayFive + " |                                                                                           |");
            Console.Write(
 $@"|     Value: {valueAceCheck}" + spacingValue + $@"          |     |  |     |  |     |  |     |  |     |                                                                                           |
|                        |_____|  |_____|  |_____|  |_____|  |_____|                                                                                           |
|                         {face1} {face2} {face3} {face4} {face5}           (S) Stand                                                                     |
|                                                                                                                                                              |
|______________________________________________________________________________________________________________________________________________________________|
");
            return value;
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

        public int TwoCardDealer(string suit1, int faceValue1, string face1,
            string suit2, int faceValue2, string face2)
        {
            int value = faceValue1 + faceValue2;
            var menuController = new Controllers.MenuController();
            string spacingValue = menuController.IsDoubleDigit(value);

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

        public int ThreeCardDealer(string suit1, int faceValue1, string face1,
            string suit2, int faceValue2, string face2,
            string suit3, int faceValue3, string face3)
        {
            var menu = new Controllers.MenuController();
            var win = new Models.Wincondition();
            int value = faceValue1 + faceValue2 + faceValue3;

            string[] threeCardListPlayer = new string[] { face1, face2, face3 };

            int valueAceCheck = win.ConvertAceValue(value, threeCardListPlayer);

            string spacingValue = menu.IsDoubleDigit(value);

            string faceDisplayOne = menu.CardDisplay(face1);
            string faceDisplayTwo = menu.CardDisplay(face2);
            string faceDisplayThree = menu.CardDisplay(face3);
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
$@"|     Value: {valueAceCheck}" + spacingValue + $@"          |     |  |     |  |     |                                                                                                             |
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

        public int FourCardDealer(string suit1, int faceValue1, string face1,
            string suit2, int faceValue2, string face2,
            string suit3, int faceValue3, string face3,
            string suit4, int faceValue4, string face4)
        {
            var menu = new Controllers.MenuController();
            var win = new Models.Wincondition();
            int value = faceValue1 + faceValue2 + faceValue3 + faceValue4;

            string[] fourCardListPlayer = new string[] { face1, face2, face3, face4 };

            int valueAceCheck = win.ConvertAceValue(value, fourCardListPlayer);
            string spacingValue = menu.IsDoubleDigit(value);

            string faceDisplayOne = menu.CardDisplay(face1);
            string faceDisplayTwo = menu.CardDisplay(face2);
            string faceDisplayThree = menu.CardDisplay(face3);
            string faceDisplayFour = menu.CardDisplay(face4);
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
|                         _____    _____    _____    _____                                                                                                     |
|                        |    {suit1}|  |    {suit2}|  |    {suit3}|  |    {suit4}|                                                                                                    |
|                        ");
            Console.Write("|  " + faceDisplayOne + " |");
            Console.Write("  |  " + faceDisplayTwo + " |");
            Console.Write("  |  " + faceDisplayThree + " |");
            Console.WriteLine("  |  " + faceDisplayFour + " |                                                                                                    |");
            Console.Write(
$@"|     Value: {valueAceCheck}" + spacingValue + $@"          |     |  |     |  |     |  |     |                                                                                                    |
|                        |_____|  |_____|  |_____|  |_____|                                                                                                    |
|                         {face1} {face2} {face3} {face4}                                                                                                  |
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

        public int FiveCardDealer(string suit1, int faceValue1, string face1,
            string suit2, int faceValue2, string face2,
            string suit3, int faceValue3, string face3,
            string suit4, int faceValue4, string face4,
            string suit5, int faceValue5, string face5)
        {
            var menu = new Controllers.MenuController();
            var win = new Models.Wincondition();
            int value = faceValue1 + faceValue2 + faceValue3 + faceValue4 + faceValue5;

            string[] fiveCardListPlayer = new string[] { face1, face2, face3, face4, face5 };

            int valueAceCheck = win.ConvertAceValue(value, fiveCardListPlayer);
            string spacingValue = menu.IsDoubleDigit(value);

            string faceDisplayOne = menu.CardDisplay(face1);
            string faceDisplayTwo = menu.CardDisplay(face2);
            string faceDisplayThree = menu.CardDisplay(face3);
            string faceDisplayFour = menu.CardDisplay(face4);
            string faceDisplayFive = menu.CardDisplay(face5);
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
|                         _____    _____    _____    _____    _____                                                                                            |
|                        |    {suit1}|  |    {suit2}|  |    {suit3}|  |    {suit4}|  |    {suit5}|                                                                                           |
|                        ");
            Console.Write("|  " + faceDisplayOne + " |");
            Console.Write("  |  " + faceDisplayTwo + " |");
            Console.Write("  |  " + faceDisplayThree + " |");
            Console.Write("  |  " + faceDisplayFour + " |");
            Console.WriteLine("  |  " + faceDisplayFive + " |                                                                                           |");
            Console.Write(
$@"|     Value: {valueAceCheck}" + spacingValue + $@"          |     |  |     |  |     |  |     |  |     |                                                                                           |
|                        |_____|  |_____|  |_____|  |_____|  |_____|                                                                                           |
|                         {face1} {face2} {face3} {face4} {face5}                                                                                         |
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

        public void WinScreen(int money, int wins, int splits, int losses, int rounds)
        {
            var menuController = new Controllers.MenuController();
            string spacingWins = menuController.IsDoubleDigit(wins);
            string spacingSplits = menuController.IsDoubleDigit(splits);
            string spacingLosses = menuController.IsDoubleDigit(losses);
            string spacingRounds = menuController.IsDoubleDigit(rounds);

            Console.Clear();
            Console.Write(
@$" ______________________________________________________________________________________________________________________________________________________________
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                      ______________________________________________                                                          |
|                                                    /                                                \                                                        |
|                                                   |  ♦       You beat the game!                   ♥  |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |          Here is your stats...                   |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |          Money: {money}                            |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |          Wins: {wins}" + spacingWins + $@"                                |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |          Splits: {splits}" + spacingSplits + $@"                              |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |          Losses: {losses}" + spacingLosses + $@"                              |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |          Rounds: {rounds}" + spacingRounds + $@"                              |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |          Thank you for playing!                  |                                                       |
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
            Console.ReadLine();
            System.Environment.Exit(1);
        }

        public void LoseScreen(int money, int wins, int splits, int losses, int rounds)
        {
            var menuController = new Controllers.MenuController();
            string spacingWins = menuController.IsDoubleDigit(wins);
            string spacingSplits = menuController.IsDoubleDigit(splits);
            string spacingLosses = menuController.IsDoubleDigit(losses);
            string spacingRounds = menuController.IsDoubleDigit(rounds);

            Console.Clear();
            Console.Write(
@$" ______________________________________________________________________________________________________________________________________________________________
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                                                                                                                              |
|                                                      ______________________________________________                                                          |
|                                                    /                                                \                                                        |
|                                                   |  ♦       You lost the game!                   ♥  |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |          Here is your stats...                   |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |          Money: {money}                                |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |          Wins: {wins}" + spacingWins + $@"                                |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |          Splits: {splits}" + spacingSplits + $@"                              |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |          Losses: {losses}" + spacingLosses + $@"                              |                                                       |
|                                                   |                                                  |                                                       |
|                                                   |          Rounds: {rounds}" + spacingRounds + $@"                              |                                                       |
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
            Console.ReadLine();
            System.Environment.Exit(1);
        }
    }
}
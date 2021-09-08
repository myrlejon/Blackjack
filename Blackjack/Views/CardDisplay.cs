using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Views
{
    class CardDisplay
    {
        public void PrintCard(string suit, int faceValue, string face)
        {
            Console.WriteLine(" _____");
            Console.WriteLine("|    " + suit + "|");
            if (faceValue >= 10) { Console.WriteLine("|  " + faceValue + " |"); }
            else { Console.WriteLine("|  " + faceValue + "  |"); }
            Console.WriteLine("|     |");
            Console.WriteLine("|_____|");
            Console.WriteLine(" " + face);
        }



        public void PrintCardBack()
        {
            Console.WriteLine(" _____");
            Console.WriteLine("|<><><|");
            Console.WriteLine("|><><>|");
            Console.WriteLine("|<><><|");
            Console.WriteLine("|_____|");
        }
        /*
        public int ConvertCardToInt(string face)
        {
            int value = 0;

            if (face == "Ace")
            {
                value = 1;
            }
            else if (face == "Two")
            {
                value = 2;
            }
            else if (face == "Three")
            {
                value = 3;
            }
            else if (face == "Four")
            {
                value = 4;
            }
            else if (face == "Five")
            {
                value = 5;
            }
            else if (face == "Six")
            {
                value = 6;
            }
            else if (face == "Seven")
            {
                value = 7;
            }
            else if (face == "Eight")
            {
                value = 8;
            }
            else if (face == "Nine")
            {
                value = 9;
            }
            else if (face == "Ten" || face == "Jack" || face == "Queen" || face == "King")
            {
                value = 10;
            }

            return value;
        }
        */
    }
}

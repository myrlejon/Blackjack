using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Views
{
    public class Menu
    {
        public bool Intro()
        {
            bool firstTime = false;

            Console.SetWindowSize(160, 40);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            
            return firstTime;

        }
    }
}

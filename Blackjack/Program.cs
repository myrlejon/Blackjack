using System;
using System.Collections.Generic;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Controllers.GameController();
            game.Game();
        }
    }
}

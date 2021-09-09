using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Controllers
{
    class MenuController
    {
        public string IsDoubleDigit(int value)
        {
            string spacing = "";
            if (10 > value)
            {
                spacing = " ";
            }
            return spacing;
        }
    }
}

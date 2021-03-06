namespace Blackjack.Controllers
{
    // This class helps the graphics for the Menu class. 
    internal class MenuController
    {
        // This method changes the spacing if the value is double digit or not.
        public string IsDoubleDigit(int value)
        {
            string spacing = "";
            if (10 > value)
            {
                spacing = " ";
            }
            return spacing;
        }

        // This method displays the face you see on the card.
        public string CardDisplay(string face)
        {
            string value = "";

            if (face == "Ace     ") { value = "A "; }
            else if (face == "Two     ") { value = "2 ";}
            else if (face == "Three   ") { value = "3 "; }
            else if (face == "Four    ") { value = "4 "; }
            else if (face == "Five    ") { value = "5 "; }
            else if (face == "Six     ") { value = "6 "; }
            else if (face == "Seven   ") { value = "7 "; }
            else if (face == "Eight   ") { value = "8 "; }
            else if (face == "Nine    ") { value = "9 "; }
            else if (face == "Ten     ") { value = "10"; }
            else if (face == "Jack    ") { value = "J "; }
            else if (face == "Queen   ") { value = "Q "; }
            else if (face == "King    ") { value = "K "; }

            return value;
        }
    }
}
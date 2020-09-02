using System;
using System.Collections.Generic;
using System.Text;

namespace ShopGame
{
    //This derived class inherits the properties from the item class to reuse, extend and modify in this class.
    class Armour : Item
    {
        public int defenceModifier;

        //This constructor inherits the Item class variables as well as adding a new variable to it
        public Armour(string _name, string _desc, int _cost, string _type, int _defMod) : base(_name, _desc, _cost, _type)
        {
            defenceModifier = _defMod;
        }

        //This adds more information to the print function in the Item class
        public override void PrintItem()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            base.PrintItem();
            Console.WriteLine("This armour gives you " + defenceModifier + " armour");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
    }
}

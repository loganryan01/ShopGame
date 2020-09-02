using System;
using System.Collections.Generic;
using System.Text;

namespace ShopGame
{
    //This derived class inherits the properties from the item class to reuse, extend and modify in this class.
    class Weapon : Item
    {
        public int attackModifier;

        //This constructor inherits the Item class variables as well as adding a new variable to it
        public Weapon(string _name, string _desc, int _cost, string _type, int _atkMod) : base ( _name,  _desc,  _cost,  _type)
        {
            attackModifier = _atkMod;
        }

        //This adds more information to the print function in the Item class
        public override void PrintItem()
        {
            base.PrintItem();
            Console.WriteLine("This weapon deals " + attackModifier + " damage");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
    }
}

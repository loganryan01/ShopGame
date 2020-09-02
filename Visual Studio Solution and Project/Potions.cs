using System;
using System.Collections.Generic;
using System.Text;

namespace ShopGame
{
    //This derived class inherits the properties from the item class to reuse, extend and modify in this class.
    class Potions : Item
    {
        //This constructor inherits the Item class variables.
        public Potions(string _name, string _desc, int _cost, string _type) : base(_name, _desc, _cost, _type)
        {
            
        }

        //This adds more information to the print function in the Item class
        public override void PrintItem()
        {
            base.PrintItem();
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
    }
}

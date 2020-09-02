using System;
using System.Collections.Generic;
using System.Text;

namespace ShopGame
{
    //This derived class inherits the properties from the type of item class to reuse, extend and modify in this class.
    class Shield : Armour
    {
        //This constructor inherits the Armour class variables as well as setting them with a new value.
        public Shield(string _name, string _desc, int _cost, string _type, int _defMod) : base(_name, _desc, _cost, _type, _defMod)
        {
            type = "shield";
            name = "pride’s Honour";
            description = "this shield was crafted for the Queen of this land but she refused as she wass already protected by a castle.";
            cost = 10;
            defenceModifier = 4;
        }
    }
}

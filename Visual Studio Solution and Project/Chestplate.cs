using System;
using System.Collections.Generic;
using System.Text;

namespace ShopGame
{
    //This derived class inherits the properties from the type of item class to reuse, extend and modify in this class.
    class Chestplate : Armour
    {
        //This constructor inherits the Armour class variables as well as setting them with a new value.
        public Chestplate(string _name, string _desc, int _cost, string _type, int _defMod) : base(_name, _desc, _cost, _type, _defMod)
        {
            type = "chestplate";
            name = "steel Chestguard of Eternal Torment";
            description = "if an enemy were to strike you while you are wearing this chestplate they will be put into eternal torment.";
            cost = 20;
            defenceModifier = 5;
        }
    }
}

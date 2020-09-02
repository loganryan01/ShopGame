using System;
using System.Collections.Generic;
using System.Text;

namespace ShopGame
{
    //This derived class inherits the properties from the type of item class to reuse, extend and modify in this class.
    class Helmet : Armour
    {
        //This constructor inherits the Armour class variables as well as setting them with a new value.
        public Helmet(string _name, string _desc, int _cost, string _type, int _defMod) : base(_name, _desc, _cost, _type, _defMod)
        {
            type = "helmet";
            name = "silver Helmet of Sacred Dreams";
            description = "it holds all the dreams that you had";
            cost = 5;
            defenceModifier = 2;
        }
    }
}

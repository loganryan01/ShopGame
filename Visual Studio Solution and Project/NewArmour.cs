using System;
using System.Collections.Generic;
using System.Text;

namespace ShopGame
{
    //This derived class inherits the properties from the type of item class to reuse, extend and modify in this class.
    class NewArmour : Armour
    {
        //This constructor inherits the Armour class variables.
        public NewArmour(string _name, string _desc, int _cost, string _type, int _defMod) : base(_name, _desc, _cost, _type, _defMod)
        {

        }
    }
}

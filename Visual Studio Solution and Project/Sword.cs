using System;
using System.Collections.Generic;
using System.Text;

namespace ShopGame
{
    //This derived class inherits the properties from the type of item class to reuse, extend and modify in this class.
    class Sword : Weapon
    {
        //This constructor inherits the Weapon class variables as well as setting them with a new value.
        public Sword(string _name, string _desc, int _cost, string _type, int _atkMod) : base( _name,  _desc,  _cost,  _type,  _atkMod)
        {
            type = "sword";
            name = "dragon's Tooth";
            description = "it was made from the tooth of a dragon and can cut through anything";
            cost = 10;
            attackModifier = 5;
        }
    }
}

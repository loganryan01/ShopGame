using System;
using System.Collections.Generic;
using System.Text;

namespace ShopGame
{
    //This derived class inherits the properties from the type of item class to reuse, extend and modify in this class.
    class Axe : Weapon
    {
        //This constructor inherits the Weapon class variables as well as setting them with a new value.
        public Axe(string _name, string _desc, int _cost, string _type, int _atkMod) : base(_name, _desc, _cost, _type, _atkMod)
        {
            type = "axe";
            name = "oathbreaker";
            description = "legend says that it belonged to a great king until he vanished without a trace";
            cost = 25;
            attackModifier = 10;
        }
    }
}

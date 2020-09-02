using System;
using System.Collections.Generic;
using System.Text;

namespace ShopGame
{
    //This derived class inherits the properties from the type of item class to reuse, extend and modify in this class.
    class Dagger : Weapon
    {
        //This constructor inherits the Weapon class variables as well as setting them with a new value.
        public Dagger(string _name, string _desc, int _cost, string _type, int _atkMod) : base(_name, _desc, _cost, _type, _atkMod)
        {
            type = "dagger";
            name = "fury";
            description = "it was crafted by a lonely Moonwalker to hopefully avenge his wife’s death. ";
            cost = 5;
            attackModifier = 2;
        }
    }
}

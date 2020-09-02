using System;
using System.Collections.Generic;
using System.Text;

namespace ShopGame
{
    //This derived class inherits the properties from the type of item class to reuse, extend and modify in this class.
    class Boots : Armour
    {
        //This constructor inherits the Armour class variables as well as setting them with a new value.
        public Boots(string _name, string _desc, int _cost, string _type, int _defMod) : base(_name, _desc, _cost, _type, _defMod)
        {
            type = "boots";
            name = "chainmail Footguards of Endless Punishment";
            description = "one strike from these footguards will lead the enemy into an endless punishment";
            cost = 10;
            defenceModifier = 4;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ShopGame
{
    //This derived class inherits the properties from the type of item class to reuse, extend and modify in this class.
    class NewWeapon : Weapon
    {
        //This constructor inherits the Weapon class variables.
        public NewWeapon(string _name, string _desc, int _cost, string _type, int _atkMod) : base(_name, _desc, _cost, _type, _atkMod)
        {

        }
    }
}

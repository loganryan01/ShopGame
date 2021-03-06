﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShopGame
{
    //This derived class inherits the properties from the type of item class to reuse, extend and modify in this class.
    class Healing : Potions
    {
        //This constructor inherits the Potions class variables as well as setting them with a new value.
        public Healing(string _name, string _desc, int _cost, string _type) : base(_name, _desc, _cost, _type)
        {
            type = "healing";
            name = "potion of healing";
            description = "this restores a small portion of your health";
            cost = 5;
        }
    }
}

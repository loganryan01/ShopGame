﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShopGame
{
    //This derived class inherits the properties from the type of item class to reuse, extend and modify in this class.
    class NewPotion : Potions
    {
        //This constructor inherits the Potions class variables.
        public NewPotion(string _name, string _desc, int _cost, string _type) : base(_name, _desc, _cost, _type)
        {

        }
    }
}

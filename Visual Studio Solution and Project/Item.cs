using System;
using System.Collections.Generic;
using System.Text;

namespace ShopGame
{
    //This is the main class for the items in the game
    public class Item 
    {
        public string name;
        public string description;
        public int cost;
        public string type;

        //This constructor sets the name, description, cost and type variables to the items
        public Item(string _name, string _desc, int _cost, string _type)
        {
            name = _name;
            description = _desc;
            cost = _cost;
            type = _type;
        }
        
        //Prints the information about the Item
        public virtual void PrintItem()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This item is the " + char.ToUpper(name[0]) + name.Substring(1) + ".");
            Console.WriteLine(char.ToUpper(description[0]) + description.Substring(1));
            Console.WriteLine("This item costs " + cost + " gold.");
        }

        //Gets the price of the item
        public static int GetPrice(Item itemWanted)
        {
            return itemWanted.cost;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopGame
{
    //This class is used to create the shop and player's inventory to store the items
    class Inventory 
    {
        public Item[] inventory;

        //Sets the capacity for each of the inventories
        public Inventory(int capacity = 10) 
        {
            inventory = new Item[capacity];
        }

        //Gets the length of the inventories
        public int GetCapacityLength 
        { 
            get 
            {
                return inventory.Length;
            } 
        }
        
        //Adds a specific item to the specific inventory
        public int AddItem(Item itemWanted)
        {
            if (inventory != null)
            {
                for (int i = 0; i < inventory.Length; ++i)
                {
                    if (inventory[i] == null)
                    {
                        inventory[i] = itemWanted;
                        return i;
                    }
                }
            }
            return -1;
        }

        //Removes a specific item from the specific inventory
        public bool RemoveItem(Item itemBought)
        {
            for (int i = 0; i < inventory.Length; ++i)
            {
                if (inventory[i] == itemBought)
                {
                    inventory[i] = null;
                    return true;
                }
            }
            return false;
        }
        
        //Checks for a free spot in an inventory
        public bool CheckFreeSpot()
        {
            for (int i = 0; i < inventory.Length; ++i)
            {
               if (inventory[i] == null)
               {
                  return true;
               }
            }  
            return false;
        }

        //Finds a specific item in an inventory
        public Item FindItem(string itemType)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] != null)
                {
                    if (inventory[i].type.ToLower() == itemType.ToLower())
                    {
                        return inventory[i];
                    }
                }               
            }
            return null;
        }

        //Removes duplicates in the inventories
        public void RemoveDuplicates()
        {
            Array.Clear(inventory, 0, inventory.Length);
        }
    }
}

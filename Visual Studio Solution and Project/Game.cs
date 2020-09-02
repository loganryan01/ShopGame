using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ShopGame
{
    //This class is the main heart of the game as it stores all the responses and commands for the game
    public class Game 
    {
        //Type of item avaliable
        static string[] weapons = new string[] { };
        static string[] armour = new string[] { };
        static string[] potions = new string[] { };

        //Player's money
        static int playerFunds = 100;

        //Inventories
        static Inventory playerInventory = new Inventory();
        static Inventory shopInventory = new Inventory(50);

        //Weapons
        static Sword sword = new Sword("Sword", "It hurts", 10, "Sword", 5);
        static Axe axe = new Axe("Axe", "It's big", 20, "Axe", 10);
        static Bow bow = new Bow("Bow", "It's long", 5, "Bow", 2);
        static Dagger dagger = new Dagger("Dagger", "It's short", 5, "Dagger", 2);
        static NewWeapon _newWeapon = new NewWeapon("name", "desc", 5, "type", 5);

        //Armour
        static Helmet helmet = new Helmet("Helmet", "It protects your head", 5, "Helemt", 2);
        static Chestplate chestplate = new Chestplate("Chestplate", "It protects your chest", 20, "Chestplate", 5);
        static Boots boots = new Boots("Boots", "It protects your feet", 10, "Boots", 4);
        static Gloves gloves = new Gloves("Gloves", "It protects your hands", 5, "Gloves", 2);
        static Shield shield = new Shield("Shield", "It blocks attacks", 10, "Shield", 4);
        static NewArmour _newArmour = new NewArmour("name", "desc", 5, "type", 5);

        //Potions
        static Healing healing = new Healing("Healing", "Heals your health", 5, "Healing");
        static Shielding shielding = new Shielding("Shielding", "Restores shield", 5, "Shielding");
        static Invincibility invincibility = new Invincibility("invincinbility", "Shields you for a short time", 5, "Invincibility");
        static Rage rage = new Rage("Rage", "Doubles your attack", 5, "Rage");
        static NewPotion _newPotion = new NewPotion("name", "desc", 5, "type");

        //Print out Welcome and start game
        public static void Init()
        {
            //shopInventory.AddItem(sword);
            //shopInventory.AddItem(axe);
            //shopInventory.AddItem(bow);
            //shopInventory.AddItem(dagger);
            //shopInventory.AddItem(helmet);
            //shopInventory.AddItem(chestplate);
            //shopInventory.AddItem(boots);
            //shopInventory.AddItem(gloves);
            //shopInventory.AddItem(shield);
            //shopInventory.AddItem(healing);
            //shopInventory.AddItem(shielding);
            //shopInventory.AddItem(invincibility);
            //shopInventory.AddItem(rage);
            //SaveInventory();
            LoadInventory();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to my shop!");

            PlayerResponse();
        }

        //Ask for players response
        static void PlayerResponse()
        {
            string input = "";

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("What can I do for you? (Buy/Sell/View/Leave)");

            Console.ForegroundColor = ConsoleColor.Gray;
            input = Console.ReadLine().ToLower();
            if (input == "buy")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Great. Would you like to view my (W)eapons, (A)rmour or (P)otions?");
                DisplayInventory();
            }
            else if (input == "sell")
            {
                SellItem();
            }
            else if (input == "view")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This what is in your Inventory currently");
                for (int i = 0; i < playerInventory.GetCapacityLength; i++)
                {
                    if (playerInventory.inventory[i] != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Inventory Slot [{0}]: {1}", i, char.ToUpper(playerInventory.inventory[i].name[0]) + playerInventory.inventory[i].name.Substring(1));
                    }
                    else if (playerInventory.inventory[i] == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Inventory Slot [{0}]: {1}", i, null);
                    }
                    else
                    {
                        break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Press Enter to return");
                Console.ReadKey();
                Console.Clear();
                PlayerResponse();
            }
            else if (input == "create")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Welcome to the blacksmith");
                Console.WriteLine("What would you like to create? (Weapon/Armour/Potion)");
                Create();
            }
            else if (input == "leave")
            {
                SaveInventory();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ok Goodbye");
                Console.WriteLine("Press Enter to exit");
                Environment.Exit(0);
            }
        }

        //Display shops inventory
        static void DisplayInventory()
        {
            string input = "";
            string[] dWeapons = weapons.Distinct().ToArray();
            string[] dArmour = armour.Distinct().ToArray();
            string[] dPotions = potions.Distinct().ToArray();

            Console.ForegroundColor = ConsoleColor.Gray;
            input = Console.ReadLine().ToLower();
            if (input == "w")
            {
                if (weapons == null || weapons.Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no more weapons available");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadKey();
                    Console.Clear();
                    PlayerResponse();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Type the name of the weapon that you want to view");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Array.ForEach(dWeapons, v => Console.WriteLine(v));
                    DisplayItem();
                }
            }
            else if (input == "a")
            {
                if (armour == null || armour.Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no more armour available");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadKey();
                    Console.Clear();
                    PlayerResponse();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Type the name of the armour that you want to view");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Array.ForEach(dArmour, v => Console.WriteLine(v));
                    DisplayItem();
                }
            }
            else if (input == "p")
            {
                if (potions == null || potions.Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no more potions available");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadKey();
                    Console.Clear();
                    PlayerResponse();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Type the name of the potion that you want to view");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Array.ForEach(dPotions, v => Console.WriteLine(v));
                    DisplayItem();
                }
            }
        }

        //Checks if item is available and if it is then prints information
        static void DisplayItem() 
        {
            string input = "";
            Console.ForegroundColor = ConsoleColor.Gray;
            input = Console.ReadLine().ToLower();

            if (input == "sword")
            {
                Item pur = shopInventory.FindItem("sword");
                if (pur == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I'm sorry but I no longer have this item");
                    ContinueShopping();
                }
                else
                {
                    pur.PrintItem();
                    PurchaseItem(pur);
                }
            }
            else if (input == "axe")
            {
                Item pur = shopInventory.FindItem("axe");
                if (pur == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I'm sorry but I no longer have this item");
                    ContinueShopping();
                }
                else
                {
                    pur.PrintItem();
                    PurchaseItem(pur);
                }
            }
            else if (input == "bow")
            {
                Item pur = shopInventory.FindItem("bow");
                if (pur == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I'm sorry but I no longer have this item");
                    ContinueShopping();
                }
                else
                {
                    pur.PrintItem();
                    PurchaseItem(pur);
                }
            }
            else if (input == "dagger")
            {
                Item pur = shopInventory.FindItem("dagger");
                if (pur == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I'm sorry but I no longer have this item");
                    ContinueShopping();
                }
                else
                {
                    pur.PrintItem();
                    PurchaseItem(pur);
                }
            }
            else if (input == "helmet")
            {
                Item pur = shopInventory.FindItem("helmet");
                if (pur == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I'm sorry but I no longer have this item");
                    ContinueShopping();
                }
                else
                {
                    pur.PrintItem();
                    PurchaseItem(pur);
                }
            }
            else if (input == "chestplate")
            {
                Item pur = shopInventory.FindItem("chestplate");
                if (pur == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I'm sorry but I no longer have this item");
                    ContinueShopping();
                }
                else
                {
                    pur.PrintItem();
                    PurchaseItem(pur);
                }
            }
            else if (input == "boots")
            {
                Item pur = shopInventory.FindItem("boots");
                if (pur == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I'm sorry but I no longer have this item");
                    ContinueShopping();
                }
                else
                {
                    pur.PrintItem();
                    PurchaseItem(pur);
                }
            }
            else if (input == "gloves")
            {
                Item pur = shopInventory.FindItem("gloves");
                if (pur == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I'm sorry but I no longer have this item");
                    ContinueShopping();
                }
                else
                {
                    pur.PrintItem();
                    PurchaseItem(pur);
                }
            }
            else if (input == "shield")
            {
                Item pur = shopInventory.FindItem("shield");
                if (pur == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I'm sorry but I no longer have this item");
                    ContinueShopping();
                }
                else
                {
                    pur.PrintItem();
                    PurchaseItem(pur);
                }
            }
            else if (input == "healing")
            {
                Item pur = shopInventory.FindItem("healing");
                if (pur == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I'm sorry but I no longer have this item");
                    ContinueShopping();
                }
                else
                {
                    pur.PrintItem();
                    PurchaseItem(pur);
                }
            }
            else if (input == "shielding")
            {
                Item pur = shopInventory.FindItem("shielding");
                if (pur == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I'm sorry but I no longer have this item");
                    ContinueShopping();
                }
                else
                {
                    pur.PrintItem();
                    PurchaseItem(pur);
                }
            }
            else if (input == "invincibility")
            {
                Item pur = shopInventory.FindItem("invincibility");
                if (pur == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I'm sorry but I no longer have this item");
                    ContinueShopping();
                }
                else
                {
                    pur.PrintItem();
                    PurchaseItem(pur);
                }
            }
            else if (input == "rage")
            {
                Item pur = shopInventory.FindItem("rage");
                if (pur == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I'm sorry but I no longer have this item");
                    ContinueShopping();
                }
                else
                {
                    pur.PrintItem();
                    PurchaseItem(pur);
                }
            }
            else
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader("Shop.txt");
                try
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.Contains(input))
                        {
                            Item pur = shopInventory.FindItem(input);
                            if (pur == null)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("I'm sorry but I don't have this item");
                                file.Close();
                                ContinueShopping();
                            }
                            else
                            {

                                pur.PrintItem();
                                file.Close();
                                PurchaseItem(pur);
                            }
                        }
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I'm sorry but I don't have this item");
                    file.Close();
                    ContinueShopping();
                }
                
            }
        }

        //Ask player if they want to buy item
        static void PurchaseItem(Item itemWanted)
        {
            if (itemWanted != null)
            {
                if (playerFunds < Item.GetPrice(itemWanted))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I'm afraid you cannot purchase this item.");
                    Console.WriteLine("Press any key to return");
                    Console.ReadKey();
                    Console.Clear();
                    PlayerResponse();
                }
                else if (playerInventory.CheckFreeSpot() == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is no room left in your inventory");
                    Console.WriteLine("Press any key to return");
                    Console.ReadKey();
                    Console.Clear();
                    PlayerResponse();
                }
                else
                {
                    string input = "";
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Do you want to buy this item? (Y/N)");

                    Console.ForegroundColor = ConsoleColor.Gray;
                    input = Console.ReadLine().ToLower();

                    if (input == "y")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Thank you for purchasing this item");
                        playerInventory.AddItem(itemWanted);
                        shopInventory.RemoveItem(itemWanted);
                        Console.WriteLine(char.ToUpper(itemWanted.name[0]) + itemWanted.name.Substring(1) + " has been added to your inventory");
                        playerFunds -= Item.GetPrice(itemWanted);
                        Console.WriteLine("You now have " + playerFunds + " gold");
                        SaveInventory();
                        playerInventory.RemoveDuplicates();
                        shopInventory.RemoveDuplicates();
                        LoadInventory();
                        ContinueShopping();
                    }
                    else if (input == "n")
                    {
                        ContinueShopping();
                    }
                }
            }
        }

        //Ask the player if they want to continue shopping
        static void ContinueShopping()
        {
            string input = "";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Do you want to continue shopping? (Y/N)");
            Console.ForegroundColor = ConsoleColor.Gray;
            input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                Console.Clear();
                Continue();
            }
            else
            {
                SaveInventory();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Thank you for shopping. Take care traveller.");
                Console.WriteLine("Press any key to exit");
                Environment.Exit(0);
            }
        }

        //Repeats on what the player wants to view
        static void Continue()
        {
            string input = "";

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Great. What would you like to do? (Buy/Sell/View/Leave)");

            Console.ForegroundColor = ConsoleColor.Gray;
            input = Console.ReadLine().ToLower();
            if (input == "buy")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Would you like to view my (W)eapons, (A)rmour or (P)otions?");
                DisplayInventory();
            }
            else if (input == "sell")
            {
                SellItem();
            }
            else if (input == "view")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This what is in your Inventory currently");
                for (int i = 0; i < playerInventory.GetCapacityLength; i++)
                {
                    if (playerInventory.inventory[i] != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Inventory Slot [{0}]: {1}", i, char.ToUpper(playerInventory.inventory[i].name[0]) + playerInventory.inventory[i].name.Substring(1));
                    }
                    else if (playerInventory.inventory[i] == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Inventory Slot [{0}]: {1}", i, null);
                    }
                    else
                    {
                        break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Press any key to return");
                Console.ReadKey();
                Console.Clear();
                PlayerResponse();
            }
            else if (input == "create")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Welcome to the blacksmith");
                Console.WriteLine("What would you like to create? (Weapon/Armour/Potion)");
                Create();
            }
            else if (input == "leave")
            {
                SaveInventory();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ok Goodbye");
                Console.WriteLine("Press Any Key to Exit");
                Environment.Exit(0);
            }
        }

        //If player wants to sell an item
        static void SellItem()
        {
            for (int i = 0; i < playerInventory.GetCapacityLength; i++)
            {
                if (playerInventory.inventory[i] != null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ok. What would you like to sell? (Type the number of the item that you want to sell)");
                    for (i = 0; i < playerInventory.GetCapacityLength; i++)
                    {
                        if (playerInventory.inventory[i] != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Inventory Slot [{0}]: {1}", i, char.ToUpper(playerInventory.inventory[i].name[0]) + playerInventory.inventory[i].name.Substring(1));
                        }
                        else if (playerInventory.inventory[i] == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Inventory Slot [{0}]: {1}", i, null);
                        }
                    }
                    Sell();
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is nothing in your inventory");
                    Console.WriteLine("Press any key to return");
                    Console.ReadKey();
                    Console.Clear();
                    PlayerResponse();
                    break;
                }
            }
        }

        //Saves items to inventories
        static void SaveInventory()
        {
            using (StreamWriter shopWriter = new StreamWriter("Shop.txt")) //Exception thrown after an item is created, bought ad trying to sell it
            {
                foreach (Item item in shopInventory.inventory) 
                {
                    if (item != null)
                    {
                        string itemType = $"{item}";
                        string itemAdditional = "";
                        switch (itemType)
                        {
                            case "ShopGame.Sword":
                                itemAdditional = sword.attackModifier.ToString();
                                shopWriter.WriteLine($"{item},{item.name},{item.description},{item.cost},{item.type},{itemAdditional}");
                                break;
                            case "ShopGame.Axe":
                                itemAdditional = axe.attackModifier.ToString();
                                shopWriter.WriteLine($"{item},{item.name},{item.description},{item.cost},{item.type},{itemAdditional}");
                                break;
                            case "ShopGame.Bow":
                                itemAdditional = bow.attackModifier.ToString();
                                shopWriter.WriteLine($"{item},{item.name},{item.description},{item.cost},{item.type},{itemAdditional}");
                                break;
                            case "ShopGame.Dagger":
                                itemAdditional = dagger.attackModifier.ToString();
                                shopWriter.WriteLine($"{item},{item.name},{item.description},{item.cost},{item.type},{itemAdditional}");
                                break;
                            case "ShopGame.NewWeapon":
                                itemAdditional = _newWeapon.attackModifier.ToString();
                                shopWriter.WriteLine($"{item},{item.name},{item.description},{item.cost},{item.type},{itemAdditional}");
                                break;
                            case "ShopGame.Helmet":
                                itemAdditional = helmet.defenceModifier.ToString();
                                shopWriter.WriteLine($"{item},{item.name},{item.description},{item.cost},{item.type},{itemAdditional}");
                                break;
                            case "ShopGame.Chestplate":
                                itemAdditional = chestplate.defenceModifier.ToString();
                                shopWriter.WriteLine($"{item},{item.name},{item.description},{item.cost},{item.type},{itemAdditional}");
                                break;
                            case "ShopGame.Boots":
                                itemAdditional = boots.defenceModifier.ToString();
                                shopWriter.WriteLine($"{item},{item.name},{item.description},{item.cost},{item.type},{itemAdditional}");
                                break;
                            case "ShopGame.Gloves":
                                itemAdditional = gloves.defenceModifier.ToString();
                                shopWriter.WriteLine($"{item},{item.name},{item.description},{item.cost},{item.type},{itemAdditional}");
                                break;
                            case "ShopGame.Shield":
                                itemAdditional = shield.defenceModifier.ToString();
                                shopWriter.WriteLine($"{item},{item.name},{item.description},{item.cost},{item.type},{itemAdditional}");
                                break;
                            case "ShopGame.NewArmour":
                                itemAdditional = _newArmour.defenceModifier.ToString();
                                shopWriter.WriteLine($"{item},{item.name},{item.description},{item.cost},{item.type},{itemAdditional}");
                                break;
                            default:
                                shopWriter.WriteLine($"{item},{item.name},{item.description},{item.cost},{item.type}");
                                break;
                        }
                    }
                }
                shopWriter.Flush();
                shopWriter.Close();
            }

            using (StreamWriter playerWriter = new StreamWriter("Player.txt"))
            {
                foreach (Item item in playerInventory.inventory) //Goes through all the items in the player's inventory
                {
                    if (item != null)
                    {
                        string itemType = $"{item}";
                        string itemAdditional = "";
                        switch (itemType)
                        {
                            case "ShopGame.Sword":
                                itemAdditional = sword.attackModifier.ToString();
                                playerWriter.WriteLine($"{item},{item.name},{item.description},{item.cost},{item.type},{itemAdditional}");
                                break;
                            case "ShopGame.Axe":
                                itemAdditional = axe.attackModifier.ToString();
                                playerWriter.WriteLine($"{item},{item.name},{item.description},{item.cost},{item.type},{itemAdditional}");
                                break;
                            case "ShopGame.Bow":
                                itemAdditional = bow.attackModifier.ToString();
                                playerWriter.WriteLine($"{item},{item.name},{item.description},{item.cost},{item.type},{itemAdditional}");
                                break;
                            case "ShopGame.Dagger":
                                itemAdditional = dagger.attackModifier.ToString();
                                playerWriter.WriteLine($"{item},{item.name},{item.description},{item.cost},{item.type},{itemAdditional}");
                                break;
                            case "ShopGame.NewWeapon":
                                itemAdditional = _newWeapon.attackModifier.ToString();
                                playerWriter.WriteLine($"{item},{item.name},{item.description},{item.cost},{item.type},{itemAdditional}");
                                break;
                            case "ShopGame.Helmet":
                                itemAdditional = helmet.defenceModifier.ToString();
                                playerWriter.WriteLine($"{item},{item.name},{item.description},{item.cost},{item.type},{itemAdditional}");
                                break;
                            case "ShopGame.Chestplate":
                                itemAdditional = chestplate.defenceModifier.ToString();
                                playerWriter.WriteLine($"{item},{item.name},{item.description},{item.cost},{item.type},{itemAdditional}");
                                break;
                            case "ShopGame.Boots":
                                itemAdditional = boots.defenceModifier.ToString();
                                playerWriter.WriteLine($"{item},{item.name},{item.description},{item.cost},{item.type},{itemAdditional}");
                                break;
                            case "ShopGame.Gloves":
                                itemAdditional = gloves.defenceModifier.ToString();
                                playerWriter.WriteLine($"{item},{item.name},{item.description},{item.cost},{item.type},{itemAdditional}");
                                break;
                            case "ShopGame.Shield":
                                itemAdditional = shield.defenceModifier.ToString();
                                playerWriter.WriteLine($"{item},{item.name},{item.description},{item.cost},{item.type},{itemAdditional}");
                                break;
                            case "ShopGame.NewArmour":
                                itemAdditional = _newArmour.defenceModifier.ToString();
                                playerWriter.WriteLine($"{item},{item.name},{item.description},{item.cost},{item.type},{itemAdditional}");
                                break;
                            default:
                                playerWriter.WriteLine($"{item},{item.name},{item.description},{item.cost},{item.type}");
                                break;
                        }
                    }
                }
                playerWriter.Flush();
                playerWriter.Close();
            }
        }

        //Load items from inventories
        static void LoadInventory()
        {
            try
            {
                using (StreamReader shopReader = new StreamReader("Shop.txt"))
                {
                    foreach (string line in File.ReadAllLines("Shop.txt"))
                    {
                        string[] parts = line.Split(',');
                        string itemType = parts[0];
                        switch (itemType)
                        {
                            case "ShopGame.Sword":
                                Sword sword = new Sword(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4], Convert.ToInt32(parts[5]));
                                weapons = weapons.Concat(new string[] { parts[4] }).ToArray();
                                shopInventory.AddItem(sword);
                                break;
                            case "ShopGame.Axe":
                                Axe axe = new Axe(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4], Convert.ToInt32(parts[5]));
                                weapons = weapons.Concat(new string[] { parts[4] }).ToArray();
                                shopInventory.AddItem(axe);
                                break;
                            case "ShopGame.Bow":
                                Bow bow = new Bow(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4], Convert.ToInt32(parts[5]));
                                weapons = weapons.Concat(new string[] { parts[4] }).ToArray();
                                shopInventory.AddItem(bow);
                                break;
                            case "ShopGame.Dagger":
                                Dagger dagger = new Dagger(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4], Convert.ToInt32(parts[5]));
                                weapons = weapons.Concat(new string[] { parts[4] }).ToArray();
                                shopInventory.AddItem(dagger);
                                break;
                            case "ShopGame.Helmet":
                                Helmet helmet = new Helmet(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4], Convert.ToInt32(parts[5]));
                                armour = armour.Concat(new string[] { parts[4] }).ToArray();
                                shopInventory.AddItem(helmet);
                                break;
                            case "ShopGame.Chestplate":
                                Chestplate chestplate = new Chestplate(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4], Convert.ToInt32(parts[5]));
                                armour = armour.Concat(new string[] { parts[4] }).ToArray();
                                shopInventory.AddItem(chestplate);
                                break;
                            case "ShopGame.Boots":
                                Boots boots = new Boots(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4], Convert.ToInt32(parts[5]));
                                armour = armour.Concat(new string[] { parts[4] }).ToArray();
                                shopInventory.AddItem(boots);
                                break;
                            case "ShopGame.Gloves":
                                Gloves gloves = new Gloves(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4], Convert.ToInt32(parts[5]));
                                armour = armour.Concat(new string[] { parts[4] }).ToArray();
                                shopInventory.AddItem(gloves);
                                break;
                            case "ShopGame.Shield":
                                Shield shield = new Shield(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4], Convert.ToInt32(parts[5]));
                                armour = armour.Concat(new string[] { parts[4] }).ToArray();
                                shopInventory.AddItem(shield);
                                break;
                            case "ShopGame.Healing":
                                Healing healing = new Healing(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4]);
                                potions = potions.Concat(new string[] { parts[4] }).ToArray();
                                shopInventory.AddItem(healing);
                                break;
                            case "ShopGame.Shielding":
                                Shielding shielding = new Shielding(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4]);
                                potions = potions.Concat(new string[] { parts[4] }).ToArray();
                                shopInventory.AddItem(shielding);
                                break;
                            case "ShopGame.Invincibility":
                                Invincibility invincibility = new Invincibility(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4]);
                                potions = potions.Concat(new string[] { parts[4] }).ToArray();
                                shopInventory.AddItem(invincibility);
                                break;
                            case "ShopGame.Rage":
                                Rage rage = new Rage(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4]);
                                potions = potions.Concat(new string[] { parts[4] }).ToArray();
                                shopInventory.AddItem(rage);
                                break;
                            case "ShopGame.NewWeapon":
                                NewWeapon newWeapon = new NewWeapon(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4], Convert.ToInt32(parts[5]));
                                weapons = weapons.Concat(new string[] { parts[4] }).ToArray();
                                shopInventory.AddItem(newWeapon);
                                break;
                            case "ShopGame.NewArmour":
                                NewArmour newArmour = new NewArmour(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4], Convert.ToInt32(parts[5]));
                                armour = armour.Concat(new string[] { parts[4] }).ToArray();
                                shopInventory.AddItem(newArmour);
                                break;
                            case "ShopGame.NewPotion":
                                NewPotion newPotion = new NewPotion(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4]);
                                potions = potions.Concat(new string[] { parts[4] }).ToArray();
                                shopInventory.AddItem(newPotion);
                                break;
                        }
                    }
                    shopReader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The Shop.txt could not be read");
                Console.WriteLine(e.Message);
            }

            try
            {
                using (StreamReader playerReader = new StreamReader("Player.txt"))
                {
                    foreach (string line in File.ReadAllLines("Player.txt"))
                    {
                        string[] parts = line.Split(',');
                        string itemType = parts[0];
                        switch (itemType)
                        {
                            case "ShopGame.Sword":
                                Sword sword = new Sword(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4], Convert.ToInt32(parts[5]));
                                playerInventory.AddItem(sword);
                                break;
                            case "ShopGame.Axe":
                                Axe axe = new Axe(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4], Convert.ToInt32(parts[5]));
                                playerInventory.AddItem(axe);
                                break;
                            case "ShopGame.Bow":
                                Bow bow = new Bow(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4], Convert.ToInt32(parts[5]));
                                playerInventory.AddItem(bow);
                                break;
                            case "ShopGame.Dagger":
                                Dagger dagger = new Dagger(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4], Convert.ToInt32(parts[5]));
                                playerInventory.AddItem(dagger);
                                break;
                            case "ShopGame.Helmet":
                                Helmet helmet = new Helmet(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4], Convert.ToInt32(parts[5]));
                                playerInventory.AddItem(helmet);
                                break;
                            case "ShopGame.Chestplate":
                                Chestplate chestplate = new Chestplate(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4], Convert.ToInt32(parts[5]));
                                playerInventory.AddItem(chestplate);
                                break;
                            case "ShopGame.Boots":
                                Boots boots = new Boots(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4], Convert.ToInt32(parts[5]));
                                playerInventory.AddItem(boots);
                                break;
                            case "ShopGame.Gloves":
                                Gloves gloves = new Gloves(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4], Convert.ToInt32(parts[5]));
                                playerInventory.AddItem(gloves);
                                break;
                            case "ShopGame.Shield":
                                Shield shield = new Shield(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4], Convert.ToInt32(parts[5]));
                                playerInventory.AddItem(shield);
                                break;
                            case "ShopGame.Healing":
                                Healing healing = new Healing(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4]);
                                playerInventory.AddItem(healing);
                                break;
                            case "ShopGame.Shielding":
                                Shielding shielding = new Shielding(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4]);
                                playerInventory.AddItem(shielding);
                                break;
                            case "ShopGame.Invincibility":
                                Invincibility invincibility = new Invincibility(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4]);
                                playerInventory.AddItem(invincibility);
                                break;
                            case "ShopGame.Rage":
                                Rage rage = new Rage(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4]);
                                playerInventory.AddItem(rage);
                                break;
                            case "ShopGame.NewWeapon":
                                NewWeapon newWeapon = new NewWeapon(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4], Convert.ToInt32(parts[5]));
                                playerInventory.AddItem(newWeapon);
                                break;
                            case "ShopGame.NewArmour":
                                NewArmour newArmour = new NewArmour(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4], Convert.ToInt32(parts[5]));
                                playerInventory.AddItem(newArmour);
                                break;
                            case "ShopGame.NewPotion":
                                NewPotion newPotion = new NewPotion(parts[1], parts[2], Convert.ToInt32(parts[3]), parts[4]);
                                playerInventory.AddItem(newPotion);
                                break;
                        }
                    }
                    playerReader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The Player.txt could not be found");
                Console.WriteLine(e.Message);
            }
        }

        //Sell menu for the game
        static void Sell()
        {
            string input = "";
            Console.ForegroundColor = ConsoleColor.Gray;
            input = Console.ReadLine().ToLower();

            if (input == "0")
            {
                if (playerInventory.inventory[0] == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is nothing in this slot try a different number");
                    Sell();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Are you sure you want to sell " + char.ToUpper(playerInventory.inventory[0].name[0]) + playerInventory.inventory[0].name.Substring(1) + "? (Y/N)");
                    Console.WriteLine("You will recieve " + playerInventory.inventory[0].cost + " gold back.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    input = Console.ReadLine().ToLower();
                    if (input == "y")
                    {
                        shopInventory.AddItem(playerInventory.inventory[0]);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(char.ToUpper(playerInventory.inventory[0].name[0]) + playerInventory.inventory[0].name.Substring(1) + " has been removed from your inventory.");
                        playerFunds += playerInventory.inventory[0].cost;
                        Console.WriteLine("You have recieved " + playerInventory.inventory[0].cost + " gold back.");
                        Console.WriteLine("You now have " + playerFunds + " gold.");
                        playerInventory.RemoveItem(playerInventory.inventory[0]);
                        SaveInventory();
                        playerInventory.RemoveDuplicates();
                        shopInventory.RemoveDuplicates();
                        LoadInventory();
                        ContinueShopping();
                    }
                    else if (input == "n")
                    {
                        ContinueShopping();
                    }
                }
            }
            else if (input == "1")
            {
                if (playerInventory.inventory[1] == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is nothing in this slot try a different number");
                    Sell();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Are you sure you want to sell " + char.ToUpper(playerInventory.inventory[1].name[0]) + playerInventory.inventory[1].name.Substring(1) + "? (Y/N)");
                    Console.WriteLine("You will recieve " + playerInventory.inventory[1].cost + " gold back.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    input = Console.ReadLine().ToLower();
                    if (input == "y")
                    {
                        shopInventory.AddItem(playerInventory.inventory[1]);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(char.ToUpper(playerInventory.inventory[1].name[0]) + playerInventory.inventory[1].name.Substring(1) + " has been removed from your inventory.");
                        playerFunds += playerInventory.inventory[1].cost;
                        Console.WriteLine("You have recieved " + playerInventory.inventory[1].cost + " gold back.");
                        Console.WriteLine("You now have " + playerFunds + " gold.");
                        playerInventory.RemoveItem(playerInventory.inventory[1]);
                        SaveInventory();
                        playerInventory.RemoveDuplicates();
                        shopInventory.RemoveDuplicates();
                        LoadInventory();
                        ContinueShopping();
                    }
                    else if (input == "n")
                    {
                        ContinueShopping();
                    }
                }
            }
            else if (input == "2")
            {
                if (playerInventory.inventory[2] == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is nothing in this slot try a different number");
                    Sell();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Are you sure you want to sell " + char.ToUpper(playerInventory.inventory[2].name[0]) + playerInventory.inventory[2].name.Substring(1) + "? (Y/N)");
                    Console.WriteLine("You will recieve " + playerInventory.inventory[2].cost + " gold back.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    input = Console.ReadLine().ToLower();
                    if (input == "y")
                    {
                        shopInventory.AddItem(playerInventory.inventory[2]);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(char.ToUpper(playerInventory.inventory[2].name[0]) + playerInventory.inventory[2].name.Substring(1) + " has been removed from your inventory.");
                        playerFunds += playerInventory.inventory[2].cost;
                        Console.WriteLine("You have recieved " + playerInventory.inventory[2].cost + " gold back.");
                        Console.WriteLine("You now have " + playerFunds + " gold.");
                        playerInventory.RemoveItem(playerInventory.inventory[2]);
                        SaveInventory();
                        playerInventory.RemoveDuplicates();
                        shopInventory.RemoveDuplicates();
                        LoadInventory();
                        ContinueShopping();
                    }
                    else if (input == "n")
                    {
                        ContinueShopping();
                    }
                }
            }
            else if (input == "3")
            {
                if (playerInventory.inventory[3] == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is nothing in this slot try a different number");
                    Sell();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Are you sure you want to sell " + char.ToUpper(playerInventory.inventory[3].name[0]) + playerInventory.inventory[3].name.Substring(1) + "? (Y/N)");
                    Console.WriteLine("You will recieve " + playerInventory.inventory[3].cost + " gold back.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    input = Console.ReadLine().ToLower();
                    if (input == "y")
                    {
                        shopInventory.AddItem(playerInventory.inventory[3]);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(char.ToUpper(playerInventory.inventory[3].name[0]) + playerInventory.inventory[3].name.Substring(1) + " has been removed from your inventory.");
                        playerFunds += playerInventory.inventory[3].cost;
                        Console.WriteLine("You have recieved " + playerInventory.inventory[3].cost + " gold back.");
                        Console.WriteLine("You now have " + playerFunds + " gold.");
                        playerInventory.RemoveItem(playerInventory.inventory[3]);
                        SaveInventory();
                        playerInventory.RemoveDuplicates();
                        shopInventory.RemoveDuplicates();
                        LoadInventory();
                        ContinueShopping();
                    }
                    else if (input == "n")
                    {
                        ContinueShopping();
                    }
                }
            }
            else if (input == "4")
            {
                if (playerInventory.inventory[4] == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is nothing in this slot try a different number");
                    Sell();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Are you sure you want to sell " + char.ToUpper(playerInventory.inventory[4].name[0]) + playerInventory.inventory[4].name.Substring(1) + "? (Y/N)");
                    Console.WriteLine("You will recieve " + playerInventory.inventory[4].cost + " gold back.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    input = Console.ReadLine().ToLower();
                    if (input == "y")
                    {
                        shopInventory.AddItem(playerInventory.inventory[4]);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(char.ToUpper(playerInventory.inventory[4].name[0]) + playerInventory.inventory[4].name.Substring(1) + " has been removed from your inventory.");
                        playerFunds += playerInventory.inventory[4].cost;
                        Console.WriteLine("You have recieved " + playerInventory.inventory[4].cost + " gold back.");
                        Console.WriteLine("You now have " + playerFunds + " gold.");
                        playerInventory.RemoveItem(playerInventory.inventory[4]);
                        SaveInventory();
                        playerInventory.RemoveDuplicates();
                        shopInventory.RemoveDuplicates();
                        LoadInventory();
                        ContinueShopping();
                    }
                    else if (input == "n")
                    {
                        ContinueShopping();
                    }
                }
            }
            else if (input == "5")
            {
                if (playerInventory.inventory[5] == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is nothing in this slot try a different number");
                    Sell();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Are you sure you want to sell " + char.ToUpper(playerInventory.inventory[5].name[0]) + playerInventory.inventory[5].name.Substring(1) + "? (Y/N)");
                    Console.WriteLine("You will recieve " + playerInventory.inventory[5].cost + " gold back.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    input = Console.ReadLine().ToLower();
                    if (input == "y")
                    {
                        shopInventory.AddItem(playerInventory.inventory[5]);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(char.ToUpper(playerInventory.inventory[5].name[0]) + playerInventory.inventory[5].name.Substring(1) + " has been removed from your inventory.");
                        playerFunds += playerInventory.inventory[5].cost;
                        Console.WriteLine("You have recieved " + playerInventory.inventory[5].cost + " gold back.");
                        Console.WriteLine("You now have " + playerFunds + " gold.");
                        playerInventory.RemoveItem(playerInventory.inventory[5]);
                        SaveInventory();
                        playerInventory.RemoveDuplicates();
                        shopInventory.RemoveDuplicates();
                        LoadInventory();
                        ContinueShopping();
                    }
                    else if (input == "n")
                    {
                        ContinueShopping();
                    }
                }
            }
            else if (input == "6")
            {
                if (playerInventory.inventory[6] == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is nothing in this slot try a different number");
                    Sell();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Are you sure you want to sell " + char.ToUpper(playerInventory.inventory[6].name[0]) + playerInventory.inventory[6].name.Substring(1) + "? (Y/N)");
                    Console.WriteLine("You will recieve " + playerInventory.inventory[6].cost + " gold back.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    input = Console.ReadLine().ToLower();
                    if (input == "y")
                    {
                        shopInventory.AddItem(playerInventory.inventory[6]);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(char.ToUpper(playerInventory.inventory[6].name[0]) + playerInventory.inventory[6].name.Substring(1) + " has been removed from your inventory.");
                        playerFunds += playerInventory.inventory[6].cost;
                        Console.WriteLine("You have recieved " + playerInventory.inventory[6].cost + " gold back.");
                        Console.WriteLine("You now have " + playerFunds + " gold.");
                        playerInventory.RemoveItem(playerInventory.inventory[6]);
                        SaveInventory();
                        playerInventory.RemoveDuplicates();
                        shopInventory.RemoveDuplicates();
                        LoadInventory();
                        ContinueShopping();
                    }
                    else if (input == "n")
                    {
                        ContinueShopping();
                    }
                }
            }
            else if (input == "7")
            {
                if (playerInventory.inventory[7] == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is nothing in this slot try a different number");
                    Sell();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Are you sure you want to sell " + char.ToUpper(playerInventory.inventory[7].name[0]) + playerInventory.inventory[7].name.Substring(1) + "? (Y/N)");
                    Console.WriteLine("You will recieve " + playerInventory.inventory[7].cost + " gold back.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    input = Console.ReadLine().ToLower();
                    if (input == "y")
                    {
                        shopInventory.AddItem(playerInventory.inventory[7]);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(char.ToUpper(playerInventory.inventory[7].name[0]) + playerInventory.inventory[7].name.Substring(1) + " has been removed from your inventory.");
                        playerFunds += playerInventory.inventory[7].cost;
                        Console.WriteLine("You have recieved " + playerInventory.inventory[7].cost + " gold back.");
                        Console.WriteLine("You now have " + playerFunds + " gold.");
                        playerInventory.RemoveItem(playerInventory.inventory[7]);
                        SaveInventory();
                        playerInventory.RemoveDuplicates();
                        shopInventory.RemoveDuplicates();
                        LoadInventory();
                        ContinueShopping();
                    }
                    else if (input == "n")
                    {
                        ContinueShopping();
                    }
                }
            }
            else if (input == "8")
            {
                if (playerInventory.inventory[8] == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is nothing in this slot try a different number");
                    Sell();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Are you sure you want to sell " + char.ToUpper(playerInventory.inventory[8].name[0]) + playerInventory.inventory[8].name.Substring(1) + "? (Y/N)");
                    Console.WriteLine("You will recieve " + playerInventory.inventory[8].cost + " gold back.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    input = Console.ReadLine().ToLower();
                    if (input == "y")
                    {
                        shopInventory.AddItem(playerInventory.inventory[8]);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(char.ToUpper(playerInventory.inventory[8].name[0]) + playerInventory.inventory[8].name.Substring(1) + " has been removed from your inventory.");
                        playerFunds += playerInventory.inventory[8].cost;
                        Console.WriteLine("You have recieved " + playerInventory.inventory[8].cost + " gold back.");
                        Console.WriteLine("You now have " + playerFunds + " gold.");
                        playerInventory.RemoveItem(playerInventory.inventory[8]);
                        SaveInventory();
                        playerInventory.RemoveDuplicates();
                        shopInventory.RemoveDuplicates();
                        LoadInventory();
                        ContinueShopping();
                    }
                    else if (input == "n")
                    {
                        ContinueShopping();
                    }
                }
            }
            else if (input == "9")
            {
                if (playerInventory.inventory[9] == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is nothing in this slot try a different number");
                    Sell();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Are you sure you want to sell " + char.ToUpper(playerInventory.inventory[9].name[0]) + playerInventory.inventory[9].name.Substring(1) + "? (Y/N)");
                    Console.WriteLine("You will recieve " + playerInventory.inventory[9].cost + " gold back.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    input = Console.ReadLine().ToLower();
                    if (input == "y")
                    {
                        shopInventory.AddItem(playerInventory.inventory[9]);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(char.ToUpper(playerInventory.inventory[9].name[0]) + playerInventory.inventory[9].name.Substring(1) + " has been removed from your inventory.");
                        playerFunds += playerInventory.inventory[9].cost;
                        Console.WriteLine("You have recieved " + playerInventory.inventory[9].cost + " gold back.");
                        Console.WriteLine("You now have " + playerFunds + " gold.");
                        playerInventory.RemoveItem(playerInventory.inventory[9]);
                        SaveInventory();
                        playerInventory.RemoveDuplicates();
                        shopInventory.RemoveDuplicates();
                        LoadInventory();
                        ContinueShopping();
                    }
                    else if (input == "n")
                    {
                        ContinueShopping();
                    }
                }
            }
        }

        //Allows super user to create items
        static void Create()
        {
            string input = "";

            Console.ForegroundColor = ConsoleColor.Gray;
            input = Console.ReadLine().ToLower();
            if (input == "weapon")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("What type of weapon is it?");
                Console.ForegroundColor = ConsoleColor.Gray;
                string type = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("What is it called?");
                Console.ForegroundColor = ConsoleColor.Gray;
                string name = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Describe this weapon");
                Console.ForegroundColor = ConsoleColor.Gray;
                string description = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("How much will this weapon cost?");
                Console.ForegroundColor = ConsoleColor.Gray;
                int cost = Convert.ToInt32(Console.ReadLine().ToLower());
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("How much damage will this weapon do?");
                Console.ForegroundColor = ConsoleColor.Gray;
                int attackModifier = Convert.ToInt32(Console.ReadLine().ToLower());
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Congratulations, you have created a new weapon.");
                Console.WriteLine("Press enter to return.");
                Console.ReadKey();
                NewWeapon newWeapon = new NewWeapon(name, description, cost, type, attackModifier);
                weapons = weapons.Concat(new string[] { type }).ToArray();
                shopInventory.AddItem(newWeapon);
                SaveInventory();
                playerInventory.RemoveDuplicates();
                shopInventory.RemoveDuplicates();
                LoadInventory();
                Console.Clear();
                Continue();
            }
            else if (input == "armour")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("What type of armour is it?");
                Console.ForegroundColor = ConsoleColor.Gray;
                string type = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("What is it called?");
                Console.ForegroundColor = ConsoleColor.Gray;
                string name = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Describe this armour");
                Console.ForegroundColor = ConsoleColor.Gray;
                string description = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("How much will this armour cost?");
                Console.ForegroundColor = ConsoleColor.Gray;
                int cost = Convert.ToInt32(Console.ReadLine().ToLower());
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("How much protection will this armour do?");
                Console.ForegroundColor = ConsoleColor.Gray;
                int defenceModifier = Convert.ToInt32(Console.ReadLine().ToLower());
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Congratulations, you have created a new armour.");
                Console.WriteLine("Press enter to return.");
                Console.ReadKey();
                NewArmour newArmour = new NewArmour(name, description, cost, type, defenceModifier);
                armour = armour.Concat(new string[] { type }).ToArray();
                shopInventory.AddItem(newArmour);
                SaveInventory();
                playerInventory.RemoveDuplicates();
                shopInventory.RemoveDuplicates();
                LoadInventory();
                Console.Clear();
                Continue();
            }
            else if (input == "potion")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("What type of potion is it?");
                Console.ForegroundColor = ConsoleColor.Gray;
                string type = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("What is it called?");
                Console.ForegroundColor = ConsoleColor.Gray;
                string name = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Describe this potion");
                Console.ForegroundColor = ConsoleColor.Gray;
                string description = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("How much will this potion cost?");
                Console.ForegroundColor = ConsoleColor.Gray;
                int cost = Convert.ToInt32(Console.ReadLine().ToLower());
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Congratulations, you have created a new potion.");
                Console.WriteLine("Press enter to return.");
                Console.ReadKey();
                NewPotion newPotion = new NewPotion(name, description, cost, type);
                potions = potions.Concat(new string[] { type }).ToArray();
                shopInventory.AddItem(newPotion);
                SaveInventory();
                playerInventory.RemoveDuplicates();
                shopInventory.RemoveDuplicates();
                LoadInventory();
                Console.Clear();
                Continue();
            }
        }
    }
}

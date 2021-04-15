using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CombatArmsRPG
{
    class Program
    {
        const string WeaponFile = "Weapons.json";
        const string UserData = "Save.json";
        static void Main(string[] args)
        {
            PrintBanner();
            try { 
            //read from Weapons.json
            string jsonStringRead = File.ReadAllText(WeaponFile);
            var weapons = JsonSerializer.Deserialize<Weapon[]>(jsonStringRead);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Weapons.json is missing.");
            }

            MainMenu();

        }
        static void PrintBanner()
        {
            Console.WriteLine(" .o88b.  .d88b.  .88b  d88. d8888b.  .d8b.  d888888b    .d8b.  d8888b. .88b  d88. .d8888.\n" +
                              "d8P  Y8 .8P  Y8. 88'YbdP`88 88  `8D d8' `8b `~~88~~'   d8' `8b 88  `8D 88'YbdP`88 88'  YP\n" +
                              "8P      88    88 88  88  88 88oooY' 88ooo88    88      88ooo88 88oobY' 88  88  88 `8bo.  \n" +
                              "8b      88    88 88  88  88 88~~~b. 88~~~88    88      88~~~88 88`8b   88  88  88   `Y8b.\n" +
                              "Y8b  d8 `8b  d8' 88  88  88 88   8D 88   88    88      88   88 88 `88. 88  88  88 db   8D\n" +
                              " `Y88P'  `Y88P'  YP  YP  YP Y8888P' YP   YP    YP      YP   YP 88   YD YP  YP  YP `8888Y'\n");
        }
        static void Save() //TODO: Create user data to test Save()
        {
            //write user data to Save.json
            string jsonStringWrite = JsonSerializer.Serialize(UserData);
            File.WriteAllText(UserData, jsonStringWrite);

        }

        static void MainMenu()
        {
            int mainChoice = 0;
            Console.Write("\nMAIN MENU\n" +
                          "---------\n" +
                          "1.GAME START\n" +
                          "2.LOADOUT\n" +
                          "3.SHOP\n\n" +

                          "0.EXIT\n" +
                          "CHOICE: ");
            try 
            { 
            mainChoice = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException formatEx)
            {
                Console.WriteLine("You idiot! That's not a number. Try again...");
                MainMenu();
            }
            while(mainChoice < 0 && mainChoice > 3)
            {
                Console.WriteLine("Erroneous input. Choose a number from 8-3.");
                MainMenu();
            }
            switch(mainChoice)
            {
                case 1:
                    Console.WriteLine("Starting game...");
                    break;
                case 2:
                    Console.WriteLine("Moving to loudout...");
                    break;
                case 3:
                    Console.WriteLine("Time to go shopping...");
                    break;
                case 0:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Erroneous input. Choose a number from 8-3.");
                    MainMenu();
                    break;
            }

        }
        static void StoryMenu()
        {
            Console.Write("\nSTORY MENU\n" +
                              "------------\n" +
                              "1.MISSION 1 - JUNK FLEA\n" +
                              "2.MISSION 2 - DEATH ROOM\n\n" +

                              "0.EXIT\n" +
                              "CHOICE: ");
        }
        static void LoudoutMenu()
        {
            Console.Write("LOADOUT\n" +
                              "-------\n" +
                              "CURRENT LOADOUT... \n" +
                              "PRIMARY WEAPON: \n" +
                              "SECONDARY WEAPON: \n" +
                              "MELEE: \n" +
                              "SUPPORT: \n\n" +

                              "CHANGE LOADOUT FOR...\n" +
                              "1.PRIMARY WEAPON\n" +
                              "2.SECONDARY WEAPON\n" +
                              "3.MELEE\n" +
                              "4.SUPPORT\n\n" +

                              "5.BACK\n\n" +
                              "0.EXIT\n" +
                              "CHOICE: ");
        }
        static void ShopMenu()
        {
            Console.Write("SHOP    GP: \n" +
                          "----\n" +
                          "1.PRIMARY WEAPONS\n" +
                          "2.SECONDARY WEAPONS\n" +
                          "3.MELEE\n" +
                          "4.SUPPORT\n\n" +

                          "5.BACK\n" +
                          "0.EXIT\n" +
                          "CHOICE: ");
        }
    }
}

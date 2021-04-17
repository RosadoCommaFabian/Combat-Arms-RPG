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
            Weapon[] weapons;
            try { 
            //read from Weapons.json
            string jsonStringRead = File.ReadAllText(WeaponFile);
            weapons = JsonSerializer.Deserialize<Weapon[]>(jsonStringRead)!;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Weapons.json is missing.");
                throw;
            }

            //17, 34
            byte[] defaultLoadout = new byte[(weapons.Length - 1) / 8 + 1];
            defaultLoadout[0] = 17;
            defaultLoadout[1] = 34;

            Save(new UserData("M4A1", "M92FS", "M9", "M67", "0", defaultLoadout));

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
        static void Save(UserData saveData) //TODO: Create user data to test Save()
        {
            //write user data to Save.json
            string jsonStringWrite = JsonSerializer.Serialize(saveData);
            File.WriteAllText(UserData, jsonStringWrite);

        }

        static void MainMenu()
        {
            Console.Write("\nMAIN MENU\n" +
                          "---------\n" +
                          "1.GAME START\n" +
                          "2.LOADOUT\n" +
                          "3.SHOP\n" +

                          "0.EXIT\n\n" +
                          "CHOICE: ");

            int input = ParseMenuResponse(4);

            switch (input)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Starting game...");
                    StoryMenu();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Moving to loudout...");
                    LoudoutMenu();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Time to go shopping...");
                    ShopMenu();
                    break;
                case 0:
                    Console.Clear();
                    Console.WriteLine("Exiting...");
                    System.Environment.Exit(1);
                    break;
                default:
                    throw new Exception($"Unexpected input: {input}");
            }

        }
        static void StoryMenu()
        {
            Console.Write("\nSTORY MENU\n" +
                              "------------\n" +
                              "1.MISSION 1 - JUNK FLEA\n" +
                              "2.MISSION 2 - DEATH ROOM\n" +
                              
                              "3.BACK\n\n" +
                              "0.EXIT\n" +
                              "CHOICE: ");

            int input = ParseMenuResponse(3);

            switch (input)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Traveling to Junk Flea...");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Traveling to Death Room...");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Backing out...");
                    MainMenu();
                    break;
                case 0:
                    Console.Clear();
                    Console.WriteLine("Exiting...");
                    System.Environment.Exit(1);
                    break;
                default:
                    throw new Exception($"Unexpected input: {input}");
            }

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
                              "4.SUPPORT\n" +

                              "5.BACK\n\n" +
                              "0.EXIT\n" +
                              "CHOICE: ");

            int input = ParseMenuResponse(6);

            switch (input)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Primary...");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Secondary...");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Melee...");
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Support...");
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Backing out...");
                    MainMenu();
                    break;
                case 0:
                    Console.Clear();
                    Console.WriteLine("Exiting...");
                    System.Environment.Exit(1);
                    break;
                default:
                    throw new Exception($"Unexpected input: {input}");
            }

        }
        static void ShopMenu()
        {
            Console.Write("SHOP    GP: \n" +
                          "----\n" +
                          "1.PRIMARY WEAPONS\n" +
                          "2.SECONDARY WEAPONS\n" +
                          "3.MELEE\n" +
                          "4.SUPPORT\n" +

                          "5.BACK\n\n" +
                          "0.EXIT\n" +
                          "CHOICE: ");

            int input = ParseMenuResponse(6);

            switch (input)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Primary...");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Secondary...");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Melee...");
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Support...");
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Backing out...");
                    MainMenu();
                    break;
                case 0:
                    Console.Clear();
                    Console.WriteLine("Exiting...");
                    System.Environment.Exit(1);
                    break;
                default:
                    throw new Exception($"Unexpected input: {input}");
            }

        }
        static int ParseMenuResponse(int choiceCount)
        {
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("You idiot! That's not a number. Try again...");
                    continue;
                }

                if ((uint)choice > (uint)choiceCount)
                {
                    Console.WriteLine("Erroneous input. Choose a number within range.");
                    continue;
                }

                return choice;
            }
        }

    }
}

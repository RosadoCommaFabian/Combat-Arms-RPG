using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CombatArmsRPG
{
    class Program
    {
        const string WeaponFile = "Weapons.json";
        static void Main(string[] args)
        {
            Console.WriteLine(" .o88b.  .d88b.  .88b  d88. d8888b.  .d8b.  d888888b    .d8b.  d8888b. .88b  d88. .d8888.\n" +
                              "d8P  Y8 .8P  Y8. 88'YbdP`88 88  `8D d8' `8b `~~88~~'   d8' `8b 88  `8D 88'YbdP`88 88'  YP\n" +
                              "8P      88    88 88  88  88 88oooY' 88ooo88    88      88ooo88 88oobY' 88  88  88 `8bo.  \n" +
                              "8b      88    88 88  88  88 88~~~b. 88~~~88    88      88~~~88 88`8b   88  88  88   `Y8b.\n" +
                              "Y8b  d8 `8b  d8' 88  88  88 88   8D 88   88    88      88   88 88 `88. 88  88  88 db   8D\n" +
                              " `Y88P'  `Y88P'  YP  YP  YP Y8888P' YP   YP    YP      YP   YP 88   YD YP  YP  YP `8888Y'\n");

            string jsonString = File.ReadAllText(WeaponFile);
            var weapons = JsonSerializer.Deserialize<Weapon[]>(jsonString);



        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CombatArmsRPG
{
    class UserData
    {
        public string PrimaryWeapon {get; set;}
        public string SecondaryWeapon { get; set; }
        public string MeleeWeapon { get; set; }
        public string SupportWeapon { get; set; }
        public string GearPoints { get; set; }
        [JsonConverter(typeof(BitArrayConverter))]
        public BitArray Unlocked { get; set; }

        public UserData() 
        {
            PrimaryWeapon = "M4A1";
            SecondaryWeapon = "M92FS";
            MeleeWeapon = "M9";
            SupportWeapon = "M67";
            GearPoints = "0";
            Unlocked = new BitArray(0);
        }
        public UserData(string primaryWeapon, string secondaryWeapon, string meleeWeapon, string supportWeapon, string gearPoints, byte[] unlockedWeaponBytes)
        {
            PrimaryWeapon = primaryWeapon;
            SecondaryWeapon = secondaryWeapon;
            MeleeWeapon = meleeWeapon;
            SupportWeapon = supportWeapon;
            GearPoints = gearPoints;
            Unlocked = new BitArray(unlockedWeaponBytes);
        }
    }
}

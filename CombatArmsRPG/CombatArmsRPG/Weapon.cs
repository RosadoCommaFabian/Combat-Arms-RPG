using System;
using System.Collections.Generic;
using System.Text;

namespace CombatArmsRPG
{
    public class Weapon
    {
        public string Name { get; set; }
        public double Damage { get; set; }
        public int Ammo { get; set; }
        public double MissChance { get; set; }
        public int Range { get; set; }
        public int Cost { get; set; }
        public LoudoutSlot Slot { get; set; }

        public Weapon(string name, double damage, int ammo, double missChance, int range, int cost, LoudoutSlot slot)
        {
            Name = name;
            Damage = damage;
            Ammo = ammo;
            MissChance = missChance;
            Range = range;
            Cost = cost;
            Slot = slot;
        }

        public enum LoudoutSlot
        {
            PrimaryWeapon,
            SecondaryWeapon,
            MeleeWeapon,
            SupportWeapon
        }
    }
}

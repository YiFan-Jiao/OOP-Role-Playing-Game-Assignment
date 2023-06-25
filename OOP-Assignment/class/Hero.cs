using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment
{
    public static class Hero
    {
        private static string _heroName;
        public static string HeroName { get { return _heroName; } }
        public static void setHero(string inputName) 
        { 
            if(string.IsNullOrEmpty(inputName))
            {
                throw new ArgumentException("Not allow its `HeroName` to be empty.");
            }
            else
            {
                _heroName = inputName;
            }
        }

        private static int _baseStrength = 5;
        public static int BaseStrength { get { return _baseStrength; } }
        public static void setBaseStrength(int setnum)
        {
            _baseStrength = setnum;
        }

        private static int _baseDefence = 3;
        public static int BaseDefence { get { return _baseDefence; } }
        public static void setBaseDefence(int setNum)
        {
            _baseDefence = setNum;
        }

        private static int _originalHealth = 10;
        public static int OriginalHealth { get { return _originalHealth; } }
        public static void setOriginalHealth(int setNum)
        {
            _originalHealth = setNum; 
        }

        private static Weapon _equippedWeapon;
        public static Weapon EquippedWeapon { get {  return _equippedWeapon; } }
        public static void EquipWeapon(int option)
        {
            _equippedWeapon = Game.WeaponList[option];
        }

        private static Armour _equippedArmor;
        public static Armour EquippedArmor { get { return _equippedArmor; } }
        public static void EquipArmour(int option)
        {
            _equippedArmor = Game.ArmourList[option];
        }

        private static int _currentHealth;
        public static int CurrentHealth { get { return _currentHealth; } }
        public static void setCurrentHealth(int hitNum)
        {
            _originalHealth = _originalHealth - hitNum;
            _currentHealth = _originalHealth;
        }
    }
}

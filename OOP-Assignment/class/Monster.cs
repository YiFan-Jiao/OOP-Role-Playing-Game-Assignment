using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment
{
    public class Monster
    {
        private string _name;
        public string Name { get { return _name; } }

        private int _strength;
        public int Strength { get { return _strength; } }

        private int _defence;
        public int Defence { get { return _defence; } }

        private int _originalHealth;
        public int OriginalHealth { get { return _originalHealth; } }

        private int _currentHealth;
        public int CurrentHealth { get { return _currentHealth; } }
        public void setCurrentHealth(int hitNum)
        {
            _originalHealth = _originalHealth - hitNum;
            _currentHealth = _originalHealth;
        }
        public Monster(string name, int strength, int defence, int originalHealth)
        {
            _name = name;
            _strength = strength;
            _defence = defence;
            _originalHealth = originalHealth;
        }
    }
}

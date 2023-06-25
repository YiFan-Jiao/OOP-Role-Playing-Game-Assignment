using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment
{
    public class Inventory
    {
        private string _name;
        public string Name { get { return  _name; } }

        private int _power;
        public int Power { get { return _power; } }
        public Inventory(string name, int power)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Not allow its `Item'name` to be empty.");
            }
            else
            {
                _name = name;
            }

            if (power <= 0)
            {
                throw new ArgumentException("Not allow its `Item'power` to be negative.");
            }
            else
            {
                _power = power;
            }
        }
    }
}

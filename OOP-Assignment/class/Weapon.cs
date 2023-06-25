using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace OOP_Assignment
{
    public class Weapon:Inventory
    {
        public Weapon(string name, int power) : base(name, power)
        {
            
        }
    }
}

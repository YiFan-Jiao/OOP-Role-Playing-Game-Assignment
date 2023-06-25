using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment
{
    public static class Game
    {
        private static List<Weapon> _weaponList = new List<Weapon>();
        public static List<Weapon> WeaponList { get { return _weaponList; } }
        
        private static List<Armour> _armourList = new List<Armour>();
        public static List<Armour> ArmourList { get { return _armourList; } }
        private static void makeWeaponList()
        {
            Weapon weapon1 = new Weapon("Weapon1", 10);
            Weapon weapon2 = new Weapon("Weapon2", 9);
            Weapon weapon3 = new Weapon("Weapon3", 8);
            Weapon weapon4 = new Weapon("Weapon4", 7);
            Weapon weapon5 = new Weapon("Weapon5", 6);

            _weaponList.Add(weapon1);
            _weaponList.Add(weapon2);
            _weaponList.Add(weapon3);
            _weaponList.Add(weapon4);
            _weaponList.Add(weapon5);
        }
        private static void makeArmourList()
        {
            Armour armour1 = new Armour("Armour1", 6);
            Armour armour2 = new Armour("Armour2", 7);
            Armour armour3 = new Armour("Armour3", 8);
            Armour armour4 = new Armour("Armour4", 9);
            Armour armour5 = new Armour("Armour5", 10);

            _armourList.Add(armour1);
            _armourList.Add(armour2);
            _armourList.Add(armour3);
            _armourList.Add(armour4);
            _armourList.Add(armour5);
        }

        private static List<Monster> _monsterList = new List<Monster>();
        public static List<Monster> MonsterList { get { return _monsterList; }  }
        private static void makeMonsterList()
        {
            Monster monster1 = new Monster("Monster1", 10, 10, 15);
            Monster monster2 = new Monster("Monster2", 11, 10, 15);
            Monster monster3 = new Monster("Monster3", 12, 10, 15);
            Monster monster4 = new Monster("Monster4", 13, 10, 15);
            Monster monster5 = new Monster("Monster5", 14, 10, 15);

            _monsterList.Add(monster1);
            _monsterList.Add(monster2);
            _monsterList.Add(monster3);
            _monsterList.Add(monster4);
            _monsterList.Add(monster5);
        }
        public static void start() 
        {
            try
            {
                Console.WriteLine("Please enter your name：");
                string Playername = Console.ReadLine();

                Hero.setHero(Playername);

                Console.WriteLine($"Your name is {Hero.HeroName}.");

                bool running = true;
                bool inSubMenuB = false;

                int winTurn = 0;
                int loseTurn = 0;
                makeWeaponList();
                makeArmourList();
                makeMonsterList();

                while (running)
                {
                    Console.WriteLine("\nMain menu");
                    Console.WriteLine("a. Statistics.");
                    Console.WriteLine("b. Inventory.");

                    if (inSubMenuB)
                    {
                        Console.WriteLine(" 1. Change weapon.");
                        Console.WriteLine(" 2. Change armour.");
                        Console.WriteLine(" 3. Back to previous menu.");
                    }
                    else
                    {
                        Console.WriteLine("c. Fight.");
                        Console.WriteLine("q. Quit");
                    }

                    Console.WriteLine("Please select an option：");
                    string choice = Console.ReadLine();

                    if (inSubMenuB)
                    {
                        switch (choice.ToLower())
                        {
                            case "1":
                                int weaponi = 1;
                                foreach (Weapon item in _weaponList)
                                {
                                    Console.WriteLine($"{weaponi++}：{item.Name}, Power{item.Power}");
                                }
                                Console.WriteLine("Please choose the weapon you want to equip：");
                                string weaponChoices = Console.ReadLine();
                                Hero.EquipWeapon(int.Parse(weaponChoices)-1);
                                Console.WriteLine($"Now {Hero.HeroName} is now equipped with a {Hero.EquippedWeapon.Name}");
                                break;
                            case "2":
                                int armouri = 1;
                                foreach (Armour item in _armourList)
                                {
                                    Console.WriteLine($"{armouri++}：{item.Name}, Power{item.Power}");
                                }
                                Console.WriteLine("Please choose the armour you want to equip：");
                                string armourChoices = Console.ReadLine();
                                Hero.EquipArmour(int.Parse(armourChoices) - 1);
                                Console.WriteLine($"Now {Hero.HeroName} is now equipped with a {Hero.EquippedArmor.Name}");
                                break;
                            case "3":
                                inSubMenuB = false;
                                break;
                            default:
                                Console.WriteLine("Invalid option, please select again.");
                                break;
                        }
                    }
                    else
                    {
                        switch (choice.ToLower())
                        {
                            case "a":
                                Console.WriteLine($"You have played {winTurn + loseTurn} times, won {winTurn} times and lost {loseTurn}.");
                                break;
                            case "b":
                                inSubMenuB = true;
                                break;
                            case "c":
                                if (_monsterList.Count > 0)
                                {
                                    Fight fight = new Fight();
                                    Random random = new Random();
                                    int randomNum = random.Next(_monsterList.Count);
                            
                                    if(fight.FightStart(_monsterList, randomNum))
                                    {
                                        winTurn++;
                                    }
                                    else
                                    {
                                        _monsterList.Clear();
                                        makeMonsterList();
                                        Hero.setBaseDefence(3);
                                        Hero.setBaseStrength(5);
                                        Hero.setOriginalHealth(10);
                                        loseTurn++;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("All monsters have been defeated.");
                                }
                                break;
                            case "q":
                                running = false;
                                break;
                            default:
                                Console.WriteLine("Invalid option, please select again.");
                                break;
                        }
                    }
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

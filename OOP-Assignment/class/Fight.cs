using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP_Assignment
{
    public class Fight
    {
        private bool HeroTurn(Monster monster)
        {
            int num;
            if (Hero.EquippedArmor != null)
            {
                num = Hero.BaseStrength + Hero.EquippedWeapon.Power - monster.Defence;
            }
            else
            {
                num = Hero.BaseStrength - monster.Defence;
            }

            if(num < 0)
            {
                num = 0;
            }

            monster.setCurrentHealth(num);
            Console.WriteLine($"\n{Hero.HeroName} hit {monster.Name}, deals {num} damage, {monster.Name}'s current health is {monster.CurrentHealth}.");
            if (monster.CurrentHealth > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool MonsterTurn(Monster monster)
        {
            int num;
            if(Hero.EquippedArmor != null)
            {
                num = monster.Strength - Hero.BaseDefence - Hero.EquippedArmor.Power;
            }
            else
            {
                num = monster.Strength - Hero.BaseDefence;
            }

            if (num < 0)
            {
                num = 0;
            }

            Hero.setCurrentHealth(num);
            Console.WriteLine($"\n{monster.Name} hit {Hero.HeroName}, deals {num} damage, {Hero.HeroName}'s current health is {Hero.CurrentHealth}");
            if (Hero.CurrentHealth > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool FightStart(List<Monster> monsterList,int randomNum)
        {
            bool isHeroTurn = true;
            bool isBattleOver = false;

            while (!isBattleOver)
            {
                if (isHeroTurn)
                {
                    bool heroWin = HeroTurn(monsterList[randomNum]);
                   if (!heroWin)
                   {
                        isBattleOver = true;
                        Console.WriteLine($"\n{Hero.HeroName} win!");

                        monsterList.Remove(monsterList[randomNum]);
                        return true;
                   }
                }
                else
                {
                    bool mosterWin = MonsterTurn(monsterList[randomNum]);
                    if (!mosterWin)
                    {
                        isBattleOver = true;
                        Console.WriteLine($"\n{monsterList[randomNum].Name} win!");

                        return false;
                    }
                }

                isHeroTurn = !isHeroTurn;
            }
            return false;
        }
    }
}

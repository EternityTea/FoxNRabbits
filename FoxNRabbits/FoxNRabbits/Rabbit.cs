using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxNRabbits
{
    class Rabbit
    {
        int DaysOfAge = 0;
        int MaxDaysOfAge = 900;
        char Sex;
        bool Pregnancy = false;
        int PregnancyDay = -1;
        int MinOffspring = 6;
        int MaxOffspring = 12;
        int Health;
        int Agility;

        public void Init(char sex, int health, int agility)
        {
            Sex = sex;
            Health = health;
            Agility = agility;
        }
    }
}

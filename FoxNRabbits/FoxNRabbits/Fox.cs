using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxNRabbits
{
    class Fox : Animal
    {
        public int MaxDaysOfAge = 2555;
        public int MinOffspring = 6;
        public int MaxOffspring = 12;
        public int MinPregnancy = 49;
        public int MaxPregnancy = 58;
        public int PregnancyCycle = 320;
        public int PrevPregnancy = 0;
        public int Maturity = 730;

        public void Init(char sex, int health, double agility, int velocity, int strength)
        {
            Sex = sex;
            Health = health;
            Agility = agility;
            Velocity = velocity;
            Strength = strength;
        }
    }
}

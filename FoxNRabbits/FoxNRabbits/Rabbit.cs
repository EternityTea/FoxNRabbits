using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxNRabbits
{
    class Rabbit : Animal
    {
        public int MaxDaysOfAge = 2555;
        public int MinOffspring = 4;
        public int MaxOffspring = 12;
        public int MinPregnancy = 30;
        public int MaxPregnancy = 32;
        public int PregnancyCycle = 30;
        public int PrevPregnancy = 0;
        public int Maturity = 90;

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

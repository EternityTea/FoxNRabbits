using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxNRabbits
{
    class Fox : Animal
    {
        public int PregnancyCycle = 320;
        public int PrevPregnancy = 0;
        public int Maturity = 730;

        public void Init(int daysofage, char sex, int health, double agility, int velocity, int strength, int prevpregnancy)
        {
            DaysOfAge = daysofage;
            Sex = sex;
            Health = health;
            Agility = agility;
            Velocity = velocity;
            Strength = strength;
            PrevPregnancy = prevpregnancy;
        }
    }
}

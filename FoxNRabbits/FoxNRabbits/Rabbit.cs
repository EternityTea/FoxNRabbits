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

        public void Init(int daysofage ,char sex, int health, double agility, int velocity, int strength)
        {
            DaysOfAge = daysofage;
            Sex = sex;
            Health = health;
            Agility = agility;
            Velocity = velocity;
            Strength = strength;
        }
    }
}

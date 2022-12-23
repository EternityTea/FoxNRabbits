using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxNRabbits
{
    abstract class Animal
    {
        public int DaysOfAge = 0;
        public char Sex;
        public bool Pregnancy = false;
        public int PregnancyDay = -1;
        public int Health;
        public double Agility;
        public int Velocity;
        public int Strength;
    }
}

using System;
using System.Collections;

namespace FoxNRabbits
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList PopR = new ArrayList();
            ArrayList PopF = new ArrayList();
            int Days = 0;
            int pop = 0;
            char Sex = 'm';
            int flag = 0;
            Random rnd = new Random();
            Rabbit RabbitTemplate = new Rabbit();
            Fox FoxTemplate = new Fox();
            Console.Write("Введите популяцию кроликов: ");
            pop = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < pop; i++)
            {
                flag = rnd.Next(1, 3);
                if (flag == 1)
                {
                    Sex = 'm';
                }
                else
                {
                    Sex = 'f';
                }
                RabbitTemplate = new Rabbit();
                RabbitTemplate.Init(Sex, rnd.Next(10, 30), 0.1 + rnd.NextDouble() * (0.8), rnd.Next(10, 30), rnd.Next(10, 30));
                PopR.Add(RabbitTemplate);
            }
            Console.Write("Введите популяцию лис: ");
            pop = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < pop; i++)
            {
                flag = rnd.Next(1, 3);
                if (flag == 1)
                {
                    Sex = 'm';
                }
                else
                {
                    Sex = 'f';
                }
                FoxTemplate = new Fox();
                FoxTemplate.Init(Sex, rnd.Next(10, 30), 0.1 + rnd.NextDouble() * (0.8), rnd.Next(10, 30), rnd.Next(10, 30));
                PopF.Add(FoxTemplate);
            }

            while (true) {
                Console.WriteLine("Сколько дней подождать?");
                Days = Convert.ToInt32(Console.ReadLine());
                
                for (int i = 0; i < Days; i++)
                {

                }

            }

        }
    }
}

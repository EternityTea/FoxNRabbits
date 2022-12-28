using System;
using System.Collections.Generic;
using System.IO;

namespace FoxNRabbits
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int Day = 0;

            List<Rabbit> PopR = new List<Rabbit>();
            List<Fox> PopF = new List<Fox>();

            int Days = 0;
            int pop = 0;
            char Sex = 'm';
            int Index = 0;
            int flag = 0;
            int offspring = 0;

            double HuntChance = 0;
            double rndHunt = 0;
            int VelocityFight = 0;
            int HuntRemoveHealth = 0;

            Random rnd = new Random();
            Rabbit RabbitTemplate = new Rabbit();
            Fox FoxTemplate = new Fox();

            //ввод начальной популяции кроликов
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
                RabbitTemplate.Init(rnd.Next(1, 365) ,Sex, rnd.Next(10, 40), 0.1 + rnd.NextDouble() * (0.8), rnd.Next(40, 61), rnd.Next(4, 20));
                PopR.Add(RabbitTemplate);
            }
            //ввод начальной популяции лис
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
                FoxTemplate.Init(rnd.Next(1, 1095) , Sex, rnd.Next(10, 40), 0.1 + rnd.NextDouble() * (0.8), rnd.Next(40, 61), rnd.Next(4, 20), 320);
                PopF.Add(FoxTemplate);
            }

            //Основной цикл

            while (true) {
                Console.Clear();
                //Дебаг или результаты прожитых дней
                Console.WriteLine($"День {Day}.");
                Console.WriteLine($"Популяция кроликов: {PopR.Count}.");
                Console.WriteLine($"Популяция Лисиц: {PopF.Count}.");
                Console.WriteLine();

                //for (int i = 0; i < PopR.Count; i++)
                //{
                //    Console.WriteLine($"{i + 1}. {PopR[i].Health}");
                //}
                //Console.WriteLine("--------------------");

                Console.WriteLine("Сколько дней подождать?");
                Days = Convert.ToInt32(Console.ReadLine());
                
                for (int i = 0; i < Days; i++)
                {
                    Day++;
                    //увеличение прожитых дней и счетчиков, а также рождение потомства
                    for (int j = 0; j < PopR.Count; j++)
                    {
                        if (PopR[j].PregnancyDay >= 0)
                        {
                            PopR[j].PregnancyDay++;
                            if (PopR[j].PregnancyDay > 30 + rnd.Next(0, 3))
                            {
                                offspring = rnd.Next(4, 13);
                                for (int l = 0; l < offspring; l++)
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
                                    RabbitTemplate.Init(0, Sex, rnd.Next(10, 40), 0.1 + rnd.NextDouble() * (0.8), rnd.Next(4, 30), rnd.Next(4, 20));
                                    PopR.Add(RabbitTemplate);
                                    PopR[j].Pregnancy = false;
                                    PopR[j].PregnancyDay = -1;
                                    PopR[j].Health -= 10;
                                }
                                
                            }
                        }
                        PopR[j].DaysOfAge += 1;
                        if (PopR[j].DaysOfAge >= 2555 + rnd.Next(-182, 183))
                        {
                            PopR.RemoveAt(j);
                            j--;
                        }
                    }
                    for (int j = 0; j < PopF.Count; j++)
                    {
                        if (PopF[j].PregnancyDay >= 0)
                        {
                            PopF[j].PregnancyDay++;
                            if (PopF[j].PregnancyDay > 49 + rnd.Next(0, 10))
                            {
                                offspring = rnd.Next(4, 14);
                                for (int l = 0; l < offspring; l++)
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
                                    FoxTemplate.Init(0, Sex, rnd.Next(10, 40), 0.1 + rnd.NextDouble() * (0.8), rnd.Next(4, 30), rnd.Next(4, 20), 0);
                                    PopF.Add(FoxTemplate);
                                    PopF[j].Pregnancy = false;
                                    PopF[j].PregnancyDay = -1;
                                    PopF[j].Health -= 10;
                                }
                            }
                        }
                        if (PopF[j].Pregnancy == false)
                        {
                            PopF[j].PrevPregnancy++;
                        }
                        PopF[j].DaysOfAge += 1;
                        if (PopF[j].DaysOfAge >= 2555 + rnd.Next(-182, 183))
                        {
                            PopF.RemoveAt(j);
                            j--;
                        }
                    }

                    //Лес голодает
                    for (int j = 0; j < PopR.Count; j++)
                    {
                        PopR[j].Health -= 4;
                        if (PopR[j].Health <= 0)
                        {
                            PopR.RemoveAt(j);
                            j--;
                        }
                    }

                    for (int j = 0; j < PopF.Count; j++)
                    {
                        PopF[j].Health -= 4;
                        if (PopF[j].Health <= 0)
                        {
                            PopF.RemoveAt(j);
                            j--;
                        }
                    }

                    //Лес кушает пищу растительного происхождения
                    for (int j = 0; j < PopR.Count; j++)
                    {
                        PopR[j].Health += rnd.Next(0, 14);
                    }
                    for (int j = 0; j < PopF.Count; j++)
                    {
                        PopF[j].Health += rnd.Next(0, 9);
                    }

                    //Звери спариваются

                    for (int j = 0; j < PopR.Count; j++)
                    {
                        Index = rnd.Next(0, PopR.Count);
                        if (PopR[j].Sex == 'm' && PopR[Index].Sex == 'f' && PopR[Index].Pregnancy == false && PopR[Index].DaysOfAge >= 90 && PopR[j].DaysOfAge >= 90)
                        {
                            flag = rnd.Next(1, 5);
                            if (flag < 4)
                            {
                                PopR[Index].Pregnancy = true;
                                PopR[Index].PregnancyDay = 0;
                                PopR[j].Health -= 2;
                            }
                        }
                        if (PopR[j].Sex == 'f' && PopR[Index].Sex == 'm' && PopR[j].Pregnancy == false && PopR[Index].DaysOfAge >= 90 && PopR[j].DaysOfAge >= 90)
                        {
                            flag = rnd.Next(1, 5);
                            if (flag < 4)
                            {
                                PopR[j].Pregnancy = true;
                                PopR[j].PregnancyDay = 0;
                                PopR[Index].Health -= 2;
                            }
                        }
                    }

                    for (int j = 0; j < PopF.Count; j++)
                    {
                        Index = rnd.Next(0, PopF.Count);
                        if (PopF[j].Sex == 'm' && PopF[Index].Sex == 'f' && PopF[Index].Pregnancy == false && PopF[Index].DaysOfAge >= 730 && PopF[j].DaysOfAge >= 730 && PopF[Index].PrevPregnancy >= 320)
                        {
                            flag = rnd.Next(1, 5);
                            if (flag < 4)
                            {
                                PopF[Index].Pregnancy = true;
                                PopF[Index].PregnancyDay = 0;
                                PopF[Index].PrevPregnancy = 0;
                                PopF[j].Health -= 2;
                            }
                        }
                        if (PopF[j].Sex == 'f' && PopF[Index].Sex == 'm' && PopF[j].Pregnancy == false && PopF[Index].DaysOfAge >= 730 && PopF[j].DaysOfAge >= 730 && PopF[j].PrevPregnancy >= 320)
                        {
                            flag = rnd.Next(1, 5);
                            if (flag < 4)
                            {
                                PopF[j].Pregnancy = true;
                                PopF[j].PregnancyDay = 0;
                                PopF[j].PrevPregnancy = 0;
                                PopF[Index].Health -= 2;
                            }
                        }
                    }

                    //Лисы охотятся

                    for (int j = 0; j < PopF.Count; j++)
                    {
                        if (PopR.Count == 0)
                        {
                            Console.WriteLine($"День {Day}.");
                            Console.WriteLine("В лесу не осталось кроликов");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                        Index = rnd.Next(0, PopR.Count);
                        VelocityFight = PopF[j].Velocity - PopR[Index].Velocity + 4;
                        if (VelocityFight > 0)
                        {
                            HuntChance = PopR[Index].Agility - PopF[j].Agility;
                            if (PopR[Index].DaysOfAge < 90)
                            {
                                HuntChance += 0.1;
                            }
                            if (PopR[Index].Health < 30)
                            {
                                HuntChance += 0.1;
                            }
                            if (PopF[j].Health < 30)
                            {
                                HuntChance -= 0.1;
                            }
                            HuntRemoveHealth = PopF[j].Strength - PopR[Index].Strength;
                            if (HuntRemoveHealth > 0)
                            {
                                PopR[Index].Health -= HuntRemoveHealth;
                            }

                            rndHunt = rnd.NextDouble();
                            if (rndHunt <= HuntChance)
                            {
                                PopF[j].Health += 60;
                                PopR.RemoveAt(Index);
                            }
                        }
                    }
                    
                }
                

            }

        }
    }
}

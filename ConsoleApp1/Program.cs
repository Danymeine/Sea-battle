using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static bool Equals (int [,] Array_1 , int[,] Array2)
        {
            bool marker = true;
            for (int i =0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Array_1[i, j] != Array2[i, j])
                    {
                        marker = false;
                    }
                }
            }
            return marker;
        }
        static void F1(ref int[,] mainArray, ref int[,] myChoice, ref int [,] myPopadanie, ref int [,] enemyArray, ref int[,] enemyChoice, ref int [,] enemyPopadanie, ref int kolvo, ref int kolvo2)
        {
            Console.Clear();
            /*for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" {0}\t", enemyArray[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();
                Console.WriteLine();
            }*/
            Console.WriteLine("Вот ваше поле боя");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (enemyChoice[i,j] == 1)
                    {
                        if (enemyChoice[i,j] == mainArray[i, j])
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" {0}\t", mainArray[i, j]);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(" {0}\t", mainArray[i, j]);
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" {0}\t", mainArray[i, j]);
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("Ваш выбор на поле боя");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (myChoice[i, j] == 1)
                    {
                        if (myChoice[i, j] == enemyArray[i, j])
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" {0}\t", myChoice[i, j]);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(" {0}\t", myChoice[i, j]);
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" {0}\t", myChoice[i, j]);
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("Ввделите координаты, куда будем бить (<<строка>> enter <<столбец>>)");
            //string koord = Console.ReadLine();
            /*while (koord.Length != 3)
            {
                Console.Write("Введите координаты корректно. В формате x y где  x - строка у - столбец");
                koord = Console.ReadLine();
            }*/
            int stroka = 0;
            string stroka_Stroka = Console.ReadLine();
            while ((int.TryParse(stroka_Stroka, out stroka) == false) || (stroka < 1) || (stroka > 5))
            {
                Console.Write("Введите координату корректно");
                stroka_Stroka = Console.ReadLine();
            }
            stroka--;
            //Console.WriteLine(stroka);

            int stolb = 0;
            string stolb_Stroka = Console.ReadLine();
            while ((int.TryParse(stolb_Stroka, out stolb) == false) || (stolb < 1) || (stolb > 5))
            {
                Console.Write("Введите координату корректно");
                stolb_Stroka = Console.ReadLine();
            }
            stolb--;
            //Console.WriteLine(stolb);
            myChoice[stroka, stolb] = 1;
            //Console.WriteLine(myChoice[stroka, stolb]);
            //Console.WriteLine(enemyArray[stroka, stolb]);
            //Console.WriteLine(enemyChoice[stroka, stolb]);
            if (enemyArray[stroka,stolb] == 1)
            {
                myPopadanie[stroka, stolb] = 1;
            }
            Random yourRandom = new Random();
            stroka = yourRandom.Next(0, 5);
            stolb = yourRandom.Next(0, 5);
            while (enemyChoice[stroka,stolb] == 1)
            {
                stroka = yourRandom.Next(0, 5);
                stolb = yourRandom.Next(0, 5);
            }
            enemyChoice[stroka, stolb] = 1;
            if (mainArray[stroka,stolb] == 1)
            {
                enemyPopadanie[stroka, stolb] = 1;

            }
            //var result = { mainArray, myChoice, myPopadanie, enemyArray, enemyChoice, enemyPopadanie };
            //return (result);
        }
        
        static void Main()
        {
            Console.WriteLine("Добро пожаловать в игру!");
            int[,] mainArray = new int[5,5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mainArray[i, j] = 0;

                }
            }
            Random myRandom = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mainArray[i, j] = myRandom.Next(0, 2);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" {0}\t", mainArray[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("Ну что, вы готовы, Адмирал?");
            string ansv = Console.ReadLine();
            while ((ansv != "Нет") && (ansv != "нет") && (ansv != "Ytn") && (ansv != "ytn") && (ansv != "Да") && (ansv != "да") && (ansv != "Lf") && (ansv != "lf"))
            {
                Console.WriteLine("Я вас немного недопонял. Скажите ещё раз: Да или Нет");
                ansv = Console.ReadLine();
            }
            if ((ansv == "Да") || (ansv == "да") || (ansv == "Lf") || (ansv == "lf"))
            {
                if ((ansv == "Lf") || (ansv == "lf"))
                {
                    Console.WriteLine("Проблемы с раскладкой? :D");
                }
                Console.WriteLine("Ну, начнём!");
                Console.ReadKey();
                //F1(mainArray);
                int[,] myChoice = new int[5, 5];
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        myChoice[i, j] = 0;

                    }
                }
                int[,] myPopadanie = new int[5, 5];
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        myPopadanie[i, j] = 0;

                    }
                }
                int[,] enemyChoice = new int[5, 5];
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        enemyChoice[i, j] = 0;

                    }
                }
                int[,] enemyPopadanie = new int[5, 5];
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        enemyPopadanie[i, j] = 0;

                    }
                }
                //посчитаю колличество кораблей в флоте игрока
                int kolvo = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        kolvo += mainArray[i, j];

                    }
                }
                //вывожу это колличество для проверки
                //Console.WriteLine(kolvo);
                //Console.Read();
                int[,] enemyArray = new int[5, 5];
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        enemyArray[i, j] = myRandom.Next(0, 2);
                    }
                }
                //считаю колличество кораблей во флоте соперника
                int kolvo2 = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        kolvo2 += enemyArray[i, j];

                    }
                }
                //вывожу колличество для проверки
                //Console.WriteLine(kolvo2);
                //Console.Read();
                while (kolvo != kolvo2)
                {
                    enemyArray = new int[5, 5];
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            enemyArray[i, j] = myRandom.Next(0, 2);
                        }
                    }
                    kolvo2 = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            kolvo2 += enemyArray[i, j];

                        }
                    }
                    //Console.WriteLine(kolvo2);
                }
                Console.WriteLine("Соперник подобран");
                Console.Read();
                //Console.WriteLine(Equals(myChoice, myChoice));
                //Console.ReadKey();
                while ((Equals(myPopadanie, enemyArray) == false) && (Equals(mainArray, enemyPopadanie) == false))
                {
                    F1(ref mainArray, ref myChoice, ref myPopadanie, ref enemyArray, ref enemyChoice, ref enemyPopadanie, ref kolvo, ref kolvo2);
                }
                if (Equals(myPopadanie, enemyArray))
                {
                    Console.WriteLine("Поздравляем, вы победили!");
                }
                else
                {
                    Console.WriteLine("Сожалею, но вы проиграли. Удачи вам в другой раз");
                }
            }
            else
            {
                /*Console.WriteLine("Что-то не так? Начнём с начала?");
                string ansv2 = Console.ReadLine();
                while ((ansv != "Нет") && (ansv != "нет") && (ansv != "Ytn") && (ansv != "ytn") && (ansv != "Да") && (ansv != "да") && (ansv != "Lf") && (ansv != "lf"))
                {
                    Console.WriteLine("Я вас немного недопонял. Скажите ещё раз: Да или Нет");
                    ansv2 = Console.ReadLine();
                }
                if ((ansv == "Да") || (ansv == "да") || (ansv == "Lf") || (ansv == "lf"))
                {
                    Console.WriteLine("Давайте попробуем сначала");
                    Console.ReadKey();
                    Main();
                }
                else
                {*/
                    Console.WriteLine("Было приятно с Вами повидаться");
                //}
            }
            
            Console.WriteLine("Это была тяжёлая, но интересная ночь программирования. А днём, как проснулся было 3 часа отладки. Это первая моя плоноценная программа \nСпасибо за внимание к моему проекту");
            //когда делаю массив врага нужно учесть одинаковое колличество кораблей на поле
            //F2(mainArray);
            //F1(mainArray);
            // Console.Write(mainArray);
            Console.Read();
        }
    }
}

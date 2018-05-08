using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============================================================");
            Console.WriteLine("Приветствую Вас, хорошей игры! Разрабочтик - Бондаренко Е.С.");
            Console.WriteLine("============================================================");
            bool gameover = false;
            int player = 2;
            int n = 0;
            //Счетчики
            int el1 = 0;
            int el2 = 0;
            //
            while (true)
            {
                // Пытаемся получить данные от пользователя
                try
                {
                    Console.WriteLine("Введите размерность массива: (Не более 6)");
                    n = Convert.ToInt32(Console.ReadLine()) + 1;
                    if (n > 7)
                    {
                        Console.WriteLine("Вы ввели слишком большое число! Игровое поле не может быть больше 6х6");
                    }
                    else
                    {
                        break;
                    }
                    Console.WriteLine();
                }
                // Ошибка ввода данных
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка:" + ex.Message);
                }
            }
            int[,] nxn = new int[n, n];
            //Заполнение верхней строчки указателей
            for (int j = 0; j < n; j++)
            {
                nxn[0, j] = j;
            }
            //Заполнение нижней строчки указателей
            for (int i = 0; i < n; i++)
            {
                nxn[i, 0] = i;
            }
            //Заполнение массива элементами
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    nxn[i, j] = -1;
                }
            }
            //Проверка на наличие полностью заполненных строк/стоблцов/диагоналей
            while ((gameover == false))
            {
                //Вывод массива
                VivodMas(n, nxn);
                int i1 = 0; int j1 = 0;
                int igrok = 0;
                // Пытаемся получить данные от пользователя
                try
                {
                    while (true)
                    {
                        Console.WriteLine("Выберете ячейку матрицы:");
                        Console.WriteLine("Строка:");
                        i1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Столбец:");
                        j1 = Convert.ToInt32(Console.ReadLine());
                        if ((i1 > n) | (j1 > n))
                        {
                            Console.WriteLine("Размерность массива " + Convert.ToInt32(n - 1) + "x" + Convert.ToInt32(n - 1) + "! Введите число меньше " + Convert.ToInt32(n - 1));
                        }
                        else if ((nxn[i1, j1] == 0) | (nxn[i1, j1] == 1))
                        {
                            Console.WriteLine("Эта ячейка уже занята, выберите другую!");
                        }
                        else
                        {
                            break;
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Какое значение вводим? (0 или 1)");
                        igrok = Convert.ToInt32(Console.ReadLine());
                        if ((igrok != 0) & (igrok != 1))
                        {
                            Console.WriteLine("Вы ввели что-то не то. Введите 0 или 1!");
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                // Ошибка ввода данных
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка:" + ex.Message);
                }
                //Заполняем выбранную ячейку выбранным игроком
                nxn[i1, j1] = igrok;

                //Проверка по строчкам
                for (int i = 1; i < n; i++)
                {
                    for (int j = 1; j < n; j++)
                    {
                        if ((nxn[i, j] != 1) & (nxn[i, j] != 0))
                        {
                            el1 = 0;
                            el2 = 0;
                            break;
                        }
                        else if ((nxn[i, j] == 1))
                        {
                            el1++;
                            if (el1 == n - 1) { player = 1; gameover = true; break; }
                        }
                        else if ((nxn[i, j] == 0))
                        {
                            el2++;
                            if (el2 == n - 1) { player = 0; gameover = true; break; }
                        }
                        else if ((el1 == n - 1) | (el2 == n - 2))
                        {
                            break;
                        }
                    }
                }

                //Проверка по столбцам
                for (int j = 1; j < n; j++)
                {
                    for (int i = 1; i < n; i++)
                    {
                        if ((nxn[i, j] != 1) & (nxn[i, j] != 0))
                        {
                            el1 = 0;
                            el2 = 0;
                            break;
                        }
                        else if ((nxn[i, j] == 1))
                        {
                            el1++;
                            if (el1 == n - 1) { player = 1; gameover = true; break; }
                        }
                        else if ((nxn[i, j] == 0))
                        {

                            el2++;
                            if (el2 == n - 1) { player = 0; gameover = true; break; }
                        }
                        else if ((el1 == n - 1) | (el2 == n - 2))
                        {
                            break;
                        }
                    }
                }

                //Проверка по главной диагонали
                for (int i = 1; i < n; i++)
                {
                    if ((nxn[i, i] != 1) & (nxn[i, i] != 0))
                    {
                        el1 = 0;
                        el2 = 0;
                        break;
                    }
                    else if ((nxn[i, i] == 1))
                    {
                        el1++;
                        if (el1 == n - 1) { player = 1; gameover = true; break; }
                    }
                    else if ((nxn[i, i] == 0))
                    {
                        el2++;
                        if (el2 == n - 1) { player = 0; gameover = true; break; }
                    }
                    else if ((el1 == n - 1) | (el2 == n - 2))
                    {
                        break;
                    }
                }

                //Проверка по побочной диагонали
                for (int i = n - 1; i > 0; i--)
                {
                    for (int j = 1; j < n; i--, j++)
                    {
                        if ((nxn[i, j] != 1) & (nxn[i, j] != 0))
                        {
                            el1 = 0;
                            el2 = 0;
                            break;
                        }
                        else if ((nxn[i, j] == 1))
                        {
                            el1++;
                            if (el1 == n - 1) { player = 1; gameover = true; break; }
                        }
                        else if ((nxn[i, j] == 0))
                        {
                            el2++;
                            if (el2 == n - 1) { player = 0; gameover = true; break; }
                        }
                        else if ((el1 == n - 1) | (el2 == n - 2))
                        {
                            break;
                        }
                    }
                }
            }
            //Вывод массива
            VivodMas(n, nxn);
            Console.WriteLine("============================================================");
            Console.WriteLine("Игра окончена! Выиграл игрок " + player + "!");
            Console.WriteLine("============================================================");
            Console.ReadLine();
        }

        //Вывод массива
        static void VivodMas(int n, int[,] nxn)
        {
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(nxn[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}

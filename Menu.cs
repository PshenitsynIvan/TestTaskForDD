using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskForDD
{
    internal class Menu : IDisposable
    {
        Matrix matrix = new Matrix();
        public void StartApp()
        {
            Console.WriteLine();
            Console.WriteLine(" Добро пожаловать в игру 'Сейф братьев пилотов!' \n \n Введите '1', чтобы сыграть в игру. " +
            "\n Введите '0', чтобы выйти из приложения.");
            Console.Write(" Поле ввода: ");
            bool result = int.TryParse(Console.ReadLine(), out var menuChoice);
            if (result == false)
            {
                Console.WriteLine();
                throw new Exception(" Ввод других символов кроме чисел не допускается.");
            }
            if (menuChoice == 1) { StartGame(); }

            else if (menuChoice == 0)
            {
                Console.WriteLine();
                Console.WriteLine(" Выход из приложения...");
                Dispose();
            }
            else if (menuChoice != 1 || menuChoice != 0) { throw new Exception(" Введите нужное число."); }

        }

        public void StartGame()
        {
            Console.WriteLine();
            Console.Write(" Введите размерность матрицы NxN:");
            Console.Write(" ");
            bool result = int.TryParse(Console.ReadLine(), out var sizeChoise);
            if (result == false)
            {
                Console.WriteLine();
                throw new Exception(" Ввод других символов кроме чисел не допускается.");
            }
            else
            {
                matrix.Size = sizeChoise;
                Console.WriteLine();
                matrix.CreateMatrix();
                Console.WriteLine();
                matrix.ChangeMatrix();
            }
        }
        public void StartAgain()
        {
            try
            {

                Console.WriteLine();
                Console.Write(" Работа приложения завершена. Желаете ли произвести повторный запуск? \n " +
                    "\n '1' - Да \n '0' - Нет \n Поле ввода: ");
                bool result = int.TryParse(Console.ReadLine(), out var appChoice);
                if (result == false)
                {
                    Console.WriteLine();
                    throw new Exception(" Ввод других символов кроме чисел не допускается.");
                }
                if (appChoice == 1)
                {
                    Console.Clear();    
                    StartApp();
                }
                else if (appChoice == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine(" Выход из приложения...");
                    Environment.Exit(0);
                }
                else if (appChoice != 1 || appChoice != 0)
                {
                    throw new Exception(" Введите нужное число.");
                }
            }

            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine($" Ошибка:{ex.Message}");
                Console.ResetColor();
                StartAgain();
            }
        }


        public void Dispose()
        {
            matrix.Dispose();
            Environment.Exit(0);
        }    
           
    }
}

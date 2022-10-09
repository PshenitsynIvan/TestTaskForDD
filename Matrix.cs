using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskForDD
{
    internal class Matrix: IDisposable
    {
        public static int size;
        public int Size
        {
            get => size;

            set
            {
                if (value == 1)
                    throw new Exception(" Размер матрицы не должен быть единичным.");
                else if (value == 0)
                    throw new Exception(" Размер матрицы не может быть нулевым.");
                else if(value < 0)
                    throw new Exception(" Размер матрицы не может быть отрицательным");
                else
                    size = value;
            }

        }

        private int[,] arr = new int[size,size];
        public int [,] CreateMatrix()
        {
            var rand = new Random();
            int[,] matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = rand.Next(0,2);
                    Console.Write("{0,3}  ", matrix[i, j]);
                }
                Console.WriteLine();
            }

            return arr = matrix;

        }


        public int[,] TestCreateMatrix()
        {
            
            int[,] matrix = { { 1, 0, 1,1 }, { 0, 1, 1,0 }, { 1, 1, 0, 1 }, { 0, 0, 1, 1 } };
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                { 
                    Console.Write("{0,3}  ", matrix[i, j]);
                }
                Console.WriteLine();
            }

            return arr = matrix;

        }


        public void ChangeMatrix()
        {
            Console.WriteLine();
            Console.WriteLine(" Введите номер элемента матрицы в формате [X] - номер строки [Y] - номер столбца , " +
                "значение которого хотите поменять: ");
            Console.Write(" Поле ввода [X]: ");
            bool result1 = int.TryParse(Console.ReadLine(), out var rowTempIndex);
            if (result1 == false)
            {
                Console.WriteLine();
                throw new Exception(" Ввод других символов кроме чисел не допускается.");
            }
            int rowIndex = rowTempIndex - 1;
            if (rowIndex < 0 || rowIndex > size - 1)
            {
                throw new Exception("Номер строки может быть от 1 до " + size);
            }

            Console.Write(" Поле ввода [Y]: ");
            bool result2 = int.TryParse(Console.ReadLine(), out var columnTempIndex);
            

            int columnIndex = columnTempIndex - 1;
            if (result2 == false)
            {
                Console.WriteLine();
                throw new Exception(" Ввод других символов кроме чисел не допускается.");
            }
            if (columnIndex < 0 || columnIndex > size - 1)
            {
                throw new Exception("Номер столбца может быть от 1 до " + size);
            }

            Console.Write($"Выбранный элемент: { arr[rowIndex ,columnIndex]}");
               
               Console.WriteLine();
            
          
            for(int i = 0; i < size; i++)
            {
                arr[rowIndex, i] = Math.Abs(arr[rowIndex, i] - 1);
            }
            for (int i = 0; i < size; i++)
            {
                if (i != rowIndex) { 
                    arr[i, columnIndex] = Math.Abs(arr[i, columnIndex] - 1);
                }
            }
            ShowMatrix();
            bool isFinished = CheckMatrix();
            if (isFinished)
            {
                Console.WriteLine();
                Console.WriteLine("Поздравляем, Вы выиграли ");
                
            }
            else
            {
                ChangeMatrix();
            }
           

        }


        public void ShowMatrix()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write("{0,3}  ", arr[i, j]);
                }
                Console.WriteLine();
            }
        }

        public bool CheckMatrix()
        {
            bool result = true;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if(arr[i, j] == 0)
                    {
                        result = false;
                        break;
                    }
                }
                if (!result) break;
                
            }

            return result;
        }

        public void Dispose()
        {
            
        }

    }
}

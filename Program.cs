using System;

// Как не нужно писать код часть вторая
// Задача: Задайте двумерный массив
// Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива
// Задача: Задайте прямоугольный двумерный массив
// Напишите программу, которая будет находить строку с наименьшей суммой элементов
// Задача: Задайте две матрицы
// Напишите программу, которая будет находить произведение двух матриц
// Задача: Сформируйте трёхмерный массив из неповторяющихся двузначных чисел
// Напишите программу, которая построчно выведет элементы и их индексы
// Задача: Заполните спирально массив 4 на 4 числами от 1 до 16
// Задача: Дан двумерный массив
// Заменить в нём элементы первой строки элементами главной диагонали
// А элементы последней строки, элементами побочной диагонали
// 1  2  3  4     1  6  11  15  5  6  7  8 => 5  6  7  8
// 9  10 11 12    9  10 11  12
// 12 13 14 15    12 10 7   4
// Задача: Дан двумерный массив, заполненный случайными числами от -9 до 9
// Подсчитать частоту вхождения каждого числа в массив, используя словарь
// Задача: Найти минимальный по модулю элемент
// Вывести все столбцы и строки, содержащие элементы, равные по модулю минимальному
// Задача: Заполните двумерный массив 3х3 числами от 1 до 9 змейкой
// 1 6 7 2 5 83 4 9

namespace WrongWriteCodePartTwo
{
   internal class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("---------------------------------------------------------------------");
         Console.WriteLine("Упорядочивание по убыванию элементов каждой строки двумерного массива");
         Console.WriteLine("---------------------------------------------------------------------");

         Console.WriteLine("--------------------------------------------------------------------------------");
         Console.WriteLine("Находение строки с наименьшей суммой элементов прямоугольного двумерного массива");
         Console.WriteLine("--------------------------------------------------------------------------------");

         Console.Write("Введите количество строк массива:");
         int rows = Convert.ToInt32(Console.ReadLine());
         Console.WriteLine("Введите количество столбцов массива:");
         int columns = Convert.ToInt32(Console.ReadLine());
         int[,] massif = new int[rows, columns];
         // Метод заполнения массива
         void FillingsMassif()
         {
            Random chance = new Random();
            for (int i = 0; i < rows; i++)
            {
               for (int j = 0; j < columns; j++)
               {
                  massif[i, j] = chance.Next(-10, 9);
               }
            }
         }

         // Метод вывода массива
         void PrintArray()
         {
            for (int i = 0; i < rows; i++)
            {
               for (int j = 0; j < columns; j++)
               {
                  Console.Write(" {0}  ", massif[i, j]);
               }

               Console.WriteLine();
            }
         }

         // Метод упорядочения элементов строки массива от максимального к минимальному
         void Task54()
         {
            for (int m = 0; m < columns - 1; m++)
            {
               for (int i = 0; i < rows; i++)
               {
                  for (int j = 0; j < columns - 1; j++)
                  {
                     if (massif[i, j] < massif[i, j + 1])
                     {
                        int temp = massif[i, j];
                        massif[i, j] = massif[i, j + 1];
                        massif[i, j + 1] = temp;
                     }
                  }
               }
            }
         }

         // Метод нахождения строки в массиве с наименьшей суммой элементов
         void Task56()
         {
            int rowMinSum = 1; int minI = 1;
            for (int i = 0; i < rows; i++)
            {
               int temp1 = 0;
               for (int j = 0; j < columns; j++)
               {
                  temp1 = massif[i, j] + temp1;
               }

               if (temp1 < rowMinSum)
               {
                  minI = i;
                  rowMinSum = temp1;
               }
            }

            Console.WriteLine("минимальная сумма строк = " + rowMinSum + ", в строке под номером: " + (minI + 1));
         }

         FillingsMassif();
         Console.WriteLine("Исходный массив");
         PrintArray();
         Task54();
         Console.WriteLine("Упорядоченный массив по убыванию по строкам");
         PrintArray();
         Console.WriteLine();
         Console.WriteLine("Строка с наименьшей суммой элементов");
         Console.WriteLine("Прямоугольный массив");
         PrintArray();
         Task56();

         Console.WriteLine("-------------------------------");
         Console.WriteLine("Умножение двух двумерных матриц");
         Console.WriteLine("-------------------------------");
         Console.WriteLine("Введите количество строк и столбцов матрицы А");
         int row1 = Convert.ToInt32(Console.ReadLine());
         int column1 = Convert.ToInt32(Console.ReadLine());
         Console.WriteLine("Введите количество строк и столбцов матрицы B");
         int row2 = Convert.ToInt32(Console.ReadLine());
         int column2 = Convert.ToInt32(Console.ReadLine());

         int[,] arr1 = new int[row1, column1];
         int[,] arr2 = new int[row2, column2];

         FillArr1(arr1);
         FillArr1(arr2);
         Console.WriteLine("Матрица А:");
         PrintArr1(arr1);
         Console.WriteLine("Матрица B:");
         PrintArr1(arr2);
         Console.WriteLine("Матрица С = А * В:");
         Multiplication(arr1, arr2);
         PrintArr1(Multiplication(arr1, arr2));

         // Метод перемножения матриц
         int[,] Multiplication(int[,] a, int[,] b)
         {
            if (a.GetLength(1) != b.GetLength(0))
            {
               if (a.GetLength(1) != b.GetLength(0))
               {
                  Console.WriteLine("Матрицы нельзя перемножить. Введите другие размерности матриц");
               }
            }

            int[,] r = new int[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
               for (int j = 0; j < b.GetLength(1); j++)
               {
                  for (int k = 0; k < b.GetLength(0); k++)
                  {
                     r[i, j] += a[i, k] * b[k, j];
                  }
               }
            }

            return r;
         }

         // Метод вывода массива
         void PrintArr1(int[,] c)
         {
            for (int i = 0; i < c.GetLength(0); i++)
            {
               for (int j = 0; j < c.GetLength(1); j++)
               {
                  Console.Write("{0} ", c[i, j]);
               }

               Console.WriteLine();
            }
         }

         // Метод заполнения массива
         void FillArr1(int[,] array)
         {
            int row = array.GetLength(0);
            int column = array.GetLength(1);
            Random rand = new Random();
            for (int i = 0; i < row; i++)
            {
               for (int j = 0; j < column; j++)
               {
                  array[i, j] = rand.Next(-9, 8);
               }
            }
         }

         Console.WriteLine("-------------------------------------------------------------------");
         Console.WriteLine("Трёхмерный прямоугольный массив из неповторяющихся двузначных чисел");
         Console.WriteLine("-------------------------------------------------------------------");

         Random rnd = new Random();
         int r1 = rnd.Next(2, 5);
         int r2 = rnd.Next(2, 5);
         int r3 = rnd.Next(2, 5);
         // Инициализация прямоугольного массива (z,y,x) заполненный нулевыми значениями 
         int[,,] arr = new int[r1, r2, r3];
         // Инициализация зубчатого трехмерного массива на рондомное кол стр
         int[][][] arrZ = new int[rnd.Next(3, 6)][][];

         FillArr();
         PrintArr();

         FillArrZ();
         PrintArrZ();

         // Метод заполнения прямоугольного 3-х мерного массива
         void FillArr()
         {
            Random rand = new Random();
            int L1 = arr.GetLength(0);
            int L2 = arr.GetLength(1);
            int L3 = arr.GetLength(2);
            int L4 = L1 * L2 * L3;
            // Массив для проверки чисел на неповторяемость 
            int[] mass = new int[L4];
            mass[0] = 0;
            int k = 0;
            int q = 0;
            int g = 0;
            for (int m = 0; m < L1; m++)
            {
               for (int i = 0; i < L2; i++)
               {
                  for (int j = 0; j < L3; j++)
                  {
                     int numm = rand.Next(10, 98);
                     // Проверка на уникальность значений, вводимых в 3х мерный массив
                     for (k = 0; k < L4; k++)
                     {
                        if (mass[k] != numm)
                        {
                           q++;
                        }
                     }

                     if (q == L4)
                     {
                        arr[m, i, j] = numm;
                        q = 0;
                        mass[g] = numm;
                        g++;
                     }
                     else
                     {
                        q = 0;
                        j--;
                     }
                  }
               }
            }
         }

         // Метод вывода 3х мерного прямоугольного массива
         void PrintArr()
         {
            int L1 = arr.GetLength(0);
            int L2 = arr.GetLength(1);
            int L3 = arr.GetLength(2);
            Console.WriteLine("Прямоугольный трехмерный массив размерностью: [" + L1 + ", " + L2 + ", " + L3 + "] ");
            for (int m = 0; m < L1; m++)
            {
               Console.WriteLine("Page №: " + (m));
               for (int i = 0; i < L2; i++)
               {
                  for (int j = 0; j < L3; j++)
                  {
                     Console.Write("arr [" + m + ", " + i + ", " + j + "] = " + arr[m, i, j] + "; ");
                  }

                  Console.WriteLine();
               }

               Console.WriteLine("===========================================================================================");
            }
         }

         // Метод заполнения зубчатого 3-х мерного массива
         void FillArrZ()
         {
            Random rand = new Random();
            int L = arrZ.Length;
            for (int i = 0; i < L; i++)
            {
               // Генерация случайного кол строк для каждой из стр 
               arrZ[i] = new int[rand.Next(2, 9)][];
               // Перебор строк 
               for (int j = 0; j < arrZ[i].Length; j++)
               {
                  // Для каждой строки генерация рондомно кол элементов 
                  arrZ[i][j] = new int[rand.Next(2, 9)];
                  for (int k = 0; k < arrZ[i][j].Length; k++)
                  {
                     // Для каждого элемента генерация рондомно значения 
                     arrZ[i][j][k] = rand.Next(100);
                  }
               }
            }
         }

         // Метод вывода 3-х мерного зубчатого массива
         void PrintArrZ()
         {
            Console.WriteLine("Трехмерный зубчатый массив:");
            for (int i = 0; i < arrZ.Length; i++)
            {
               Console.WriteLine("Page №: " + (i));
               for (int j = 0; j < arrZ[i].Length; j++)
               {
                  for (int k = 0; k < arrZ[i][j].Length; k++)
                  {
                     Console.Write("arr [" + i + ", " + j + ", " + k + "] = " + arrZ[i][j][k] + "; ");
                  }

                  Console.WriteLine();
               }

               Console.WriteLine("==============================================================================================");
            }
         }

         Console.WriteLine();

         Console.WriteLine("-----------------------------------------------");
         Console.WriteLine("Заполнение спирально двумерного массива 2 метод");
         Console.WriteLine("-----------------------------------------------");

         Console.WriteLine();
         int sizeX = 3;
         int sizeY = 4;
         int[,] matrix = new int[sizeX, sizeY];

         int indexX = 0;
         int indexY = 0;

         // Для изменения индекса строки
         int changeX = 0;
         // Для изменения индекса столбца
         int changeY = 1;

         // Считает шаги когда надо повернуть
         int steps = sizeY;
         // Для измения кол шага
         int direction = 0;
         // matrix.Length - общее кол элементов массива
         for (int i = 0; i < matrix.Length; i++)
         {
            matrix[indexX, indexY] = i + 1;
            //'Console.Write( matrix[indexX,indexY] + "\t");
            steps--;
            if (steps == 0)
            {
               steps = sizeY * ((direction) % 2) + sizeX * ((direction + 1) % 2) - 1 - direction / 2;
               // Изменение кол шага после каждого второго поворота (при повороте четное кол раз: sizeX - 1 dairection/2,  при повороте нечетное кол раз : sizeY - 1 dairection/2)
               int temp = changeX;
               changeX = changeY;
               changeY = -temp;
               // Меняем направление 
               direction++;
            }

            indexX += changeX;
            indexY += changeY;
         }

         for (int i = 0; i < matrix.GetLength(0); i++)
         {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
               Console.Write(matrix[i, j] + "\t");
            }

            Console.WriteLine();
         }

         Console.WriteLine("-----------------------------------------------------------------------------------------------------");
         Console.WriteLine("Дан двумерный массив. Заменить в нём элементы первой строки элементами главной диагонали. А элементы последней строки, элементами побочной диагонали.");
         Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");

         Console.WriteLine();
         Console.WriteLine("Введите размерность массива");

         int rows1 = Convert.ToInt32(Console.ReadLine());
         int columns1 = Convert.ToInt32(Console.ReadLine()); ;
         int[,] array1 = new int[rows1, columns1];

         // Метод замены строк в массиве
         void Zadacha1(int[,] array)
         {
            int temp = 0;
            int j;
            int l1 = array.GetLength(0);
            int l2 = array.GetLength(1);
            for (j = 0; j < l2; j++)
            {
               if (j > l1 - 1) break;
               temp = array[l1 - 1 - j, j];
               array[0, j] = array[j, j];
               array[l1 - 1, j] = array[l1 - 1 - j, j];
            }

            array[l1 - 1, j - 1] = temp;
         }

         // Метод заполения массива
         void FillArray1(int[,] array)
         {
            Random rand = new Random();
            int rows = array.GetLength(0);
            int columns = array.GetLength(1); ;
            for (int i = 0; i < rows; i++)
            {
               for (int j = 0; j < columns; j++)
               {
                  array[i, j] = rand.Next(-10, 9);
               }
            }
         }

         // Метод вывода массива
         void PrintArray1(int[,] array)
         {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1); ;
            for (int i = 0; i < rows; i++)
            {
               for (int j = 0; j < columns; j++)
               {
                  Console.Write(array[i, j] + "   ");
               }

               Console.WriteLine();
            }
         }

         FillArray1(array1);
         Console.WriteLine("Исходный массив");
         PrintArray1(array1);
         Console.WriteLine("Упорядоченный массив c заменой строк");
         Zadacha1(array1);
         PrintArray1(array1);
      }
   }
}
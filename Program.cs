using System;
using System.Collections.Generic;

// Как не нужно писать код часть вторая
// Задача: Задайте двумерный массив
// Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива
// Задача: Задайте прямоугольный двумерный массив
// Напишите программу, которая будет находить строку с наименьшей суммой элементов
// Задача: Сформируйте трёхмерный массив из неповторяющихся двузначных чисел
// Напишите программу, которая построчно выведет элементы и их индексы
// Задача: Заполните спирально массив 4 на 4 числами от 1 до 16
// - Задача: Дан двумерный массив
// Заменить в нём элементы первой строки элементами главной диагонали
// А элементы последней строки, элементами побочной диагонали
// Задача: Дан двумерный массив, заполненный случайными числами от -9 до 9
// Подсчитать частоту вхождения каждого числа в массив, используя словарь
// - Задача: Найти минимальный по модулю элемент
// Вывести все столбцы и строки, содержащие элементы, равные по модулю минимальному
// - Задача: Заполните двумерный массив 3х3 числами от 1 до 9 змейкой
// 1 6 7
// 2 5 8
// 3 4 9

namespace WrongWriteCodePartTwo
{
   internal class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("---------------------------------------------------------------------");
         Console.WriteLine("Упорядочивание по убыванию элементов каждой строки двумерного массива");
         Console.WriteLine("---------------------------------------------------------------------");
         Console.Write("Введите количество строк массива: ");
         int rows = Convert.ToInt32(Console.ReadLine());
         Console.Write("Введите количество столбцов массива: ");
         int columns = Convert.ToInt32(Console.ReadLine());
         int[,] massif = new int[rows, columns];

         // Метод заполнения массива
         void FillingsMassif()
         {
            Random chance = new Random();
            int i = 0;
            while (i < rows)
            {
               int j = 0;
               while (j < columns)
               {
                  massif[i, j] = chance.Next(10, 100);
                  j++;
               }

               i++;
            }
         }

         // Метод вывода массива
         void PrintMassif()
         {
            int i = 0;
            while (i < rows)
            {
               int j = 0;
               while (j < columns)
               {
                  Console.Write("{0}\t", massif[i, j]);
                  j++;
               }

               i++;
               Console.WriteLine();
            }
         }

         // Метод упорядочения элементов строки массива от максимального к минимальному
         void MaximumToMinimum()
         {
            int m = 0;
            while (m < columns - 1)
            {
               int i = 0;
               while (i < rows)
               {
                  int j = 0;
                  while (j < columns - 1)
                  {
                     if (massif[i, j] < massif[i, j + 1])
                     {
                        int temp = massif[i, j];
                        massif[i, j] = massif[i, j + 1];
                        massif[i, j + 1] = temp;
                     }

                     j++;
                  }

                  i++;
               }

               m++;
            }
         }

         FillingsMassif();
         Console.WriteLine("Исходный массив:");
         PrintMassif();
         MaximumToMinimum();
         Console.WriteLine("Упорядоченный массив по убыванию в строке:");
         PrintMassif();

         Console.WriteLine("--------------------------------------------------------------------------------");
         Console.WriteLine("Находение строки с наименьшей суммой элементов прямоугольного двумерного массива");
         Console.WriteLine("--------------------------------------------------------------------------------");

         // Метод ввода количества строк
         int SizeRow()
         {
            int n;
            do
            {
               Console.Write("Введите количество строк массива: ");
               int.TryParse(Console.ReadLine(), out n);
               if (n <= 0 || n > 20)
               {
                  Console.WriteLine("Введено неверное значение");
               }
            } while (n <= 0 || n > 20);

            return n;
         }

         // Метод ввода количества столбцов и проверка на прямоугольность массива
         int SizeColumn(int rank)
         {
            int m;
            do
            {
               Console.Write("Введите количество столбцов массива: ");
               int.TryParse(Console.ReadLine(), out m);
               // Проверка на прямоугольность массива
               if (rank == m)
               {
                  Console.WriteLine("Количество строк массива равно количеству столбцов: матрица");
               }
               else if (m <= 0 || m > 20)
               {
                  Console.WriteLine("Введено неверное значение");
               }
            } while (m <= 0 || m > 20 || rank == m);

            return m;
         }

         int strip = SizeRow();
         int verticals = SizeColumn(strip);
         int[,] cluster = new int[strip, verticals];

         // Метод заполнения массива
         void CompletionMassif()
         {
            Random stochastic = new Random();
            int i = 0;
            while (i < strip)
            {
               int j = 0;
               while (j < verticals)
               {
                  cluster[i, j] = stochastic.Next(10, 100);
                  j++;
               }

               i++;
            }
         }

         // Метод вывода массива
         void OutputMassif()
         {
            int i = 0;
            while (i < strip)
            {
               int j = 0;
               while (j < verticals)
               {
                  Console.Write("{0}\t", cluster[i, j]);
                  j++;
               }

               i++;
               Console.WriteLine();
            }
         }

         // Метод нахождения строки в массиве с наименьшей суммой элементов
         void MinSumRowElements(int[,] inputArray)
         {
            Console.WriteLine("Одномерный массив сумм элементов строк двумерного массива");
            int[] sumArray = new int[inputArray.GetLength(0)];
            int i = 0;
            while (i < inputArray.GetLength(0))
            {
               int sum = 0;
               int j = 0;
               while (j < inputArray.GetLength(1))
               {
                  sum += inputArray[i, j];
                  j++;
               }

               sumArray[i] = sum;

               i++;
            }

            int k = 0;
            while (k < sumArray.Length)
            {
               Console.WriteLine(sumArray[k]);
               k++;
            }

            // Поиск максимального элемента массива
            int rank = 0;
            int indexMinSum = 0;
            int minSum = sumArray[0];
            while (rank < sumArray.Length)
            {
               // Cчитаем, что минимум - это нулевой элемент массива
               if (minSum > sumArray[rank])
               {
                  minSum = sumArray[rank];
                  indexMinSum = rank;
               }

               rank++;
            }

            Console.WriteLine("Минимальная сумма элементов: {0}," + " в строке с индексом: {1}", minSum, indexMinSum);
         }

         CompletionMassif();
         Console.WriteLine("Прямоугольный массив");
         OutputMassif();
         MinSumRowElements(cluster);

         Console.WriteLine("-------------------------------------------------------------------");
         Console.WriteLine("Трёхмерный прямоугольный массив из неповторяющихся двузначных чисел");
         Console.WriteLine("-------------------------------------------------------------------");
         Random arbitrary = new Random();
         int chanceone = arbitrary.Next(2, 6);
         int chancetwo = arbitrary.Next(2, 6);
         int chancethree = arbitrary.Next(2, 6);
         // Инициализация прямоугольного массива (z,y,x) заполненного нулевыми значениями 
         int[,,] parade = new int[chanceone, chancetwo, chancethree];

         // Метод заполнения прямоугольного 3-х мерного массива
         void CompletionCollection()
         {
            Random casual = new Random();
            int forceone = parade.GetLength(0);
            int forcetwo = parade.GetLength(1);
            int forcethree = parade.GetLength(2);
            int forcefour = forceone * forcetwo * forcethree;
            // Массив для проверки чисел на неповторяемость 
            int[] range = new int[forcefour];
            range[0] = 0;
            int m = 0;
            int n = 0;
            int i = 0;
            while (i < forceone)
            {
               int j = 0;
               while (j < forcetwo)
               {
                  int k = 0;
                  while (k < forcethree)
                  {
                     int number = casual.Next(10, 100);
                     // Проверка на уникальность значений, вводимых в 3х мерный массив
                     int l = 0;
                     while (l < forcefour)
                     {
                        if (range[l] != number)
                        {
                           m++;
                        }

                        l++;
                     }

                     if (m == forcefour)
                     {
                        parade[i, j, k] = number;
                        m = 0;
                        range[n] = number;
                        n++;
                     }
                     else
                     {
                        m = 0;
                        k--;
                     }

                     k++;
                  }

                  j++;
               }

               i++;
            }
         }

         // Метод вывода 3-х мерного прямоугольного массива
         void PrintCollection()
         {
            int x = parade.GetLength(0);
            int y = parade.GetLength(1);
            int z = parade.GetLength(2);
            Console.WriteLine("Прямоугольный трехмерный массив размерностью: [" + x + ", " + y + ", " + z + "] ");
            int i = 0;
            while (i < x)
            {
               Console.WriteLine("Глубина №: " + i);
               int j = 0;
               while (j < y)
               {
                  int k = 0;
                  while (k < z)
                  {
                     Console.Write("Элемент " + parade[i, j, k] + "; " + "Индекс [" + i + ", " + j + ", " + k + "] ");
                     k++;
                  }

                  Console.WriteLine();
                  j++;
               }

               i++;
            }
         }

         CompletionCollection();
         PrintCollection();

         Console.WriteLine("---------------------------------------");
         Console.WriteLine("Заполнение спирально двумерного массива");
         Console.WriteLine("---------------------------------------");
         int sizeX = 3;
         int sizeY = 4;
         int[,] matrix = new int[sizeX, sizeY];

         void FillingSpirally()
         {
            int indexX = 0;
            int indexY = 0;

            // Для изменения индекса строки
            int changeX = 0;
            // Для изменения индекса столбца
            int changeY = 1;

            // Считает шаги когда надо повернуть
            int steps = sizeY;
            // Для измения количества шагов
            int direction = 0;
            // matrix.Length - общее количество элементов массива
            int i = 0;
            while (i < matrix.Length)
            {
               matrix[indexX, indexY] = i + 1;
               steps--;
               if (steps == 0)
               {
                  steps = sizeY * (direction % 2) + sizeX * ((direction + 1) % 2) - 1 - direction / 2;
                  // Изменение количества шагов после каждого второго поворота
                  // при повороте четное количество раз: sizeX - 1 dairection/2,
                  // при повороте нечетное количество раз : sizeY - 1 dairection/2
                  int temp = changeX;
                  changeX = changeY;
                  changeY = -temp;
                  // Меняем направление 
                  direction++;
               }

               indexX += changeX;
               indexY += changeY;
               i++;
            }
         }

         void OutputList()
         {
            int k = 0;
            while (k < matrix.GetLength(0))
            {
               int l = 0;
               while (l < matrix.GetLength(1))
               {
                  Console.Write(matrix[k, l] + "\t");
                  l++;
               }

               k++;
               Console.WriteLine();
            }
         }

         FillingSpirally();
         OutputList();

         Console.WriteLine("---------------------------------------------------------------------------------");
         Console.WriteLine("Замена в двумерном массиве элементов первой строки элементами главной диагонали\n" +
                           "и элементов последней строки, элементами побочной диагонали");
         Console.WriteLine("---------------------------------------------------------------------------------");
         Console.WriteLine("Введите размерность массива");

         // Метод ввода количества строк
         int DimensionRow()
         {
            int n;
            do
            {
               Console.Write("Введите количество строк массива: ");
               int.TryParse(Console.ReadLine(), out n);
               if (n <= 0 || n > 20)
               {
                  Console.WriteLine("Введено неверное значение");
               }
            } while (n <= 0 || n > 20);

            return n;
         }

         // Метод ввода количества столбцов и проверка на прямоугольность массива
         int DimensionColumn(int rank)
         {
            int m;
            do
            {
               Console.Write("Введите количество столбцов массива: ");
               int.TryParse(Console.ReadLine(), out m);
               // Проверка на прямоугольность массива
               if (rank == m)
               {
                  Console.WriteLine("Количество строк массива равно количеству столбцов: матрица");
               }
               else if (m <= 0 || m > 20)
               {
                  Console.WriteLine("Введено неверное значение");
               }
            } while (m <= 0 || m > 20 || rank == m);

            return m;
         }

         int argument = DimensionRow();
         int tower = DimensionColumn(argument);
         int[,] formation = new int[argument, tower];

         // Метод заполения массива
         void FillingArray(int[,] set)
         {
            Random sporadic = new Random();
            int row = set.GetLength(0);
            int column = set.GetLength(1);
            int i = 0;
            while (i < row)
            {
               int j = 0;
               while (j < column)
               {
                  set[i, j] = sporadic.Next(-10, 11);
                  j++;
               }

               i++;
            }
         }

         // Метод замены строк в массиве
         void ReplacementRows(int[,] set)
         {
            int temp = 0;
            int lineone = set.GetLength(0);
            int linetwo = set.GetLength(1);
            var j = 0;
            while (j < linetwo)
            {
               if (j > lineone - 1)
               {
                  break;
               }

               temp = set[lineone - 1 - j, j];
               set[0, j] = set[j, j];
               set[lineone - 1, j] = set[lineone - 1 - j, j];
               j++;
            }

            set[lineone - 1, j - 1] = temp;
         }

         // Метод вывода массива
         void PrintingArray(int[,] set)
         {
            int row = set.GetLength(0);
            int column = set.GetLength(1);
            int i = 0;
            while (i < row)
            {
               int j = 0;
               while (j < column)
               {
                  Console.Write(set[i, j] + "\t");
                  j++;
               }

               i++;
               Console.WriteLine();
            }
         }

         FillingArray(formation);
         Console.WriteLine("Исходный массив");
         PrintingArray(formation);
         Console.WriteLine("Упорядоченный массив c заменой строк");
         ReplacementRows(formation);
         PrintingArray(formation);

         Console.WriteLine("----------------------------------------------------------------------------------");
         Console.WriteLine("Расчет частоты вхождения каждого числа двумерного массива с использованием словаря");
         Console.WriteLine("----------------------------------------------------------------------------------");
         // Создаем словарь для подсчета частоты чисел: ключ - число, значение - количество вхождений
         Dictionary<int, int> frequency = new Dictionary<int, int>();
         Console.Write("Введите количество строк массива: ");
         int rowing = Convert.ToInt32(Console.ReadLine());
         Console.Write("Введите количество столбцов массива: ");
         int pier = Convert.ToInt32(Console.ReadLine());
         int[,] massive = new int[rowing, pier];

         // Метод заполнения массива
         void FillingsCollection()
         {
            Random chance = new Random();
            int i = 0;
            while (i < rowing)
            {
               int j = 0;
               while (j < pier)
               {
                  massive[i, j] = chance.Next(-9, 10);
                  j++;
               }

               i++;
            }
         }

         // Метод вывода массива
         void PrintingCollection()
         {
            Console.WriteLine("Исходный массив:");
            int i = 0;
            while (i < rowing)
            {
               int j = 0;
               while (j < pier)
               {
                  Console.Write("{0}\t", massive[i, j]);
                  j++;
               }

               i++;
               Console.WriteLine();
            }
         }

         // Метод подсчета частоты чисел
         void CalculateFrequency()
         {
            int i = 0;
            while (i < rowing)
            {
               int j = 0;
               while (j < pier)
               {
                  int number = massive[i, j];

                  // Если число уже есть в словаре, увеличиваем счетчик
                  if (frequency.ContainsKey(number))
                  {
                     frequency[number]++;
                  }
                  // Иначе добавляем число в словарь с начальным значением 1
                  else
                  {
                     frequency[number] = 1;
                  }

                  j++;
               }

               i++;
            }
         }

         // Метод вывода результатов подсчета
         void OutputResults()
         {
            Console.WriteLine("Частота вхождения чисел:");
            foreach (KeyValuePair<int, int> pair in frequency)
            {
               Console.WriteLine("Число {0,3}: {1,2} раз(а)", pair.Key, pair.Value);
            }

            Console.WriteLine("Всего элементов в массиве: {0}", rowing * pier);
            Console.WriteLine("Уникальных чисел: {0}", frequency.Count);
         }

         FillingsCollection();
         PrintingCollection();
         CalculateFrequency();
         OutputResults();

         // Задача: Найти минимальный по модулю элемент
         // Вывести все столбцы и строки, содержащие элементы, равные по модулю минимальному

         // Метод ввода количества строк
         int DimensionLine()
         {
            int n;
            do
            {
               Console.Write("Введите количество строк массива: ");
               int.TryParse(Console.ReadLine(), out n);
               if (n <= 0 || n > 20)
               {
                  Console.WriteLine("Введено неверное значение");
               }
            } while (n <= 0 || n > 20);

            return n;
         }

         // Метод ввода количества столбцов
         int DimensionRank(int rank)
         {
            int m;
            do
            {
               Console.Write("Введите количество столбцов массива: ");
               int.TryParse(Console.ReadLine(), out m);
               // Проверка на прямоугольность массива
               if ((m <= 0 || m > 20))
               {
                  Console.WriteLine("Введено неверное значение");
               }
            } while (m <= 0 || m > 20 || rank == m);

            return m;
         }

         int bank = DimensionLine();
         int entry = DimensionRank(bank);
         int[,] table = new int[bank, entry];
         // Минимальный по модулю элемент
         int minAbs;

         // Метод заполнения массива
         void FillingsTable(int[,] grouping)
         {
            Random blind = new Random();
            int i = 0;
            while (i < bank)
            {
               int j = 0;
               while (j < entry)
               {
                  grouping[i, j] = blind.Next(-99, 100);
                  j++;
               }

               i++;
            }
         }

         // Метод для вывода матрицы
         void PrintSet(int[,] selection)
         {
            Console.WriteLine("Исходная матрица:");
            int row = selection.GetLength(0);
            int column = selection.GetLength(1);
            int i = 0;
            while (i < row)
            {
               int j = 0;
               while (j < column)
               {
                  Console.Write("{0}\t", selection[i, j]);
                  j++;
               }

               i++;
               Console.WriteLine();
            }
         }

         // Метод нахождения минимального по модулю элемента
         void GetMimumModulus(int[,] scheme)
         {
            minAbs = table[0, 0];
            int i = 0;
            while (i < scheme.GetLength(0))
            {
               int j = 0;
               while (j < scheme.GetLength(1))
               {
                  int absValue = Math.Abs(scheme[i, j]);
                  if (absValue < minAbs)
                  {
                     minAbs = absValue;
                  }

                  j++;
               }

               i++;
            }

            Console.WriteLine($"Минимальный элемент по модулю: {minAbs}");
         }

         void MarkingsRowAndColumn(int[,] package)
         {
            // Создаем массивы для отметки строк и столбцов
            bool[] rowsMin = new bool[package.GetLength(0)];
            bool[] colsMin = new bool[package.GetLength(1)];

            // Отмечаем строки и столбцы, содержащие минимальный по модулю элемент
            int i = 0;
            while (i < package.GetLength(0))
            {
               int j = 0;
               while (j < package.GetLength(1))
               {
                  if (Math.Abs(package[i, j]) == minAbs)
                  {
                     rowsMin[i] = true;
                     colsMin[j] = true;
                  }

                  j++;
               }

               i++;
            }

            // Выводим результаты
            Console.WriteLine("Строки, содержащие минимальный по модулю элемент:");
            int k = 0;
            while (k < package.GetLength(0))
            {
               if (rowsMin[k])
               {
                  Console.Write("Строка {0}: ", k + 1);
                  int l = 0;
                  while (l < package.GetLength(1))
                  {
                     Console.Write("{0} ", table[k, l]);


                     l++;
                  }

                  Console.WriteLine();
               }

               k++;
            }

            Console.WriteLine("Столбцы, содержащие минимальный по модулю элемент:");
            for (int m = 0; m < package.GetLength(1); m++)
            {
               if (colsMin[m])
               {
                  Console.Write("Столбец {0}: ", m + 1);
                  for (int n = 0; n < package.GetLength(0); n++)
                  {
                     Console.Write("{0} ", table[n, m]);
                  }
                  Console.WriteLine();
               }
            }
         }

         FillingsTable(table);
         PrintSet(table);
         GetMimumModulus(table);
         MarkingsRowAndColumn(table);

         Console.ReadKey();
      }
   }
}
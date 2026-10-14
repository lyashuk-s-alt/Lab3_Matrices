using System;
using System.Diagnostics;

namespace Rozumatic_ASD_Lab3
{
    class Program
    {
        // 1. Транспонування квадратної матриці In-place O(n^2)
        static void TransposeMatrix(int[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = temp;
                }
            }
        }

        // 2. Пошук сідлової точки: min у рядку та max у стовпчику
        static void FindSaddlePoints(int[,] matrix, int rows, int cols)
        {
            bool found = false;

            for (int i = 0; i < rows; i++)
            {
                int minRowVal = matrix[i, 0];
                int minColIdx = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] < minRowVal)
                    {
                        minRowVal = matrix[i, j];
                        minColIdx = j;
                    }
                }

                bool isSaddle = true;
                for (int k = 0; k < rows; k++)
                {
                    if (matrix[k, minColIdx] > minRowVal)
                    {
                        isSaddle = false;
                        break;
                    }
                }

                if (isSaddle)
                {
                    Console.WriteLine("🎯 Знайдено сідлову точку: Значення = " + minRowVal + " в комірці [" + i + ", " + minColIdx + "]");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("📘 У заданій матриці сідлових точок немає.");
            }
        }

        // ІНДИВІДУАЛЬНЕ ЗАВДАННЯ. Варіант 3: Перевірка матриці на симетричність відносно головної діагоналі
        static bool IsSymmetric(int[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] != matrix[j, i])
                    {
                        return false; // Якщо хоч один елемент не збігається — вона не симетрична
                    }
                }
            }
            return true;
        }

        static void PrintMatrix(int[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                Console.Write(" [ ");
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(4) + " ");
                }
                Console.WriteLine("]");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine("       РОЗУМАТИК // ЛАБОРАТОРНА РОБОТА №3: ДВОВИМІРНІ МАТРИЦІ             ");
            Console.WriteLine("==========================================================================");

            // Тестова квадратна матриця 4х4 із завдання
            int[,] matrix = new int[,]
            {
                { 12, 14, 11, 15 },
                { 8,  10, 6,  9  },
                { 28, 22, 19, 25 },
                { 5,  7,  4,  6  }
            };

            int n = 4;
            Console.WriteLine("Початкова матриця 4x4:");
            PrintMatrix(matrix, n, n);

            // 1. Перевірка на симетричність ДО транспонування
            Console.WriteLine("\n--- ВАРІАНТ №3: ПЕРЕВІРКА НА СИМЕТРИЧНІСТЬ ---");
            if (IsSymmetric(matrix, n))
                Console.WriteLine("Результат: Матриця є СИМЕТРИЧНОЮ відносно головної діагоналі.");
            else
                Console.WriteLine("Результат: Матриця НЕ є симетричною відносно головної діагоналі.");

            // 2. Пошук сідлових точок
            Console.WriteLine("\n--- Пошук сідлових точок ---");
            FindSaddlePoints(matrix, n, n);

            // 3. Транспонування матриці
            Console.WriteLine("\n--- Транспонування матриці (In-place) ---");
            Stopwatch sw = Stopwatch.StartNew();
            TransposeMatrix(matrix, n);
            sw.Stop();

            PrintMatrix(matrix, n, n);
            Console.WriteLine("\n⏱ Час транспонування: " + sw.Elapsed.TotalMilliseconds + " мс");
            Console.WriteLine("✅ Роботу виконано успішно!");
        }
    }
}

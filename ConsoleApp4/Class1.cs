using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    class MatrixTasks
    {
        private double[,] matrix;
        private static Random random = new Random();

        // Конструктор 1: Создание пустой матрицы заданного размера
        public MatrixTasks(int n, int m)
        {
            matrix = new double[n, m];
        }

        // Задание 1.1 (Руками)
        public MatrixTasks(int n, int m, bool diagonalFill)
        {
            matrix = new double[n, m];

            if (diagonalFill)
            {
                for (int d = 0; d < n + m - 1; d++)
                {
                    for (int i = n - 1; i >= 0; i--)
                    {
                        int j = m - 1 - (d - (n - 1 - i));
                        if (j >= 0 && j < m)
                        {
                            Console.Write($"Элемент [{i}, {j}]: ");
                            while (!double.TryParse(Console.ReadLine(), out matrix[i, j]))
                            {
                                Console.WriteLine("Некорректный ввод.");
                                Console.Write($"Элемент [{i}, {j}]: ");
                            }
                        }
                    }
                }
            }
        }

        // Задание 1.1 (от 1 до n*m)
        public MatrixTasks(int n, int m, int initialValue)
        {
            matrix = new double[n, m];
            int value = initialValue;

            for (int d = 0; d < n + m - 1; d++)
            {
                for (int i = n - 1; i >= 0; i--)
                {
                    int j = m - 1 - (d - (n - 1 - i));
                    if (j >= 0 && j < m)
                    {
                        matrix[i, j] = value++;
                    }
                }
            }
        }

        // Задание 1.2
        public MatrixTasks(int n, bool randomDiagonal)
        {
            matrix = new double[n, n];

            if (randomDiagonal)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i < j)
                        {
                            matrix[i, j] = random.NextDouble() * 0.5 + 0.5;
                        }
                        else
                        {
                            matrix[i, j] = random.NextDouble() * 0.5;
                        }
                    }
                }
            }
        }

        // Задание 1.3
        public MatrixTasks(int n, bool isSpiral, bool s)
        {
            matrix = new double[n, n];
            if (isSpiral)
            {
                int x = n / 2;
                int y = n / 2;
                int value = 1;

                matrix[x, y] = value++;
                int steps = 1;

                while (value <= n * n)
                {
                    // вверх
                    for (int i = 0; i < steps && value <= n * n; i++)
                    {
                        x--;
                        if (x >= 0 && x < n && y >= 0 && y < n)
                        {
                            matrix[x, y] = value++;
                        }
                    }
                    // вправо
                    for (int i = 0; i < steps && value <= n * n; i++)
                    {
                        y++;
                        if (x >= 0 && x < n && y >= 0 && y < n)
                        {
                            matrix[x, y] = value++;
                        }
                    }
                    steps++;

                    // вниз
                    for (int i = 0; i < steps && value <= n * n; i++)
                    {
                        x++;
                        if (x >= 0 && x < n && y >= 0 && y < n)
                        {
                            matrix[x, y] = value++;
                        }
                    }
                    // влево
                    for (int i = 0; i < steps && value <= n * n; i++)
                    {
                        y--;
                        if (x >= 0 && x < n && y >= 0 && y < n)
                        {
                            matrix[x, y] = value++;
                        }
                    }
                    steps++;
                }
            }
        }

        //Заполнение случайными числами
        public MatrixTasks(int n, int m, bool randomFill, int maxRandom)
        {
            matrix = new double[n, m];
            if (randomFill)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        matrix[i, j] = random.Next(0, maxRandom + 1);
                    }
                }
            }
        }

        //// Задание 3
        //public static MatrixTasks Calc(MatrixTasks A, MatrixTasks B, MatrixTasks C)
        //{
        //    MatrixTasks result = new MatrixTasks(A.matrix.GetLength(0), A.matrix.GetLength(1));

        //    for (int i = 0; i < A.matrix.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < A.matrix.GetLength(1); j++)
        //        {
        //            result.matrix[i, j] = 7 * A.matrix[i, j] - (B.matrix[j, i] - 3 * C.matrix[i, j]);
        //        }
        //    }

        //    return result;
        //}

        // Задание 2
        public void ColumnCalc()
        {
            int n = matrix.GetLength(0);
            List<int> numberColumn = new List<int>();

            for (int j = 0; j < n; j++)
            {
                bool pos = true;
                double fElement = matrix[0, j];

                for (int i = 0; i < n; i++)
                {
                    if (i == j || i + j == n - 1)
                    {
                        if (fElement <= matrix[i, j])
                        {
                            pos = false;
                            break;
                        }
                    }
                }

                if (pos)
                {
                    numberColumn.Add(j);
                }
            }

            Console.WriteLine("Столбцы: " + string.Join(", ", numberColumn));
        }

        public static MatrixTasks operator *(double num, MatrixTasks mat)
        {
            int rows = mat.matrix.GetLength(0);
            int cols = mat.matrix.GetLength(1);
            MatrixTasks result = new MatrixTasks(rows, cols);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result.matrix[i, j] = num * mat.matrix[i, j];
                }
            }
            return result;

        }

        //Перегрузка вычитания матриц
        public static MatrixTasks operator -(MatrixTasks mat1, MatrixTasks mat2)
        {
            int rows = mat1.matrix.GetLength(0);
            int cols = mat1.matrix.GetLength(1);

            if (rows != mat2.matrix.GetLength(0) || cols != mat2.matrix.GetLength(1))
            {
                throw new ArgumentException("Матрицы имеют разные размеры");
            }

            MatrixTasks result = new MatrixTasks(rows, cols);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result.matrix[i, j] = mat1.matrix[i, j] - mat2.matrix[i, j];
                }
            }
            return result;
        }

        //Перегрпзка оператора умножения матриц
        public static MatrixTasks operator *(MatrixTasks mat1, MatrixTasks mat2)
        {
            int mat1Rows = mat1.matrix.GetLength(0);
            int mat1Cols = mat1.matrix.GetLength(1);
            int mat2Rows = mat2.matrix.GetLength(0);
            int mat2Cols = mat2.matrix.GetLength(1);
            if (mat1Cols != mat2Rows)
            {
                throw new ArgumentException("Матрицы имеют недопустимые размеры для умножения");
            }

            MatrixTasks result = new MatrixTasks(mat1Rows, mat2Cols);

            for (int i = 0; i < mat1Rows; i++)
            {
                for (int j = 0; j < mat2Cols; j++)
                {
                    for (int k = 0; k < mat1Cols; k++)
                    {
                        result.matrix[i, j] += mat1.matrix[i, k] * mat2.matrix[k, j];
                    }
                }
            }

            return result;
        }

        public MatrixTasks Transponse()
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            MatrixTasks result = new MatrixTasks(rows, cols);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result.matrix[j, i] = matrix[i, j];
                }
            }
            return result;
        }   

        //ToString 
        public override string ToString()
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            string res = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    res += $"{matrix[i, j],6:F2} ";
                }
                res += "\n";
            }
            return res;
        }
    }
}

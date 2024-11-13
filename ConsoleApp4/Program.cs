using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main()
        {

            

            //ЗАДАНИЕ 1.1
            Console.WriteLine("\nЗАДАНИЕ 1:\n");



            var diagonalMatrix = new MatrixTasks(4, 4, 0);
            Console.WriteLine("Матрица, заполненная по диагонали:\n" + diagonalMatrix);


            //ЗАДАНИЕ 1.2
            var randomDiagonalMatrix = new MatrixTasks(5, true);
            Console.WriteLine("Матрица, заполненная случайными числами по диагонали:\n" + randomDiagonalMatrix);

            //ЗАДАНИЕ 1.3
            var spiralMatrix = new MatrixTasks(5, true, true);
            Console.WriteLine("Матрица, заполненная по спирали:\n" + spiralMatrix);


            //ЗАДАНИЕ 2
            Console.WriteLine("\nЗАДАНИЕ 2:\n");
            var matrix_quad = new MatrixTasks(5, 5, true, 100);
            Console.WriteLine("Матрица:\n" + matrix_quad);
            matrix_quad.ColumnCalc();


            //ЗАДАНИЕ 3 7*А*(Вт-С)
            Console.WriteLine("\nЗАДАНИЕ 3:\n");

            var A = new MatrixTasks(3, 3, true, 10);
            var B = new MatrixTasks(3, 3, true, 10);
            var C = new MatrixTasks(3, 3, true, 10);

            Console.WriteLine("Матрица (A):\n" + A);
            Console.WriteLine("Матрица (B):\n" + B);
            Console.WriteLine("Матрица (C):\n" + C);

            Console.WriteLine("\nРезультат выражения (7 * A) :\n" + (7 * A));
            Console.WriteLine("\nРезультат выражения B.Transponse() :\n" + B.Transponse());
            Console.WriteLine("\nРезультат выражения B.Transponse() - C :\n" + (B.Transponse() - C));

            MatrixTasks result = (7 * A) * (B.Transponse() - C);

            
            Console.WriteLine("\nРезультат выражения * :\n" + result);


            Console.WriteLine("------------------ЗАДАНИЕ 4------------------:\n");
          
            Files.first();
            Console.WriteLine("Задание 5:");
            Files.TouchToysFile();
            Files.readtoys();
            Console.WriteLine("Задание 6");
            Files.zapforsix();
            Files.six();
            Console.WriteLine("Задание 7");
            Files.zapfor7();
            Files.calc7();
            Console.WriteLine("Задание 8");
            Files.eight();




        }
    }
}

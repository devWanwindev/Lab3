using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main()
        {

            

            //ЗАДАНИЕ 1.1
            Console.WriteLine("\nЗАДАНИЕ 1:\n");

            Console.WriteLine("Введите n, m: ");
            string x = Console.ReadLine();
            string y = Console.ReadLine();
            if ((int.TryParse(x, out int n)) && (int.TryParse(y, out int m)))
            {
                if ((n >= 0) && (m >= 0))
                {
                    var diagonalMatrix = new MatrixTasks(n, m, 0);
                    Console.WriteLine("Матрица, заполненная по диагонали:\n" + diagonalMatrix);
                }
                else 
                { 
                    Console.WriteLine("Неверные данные"); 
                }
            }
            else
            {
                Console.WriteLine("Неверные данные");
            }


            //ЗАДАНИЕ 1.2
            Console.WriteLine("\nЗАДАНИЕ 1.2:\n");
            Console.WriteLine("Введите n: ");
            x = Console.ReadLine();
            if ((int.TryParse(x, out int n1)) && (n1 >= 0)){
                var randomDiagonalMatrix = new MatrixTasks(n1, true);
                Console.WriteLine("Матрица, заполненная случайными числами по диагонали:\n" + randomDiagonalMatrix);
            }
            else
            {
                Console.WriteLine("Неверные данные");
            }



            //ЗАДАНИЕ 1.3
            Console.WriteLine("\nЗАДАНИЕ 1.3:\n");
            Console.WriteLine("Введите n: ");
            x = Console.ReadLine();
            if ((int.TryParse(x, out int n2)) && (n2 >= 0))
            {
                var spiralMatrix = new MatrixTasks(n2, true, true);
                Console.WriteLine("Матрица, заполненная по спирали:\n" + spiralMatrix);
            }
            else
            {
                Console.WriteLine("Неверные данные");
            }


            //ЗАДАНИЕ 2
            Console.WriteLine("\nЗАДАНИЕ 2:\n");
            x = Console.ReadLine();
            if ((int.TryParse(x, out int n3)) && (n3 >= 0)) { 
                var matrix_quad = new MatrixTasks(n3, n3, true, 100);
                Console.WriteLine("Матрица:\n" + matrix_quad);
                matrix_quad.ColumnCalc();
            }
            else
            {
                Console.WriteLine("Неверные данные");
            }


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

//                                                  Задание 2
//  Написать статический метод, выполняющий указанное действие над элементами матрицы целых чисел.
//  Параметры: матрица целых чисел, заданное действие – объект стандартного делегата Action.
//  Используя написанный метод:
//      •	вывести матрицу на экран;
//      •	вывести на экран положительные элементы матрицы;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8_2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Random r = new Random();
                int[,] matrix = {
                {r.Next(-9,9), r.Next(-9,9), r.Next(-9,9), r.Next(-9,9),r.Next(-9,9) },
                {r.Next(-9,9), r.Next(-9,9), r.Next(-9,9), r.Next(-9,9),r.Next(-9,9) },
                {r.Next(-9,9), r.Next(-9,9), r.Next(-9,9), r.Next(-9,9),r.Next(-9,9) },
                {r.Next(-9,9), r.Next(-9,9), r.Next(-9,9), r.Next(-9,9),r.Next(-9,9) },
                {r.Next(-9,9), r.Next(-9,9), r.Next(-9,9), r.Next(-9,9),r.Next(-9,9) }};
                //      •	вывести матрицу на экран;
                Console.WriteLine("Исходная матрица:");
                Function.ShowMatrix(matrix, x => { return true; }, Console.Write);
                Console.WriteLine();
                //      •	вывести на экран положительные элементы матрицы;
                Console.WriteLine("Положительные элементы матрицы:");
                Function.ShowMatrix(matrix, x => x >= 0, Console.Write);
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

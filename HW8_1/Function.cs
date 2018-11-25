using System;

namespace HW8_1
{
    class Function
    {
        //  Написать статический метод, возвращающий количество элементов одномерного массива целых чисел, удовлетворяющих заданному условию.
        //  Параметры: массив целых чисел, заданный критерий – объект, содержащий ссылку на метод.
        //public static int Find(int[] arr, Criterion criterion)               //объявляем свой делегат
        //public static int Find(int[] arr, Predicate<int> criterion)          //объявляем стандартный делегат Predicate
        public static int Find(int[] arr, Func<int, bool> criterion)          //объявляем стандартный делегат Func
        {
            int count = 0;
            foreach (int item in arr)
            {
                if (criterion(item))
                    count++;
            }
            return (count);
        }
        // количество элементов массива, квадрат которых не превышает 12.6;
        public static bool IsSquareLessThen12_6(int x)
        {
            return (12.6 > x * x);
        }
        // количество отрицательных элементов массива, стоящих на местах кратных 3
        public static bool IsNegativeMultipleOf3(int x)
        {
            return (x < 0 && x % 3 == 0);
        }
        //количество элементов массива, не принадлежащих интервалу[-3, 2.5]
        public static bool IsNotIncludedInTheInterval(int x, double xMin, double xMax)
        {
            return (!(x >= xMin && xMax >= x));
        }
        public static void ShowArray(string str, int[] arr)
        {
            Console.WriteLine(str);
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Console.Write(arr[i] + ", ");
            }
            Console.WriteLine(arr[arr.Length - 1]);
        }
    }
}

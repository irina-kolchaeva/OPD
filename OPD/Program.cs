using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OPD
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("Задание: \n" +
                              "1 – Сортировка матрицы \n" +
                              "2 - Подписчики \n");
            while (true)
            {
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '1': SortArray(); break;
                    case '2': Subscriber(); break;
                    default: break;
                }
            }
        }
        public static void SortArray()
        {
            Console.WriteLine("Задание 1: сортировка матрицы.");

            var arr = new[,]
            {
                { 12, 100, 100, 0 },
                { 70, 0, 80, 1 },
                { 200, 2, 10, 0 }
            };
            Console.WriteLine("\nМассив в исходном виде: ");
            arr.Print();

            // Сортировка по возрастанию сумм элементов.
            var arr1 = arr.SortRows((x, y) => x > y, (x, y) => x + y > x + y ? x + y : x + y);
            Console.WriteLine("\nМассив после сортировки по возрастанию сумм элементов: ");
            arr1.Print();

            // Сортировка по убыванию сумм элементов.
            var arr2 = arr.SortRows((x, y) => x < y, (x, y) => x + y > x + y ? x + y : x + y);
            Console.WriteLine("\nМассив после сортировки по убыванию сумм элементов: ");
            arr2.Print();

            // Сортировка по возрастанию максимального элемента.
            var arr3 = arr.SortRows((x, y) => x > y, (x, y) => x > y ? x : y);
            Console.WriteLine("\nМассив после сортировки по возрастанию максимального элемента: ");
            arr3.Print();

            // Сортировка по убыванию максимального элемента.
            var arr4 = arr.SortRows((x, y) => x < y, (x, y) => x > y ? x : y);
            Console.WriteLine("\nМассив после сортировки по убыванию максимального элемента: ");
            arr4.Print();

            // Сортировка по возрастанию минимального элемента.
            var arr5 = arr.SortRows((x, y) => x > y, (x, y) => x < y ? x : y);
            Console.WriteLine("\nМассив после сортировки по возрастанию минимального элемента: ");
            arr5.Print();

            // Сортировка по убыванию минимального элемента.
            var arr6 = arr.SortRows((x, y) => x < y, (x, y) => x < y ? x : y);
            Console.WriteLine("\nМассив после сортировки по убыванию минимального элемента: ");
            arr6.Print();

            Console.ReadKey();
            Console.Clear();
        }
        public static void Subscriber()
        {
            Console.WriteLine("Задание 2: события.");

            var timer = new Countdown();

            var subscriberA = new Subscriber(timer, "А");
            var subscriberB = new Subscriber(timer, "Б");
            var subscriberC = new Subscriber(timer, "В");
            timer.Skip(1000, "1");
            timer.Skip(2000, "2");
            subscriberA.Ubsubscribe();
            timer.Skip(3000, "3");
            subscriberB.Ubsubscribe();
            var subscribeDD = new Subscriber(timer, "Д");
            timer.Skip(1000, "4");
            subscriberC.Ubsubscribe();
            timer.Skip(2000, "5");

            Console.ReadKey();
            Console.Clear();
        }
    }
}
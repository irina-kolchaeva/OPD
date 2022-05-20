using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPD
{
    public static class ArraySorter
    {
        public static int[,] SortRows(this int[,] array,
                                      Func<int, int, bool> orderFunc,
                                      Func<int, int, int> aggregationFunc)
        {
            var rowsCount = array.GetLength(0);

            var columnCount = array.GetLength(1);

            var aggregations = new Tuple<int, int>[rowsCount];

            // Для каждой строки массива определяем агрегированное значение.
            for (int i = 0; i < rowsCount; i++)
            {
                var current = columnCount > 1 ? aggregationFunc(array[i, 0], array[i, 1]) : array[i, 0];
                for (int j = 2; j < columnCount; j++)
                    current = aggregationFunc(current, array[i, j]);
                aggregations[i] = new Tuple<int, int>(i, current);
            }

            // Сортировка пузырьком.
            for (int i = 0; i < rowsCount; i++)
                for (int j = 0; j < rowsCount - 1 - i; j++)
                    if (orderFunc(aggregations[j].Item2, aggregations[j + 1].Item2))
                        (aggregations[j], aggregations[j + 1]) = (aggregations[j + 1], aggregations[j]);

            // Создаем новый массив и заполяем его строками в правильном порядке.
            int[,] result = new int[rowsCount, columnCount];

            for (int i = 0; i < rowsCount; i++)
                for (int j = 0; j < columnCount; j++)
                    result[i, j] = array[aggregations[i].Item1, j];

            return result;
        }

        public static void Print(this int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    Console.Write(array[i, j] + "\t ");
                Console.WriteLine();
            }
        }

    }
}

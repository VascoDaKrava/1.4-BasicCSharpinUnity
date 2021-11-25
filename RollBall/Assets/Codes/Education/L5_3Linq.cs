using System.Collections.Generic;
using System.Linq;

namespace Kravchuk
{
    public static class L5_3Linq
    {
        // 5.3 Дана коллекция List<T>.Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
        // 5.3.a для целых чисел;
        // 5.3.b* для обобщенной коллекции;
        // 5.3.c** используя Linq.

        /// <summary>
        /// How many each element appears in the list
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Dictionary<int, int> Frequency(this List<int> list)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();

            foreach (int item in list)
            {
                if (result.ContainsKey(item))
                {
                    result[item]++;
                }
                else
                {
                    result.Add(item, 1);
                }
            }

            return result;
        }

        /// <summary>
        /// How many each element appears in the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Dictionary<T, int> Frequency<T>(this List<T> list)
        {
            Dictionary<T, int> result = new Dictionary<T, int>();

            foreach (T item in list)
            {
                if (result.ContainsKey(item))
                {
                    result[item]++;
                }
                else
                {
                    result.Add(item, 1);
                }
            }

            return result;
        }

        /// <summary>
        /// How many each element appears in the list (using Linq-query)
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Dictionary<int, int> FrequencyLinq(this List<int> list)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();

            var queryResult =
                from item
                      in list
                group item
                by item
                      into gr
                select new
                {
                    Value = gr.Key,
                    Count = gr.Count()
                };

            foreach (var item in queryResult)
            {
                result.Add(item.Value, item.Count);
            }

            return result;
        }
    }
}
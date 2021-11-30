using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Kravchuk
{
    public class L5_4Lambda
    {
        // 5.4 * Дан фрагмент программы.
        // 5.4.а. Свернуть обращение к OrderBy с использованием лямбда-выражения =>.
        // 5.4.b. * Развернуть обращение к OrderBy с использованием делегата

        public L5_4Lambda()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
                {
                    {"four", 4 },
                    {"two", 2 },
                    {"one", 1 },
                    {"three", 3 },
                };

            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });

            foreach (var pair in d)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }

            var d_a = dict.OrderBy(pair => pair.Value);

            foreach (var pair in d_a)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }
        }
    }
}
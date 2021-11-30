using System.Collections.Generic;
using UnityEngine;

namespace Kravchuk
{
    public class L5 : IUpdatable
    {
        private InputManager _im = new InputManager();
        private string _myStr = "aaccdd0a";
        private char _myChar = 'a';
        private List<int> _myList = new List<int>() { 5, 1, 3, 5, 3, 4, 5 };
        private List<char> _myList2 = new List<char>() { 'a', 'b', 'c', 'c', 'a', 'a' };

        private void DoIt()
        {
            Debug.LogWarning($"Quantity char \'{_myChar}\' in the string \"{_myStr}\" : { _myStr.QuantityChars(_myChar) }");

            Debug.LogWarning("Int collection");
            foreach (KeyValuePair<int, int> item in _myList.Frequency())
            {
                Debug.LogWarning($"{item.Key} - {item.Value}");
            }

            Debug.LogWarning("T collection");
            foreach (var item in _myList2.Frequency())
            {
                Debug.LogWarning($"{item.Key} - {item.Value}");
            }

            Debug.LogWarning("Linq");
            foreach (KeyValuePair<int, int> item in _myList.FrequencyLinq())
            {
                Debug.LogWarning($"{item.Key} - {item.Value}");
            }
        }

        public void DoItInUpdate()
        {
            if (_im.IsFivePress)
            {
                DoIt();
                new L5_4Lambda();
            }
        }
    }
}